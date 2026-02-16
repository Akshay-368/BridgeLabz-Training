using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Core;

namespace Utility
{
    internal class TestInsufficientBalance
    {
        // ------------------------------------------------------------
        // MAIN TEST METHOD
        // ------------------------------------------------------------
        internal async Task RunTestAsync()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n===== INSUFFICIENT BALANCE TEST =====");
                Console.ResetColor();


                // -----------------------------
                // Get Account ID
                // -----------------------------
                Console.Write("Enter Account ID: ");
                string? idInput = Console.ReadLine();

                Console.Write("Enter Withdraw Amount (More than balance): ");
                string? amountInput = Console.ReadLine();


                if (!int.TryParse(idInput, out int accountId) ||
                    !decimal.TryParse(amountInput, out decimal amount))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Invalid input.");
                    Console.ResetColor();
                    return;
                }


                // -----------------------------
                // Try Withdraw
                // -----------------------------
                await TryWithdraw(accountId, amount);


                // -----------------------------
                // If No Error (Should NOT Happen)
                // -----------------------------
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine(" WARNING: Withdrawal succeeded (unexpected).");
                Console.ResetColor();
            }
            catch (SqlException ex)
            {
                // -----------------------------
                // Expected Error
                // -----------------------------
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Test Passed!");
                Console.WriteLine($"Expected Error: {ex.Message}");
                Console.ResetColor();
            }
            catch (Exception ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n Error: {ex.Message}");
                Console.ResetColor();
            }
        }


        // ------------------------------------------------------------
        // WITHDRAW METHOD
        // ------------------------------------------------------------
        private async Task TryWithdraw(int accountId, decimal amount)
        {
            using (DbConnection db = new DbConnection())
            {
                SqlConnection connection = await db.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("sp_Withdraw", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountId", accountId);
                    cmd.Parameters.AddWithValue("@Amount", amount);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }
    }
}
