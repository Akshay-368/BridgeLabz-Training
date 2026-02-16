using System;
using System.Data;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Core;

namespace Utility
{
    internal class CreateAccount
    {
        internal async Task CreateAsync()
        {
            try
            {
                Console.WriteLine("=== CREATE NEW ACCOUNT ===");

                // 1. Take input from user
                Console.Write("Enter Holder Name: ");
                string holderName = Console.ReadLine();

                Console.Write("Enter Initial Balance: ");
                decimal balance = Convert.ToDecimal(Console.ReadLine());

                // 2. Create DB connection inside using (auto close)
                using (DbConnection db = new DbConnection())
                {
                    SqlConnection connection = await db.OpenAsync();

                    // 3. Create SqlCommand for Stored Procedure
                    using (SqlCommand cmd = new SqlCommand("sp_InsertAccount", connection))
                    {
                        cmd.CommandType = CommandType.StoredProcedure;

                        // 4. Input Parameters
                        cmd.Parameters.AddWithValue("@HolderName", holderName);
                        cmd.Parameters.AddWithValue("@Balance", balance);

                        // 5. Output Parameter
                        SqlParameter outputId = new SqlParameter
                        {
                            ParameterName = "@NewAccountId",
                            SqlDbType = SqlDbType.Int,
                            Direction = ParameterDirection.Output
                        };

                        cmd.Parameters.Add(outputId);

                        // 6. Execute
                        await cmd.ExecuteNonQueryAsync();

                        // 7. Get Output Value
                        int newAccountId = Convert.ToInt32(outputId.Value);

                        Console.WriteLine();
                        Console.WriteLine("Account created successfully! ");
                        Console.WriteLine($"New Account ID: {newAccountId}");
                    }
                }
            }
            catch (FormatException)
            {
                Console.WriteLine("Invalid number format. Please enter correct values.");
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
