namespace Utilities;

using System;
using System.Data;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class ViewAuditLogs
{
    internal async Task ViewAuditLogsAsync()
    {
        Console.ForegroundColor = ConsoleColor.Magenta;

        Console.WriteLine("=======================================");
        Console.WriteLine("         SYSTEM AUDIT LOGS             ");
        Console.WriteLine("=======================================\n");

        Console.ResetColor();

        try
        {
            // Create DB connection
            using DbConnection db = new DbConnection();

            // Open connection
            SqlConnection connection = await db.OpenAsync();

            // SQL Query
            string query = @"SELECT
                                LogId,
                                ActionType,
                                ContactId,
                                ActionDate,
                                OldValue,
                                NewValue
                             FROM SystemAuditLogs
                             ORDER BY ActionDate DESC";

            // Create Command
            using SqlCommand command = new SqlCommand(query, connection);

            // Execute Reader
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            // Check if logs exist
            if (!reader.HasRows)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No audit logs found.");
                Console.ResetColor();
                return;
            }

            // Read data
            while (await reader.ReadAsync())
            {
                Console.ForegroundColor = ConsoleColor.DarkGreen;

                Console.WriteLine("---------------------------------------");

                Console.WriteLine($"Log ID      : {reader["LogId"]}");
                Console.WriteLine($"Action      : {reader["ActionType"]}");
                Console.WriteLine($"Contact ID  : {reader["ContactId"] ?? "N/A"}");
                Console.WriteLine($"Date        : {reader["ActionDate"]}");

                Console.ForegroundColor = ConsoleColor.DarkYellow;
                Console.WriteLine("\nOld Value:");
                Console.WriteLine(reader["OldValue"] ?? "N/A");

                Console.ForegroundColor = ConsoleColor.DarkCyan;
                Console.WriteLine("\nNew Value:");
                Console.WriteLine(reader["NewValue"] ?? "N/A");

                Console.ResetColor();
            }

            Console.WriteLine("---------------------------------------");

            Console.ForegroundColor = ConsoleColor.Magenta;
            Console.WriteLine("\nEnd of Audit Log List");
            Console.ResetColor();
        }
        catch (SqlException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Database Error:");
            Console.WriteLine(ex.Message);

            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;

            Console.WriteLine("Unexpected Error:");
            Console.WriteLine(ex.Message);

            Console.ResetColor();
        }
    }
}
