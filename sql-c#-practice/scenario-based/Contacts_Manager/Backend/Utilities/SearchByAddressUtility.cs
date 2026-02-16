namespace Utilities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class SearchByAddress
{
    // =============================================
    // MAIN ENTRY METHOD
    // =============================================

    internal async Task SearchByAddressAsync()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===================================");
        Console.WriteLine("      SEARCH BY ADDRESS 📍         ");
        Console.WriteLine("===================================");
        Console.ResetColor();

        Console.Write("\nEnter address keyword to search: ");
        string addressText = Console.ReadLine()?.Trim();

        // Step 1: Validate input
        if (string.IsNullOrWhiteSpace(addressText))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Address cannot be empty.");
            Console.ResetColor();
            return;
        }

        try
        {
            // Step 2: Call DB method
            List<ContactDto> results =
                await SearchContactsByAddressAsync(addressText);

            // Step 3: Check if any result exists
            if (results.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo contacts found for this address.");
                Console.ResetColor();
                return;
            }

            // Step 4: Display result count
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nFound {results.Count} contact(s):");
            Console.ResetColor();

            // Step 5: Display contacts
            DisplayResults(results);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("\nSearch Failed ❌");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }


    // =============================================
    // DATABASE SEARCH METHOD
    // =============================================

    private async Task<List<ContactDto>> SearchContactsByAddressAsync(string keyword)
    {
        List<ContactDto> list = new List<ContactDto>();

        // Step 1: Create DB connection
        using DbConnection db = new DbConnection();

        // Step 2: Open connection
        SqlConnection connection = await db.OpenAsync();

        // Step 3: Prepare SQL query
        string query = @"
            SELECT *
            FROM Contacts
            WHERE Address LIKE @Search
        ";

        // Step 4: Create SQL Command
        using SqlCommand cmd = new SqlCommand(query, connection);

        // Step 5: Add parameter
        cmd.Parameters.AddWithValue("@Search", $"%{keyword}%");

        // Step 6: Execute reader
        using SqlDataReader reader = await cmd.ExecuteReaderAsync();

        // Step 7: Read data row by row
        while (await reader.ReadAsync())
        {
            ContactDto contact = new ContactDto
            {
                ContactId = Convert.ToInt32(reader["ContactId"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                Email = reader["Email"]?.ToString(),
                Address = reader["Address"]?.ToString(),
                ContactType = reader["ContactType"].ToString(),
                RelationType = reader["RelationType"].ToString(),
                IsVip = Convert.ToBoolean(reader["IsVip"])
            };

            // Step 8: Add to list
            list.Add(contact);
        }

        // Step 9: Return final list
        return list;
    }


    // =============================================
    // DISPLAY METHOD
    // =============================================

    private void DisplayResults(List<ContactDto> contacts)
    {
        foreach (var c in contacts)
        {
            Console.WriteLine("------------------------------------");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"ID       : {c.ContactId}");
            Console.WriteLine($"Name     : {c.FirstName} {c.LastName}");
            Console.WriteLine($"Phone    : {c.PhoneNumber}");
            Console.WriteLine($"Email    : {c.Email ?? "N/A"}");
            Console.WriteLine($"Address  : {c.Address ?? "N/A"}");
            Console.WriteLine($"Type     : {c.ContactType}");
            Console.WriteLine($"Relation : {c.RelationType}");
            Console.WriteLine($"VIP      : {(c.IsVip ? "YES ⭐" : "NO")}");

            Console.ResetColor();

            Console.WriteLine("------------------------------------\n");
        }
    }


    // =============================================
    // INTERNAL DTO
    // =============================================

    private class ContactDto
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ContactType { get; set; }

        public string RelationType { get; set; }

        public bool IsVip { get; set; }
    }
}
