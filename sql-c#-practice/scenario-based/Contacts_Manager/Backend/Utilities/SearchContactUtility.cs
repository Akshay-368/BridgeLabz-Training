namespace Utilities;

using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class SearchContact
{
    public async Task SearchContactAsync()
    {


        Console.ForegroundColor = ConsoleColor.Cyan;
        Console.WriteLine("===================================");
        Console.WriteLine("         SEARCH CONTACT            ");
        Console.WriteLine("===================================");
        Console.ResetColor();

        Console.Write("\nEnter name to search (First or  Last): ");
        string searchText = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(searchText))
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Search text cannot be empty.");
            Console.ResetColor();
            return;
        }

        try
        {
            List<ContactDto> results = await SearchContactsAsync(searchText);

            if (results.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\nNo matching contacts found.");
                Console.ResetColor();
                return;
            }

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine($"\nFound {results.Count} result(s):");
            Console.ResetColor();

            DisplayResults(results);
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Search Failed:");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }

    // =============================================
    // DATABASE SEARCH
    // =============================================

    private async Task<List<ContactDto>> SearchContactsAsync(string keyword)
    {
        List<ContactDto> list = new List<ContactDto>();

        using DbConnection db = new DbConnection();

        SqlConnection connection = await db.OpenAsync();

        string query = @"
            SELECT *
            FROM Contacts
            WHERE 
                FirstName LIKE @Search
                OR LastName LIKE @Search
        ";

        using SqlCommand cmd = new SqlCommand(query, connection);

        cmd.Parameters.AddWithValue("@Search", $"%{keyword}%");

        using SqlDataReader reader = await cmd.ExecuteReaderAsync();

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

            list.Add(contact);
        }

        return list;
    }

    // =============================================
    // DISPLAY RESULTS
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
