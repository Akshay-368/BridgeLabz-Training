using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Core;

namespace Utility
{
    internal class Deposit
    {
        internal async Task DepositAsync()
        {
            try
            {
                Console.WriteLine("=== DEPOSIT MONEY ===");

                // 1. Take input
                Console.Write("Enter Account ID: ");
                int accountId = Convert.ToInt32(Console.ReadLine());

                Console.Write("Enter Deposit Amount: ");
                decimal amount = Convert.ToDecimal(Console.ReadLine());

                // 2. Open DB connection inside using
                using (DbConnection db = new DbConnection())
                {
                    SqlConnection connection = await db.OpenAsync();

                    // 3. Prepare SqlCommand
                    using (SqlCommand cmd = new SqlCommand("sp_Deposit", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // 4. Add parameters
                        cmd.Parameters.AddWithValue("@AccountId", accountId);
                        cmd.Parameters.AddWithValue("@Amount", amount);

                        // 5. Execute
                        await cmd.ExecuteNonQueryAsync();

                        Console.WriteLine();
                        Console.WriteLine("Deposit successful! ");
                        Console.WriteLine($"Amount Deposited: {amount}");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid input. Please enter valid numbers.");
            }
            catch (SqlException ex)
            {
                Console.WriteLine("Database Error: " + ex.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }
}
