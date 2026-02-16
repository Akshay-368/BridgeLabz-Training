namespace Utilities;

using System;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class SyncDatabase
{
    // =============================================
    // MAIN METHOD
    // =============================================

    internal async Task SyncAsync()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===================================");
        Console.WriteLine("        DATABASE SYNC           ");
        Console.WriteLine("===================================");
        Console.ResetColor();

        Console.WriteLine("\nStarting synchronization...\n");

        try
        {
            // Step 1: Get database info
            DatabaseInfo info = await GetDatabaseInfoAsync();

            // Step 2: Display info
            DisplayReport(info);

            // Step 3: Refresh timestamps
            await RefreshUpdatedDateAsync();

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSynchronization Completed Successfully ");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSync Failed ");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }


    // =============================================
    // GET DATABASE STATUS
    // =============================================

    private async Task<DatabaseInfo> GetDatabaseInfoAsync()
    {
        DatabaseInfo info = new DatabaseInfo();

        using DbConnection db = new DbConnection();

        SqlConnection connection = await db.OpenAsync();


        // -------------------------------
        // Get total contacts
        // -------------------------------
        string countQuery = "SELECT COUNT(*) FROM Contacts";

        using (SqlCommand cmd = new SqlCommand(countQuery, connection))
        {
            info.TotalContacts =
                Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }


        // -------------------------------
        // Get last updated time
        // -------------------------------
        string dateQuery = "SELECT MAX(UpdatedDate) FROM Contacts";

        using (SqlCommand cmd = new SqlCommand(dateQuery, connection))
        {
            object result = await cmd.ExecuteScalarAsync();

            if (result != DBNull.Value)
            {
                info.LastUpdated = Convert.ToDateTime(result);
            }
        }


        // -------------------------------
        // Get audit log count
        // -------------------------------
        string auditQuery = "SELECT COUNT(*) FROM SystemAuditLogs";

        using (SqlCommand cmd = new SqlCommand(auditQuery, connection))
        {
            info.TotalLogs =
                Convert.ToInt32(await cmd.ExecuteScalarAsync());
        }

        return info;
    }


    // =============================================
    // REFRESH UPDATED DATE
    // =============================================

    private async Task RefreshUpdatedDateAsync()
    {
        using DbConnection db = new DbConnection();

        SqlConnection connection = await db.OpenAsync();

        string query = @"
            UPDATE Contacts
            SET UpdatedDate = SYSDATETIME()
        ";

        using SqlCommand cmd = new SqlCommand(query, connection);

        await cmd.ExecuteNonQueryAsync();
    }


    // =============================================
    // DISPLAY REPORT
    // =============================================

    private void DisplayReport(DatabaseInfo info)
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("---------- DATABASE STATUS ----------");

        Console.WriteLine($"Total Contacts   : {info.TotalContacts}");
        Console.WriteLine($"Total Audit Logs : {info.TotalLogs}");

        if (info.LastUpdated != DateTime.MinValue)
        {
            Console.WriteLine($"Last Update      : {info.LastUpdated}");
        }
        else
        {
            Console.WriteLine("Last Update      : No records found");
        }

        Console.WriteLine("-------------------------------------");

        Console.ResetColor();
    }


    // =============================================
    // INTERNAL DTO
    // =============================================

    private class DatabaseInfo
    {
        public int TotalContacts { get; set; }

        public int TotalLogs { get; set; }

        public DateTime LastUpdated { get; set; }
    }
}
