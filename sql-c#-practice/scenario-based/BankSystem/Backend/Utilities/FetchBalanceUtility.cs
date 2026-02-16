using System;
using System.Collections.Generic;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Core;

namespace Utility
{
    internal class GetBalance
    {
        // ------------------------------------------------------------
        // STATIC DICTIONARY (CACHE)
        // Stores: AccountId -> Balance
        // Shared across all GetBalance objects
        // ------------------------------------------------------------
        private static Dictionary<int, decimal> _balanceCache 
            = new Dictionary<int, decimal>();


        // ------------------------------------------------------------
        // MAIN METHOD
        // ------------------------------------------------------------
        internal async Task GetBalanceAsync()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.Write("\nEnter Account ID: ");
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
                // Check Cache First
                // -----------------------------
                if (_balanceCache.ContainsKey(accountId))
                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    Console.WriteLine("\n  Showing CACHED data:");
                    Console.ResetColor();

                    Console.WriteLine($"Account ID : {accountId}");
                    Console.WriteLine($"Balance    : {_balanceCache[accountId]}");

                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("\nType 'new' to refresh from database");
                    Console.WriteLine("Or press Enter to keep cached data.");
                    Console.ResetColor();

                    string? choice = Console.ReadLine();

                    // If user DOES NOT want fresh data
                    if (!string.Equals(choice, "new", StringComparison.OrdinalIgnoreCase))
                    {
                        Console.ForegroundColor = ConsoleColor.Magenta;
                        Console.WriteLine("\n Using previously loaded data.");
                        Console.ResetColor();
                        return;
                    }

                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n Fetching fresh data from database...");
                    Console.ResetColor();
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    Console.WriteLine("\n No cached data found. Loading from database...");
                    Console.ResetColor();
                }


                // -----------------------------
                // Fetch Fresh Data
                // -----------------------------
                decimal freshBalance = await FetchBalanceFromDatabase(accountId);

                // -----------------------------
                // Update Cache
                // -----------------------------
                if (_balanceCache.ContainsKey(accountId))
                {
                    _balanceCache[accountId] = freshBalance;
                }
                else
                {
                    _balanceCache.Add(accountId, freshBalance);
                }


                // -----------------------------
                // Show Result
                // -----------------------------
                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Fresh Data Loaded:");
                Console.ResetColor();

                Console.WriteLine($"Account ID : {accountId}");
                Console.WriteLine($"Balance    : {freshBalance}");

                Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.WriteLine("\n(Cache Updated)");
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
        // DATABASE CALL METHOD
        // ------------------------------------------------------------
        private async Task<decimal> FetchBalanceFromDatabase(int accountId)
        {
            using (DbConnection db = new DbConnection())
            {
                SqlConnection connection = await db.OpenAsync();

                using (SqlCommand cmd = new SqlCommand("sp_GetBalance", connection))
                {
                    cmd.CommandType = CommandType.StoredProcedure;

                    // Add Parameter
                    cmd.Parameters.AddWithValue("@AccountId", accountId);

                    object? result = await cmd.ExecuteScalarAsync();

                    // -----------------------------
                    // Check Result
                    // -----------------------------
                    if (result == null || result == DBNull.Value)
                    {
                        throw new Exception("Account not found or deleted.");
                    }

                    return Convert.ToDecimal(result);
                }
            }
        }
    }
}
