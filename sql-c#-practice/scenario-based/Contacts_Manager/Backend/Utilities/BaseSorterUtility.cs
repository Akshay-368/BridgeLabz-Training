namespace Utilities;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal abstract class BaseSorter
{
    // =============================================
    // MAIN TEMPLATE METHOD
    // =============================================

    internal async Task SortAsync()
    {
        Console.ForegroundColor = ConsoleColor.Cyan;

        Console.WriteLine("===================================");
        Console.WriteLine($"      SORTING BY {GetSortTitle()} 📊");
        Console.WriteLine("===================================");
        Console.ResetColor();

        try
        {
            List<ContactDto> list = await LoadSortedDataAsync();

            if (list.Count == 0)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("No contacts found.");
                Console.ResetColor();
                return;
            }

            Display(list);

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\nSorting Completed ✅");
            Console.ResetColor();
        }
        catch (Exception ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Sorting Failed ❌");
            Console.WriteLine(ex.Message);
            Console.ResetColor();
        }
    }


    // =============================================
    // LOAD SORTED DATA
    // =============================================

    private async Task<List<ContactDto>> LoadSortedDataAsync()
    {
        List<ContactDto> list = new List<ContactDto>();

        using DbConnection db = new DbConnection();

        SqlConnection connection = await db.OpenAsync();

        string query = $@"
            SELECT *
            FROM Contacts
            ORDER BY {GetOrderByColumn()}
        ";

        using SqlCommand cmd = new SqlCommand(query, connection);

        using SqlDataReader reader = await cmd.ExecuteReaderAsync();

        while (await reader.ReadAsync())
        {
            ContactDto contact = new ContactDto
            {
                ContactId = Convert.ToInt32(reader["ContactId"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                Address = reader["Address"]?.ToString(),
                IsVip = Convert.ToBoolean(reader["IsVip"])
            };

            list.Add(contact);
        }

        return list;
    }


    // =============================================
    // DISPLAY
    // =============================================

    private void Display(List<ContactDto> contacts)
    {
        foreach (var c in contacts)
        {
            Console.WriteLine("----------------------------------");

            Console.ForegroundColor = ConsoleColor.White;

            Console.WriteLine($"ID      : {c.ContactId}");
            Console.WriteLine($"Name    : {c.FirstName} {c.LastName}");
            Console.WriteLine($"Phone   : {c.PhoneNumber}");
            Console.WriteLine($"Address : {c.Address ?? "N/A"}");
            Console.WriteLine($"VIP     : {(c.IsVip ? "YES ⭐" : "NO")}");

            Console.ResetColor();
        }

        Console.WriteLine("----------------------------------");
    }


    // =============================================
    // TEMPLATE METHODS (OVERRIDE)
    // =============================================

    protected abstract string GetOrderByColumn();

    protected abstract string GetSortTitle();


    // =============================================
    // INTERNAL DTO
    // =============================================

    private class ContactDto
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Address { get; set; }

        public bool IsVip { get; set; }
    }
}
