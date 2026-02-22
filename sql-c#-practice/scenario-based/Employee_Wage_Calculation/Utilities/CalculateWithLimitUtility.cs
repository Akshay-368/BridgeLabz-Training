using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Interfaces;
using Core;

namespace Utilities
{
    internal class CalculateWithLimit : ICalculateWithLimit
    {
        public async Task CalculateWithLimitAsync()
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


                // ---------------- Queries ----------------

                string empQuery = @"
                SELECT 
                    FirstName,
                    LastName,
                    HourlyRate,
                    EmployeeType
                FROM Employees
                WHERE EmployeeId = @EmployeeId
                      AND IsDeleted = 0";


                string attendanceQuery = @"
                SELECT WorkDate
                FROM Attendance
                WHERE EmployeeId = @EmployeeId
                      AND IsPresent = 1
                      AND MONTH(WorkDate) = @Month
                      AND YEAR(WorkDate) = @Year
                ORDER BY WorkDate ASC";


                using (DbConnection db = new DbConnection())
                {
                    using (SqlConnection connection = await db.OpenAsync())
                    {
                        // ---------------- Get Employee ----------------

                        string firstName = "";
                        string lastName = "";
                        decimal hourlyRate = 0;
                        string employeeType = "";

                        using (SqlCommand empCmd =
                               new SqlCommand(empQuery, connection))
                        {
                            empCmd.Parameters.AddWithValue("@EmployeeId", employeeId);

                            using (SqlDataReader empReader =
                                   await empCmd.ExecuteReaderAsync())
                            {
                                if (!empReader.HasRows)
                                {
                                    Console.WriteLine("\n Employee not found.");
                                    return;
                                }

                                await empReader.ReadAsync();

                                firstName = empReader["FirstName"].ToString()!;
                                lastName = empReader["LastName"].ToString()!;
                                hourlyRate =
                                    Convert.ToDecimal(empReader["HourlyRate"]);
                                employeeType =
                                    empReader["EmployeeType"].ToString()!;
                            }
                        }


                        // ---------------- Get Attendance ----------------

                        int hoursPerDay =
                            employeeType == "Full Time" ? 8 : 4;

                        int totalDays = 0;
                        decimal totalHours = 0;


                        using (SqlCommand attCmd =
                               new SqlCommand(attendanceQuery, connection))
                        {
                            attCmd.Parameters.AddWithValue("@EmployeeId", employeeId);
                            attCmd.Parameters.AddWithValue("@Month", month);
                            attCmd.Parameters.AddWithValue("@Year", year);

                            using (SqlDataReader attReader =
                                   await attCmd.ExecuteReaderAsync())
                            {
                                if (!attReader.HasRows)
                                {
                                    Console.WriteLine("\n No attendance data.");
                                    return;
                                }

                                while (await attReader.ReadAsync())
                                {
                                    if (totalDays >= 20 ||
                                        totalHours >= 100)
                                    {
                                        break;
                                    }

                                    totalDays++;
                                    totalHours += hoursPerDay;
                                }
                            }
                        }


                        // ---------------- Calculation ----------------

                        decimal salary =
                            totalHours * hourlyRate;


                        // ---------------- Save ----------------

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
                            @EmpId,
                            @Month,
                            @Year,
                            @Days,
                            @Hours,
                            0,
                            @Salary
                        )";


                        using (SqlCommand insertCmd =
                               new SqlCommand(insertQuery, connection))
                        {
                            insertCmd.Parameters.AddWithValue("@EmpId", employeeId);
                            insertCmd.Parameters.AddWithValue("@Month", month);
                            insertCmd.Parameters.AddWithValue("@Year", year);
                            insertCmd.Parameters.AddWithValue("@Days", totalDays);
                            insertCmd.Parameters.AddWithValue("@Hours", totalHours);
                            insertCmd.Parameters.AddWithValue("@Salary", salary);

                            await insertCmd.ExecuteNonQueryAsync();
                        }


                        // ---------------- Output ----------------

                        Console.WriteLine("\n================================");
                        Console.WriteLine(" Wage With Limit Report ");
                        Console.WriteLine("================================");

                        Console.WriteLine($"Employee : {firstName} {lastName}");
                        Console.WriteLine($"Month    : {month}/{year}");
                        Console.WriteLine($"Days     : {totalDays}");
                        Console.WriteLine($"Hours    : {totalHours}");
                        Console.WriteLine($"Rate     : ₹{hourlyRate}");
                        Console.WriteLine($"Salary   : ₹{salary}");

                        Console.WriteLine("================================");
                        Console.WriteLine(" Limit Applied (100 hrs / 20 days)");
                        Console.WriteLine(" Saved to Wages Table");
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
}
