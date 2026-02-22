using System;
using System.Threading.Tasks;
using Microsoft.Data.SqlClient;
using Interfaces;
using Core;

namespace Utilities
{
    internal class MarkAttendance : IMarkAttendance
    {
        public async Task MarkAttendanceAsync()
        {
            try
            {
                // ---------------- Get Input ----------------

                Console.Write("Enter Employee ID: ");
                int employeeId = int.Parse(Console.ReadLine()!);

                Console.WriteLine("\n1. Clock In");
                Console.WriteLine("2. Clock Out");
                Console.Write("Choose Option: ");

                int option = int.Parse(Console.ReadLine()!);

                DateTime today = DateTime.Today;

                string query = "";

                // ---------------- Clock In ----------------
                if (option == 1)
                {
                    query = @"
                    IF EXISTS
                    (
                        SELECT 1 FROM Attendance
                        WHERE EmployeeId = @EmployeeId
                        AND WorkDate = @WorkDate
                    )
                    BEGIN
                        UPDATE Attendance
                        SET 
                            IsPresent = 1,
                            ClockedIn = SYSDATETIME(),
                            ClockedOut = NULL
                        WHERE EmployeeId = @EmployeeId
                        AND WorkDate = @WorkDate
                    END
                    ELSE
                    BEGIN
                        INSERT INTO Attendance
                        (
                            EmployeeId,
                            WorkDate,
                            IsPresent,
                            ClockedIn
                        )
                        VALUES
                        (
                            @EmployeeId,
                            @WorkDate,
                            1,
                            SYSDATETIME()
                        )
                    END";
                }

                // ---------------- Clock Out ----------------
                else if (option == 2)
                {
                    query = @"
                    UPDATE Attendance
                    SET 
                        ClockedOut = SYSDATETIME()
                    WHERE EmployeeId = @EmployeeId
                    AND WorkDate = @WorkDate
                    AND ClockedIn IS NOT NULL";
                }

                else
                {
                    Console.WriteLine("Invalid Option.");
                    return;
                }


                // ---------------- Database Work ----------------

                using (DbConnection db = new DbConnection())
                {
                    using (SqlConnection connection = await db.OpenAsync())
                    {
                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@EmployeeId", employeeId);
                            command.Parameters.AddWithValue("@WorkDate", today);

                            int rows = await command.ExecuteNonQueryAsync();

                            if (rows > 0)
                            {
                                Console.WriteLine("\n Attendance Updated Successfully ");
                            }
                            else
                            {
                                Console.WriteLine("\n No Record Updated ");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"\n Error: {ex.Message}");
            }
        }

    }
}
