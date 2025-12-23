using System;
using System.Diagnostics;

public static class EmployeeBonus
{
    public static void Main()
    {
        /*
        Write a program to find the bonus of 10 employees based on their years of service
        and the total bonus amount the company Zara has to pay, along with the old and new salary.
        Hint =>
        Zara decides to give a bonus of 5% to employees whose year of service is more than 5 years
        or 2% if less than 5 years.
        Define a double array to save salary and years of service for each of the 10 employees.
        Also define a double array to save the new salary and the bonus amount as well as variables
        to save the total bonus, total old salary, and new salary.
        Define a loop to take input from the user. If salary or year of service is an invalid number
        then ask the user to enter again. Note in this case you will have to decrement the index counter.
        Define another loop to calculate the bonus of 10 employees based on their years of service.
        Save the bonus in the array, compute the new salary, and save in the array. Also, the total bonus
        and total old and new salary can be calculated in the loop.
        Print the total bonus payout as well as the total old and new salary of all the employees.
        */

        const int employeeCount = 10;
        // Since it is a fixed number and should not be changed through out the code , so letting the compiler know.
        // Declaraing and initialzing the arrays here :as we know DataType[] var_name = new (keyword) DataType[size];
        double[] salaries = new double[employeeCount];
        double[] yearsOfService = new double[employeeCount];
        double[] bonuses = new double[employeeCount];
        double[] newSalaries = new double[employeeCount];

        double totalBonus = 0;
        double totalOldSalary = 0;
        double totalNewSalary = 0;

        // Taking input first
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"Enter salary for employee {i + 1}: ");
            double salary;
            if (!double.TryParse(Console.ReadLine(), out salary) || salary <= 0)
            {
                Console.WriteLine("Invalid salary. Please enter again.");
                i--; // decrement index to retry
                continue;
            }

            Console.WriteLine($"Enter years of service for employee {i + 1}: ");
            double years;
            if (!double.TryParse(Console.ReadLine(), out years) || years < 0)
            {
                Console.WriteLine("Invalid years of service. Please enter again.");
                i--; // decrement index to retry
                continue;
            }

            salaries[i] = salary;
            yearsOfService[i] = years;
        }


        Stopwatch sw = Stopwatch.StartNew();
        for (int i = 0; i < employeeCount; i++)
        {
            double bonusRate = yearsOfService[i] > 5 ? 0.05 : 0.02;
            bonuses[i] = salaries[i] * bonusRate;
            newSalaries[i] = salaries[i] + bonuses[i];

            totalBonus += bonuses[i];
            totalOldSalary += salaries[i];
            totalNewSalary += newSalaries[i];
        }
        sw.Stop();

        // Output results
        Console.WriteLine(" So the Employee Bonus Report is : ");
        for (int i = 0; i < employeeCount; i++)
        {
            Console.WriteLine($"Employee {i + 1}: Old Salary = {salaries[i]}, Bonus = {bonuses[i]}, New Salary = {newSalaries[i]}");
        }


        Console.WriteLine($"Total Old Salary: {totalOldSalary}");
        Console.WriteLine($"Total Bonus Payout: {totalBonus}");
        Console.WriteLine($"Total New Salary: {totalNewSalary}");

        Console.WriteLine($"Time taken for computation: {sw.Elapsed.TotalMilliseconds} ms, CPU ticks: {sw.ElapsedTicks}");
    }
}
