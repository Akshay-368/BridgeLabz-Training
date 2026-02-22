using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Interfaces;
using Core;

namespace Utilities ;

    internal class CalculateDailyWage : ICalculateDailyWage
    {
        public async Task CalculateDailyWageAsync()
        {
            try
            {
                // ---------------- Get Input ----------------

                Console.Write("Enter Employee ID: ");
                int employeeId = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Date (yyyy-mm-dd): ");
                DateTime workDate = DateTime.Parse(Console.ReadLine()!);


                // ---------------- SQL Query ----------------

                string query = @"
                SELECT 
                    e.FirstName,
                    e.LastName,
                    e.HourlyRate,
                    e.EmployeeType,
                    a.IsPresent,
                    a.ClockedIn,
                    a.ClockedOut
                FROM Employees e
                INNER JOIN Attendance a
                    ON e.EmployeeId = a.EmployeeId
                WHERE 
                    e.EmployeeId = @EmployeeId
                    AND a.WorkDate = @WorkDate
                    AND e.IsDeleted = 0";



                // ---------------- Database Work ----------------

                using (DbConnection db = new DbConnection())
                {
                    using (SqlConnection connection = await db.OpenAsync())
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeId", employeeId);
                            command.Parameters.AddWithValue("@WorkDate", workDate);

                            using (SqlDataReader reader =
                                   await command.ExecuteReaderAsync())
                            {
                                if (!reader.HasRows)
                                {
                                    Console.WriteLine("\n No attendance record found.");
                                    return;
                                }

                                await reader.ReadAsync();

                                string firstName = reader["FirstName"].ToString()!;
                                string lastName = reader["LastName"].ToString()!;
                                decimal hourlyRate =
                                    Convert.ToDecimal(reader["HourlyRate"]);

                                string employeeType =
                                    reader["EmployeeType"].ToString()!;

                                bool isPresent =
                                    Convert.ToBoolean(reader["IsPresent"]);


                                // ---------------- Calculation ----------------

                                    DateTime? clockIn =reader["ClockedIn"] == DBNull.Value
                                                ? null
                                                : (DateTime?)reader["ClockedIn"];

                                    DateTime? clockOut =
                                        reader["ClockedOut"] == DBNull.Value
                                            ? null
                                            : (DateTime?)reader["ClockedOut"];


                                    if (!isPresent || clockIn == null)
                                    {
                                        Console.WriteLine("\n Employee was Absent.");
                                        Console.WriteLine("Daily Wage: ₹0.00");
                                        return;
                                    }

                                    if (clockOut == null)
                                    {
                                        Console.WriteLine("\n Employee has not Clocked Out yet.");
                                        return;
                                    }


                                    // ---------------- Real Hours ----------------

                                    TimeSpan duration = clockOut.Value - clockIn.Value;

                                    decimal hoursWorked =
                                        (decimal)duration.TotalHours;

                                    if (hoursWorked < 0)
                                    {
                                        Console.WriteLine("\n Invalid Time Data.");
                                        return;
                                    }

                                    decimal dailyWage =
                                        hoursWorked * hourlyRate;



                                // ---------------- Output ----------------

                                Console.WriteLine("\n==============================");
                                Console.WriteLine(" Daily Wage Report ");
                                Console.WriteLine("==============================");

                                Console.WriteLine($"Employee : {firstName} {lastName}");
                                Console.WriteLine($"Type     : {employeeType}");
                                Console.WriteLine($"Hours    : {hoursWorked}");
                                Console.WriteLine($"Rate     : ₹{hourlyRate}");
                                Console.WriteLine($"Wage     : ₹{dailyWage}");

                                Console.WriteLine("==============================");
                            }
                        }
                    }
                }
            }
            catch (SqlException ex)
            {
                Console.WriteLine($"\n Database Error: {ex.Message}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error: {ex.Message}");
            }
        }
    }

