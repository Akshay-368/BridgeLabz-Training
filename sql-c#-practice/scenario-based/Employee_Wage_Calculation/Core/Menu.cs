namespace Core;

using System;
using System.Threading.Tasks;
using Interfaces;
using Utilities;

internal class Menu : IMenu
{
    public async Task StartAsync()
    {
        int choice = -1;

        while (true)
        {
            try
            {
                ShowMenu();

                Console.Write("Enter choice: ");
                choice = int.Parse(Console.ReadLine()!);


                switch (choice)
                {
                    case 1:
                        await new AddNewEmployee().AddNewEmployeeAsync();
                        break;
                        

                    case 2:
                        await new MarkAttendance().MarkAttendanceAsync();
                        break;

                    case 3:
                        await new CalculateDailyWage().CalculateDailyWageAsync();
                        break;

                    case 4:
                        await new CalculateMonthlyWage().CalculateMonthlyWageAsync();
                        break;

                    case 5:
                        await new CalculateWithLimit().CalculateWithLimitAsync();
                        break;

                    case 0:
                        Console.WriteLine("Exiting... Bye!");
                        return;

                    default:
                        Console.WriteLine("Invalid choice ");
                        break;
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error: {ex.Message} ");
            }

            Console.WriteLine("\nPress Enter to continue...");
            Console.ReadLine();
        }
    }

    // ---------------- Menu UI ----------------

    private void ShowMenu()
    {


        Console.WriteLine("====================================");
        Console.WriteLine(" Employee Wage Computation System ");
        Console.WriteLine("====================================");

        Console.WriteLine("1. Add New Employee");
        Console.WriteLine("2. Mark Attendance");
        Console.WriteLine("3. Calculate Daily Wage");
        Console.WriteLine("4. Calculate Monthly Wage");
        Console.WriteLine("5. Calculate With Limits");
        Console.WriteLine("0. Exit");

        Console.WriteLine("------------------------------------");
    }


}
