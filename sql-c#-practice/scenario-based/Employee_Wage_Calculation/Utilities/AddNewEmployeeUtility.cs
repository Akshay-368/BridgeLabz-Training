using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Interfaces;
using Core;

namespace Utilities
{
    internal class AddNewEmployee : IAddNewEmployee
    {
        public async Task AddNewEmployeeAsync()
        {
            try
            {
                // ---------------- Get User Input ----------------

                Console.Write("Enter First Name: ");
                string firstName = Console.ReadLine()!;

                Console.Write("Enter Last Name: ");
                string lastName = Console.ReadLine()!;

                Console.Write("Enter Email: ");
                string email = Console.ReadLine()!;

                Console.Write("Enter Phone Number: ");
                string phone = Console.ReadLine()!;

                Console.Write("Enter Hourly Rate: ");
                decimal hourlyRate = decimal.Parse(Console.ReadLine()!);

                Console.Write("Enter Employee Type (Full Time / Part Time): ");
                string employeeType = Console.ReadLine()!;


                // ---------------- SQL Query ----------------

                string query = @"
                    INSERT INTO Employees
                    (
                        FirstName,
                        LastName,
                        Email,
                        PhoneNumber,
                        HourlyRate,
                        EmployeeType
                    )
                    VALUES
                    (
                        @FirstName,
                        @LastName,
                        @Email,
                        @PhoneNumber,
                        @HourlyRate,
                        @EmployeeType
                    )";


                // ---------------- Database Work ----------------

                using (DbConnection db = new DbConnection())
                {
                    using (SqlConnection connection = await db.OpenAsync())
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@FirstName", firstName);
                            command.Parameters.AddWithValue("@LastName", lastName);
                            command.Parameters.AddWithValue("@Email", email);
                            command.Parameters.AddWithValue("@PhoneNumber", phone);
                            command.Parameters.AddWithValue("@HourlyRate", hourlyRate);
                            command.Parameters.AddWithValue("@EmployeeType", employeeType);

                            int rows = await command.ExecuteNonQueryAsync();

                            if (rows > 0)
                            {
                                Console.WriteLine("\n Employee Added Successfully!");
                            }
                            else
                            {
                                Console.WriteLine("\n Employee Not Added.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n  Error: {ex.Message}");
            }
        }
    }
}
