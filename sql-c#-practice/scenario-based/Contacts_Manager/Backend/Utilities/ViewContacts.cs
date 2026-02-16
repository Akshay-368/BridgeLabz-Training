namespace Utilities;

using System;
using System.Data;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class ViewContacts
{
    internal async Task ViewContactsAsync()
    {

        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("=======================================");
        Console.WriteLine("         ALL CONTACTS LIST             ");
        Console.WriteLine("=======================================\n");

        Console.ResetColor();

        try
        {
            // Create DB connection
            using DbConnection db = new DbConnection();

            // Open connection
            SqlConnection connection = await db.OpenAsync();

            //  SQL Query
            string query = @"SELECT 
                                ContactId,
                                FirstName,
                                LastName,
                                PhoneNumber,
                                Email,
                                Address,
                                ContactType,
                                DateOfBirth,
                                RelationType,
                                IsVip
                             FROM Contacts
                             ORDER BY FirstName, LastName";

            //  Create Command
            using SqlCommand command = new SqlCommand(query, connection);

            // Execute Reader
            using SqlDataReader reader = await command.ExecuteReaderAsync();

            //  Check if data exists
            if (!reader.HasRows)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No contacts found in database.");
                Console.ResetColor();
                return;
            }

            //  Read data
            while (await reader.ReadAsync())
            {
                Console.ForegroundColor = ConsoleColor.Green;

                Console.WriteLine("---------------------------------------");

                Console.WriteLine($"ID          : {reader["ContactId"]}");
                Console.WriteLine($"Name        : {reader["FirstName"]} {reader["LastName"]}");
                Console.WriteLine($"Phone       : {reader["PhoneNumber"]}");
                Console.WriteLine($"Email       : {reader["Email"] ?? "N/A"}");
                Console.WriteLine($"Address     : {reader["Address"] ?? "N/A"}");
                Console.WriteLine($"Type        : {reader["ContactType"]}");
                Console.WriteLine($"Relation    : {reader["RelationType"]}");
                Console.WriteLine($"DOB         : {reader["DateOfBirth"] ?? "N/A"}");

                bool isVip = Convert.ToBoolean(reader["IsVip"]);

                Console.WriteLine($"VIP          : {(isVip ? " YES" : "No")}");

                Console.ResetColor();
            }

            Console.WriteLine("---------------------------------------");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("\nEnd of Contact List");
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
