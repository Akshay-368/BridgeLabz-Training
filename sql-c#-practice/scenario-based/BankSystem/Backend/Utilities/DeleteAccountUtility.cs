using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Core;

namespace Utility
{
    internal class DeleteAccount
    {
        // ------------------------------------------------------------
        // Reference SAME cache used in GetBalance
        // ------------------------------------------------------------
        private static Dictionary<int, decimal> BalanceCache
            => GetBalanceCache();


        // ------------------------------------------------------------
        // MAIN METHOD
        // ------------------------------------------------------------
        internal async Task DeleteAsync()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nEnter Account ID to delete: ");
                Console.ResetColor();

                string? input = Console.ReadLine();


                // -----------------------------
                // Validate Input
                // -----------------------------
                if (!int.TryParse(input, out int accountId))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Invalid Account ID.");
                    Console.ResetColor();
                    return;
                }


                // -----------------------------
                // Confirm Deletion
                // -----------------------------
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine("\n  Are you sure you want to delete this account?");
                Console.Write("Type YES to confirm: ");
                Console.ResetColor();

                string? confirm = Console.ReadLine();

                if (!string.Equals(confirm, "YES", StringComparison.OrdinalIgnoreCase))
                {
                    Console.ForegroundColor = ConsoleColor.Magenta;
                    Console.WriteLine("\n Deletion cancelled.");
                    Console.ResetColor();
                    return;
                }


                // -----------------------------
                // Delete From Database
                // -----------------------------
                await DeleteFromDatabase(accountId);


                // -----------------------------
                // Remove From Cache
                // -----------------------------
                if (BalanceCache.ContainsKey(accountId))
                {
                    BalanceCache.Remove(accountId);

                    Console.ForegroundColor = ConsoleColor.DarkYellow;
                    Console.WriteLine("\n Cached balance removed.");
                    Console.ResetColor();
                }


                // -----------------------------
                // Success Message
                // -----------------------------
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Account deleted successfully.");
                Console.ResetColor();
            }
            catch (SqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"\n Database Error: {ex.Message}");
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
        // DATABASE DELETE
        // ------------------------------------------------------------
        private async Task DeleteFromDatabase(int accountId)
        {
            using (DbConnection db = new DbConnection())
            {
                SqlConnection connection = await db.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("sp_DeleteAccount", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    cmd.Parameters.AddWithValue("@AccountId", accountId);

                    await cmd.ExecuteNonQueryAsync();
                }
            }
        }


        // ------------------------------------------------------------
        // ACCESS GetBalance CACHE (Reflection Hack to access private field)
        // ------------------------------------------------------------
        private static Dictionary<int, decimal> GetBalanceCache()
        {
            var field = typeof(GetBalance)
                .GetField("_balanceCache",
                          System.Reflection.BindingFlags.Static |
                          System.Reflection.BindingFlags.NonPublic);

            return (Dictionary<int, decimal>)field!.GetValue(null)!;
        }
    }
}
