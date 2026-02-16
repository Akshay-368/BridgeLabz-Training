using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Core;

namespace Utility
{
    internal class Withdraw
    {
        internal async Task WithdrawAsync()
        {
            try
            {
                Console.WriteLine("=== WITHDRAW MONEY ===");

                // 1. Take input
                Console.Write("Enter Account ID: ");
                int accountId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Withdrawal Amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                // 2. Open DB connection using using (auto close)
                using (DbConnection db = new DbConnection())
                {
                    SqlConnection connection = await db.OpenAsync();

                    // 3. Prepare SqlCommand
                    using (SqlCommand cmd = new SqlCommand("sp_Withdraw", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // 4. Add parameters
                        cmd.Parameters.AddWithValue("@AccountId", accountId);
                        cmd.Parameters.AddWithValue("@Amount", amount);

                        // 5. Execute
                        await cmd.ExecuteNonQueryAsync();

                        Console.WriteLine();
                        Console.WriteLine("Withdrawal successful! ");
                        Console.WriteLine($"Amount Withdrawn: {amount}");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
            }
            catch (SqlException ex)
            {
                // This catches: insufficient balance, account not found, etc.
                Console.WriteLine("Transaction Failed ");
                Console.WriteLine("Reason: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
