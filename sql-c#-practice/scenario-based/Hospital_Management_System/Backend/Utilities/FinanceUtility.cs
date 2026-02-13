using Microsoft.Data.SqlClient;
using System.Data;
using Core; // For DbConnection
using Entities;

namespace Utilities;

internal sealed class FinanceUtility
{
    private readonly DbConnection _db;

    public FinanceUtility(DbConnection db)
    {
        _db = db;
    }

    // 1. GET PENDING BILLS (For Receptionist)
    // Logic: Find Visits where Appointment is 'Completed' BUT no Bill exists in the Bills table
    public async Task<List<PendingBill>> GetPendingBillsAsync()
    {
        var list = new List<PendingBill>();
        var conn = await _db.OpenAsync();

        string sql = @"
            SELECT 
                a.AppointmentId,
                v.VisitId,
                p.FirstName + ' ' + p.LastName AS PatientName,
                'Dr. ' + d.LastName AS DoctorName,
                d.ConsultationFee,
                v.VisitDate
            FROM Visits v
            JOIN Appointments a ON v.AppointmentId = a.AppointmentId
            JOIN Patients p ON a.PatientId = p.PatientId
            JOIN Doctors d ON a.DoctorId = d.DoctorId
            LEFT JOIN Bills b ON v.VisitId = b.VisitId
            WHERE a.StatusOfVisit = 'Completed' 
              AND b.BillId IS NULL
            ORDER BY v.VisitDate DESC";

        using var cmd = new SqlCommand(sql, conn);
        using var reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            list.Add(new PendingBill
            {
                AppointmentId = reader.GetInt32(0),
                VisitId = reader.GetInt32(1),
                PatientName = reader.GetString(2),
                DoctorName = reader.GetString(3),
                AmountDue = reader.GetDecimal(4),
                VisitDate = reader.GetDateTime(5)
            });
        }
        return list;
    }

    // 2. PROCESS PAYMENT (For Receptionist)
    // This is a transaction: Create Bill -> Record Payment -> Commit
    public async Task ProcessPaymentAsync(int visitId, decimal amount, string paymentMode)
    {
        var conn = await _db.OpenAsync();
        using var trans = conn.BeginTransaction();

        try
        {
            // Step A: Create the Bill Record
            string sqlBill = @"
                INSERT INTO Bills (VisitId, TotalAmount, PaymentStatus) 
                VALUES (@vid, @amt, 'Paid');
                SELECT CAST(SCOPE_IDENTITY() AS INT);";

            int newBillId;
            using (var cmdBill = new SqlCommand(sqlBill, conn, trans))
            {
                cmdBill.Parameters.AddWithValue("@vid", visitId);
                cmdBill.Parameters.AddWithValue("@amt", amount);
                // ExecuteScalar returns the first column of the first row (the INSERTED.BillId)
                newBillId = (int)await cmdBill.ExecuteScalarAsync();
            }

            // Step B: Record the Transaction details
            string sqlTrans = @"
                INSERT INTO PaymentTransactions (BillId, PaymentMode, AmountPaid, PaymentDate)
                VALUES (@bid, @mode, @amt, GETDATE())";

            using (var cmdTrans = new SqlCommand(sqlTrans, conn, trans))
            {
                cmdTrans.Parameters.AddWithValue("@bid", newBillId);
                cmdTrans.Parameters.AddWithValue("@mode", paymentMode);
                cmdTrans.Parameters.AddWithValue("@amt", amount);
                await cmdTrans.ExecuteNonQueryAsync();
            }

            await trans.CommitAsync();
        }
        catch
        {
            await trans.RollbackAsync();
            throw; // Re-throw so the UI knows it failed
        }
    }

    // 3. FINANCIAL REPORT (For Manager/Admin)
    // Joins Bills, Transactions, and Patient info
    public async Task<List<FinancialReportRow>> GetDailyFinancialReportAsync(DateTime date)
    {
        var list = new List<FinancialReportRow>();
        var conn = await _db.OpenAsync();

        string sql = @"
            SELECT 
                b.BillId,
                p.FirstName + ' ' + p.LastName AS PatientName,
                b.TotalAmount,
                pt.AmountPaid,
                b.PaymentStatus,
                pt.PaymentMode,
                pt.PaymentDate
            FROM Bills b
            JOIN Visits v ON b.VisitId = v.VisitId
            JOIN Appointments a ON v.AppointmentId = a.AppointmentId
            JOIN Patients p ON a.PatientId = p.PatientId
            LEFT JOIN PaymentTransactions pt ON b.BillId = pt.BillId
            WHERE CAST(pt.PaymentDate AS DATE) = CAST(@date AS DATE)
            ORDER BY pt.PaymentDate DESC";

        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@date", date);

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            list.Add(new FinancialReportRow
            {
                BillId = reader.GetInt32(0),
                PatientName = reader.GetString(1),
                TotalAmount = reader.GetDecimal(2),
                PaidAmount = reader.IsDBNull(3) ? 0 : reader.GetDecimal(3),
                PaymentStatus = reader.GetString(4),
                PaymentMode = reader.IsDBNull(5) ? "Pending" : reader.GetString(5),
                PaymentDate = reader.IsDBNull(6) ? null : reader.GetDateTime(6)
            });
        }
        return list;
    }

    public async Task DisplayFinancialDashboardAsync()
    {
        var conn = await _db.OpenAsync();
        string sql = @"
            SELECT 
                PaymentMode, 
                COUNT(TransactionId) as TransactionCount, 
                SUM(AmountPaid) as TotalRevenue
            FROM PaymentTransactions
            GROUP BY PaymentMode";

        using var cmd = new SqlCommand(sql, conn);
        using var reader = await cmd.ExecuteReaderAsync();

        Console.WriteLine("\n=== FINANCIAL DASHBOARD SUMMARY ===");
        Console.WriteLine($"{"Mode",-10} | {"Count",-8} | {"Total Revenue",-15}");
        Console.WriteLine(new string('-', 40));

        decimal grandTotal = 0;
        while (await reader.ReadAsync())
        {
            string mode = reader.GetString(0);
            int count = reader.GetInt32(1);
            decimal total = reader.GetDecimal(2);
            grandTotal += total;

            Console.WriteLine($"{mode,-10} | {count,-8} | {total,-15:C}");
        }
        Console.WriteLine(new string('=', 40));
        Console.WriteLine($"GRAND TOTAL: {grandTotal:C}");
    }


    // GET TOTAL REVENUE (For Manager Dashboard)
    public async Task<decimal> GetTotalRevenueAsync()
    {
        var conn = await _db.OpenAsync();
        // Updated to use PaymentTransactions table to match ProcessPaymentAsync
        string sql = "SELECT SUM(AmountPaid) FROM PaymentTransactions";

        using var cmd = new SqlCommand(sql, conn);
        try
        {
            var result = await cmd.ExecuteScalarAsync();
            return result != DBNull.Value ? Convert.ToDecimal(result) : 0m;
        }
        catch (SqlException ex)
        {
            throw new Exception("Unable to calculate revenue. Check database permissions.", ex);
        }
    }

    
}