namespace Utilities;

using System;
using System.Data;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class CountContacts
{
    internal async Task CountAsync()
    {
        Console.ForegroundColor = ConsoleColor.Blue;

        Console.WriteLine("=======================================");
        Console.WriteLine("        TOTAL CONTACTS COUNT           ");
        Console.WriteLine("=======================================\n");

        Console.ResetColor();

        try
        {
            // Create DB connection
            using DbConnection db = new DbConnection();

            // Open connection
            SqlConnection connection = await db.OpenAsync();

            // SQL Query
            string query = @"SELECT COUNT(*) FROM Contacts";

            // Create Command
            using SqlCommand command = new SqlCommand(query, connection);

            // Execute Scalar (Single Value)
            object result = await command.ExecuteScalarAsync();

            // Convert result safely
            int totalContacts = 0;

            if (result != null && result != DBNull.Value)
            {
                totalContacts = Convert.ToInt32(result);
            }

            // Display result
            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("---------------------------------------");
            Console.WriteLine($"Total Contacts : {totalContacts}");
            Console.WriteLine("---------------------------------------");

            Console.ResetColor();

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("\nCount Operation Completed");
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
