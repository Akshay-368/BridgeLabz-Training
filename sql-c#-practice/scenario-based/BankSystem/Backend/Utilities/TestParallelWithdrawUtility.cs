using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Core;
using System.Collections.Generic;

namespace Utility
{
    internal class TestParallelWithdraw
    {
        // ------------------------------------------------------------
        // MAIN TEST
        // ------------------------------------------------------------
        internal async Task RunTestAsync()
        {
            try
            {
                Console.ForegroundColor = ConsoleColor.Cyan;
                Console.WriteLine("\n===== PARALLEL WITHDRAW TEST =====");
                Console.ResetColor();


                // -----------------------------
                // Input
                // -----------------------------
                Console.Write("Enter Account ID: ");
                string? idInput = Console.ReadLine();

                Console.Write("Enter Withdraw Amount (per request): ");
                string? amountInput = Console.ReadLine();

                Console.Write("How many parallel requests? ");
                string? countInput = Console.ReadLine();


                if (!int.TryParse(idInput, out int accountId) ||
                    !decimal.TryParse(amountInput, out decimal amount) ||
                    !int.TryParse(countInput, out int count))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine(" Invalid input.");
                    Console.ResetColor();
                    return;
                }


                // -----------------------------
                // Create Tasks
                // -----------------------------
                List<Task> tasks = new List<Task>();

                for (int i = 1; i <= count; i++)
                {
                    int taskNo = i;

                    tasks.Add(Task.Run(async () =>
                    {
                        await WithdrawParallel(accountId, amount, taskNo);
                    }));
                }


                // -----------------------------
                // Run All Together
                // -----------------------------
                await Task.WhenAll(tasks);


                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine("\n Parallel test finished.");
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
        // SINGLE PARALLEL WITHDRAW
        // ------------------------------------------------------------
        private async Task WithdrawParallel(int accountId, decimal amount, int taskNo)
        {
            try
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

                Console.ForegroundColor = ConsoleColor.Green;
                Console.WriteLine($"[Task {taskNo}]  Withdraw Success");
                Console.ResetColor();
            }
            catch (SqlException ex)
            {
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.WriteLine($"[Task {taskNo}]  Failed: {ex.Message}");
                Console.ResetColor();
            }
        }
    }
}
