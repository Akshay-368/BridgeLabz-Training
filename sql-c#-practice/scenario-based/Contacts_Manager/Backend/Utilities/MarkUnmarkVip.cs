namespace Utilities;

using System;
using System.Data;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class MarkUnmarkVip
{
    // ============================================================
    // Main Method
    // ============================================================

    internal async Task MarkUnmarkVipAsync()
    {
        try
        {
            // ---------------- Header ----------------

            Console.ForegroundColor = ConsoleColor.Magenta;

            Console.WriteLine("=======================================");
            Console.WriteLine("        MARK / UNMARK VIP CONTACT       ");
            Console.WriteLine("=======================================\n");

            Console.ResetColor();


            // ---------------- Show All Contacts ----------------

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("Showing all contacts first...\n");
            Console.ResetColor();

            await new ViewContacts().ViewContactsAsync();

            Console.WriteLine();


            // ---------------- Read Name ----------------

            string firstName = ReadRequired("Enter First Name");
            string lastName  = ReadRequired("Enter Last Name");

            Console.WriteLine();


            // ---------------- Fetch Contact ----------------

            ContactInfo contact =
                await GetContactAsync(firstName, lastName);

            if (contact == null)
            {
                "No matching contact found.".Dump("Not Found");
                return;
            }


            // ---------------- Show Selected ----------------

            Console.ForegroundColor = ConsoleColor.Green;

            Console.WriteLine("\nSelected Contact:");
            Console.WriteLine("-----------------------------------");

            Console.WriteLine($"ID    : {contact.ContactId}");
            Console.WriteLine($"Name  : {contact.FirstName} {contact.LastName}");
            Console.WriteLine($"Phone : {contact.PhoneNumber}");
            Console.WriteLine($"VIP   : {(contact.IsVip ? "YES ⭐" : "NO")}");

            Console.WriteLine("-----------------------------------");

            Console.ResetColor();


            // ---------------- Ask New Status ----------------

            bool newVipStatus =
                ReadYesNo("\nMark as VIP? (y/n)");


            if (newVipStatus == contact.IsVip)
            {
                "No change required.".Dump("Info");
                return;
            }


            // ---------------- Update Database ----------------

            bool updated =
                await UpdateVipStatusAsync(
                    contact.ContactId,
                    newVipStatus
                );


            // ---------------- Result ----------------

            if (updated)
            {
                "VIP status updated successfully!".Dump("Success");
            }
            else
            {
                "Update failed.".Dump("Failed");
            }


            // ---------------- Pause ----------------

            Console.WriteLine();

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Press any key to return...");
            Console.ResetColor();

            Console.ReadKey(true);
        }
        catch (Exception ex)
        {
            $"Error: {ex.Message}".Dump("VIP Update Failed");
        }
    }


    // ============================================================
    // Get Contact By Name
    // ============================================================

    private async Task<ContactInfo> GetContactAsync(
        string firstName,
        string lastName)
    {
        using DbConnection db = new DbConnection();

        SqlConnection conn = await db.OpenAsync();

        string query = @"
            SELECT TOP 1
                ContactId,
                FirstName,
                LastName,
                PhoneNumber,
                IsVip
            FROM Contacts
            WHERE
                FirstName = @FirstName
                AND LastName = @LastName
        ";

        using SqlCommand cmd =
            new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@FirstName", firstName);
        cmd.Parameters.AddWithValue("@LastName", lastName);

        using SqlDataReader reader =
            await cmd.ExecuteReaderAsync();

        if (await reader.ReadAsync())
        {
            return new ContactInfo
            {
                ContactId = Convert.ToInt32(reader["ContactId"]),
                FirstName = reader["FirstName"].ToString(),
                LastName = reader["LastName"].ToString(),
                PhoneNumber = reader["PhoneNumber"].ToString(),
                IsVip = Convert.ToBoolean(reader["IsVip"])
            };
        }

        return null;
    }


    // ============================================================
    // Update VIP Status
    // ============================================================

    private async Task<bool> UpdateVipStatusAsync(
        int contactId,
        bool isVip)
    {
        using DbConnection db = new DbConnection();

        SqlConnection conn = await db.OpenAsync();

        string query = @"
            UPDATE Contacts
            SET
                IsVip = @IsVip,
                UpdatedDate = SYSDATETIME()
            WHERE
                ContactId = @Id
        ";

        using SqlCommand cmd =
            new SqlCommand(query, conn);

        cmd.Parameters.AddWithValue("@IsVip", isVip);
        cmd.Parameters.AddWithValue("@Id", contactId);

        int rows = await cmd.ExecuteNonQueryAsync();

        return rows > 0;
    }


    // ============================================================
    // Helpers
    // ============================================================

    private string ReadRequired(string label)
    {
        while (true)
        {
            Console.Write($"{label}: ");

            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            "This field is required.".Dump("Error");
        }
    }


    private bool ReadYesNo(string message)
    {
        while (true)
        {
            Console.Write($"{message}: ");

            string input = Console.ReadLine()?.ToLower();

            if (input == "y") return true;
            if (input == "n") return false;

            "Enter y or n.".Dump("Error");
        }
    }


    // ============================================================
    // Internal DTO
    // ============================================================

    private class ContactInfo
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public bool IsVip { get; set; }
    }
}
