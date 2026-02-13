using Microsoft.Data.SqlClient;
using System.Data;
using Core;
using Entities;
namespace Utilities;

internal sealed class AppointmentUtility
{
    private readonly DbConnection _db;

    public AppointmentUtility(DbConnection db)
    {
        _db = db;
    }

    // 1. Find Doctors who are actually working on a specific date
    public async Task<List<(int Id, string Name, decimal Fee, int SlotsLeft)>> 
        GetAvailableDoctorsAsync(DateTime date, int specialtyId)
    {
        var list = new List<(int, string, decimal, int)>();
        var dayName = date.DayOfWeek.ToString(); // Returns "Monday", "Tuesday", etc.

        var conn = await _db.OpenAsync();
        string sql = @"
        SELECT d.DoctorId, d.FirstName, d.LastName, d.ConsultationFee, 
               (20 - ds.CurrentNumberOfPatients) AS SlotsLeft
        FROM Doctors d
        JOIN DoctorSchedules ds ON d.DoctorId = ds.DoctorId
        WHERE d.SpecialtyId = @specId 
            AND ds.DayOfWeek = @day
            AND ds.IsAvailable = 1
            AND (20 - ds.CurrentNumberOfPatients) > 0";

        using SqlCommand cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@specId", specialtyId);
        cmd.Parameters.AddWithValue("@day", dayName);

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            string docName = $"Dr. {reader.GetString(1)} {reader.GetString(2)}";
            list.Add((
                reader.GetInt32(0), // Id
                docName,            // Name
                reader.GetDecimal(3), // Fee
                reader.GetInt32(4)  // Slots Left
            ));
        }
        return list;
    }

    // 2. The Transactional Booking Method
    public async Task BookAppointmentAsync(int patientId, int doctorId, DateTime date, string reason)
    {
        var conn = await _db.OpenAsync();
        using SqlCommand cmd = new SqlCommand("sp_BookAppointment", conn);
        cmd.CommandType = CommandType.StoredProcedure;

        cmd.Parameters.AddWithValue("@PatientId", patientId);
        cmd.Parameters.AddWithValue("@DoctorId", doctorId);
        cmd.Parameters.AddWithValue("@AppointmentDate", date);
        cmd.Parameters.AddWithValue("@Reason", reason);

        await cmd.ExecuteNonQueryAsync();
    }

    public async Task<List<AppointmentSummary>> GetAppointmentsByDateAsync(DateTime date)
    {
        var list = new List<AppointmentSummary>();
        
        // Using the existing OpenAsync() method instead of accessing private fields
        var conn = await _db.OpenAsync(); 
        
        using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            SELECT 
                a.AppointmentId, 
                p.FirstName + ' ' + p.LastName AS PatientName, 
                'Dr. ' + d.FirstName + ' ' + d.LastName AS DoctorName, 
                a.AppointmentDate, 
                a.StatusOfVisit
            FROM Appointments a
            JOIN Patients p ON a.PatientId = p.PatientId
            JOIN Doctors d ON a.DoctorId = d.DoctorId
            WHERE CAST(a.AppointmentDate AS DATE) = @date
            ORDER BY a.AppointmentDate ASC";

        cmd.Parameters.AddWithValue("@date", date.Date);

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            list.Add(new AppointmentSummary
            {
                Id = reader.GetInt32(0),
                PatientName = reader.GetString(1),
                DoctorName = reader.GetString(2),
                AppointmentDate = reader.GetDateTime(3),
                Status = reader.GetString(4)
            });
        }
        return list;
    }


    public async Task<List<AppointmentSummary>> GetDoctorAppointmentsAsync(int loggedInUserId, DateTime date)
    {
        var list = new List<AppointmentSummary>();
        var conn = await _db.OpenAsync();
        
        using var cmd = conn.CreateCommand();
        cmd.CommandText = @"
            SELECT 
                a.AppointmentId, 
                p.FirstName + ' ' + p.LastName AS PatientName, 
                'Dr. ' + d.FirstName + ' ' + d.LastName AS DoctorName, 
                a.AppointmentDate, 
                a.StatusOfVisit
            FROM Appointments a
            JOIN Patients p ON a.PatientId = p.PatientId
            JOIN Doctors d ON a.DoctorId = d.DoctorId
            WHERE d.UserId = @uId AND CAST(a.AppointmentDate AS DATE) = CAST(@date AS DATE)
            ORDER BY a.AppointmentDate ASC";

        cmd.Parameters.AddWithValue("@uId", loggedInUserId);
        cmd.Parameters.AddWithValue("@date", date.Date);

        using var reader = await cmd.ExecuteReaderAsync();
        while (await reader.ReadAsync())
        {
            list.Add(new AppointmentSummary {
                Id = reader.GetInt32(0),
                PatientName = reader.GetString(1),
                DoctorName = reader.GetString(2),
                AppointmentDate = reader.GetDateTime(3),
                Status = reader.GetString(4)
            });
        }
        return list;
    }

    public async Task SaveClinicalVisitAsync(int appId, string diagnosis, string notes)
    {
        var conn = await _db.OpenAsync();
        // We use a transaction to ensure both the visit is saved AND the appointment status is updated
        using var trans = conn.BeginTransaction();
        
        try {
            // 1. Record the clinical data
            string sqlVisit = "INSERT INTO Visits (AppointmentId,  Diagnosis, Notes) VALUES (@id, @d, @n)";
            using var cmd1 = new SqlCommand(sqlVisit, conn, trans);
            cmd1.Parameters.AddWithValue("@id", appId);
            cmd1.Parameters.AddWithValue("@d", diagnosis);
            cmd1.Parameters.AddWithValue("@n", (object)notes ?? DBNull.Value);
            await cmd1.ExecuteNonQueryAsync();

            // 2. Update Appointment to 'Completed'
            string sqlApp = "UPDATE Appointments SET StatusOfVisit = 'Completed' WHERE AppointmentId = @id";
            using var cmd2 = new SqlCommand(sqlApp, conn, trans);
            cmd2.Parameters.AddWithValue("@id", appId);
            await cmd2.ExecuteNonQueryAsync();

            await trans.CommitAsync();
        } catch {
            await trans.RollbackAsync();
            throw;
        }
    }

}
