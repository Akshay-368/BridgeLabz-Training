namespace Utilities;

using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class AddContact
{
    internal async Task AddContactAsync()
    {
        try
        {


            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║         ADD NEW CONTACT            ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine();

            // ───────────── Required Fields ─────────────
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Required Information");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  ──────────────────────────────────");
            Console.ResetColor();

            string firstName = ReadRequired("First Name          ");
            string lastName  = ReadRequired("Last Name           ");

            Console.WriteLine();

            string phone = ReadPhoneNumber();

            // ───────────── Optional Fields ─────────────
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("  Additional Information");
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.WriteLine("  ──────────────────────────────────");
            Console.ResetColor();

            string email     = ReadOptional("Email               ");
            string address   = ReadOptional("Address             ");

            Console.WriteLine();

            string contactType = ReadChoice(
                "Contact Type        ",
                new[] { "Work", "Home", "Personal", "Other" },
                "Personal"
            );

            DateTime? dob = ReadDate("Date of Birth (yyyy-MM-dd)");

            Console.WriteLine();

            string relationType = ReadChoice(
                "Relation Type       ",
                new[] { "Family", "Friend", "Acquaintance", "Colleague", "Other" },
                "Other"
            );

            string customRelation = null;

            if (relationType == "Other")
            {
                Console.WriteLine();
                customRelation = ReadOptional("Custom Relation     ");
            }

            Console.WriteLine();

            bool isVip = ReadYesNo("Mark as VIP? (y/n)  ");

            // ────────────────────────────────────────────
            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGreen;
            Console.WriteLine("  Contact information collected successfully.");
            Console.ResetColor();

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("  Press any key to return to menu...");
            Console.ResetColor();
            Console.ReadKey(true);

            // -------- Database Insert --------

            using DbConnection db = new DbConnection();

            SqlConnection conn = await db.OpenAsync();

            AddContact service = new AddContact();

            bool success = await service.InsertContactAsync(
                firstName,
                lastName,
                phone,
                email,
                address,
                contactType,
                dob,
                relationType,
                customRelation,
                isVip
            );

            if (success)
            {
                "Contact added successfully".Dump();
            }
            else
            {
                "Failed to add contact".Dump();
            }
        }

            catch (SqlException ex) when (ex.Number == 2627)
            {
                "Phone number already exists!".Dump("Duplicate Error");
            }
            catch (Exception ex)
            {
                $"Error: {ex.Message}".Dump("Add Contact Failed");
            }
        }

    // ================= Helper Methods =================

    private string ReadRequired(string field)
    {
        while (true)
        {
            Console.Write($"{field}: ");
            string input = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(input))
                return input.Trim();

            "This field is required.".Dump("Error");
        }
    }

    private string ReadOptional(string field)
    {
        Console.Write($"{field} (Optional): ");
        return Console.ReadLine()?.Trim();
    }

    private string ReadPhoneNumber()
    {
        Regex regex = new Regex(@"^[0-9]{8,15}$");

        while (true)
        {
            Console.Write("Phone Number: ");
            string phone = Console.ReadLine();

            if (regex.IsMatch(phone))
                return phone;

            "Invalid phone number.".Dump("Error");
        }
    }

    private string ReadChoice(string title, string[] options, string defaultVal)
    {
        Console.WriteLine($"\n{title}:");

        for (int i = 0; i < options.Length; i++)
        {
            Console.WriteLine($"{i + 1}. {options[i]}");
        }

        Console.Write($"Select (Default: {defaultVal}): ");

        string input = Console.ReadLine();

        if (int.TryParse(input, out int choice))
        {
            if (choice >= 1 && choice <= options.Length)
                return options[choice - 1];
        }

        return defaultVal;
    }

    private DateTime? ReadDate(string field)
    {
        Console.Write($"{field} (Optional): ");

        string input = Console.ReadLine();

        if (DateTime.TryParse(input, out DateTime date))
            return date;

        return null;
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
    // Reusable Insert Method (Used by Undo / Import / Sync)
    // ============================================================

    internal async Task<bool> InsertContactAsync(
        string firstName,
        string lastName,
        string phone,
        string email,
        string address,
        string contactType,
        DateTime? dob,
        string relationType,
        string customRelation,
        bool isVip
    )
    {
        using DbConnection db = new DbConnection();

        SqlConnection conn = await db.OpenAsync();

        using SqlCommand cmd = new SqlCommand(@"
            INSERT INTO Contacts
            (
                FirstName,
                LastName,
                PhoneNumber,
                Email,
                Address,
                ContactType,
                DateOfBirth,
                RelationType,
                CustomRelation,
                IsVip
            )
            VALUES
            (
                @FirstName,
                @LastName,
                @Phone,
                @Email,
                @Address,
                @Type,
                @DOB,
                @Relation,
                @Custom,
                @Vip
            )", conn);

        cmd.Parameters.AddWithValue("@FirstName", firstName);
        cmd.Parameters.AddWithValue("@LastName", lastName);
        cmd.Parameters.AddWithValue("@Phone", phone);

        cmd.Parameters.AddWithValue("@Email",
            string.IsNullOrWhiteSpace(email)
                ? DBNull.Value : email);

        cmd.Parameters.AddWithValue("@Address",
            string.IsNullOrWhiteSpace(address)
                ? DBNull.Value : address);

        cmd.Parameters.AddWithValue("@Type", contactType);

        cmd.Parameters.AddWithValue("@DOB",
            dob.HasValue ? dob.Value : DBNull.Value);

        cmd.Parameters.AddWithValue("@Relation", relationType);

        cmd.Parameters.AddWithValue("@Custom",
            string.IsNullOrWhiteSpace(customRelation)
                ? DBNull.Value : customRelation);

        cmd.Parameters.AddWithValue("@Vip", isVip);

        int rows = await cmd.ExecuteNonQueryAsync();



        return rows > 0;
    }

}
