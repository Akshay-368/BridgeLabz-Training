using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Interfaces;
using Core;

namespace Utilities;

    internal class CalculateMonthlyWage : ICalculateMonthlyWage
    {
        public async Task CalculateMonthlyWageAsync()
        {
            try
            {
                // ---------------- Input ----------------

                Console.Write("Enter Employee ID: ");
                int employeeId = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Month (1-12): ");
                int month = int.Parse(Console.ReadLine()!);

                Console.Write("Enter Year: ");
                int year = int.Parse(Console.ReadLine()!);


                // ---------------- Query ----------------

                string query = @"
                SELECT 
                    e.FirstName,
                    e.LastName,
                    e.HourlyRate,
                    e.EmployeeType,
                    COUNT(a.AttendanceId) AS DaysWorked
                FROM Employees e
                INNER JOIN Attendance a
                    ON e.EmployeeId = a.EmployeeId
                WHERE
                    e.EmployeeId = @EmployeeId
                    AND a.IsPresent = 1
                    AND MONTH(a.WorkDate) = @Month
                    AND YEAR(a.WorkDate) = @Year
                    AND e.IsDeleted = 0
                GROUP BY
                    e.FirstName,
                    e.LastName,
                    e.HourlyRate,
                    e.EmployeeType";


                using (DbConnection db = new DbConnection())
                {
                    using (SqlConnection connection = await db.OpenAsync())
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeId", employeeId);
                            command.Parameters.AddWithValue("@Month", month);
                            command.Parameters.AddWithValue("@Year", year);

                            using (SqlDataReader reader =
                                   await command.ExecuteReaderAsync())
                            {
                                if (!reader.HasRows)
                                {
                                    Console.WriteLine("\n No attendance data found.");
                                    return;
                                }

                                await reader.ReadAsync();

                                string firstName = reader["FirstName"].ToString()!;
                                string lastName = reader["LastName"].ToString()!;

                                decimal hourlyRate =
                                    Convert.ToDecimal(reader["HourlyRate"]);

                                string employeeType =
                                    reader["EmployeeType"].ToString()!;

                                int daysWorked =
                                    Convert.ToInt32(reader["DaysWorked"]);


                                // ---------------- Calculation ----------------

                                int hoursPerDay =
                                    employeeType == "Full Time" ? 8 : 4;

                                decimal totalHours =
                                    daysWorked * hoursPerDay;

                                decimal normalHours = 160;
                                decimal overtimeHours = 0;

                                if (totalHours > normalHours)
                                {
                                    overtimeHours = totalHours - normalHours;
                                    totalHours = normalHours;
                                }

                                decimal normalPay =
                                    totalHours * hourlyRate;

                                decimal overtimePay =
                                    overtimeHours * hourlyRate * 1.5m;

                                decimal monthlyWage =
                                    normalPay + overtimePay;


                                // ---------------- Save to DB ----------------

                                await reader.CloseAsync();

                                string insertQuery = @"
                                INSERT INTO Wages
                                (
                                    EmployeeId,
                                    WageMonth,
                                    WageYear,
                                    TotalDaysWorked,
                                    TotalHoursWorked,
                                    TotalOvertimeHours,
                                    MonthlyWage
                                )
                                VALUES
                                (
                                    @EmployeeId,
                                    @Month,
                                    @Year,
                                    @Days,
                                    @Hours,
                                    @Overtime,
                                    @Wage
                                )";

                                using (SqlCommand insertCmd =
                                       new SqlCommand(insertQuery, connection))
                                {
                                    insertCmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                                    insertCmd.Parameters.AddWithValue("@Month", month);
                                    insertCmd.Parameters.AddWithValue("@Year", year);
                                    insertCmd.Parameters.AddWithValue("@Days", daysWorked);
                                    insertCmd.Parameters.AddWithValue("@Hours", totalHours);
                                    insertCmd.Parameters.AddWithValue("@Overtime", overtimeHours);
                                    insertCmd.Parameters.AddWithValue("@Wage", monthlyWage);

                                    await insertCmd.ExecuteNonQueryAsync();
                                }


                                // ---------------- Output ----------------

                                Console.WriteLine("\n===============================");
                                Console.WriteLine(" Monthly Wage Report ");
                                Console.WriteLine("===============================");

                                Console.WriteLine($"Employee : {firstName} {lastName}");
                                Console.WriteLine($"Month    : {month}/{year}");
                                Console.WriteLine($"Days     : {daysWorked}");
                                Console.WriteLine($"Hours    : {totalHours}");
                                Console.WriteLine($"Overtime : {overtimeHours}");
                                Console.WriteLine($"Rate     : ₹{hourlyRate}");
                                Console.WriteLine($"Salary   : ₹{monthlyWage}");

                                Console.WriteLine("===============================");
                                Console.WriteLine(" Saved to Wages Table");
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

