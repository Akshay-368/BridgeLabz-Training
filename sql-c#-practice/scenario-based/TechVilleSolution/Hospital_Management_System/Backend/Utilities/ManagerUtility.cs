using Microsoft.Data.SqlClient;
using System.Data;
using Core;

namespace Utilities;

internal sealed  class ManagerUtility
{
    private readonly DbConnection _db;

    public ManagerUtility(DbConnection db)
    {
        _db = db;
    }

    // 1. VIEW AUDIT LOGS (Uses your existing vw_StaffActivityLog)
    public async Task DisplaySystemLogsAsync()
    {
        var conn = await _db.OpenAsync();
        // We select specific columns to ensure the reader indexes match perfectly
        string sql = @"
            SELECT TOP 20 
                LogId,      -- 0
                UserName,   -- 1
                TableName,  -- 2
                ActionType, -- 3
                ActionDate, -- 4
                OldValue,   -- 5
                NewValue    -- 6
            FROM vw_StaffActivityLog 
            ORDER BY ActionDate DESC";

        using var cmd = new SqlCommand(sql, conn);
        using var reader = await cmd.ExecuteReaderAsync();

        Console.WriteLine("\n=== SYSTEM ACTIVITY LOG (Last 20 Events) ===");
        // Formatting: Negative numbers align text to the left
        Console.WriteLine($"{"Date",-20} | {"User",-15} | {"Action",-20} | {"Table",-15} | {"Details",-25}");
        Console.WriteLine(new string('-', 100));

        while (await reader.ReadAsync())
        {
            // Safety checks for nulls, though your schema enforces Not Null mostly
            string date = reader.GetDateTime(4).ToString("yyyy-MM-dd HH:mm");
            string user = reader.IsDBNull(1) ? "Unknown" : reader.GetString(1);
            string table = reader.GetString(2);
            string action = reader.GetString(3);
            
            // Construct a detail string from Old/New values
            string oldV = reader.IsDBNull(5) ? "-" : reader.GetString(5);
            string newV = reader.IsDBNull(6) ? "-" : reader.GetString(6);
            string details = (oldV == "-" && newV == "-") ? "" : $"{oldV} -> {newV}";
            if (details.Length > 25) details = details.Substring(0, 22) + "..."; // Truncate long details

            Console.WriteLine($"{date,-20} | {user,-15} | {action,-20} | {table,-15} | {details,-25}");
        }
    }

    // 2. PROMOTE STAFF (Uses the NEW Stored Procedure)
    public async Task PromoteStaffAsync(int staffId, string newRole)
    {
        var conn = await _db.OpenAsync();
        using var cmd = new SqlCommand("usp_PromoteStaff", conn);
        cmd.CommandType = CommandType.StoredProcedure;
        
        cmd.Parameters.AddWithValue("@TargetStaffId", staffId);
        cmd.Parameters.AddWithValue("@NewRole", newRole);

        await cmd.ExecuteNonQueryAsync();
    }

    // 3. MANAGE DOCTOR SCHEDULE (Direct Insert)
    // Manager has permission to INSERT/UPDATE DoctorSchedules, so no SP needed here.
    public async Task AddDoctorScheduleAsync(int docId, string day, TimeSpan start, TimeSpan end)
    {
        var conn = await _db.OpenAsync();
        string sql = @"
            INSERT INTO DoctorSchedules (DoctorId, DayOfWeek, StartTime, EndTime, IsAvailable)
            VALUES (@did, @day, @start, @end, 1)";

        using var cmd = new SqlCommand(sql, conn);
        cmd.Parameters.AddWithValue("@did", docId);
        cmd.Parameters.AddWithValue("@day", day);
        cmd.Parameters.AddWithValue("@start", start);
        cmd.Parameters.AddWithValue("@end", end);

        await cmd.ExecuteNonQueryAsync();
    }
}