namespace Utilities;

using System;
using System.Data;
using System.Text.Json;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class UndoDelete
{
    // ============================================================
    // Main Method: Undo Delete
    // ============================================================

    internal async Task UndoDeleteAsync()
    {
        try
        {
            // ---------------- UI Header ----------------

            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║        UNDO DELETE CONTACT         ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine();

            // ---------------- Database Section ----------------

            using DbConnection db = new DbConnection();

            SqlConnection conn = await db.OpenAsync();

            // ---------------- Get Deleted Records ----------------

            using SqlCommand fetchCmd = new SqlCommand(@"
                SELECT TOP 10
                    LogId,
                    ActionDate,
                    OldValue
                FROM SystemAuditLogs
                WHERE ActionType = 'Delete'
                ORDER BY ActionDate DESC
            ", conn);

            using SqlDataReader reader =
                await fetchCmd.ExecuteReaderAsync();

            if (!reader.HasRows)
            {
                "No deleted records found.".Dump("Info");
                return;
            }

            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("Recently Deleted Contacts:");
            Console.ResetColor();

            Console.WriteLine();

            // Store results in memory
            var deletedList = new System.Collections.Generic.List<DeletedContact>();

            int index = 1;

            while (await reader.ReadAsync())
            {
                int logId = reader.GetInt32(0);
                DateTime date = reader.GetDateTime(1);
                string json = reader.GetString(2);

                ContactData data =
                    JsonSerializer.Deserialize<ContactData>(json);

                deletedList.Add(new DeletedContact
                {
                    LogId = logId,
                    Data = data
                });

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[{index}] ");
                Console.ResetColor();

                Console.WriteLine(
                    $"{data.FirstName} {data.LastName} | " +
                    $"{data.PhoneNumber} | " +
                    $"{date}"
                );

                index++;
            }

            reader.Close();

            Console.WriteLine();

            // ---------------- Select Record ----------------

            int choice = ReadChoice(deletedList.Count);

            DeletedContact selected =
                deletedList[choice - 1];

            Console.WriteLine();

            // ---------------- Show Details ----------------

            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("Selected Contact:");
            Console.ResetColor();

            PrintContact(selected.Data);

            Console.WriteLine();

            // ---------------- Confirmation ----------------

            bool confirm =
                ReadYesNo("Restore this contact? (y/n)");

            if (!confirm)
            {
                "Undo cancelled.".Dump("Cancelled");
                return;
            }

            // ---------------- Insert Back ----------------

            AddContact service = new AddContact();

            ContactData c = selected.Data;

            bool success = await service.InsertContactAsync(
                c.FirstName,
                c.LastName,
                c.PhoneNumber,
                c.Email,
                c.Address,
                c.ContactType,
                c.DateOfBirth,
                c.RelationType,
                c.CustomRelation,
                c.IsVip
            );

            // ---------------- Result ----------------

            if (success)
            {
                "Contact restored successfully!".Dump("Success");
            }
            else
            {
                "Restore failed.".Dump("Error");
            }

            

            // ---------------- Pause ----------------

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Press any key to return...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        catch (SqlException ex) when (ex.Number == 2627)
        {
            "Phone number already exists!".Dump("Duplicate");
        }
        catch (Exception ex)
        {
            $"Error: {ex.Message}".Dump("Undo Failed");
        }
    }

    // ============================================================
    // Helper Methods
    // ============================================================

    private int ReadChoice(int max)
    {
        while (true)
        {
            Console.Write($"Select (1-{max}): ");

            string input = Console.ReadLine();

            if (int.TryParse(input, out int num))
            {
                if (num >= 1 && num <= max)
                    return num;
            }

            "Invalid selection.".Dump("Error");
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

    private void PrintContact(ContactData c)
    {
        Console.WriteLine("-----------------------------------");

        Console.WriteLine($"Name    : {c.FirstName} {c.LastName}");
        Console.WriteLine($"Phone   : {c.PhoneNumber}");
        Console.WriteLine($"Email   : {c.Email}");
        Console.WriteLine($"Address : {c.Address}");
        Console.WriteLine($"Type    : {c.ContactType}");
        Console.WriteLine($"Relation: {c.RelationType}");
        Console.WriteLine($"DOB     : {c.DateOfBirth}");
        Console.WriteLine($"VIP     : {(c.IsVip ? "YES" : "NO")}");

        Console.WriteLine("-----------------------------------");
    }

    // ============================================================
    // Internal Helper Models
    // ============================================================

    private class DeletedContact
    {
        internal int LogId { get; set; }
        internal ContactData Data { get; set; }
    }

    private class ContactData
    {
        public int ContactId { get; set; }

        public string FirstName { get; set; }

        public string LastName { get; set; }

        public string PhoneNumber { get; set; }

        public string Email { get; set; }

        public string Address { get; set; }

        public string ContactType { get; set; }

        public DateTime? DateOfBirth { get; set; }

        public string RelationType { get; set; }

        public string CustomRelation { get; set; }

        public bool IsVip { get; set; }
    }
}
