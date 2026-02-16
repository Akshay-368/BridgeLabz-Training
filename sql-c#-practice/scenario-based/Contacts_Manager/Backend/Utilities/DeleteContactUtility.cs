namespace Utilities;

using System;
using System.Data;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using Core;
using Microsoft.Data.SqlClient;

internal class DeleteContact
{
    // ============================================================
    // Main Method: Delete Contact
    // ============================================================

    internal async Task DeleteContactAsync()
    {
        try
        {
            // ---------------- UI Header ----------------

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("╔════════════════════════════════════╗");
            Console.WriteLine("║        DELETE CONTACT              ║");
            Console.WriteLine("╚════════════════════════════════════╝");
            Console.ResetColor();

            Console.WriteLine();

            // ---------------- Read Phone Number ----------------

            string phone = ReadPhoneNumber();

            Console.WriteLine();

            // ---------------- Confirmation ----------------

            bool confirm = ReadYesNo("Are you sure you want to delete this contact? (y/n)");

            if (!confirm)
            {
                "Delete operation cancelled.".Dump("Cancelled");
                return;
            }

            // ---------------- Database Section ----------------

            // Using ensures connection is CLOSED even if error occurs
            using DbConnection db = new DbConnection();

            SqlConnection conn = await db.OpenAsync();

            using SqlCommand cmd = new SqlCommand(@"
                DELETE FROM Contacts
                WHERE PhoneNumber = @Phone
            ", conn);

            cmd.Parameters.AddWithValue("@Phone", phone);

            int rows = await cmd.ExecuteNonQueryAsync();

            // ---------------- Result Handling ----------------

            if (rows > 0)
            {
                "Contact deleted successfully.".Dump("Success");
            }
            else
            {
                "No contact found with this phone number.".Dump("Not Found");
            }

            // ---------------- Pause ----------------

            Console.WriteLine();
            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Press any key to return to menu...");
            Console.ResetColor();
            Console.ReadKey(true);
        }
        catch (Exception ex)
        {
            $"Error: {ex.Message}".Dump("Delete Failed");
        }
    }

    // ============================================================
    // Helper Methods
    // ============================================================

    // Validate phone number format
    private string ReadPhoneNumber()
    {
        Regex regex = new Regex(@"^[0-9]{8,15}$");

        while (true)
        {
            Console.Write("Enter Phone Number: ");
            string phone = Console.ReadLine();

            if (!string.IsNullOrWhiteSpace(phone) && regex.IsMatch(phone))
                return phone.Trim();

            "Invalid phone number format.".Dump("Error");
        }
    }

    // Read Yes / No input
    private bool ReadYesNo(string message)
    {
        while (true)
        {
            Console.Write($"{message}: ");

            string input = Console.ReadLine()?.ToLower();

            if (input == "y") return true;
            if (input == "n") return false;

            "Please enter y or n.".Dump("Error");
        }
    }
}
