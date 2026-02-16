namespace Utilities;

using System;
using System.Data;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class ViewVipContacts
{
    // ============================================================
    // Main Method: View VIP Contacts
    // ============================================================

    internal async Task ViewVipContactsAsync()
    {
        Console.ForegroundColor = ConsoleColor.Yellow;

        Console.WriteLine("=======================================");
        Console.WriteLine("         VIP CONTACTS LIST          ");
        Console.WriteLine("=======================================\n");

        Console.ResetColor();

        try
        {
            // ---------------- Create DB Connection ----------------

            using DbConnection db = new DbConnection();

            // ---------------- Open Connection ----------------

            SqlConnection connection = await db.OpenAsync();

            // ---------------- SQL Query ----------------

            string query = @"
                SELECT 
                    *
                FROM Contacts
                WHERE IsVip = 1
                ORDER BY FirstName, LastName";

            // ---------------- Create Command ----------------

            using SqlCommand command =
                new SqlCommand(query, connection);

            // ---------------- Execute Reader ----------------

            using SqlDataReader reader =
                await command.ExecuteReaderAsync();

            // ---------------- Check If Exists ----------------

            if (!reader.HasRows)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;

                Console.WriteLine("No VIP contacts found.");

                Console.ResetColor();
                return;
            }

            // ---------------- Read Records ----------------

            while (await reader.ReadAsync())
            {
                Console.ForegroundColor = ConsoleColor.DarkYellow;

                Console.WriteLine("---------------------------------------");

                Console.WriteLine($"ID          : {reader["ContactId"]}");
                Console.WriteLine($"Name        : {reader["FirstName"]} {reader["LastName"]}");
                Console.WriteLine($"Phone       : {reader["PhoneNumber"]}");

                Console.WriteLine($"Email       : {reader["Email"] ?? "N/A"}");
                Console.WriteLine($"Address     : {reader["Address"] ?? "N/A"}");

                Console.WriteLine($"Type        : {reader["ContactType"]}");
                Console.WriteLine($"Relation    : {reader["RelationType"]}");

                Console.WriteLine($"DOB         : {reader["DateOfBirth"] ?? "N/A"}");

                Console.WriteLine("VIP          :  YES ");

                Console.ResetColor();
            }

            // ---------------- Footer ----------------

            Console.WriteLine("---------------------------------------");

            Console.ForegroundColor = ConsoleColor.Yellow;

            Console.WriteLine("\nEnd of VIP List");

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
