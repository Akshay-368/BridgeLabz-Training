using System;
using System.Collections.Generic;
using System.Threading;


//  Employee Payroll Data (POCO)

public class EmployeePayrollData
{
    public int EmployeeId { get; set; }          //  will be set after DB insert
    public string Name { get; set; }
    public decimal Salary { get; set; }
    public DateTime StartDate { get; set; }
}


//  Database Service - ALL DB operations will go here but empty for now

public class DatabaseService
{
    // UC1 / UC2–UC5 : Add employee to employee_payroll + payroll_details
    public void AddEmployeeToPayroll ( EmployeePayrollData employee)
    {
        // TODO: implement later with ADO.NET
        // 1. Insert into employee_payroll -> get generated ID
        // 2. Insert into payroll_details using that ID
        // 3. Set employee.EmployeeId = generated ID

        Console.WriteLine($"[DB STUB] Would add employee: {employee.Name}, Salary: {employee.Salary}");
        employee.EmployeeId = new Random().Next(1000, 9999); // just a fake ID for demo
    }

    // UC6: Update salary in both tables
    public void UpdateEmployeeSalary( int employeeId , decimal newSalary)
    {
        // TODO: implement later with ADO.NET
        // UPDATE employee_payroll SET Salary = @newSalary WHERE ID = @employeeId
        // UPDATE payroll_details SET Salary = @newSalary WHERE EmployeeId = @employeeId

        Console.WriteLine( $ " [DB STUB] Would update ID {employeeId} salary to {newSalary}");
    }


}


//  Employee Payroll Service - business logic + threading

public class EmployeePayrollService
{
    private readonly DatabaseService dbService = new DatabaseService();
    private static readonly object dbLock = new object();

    // UC1 : Add multiple employees without threads
    public void AddEmployees(List<EmployeePayrollData> employees )
    {
        Console.WriteLine("UC1 : Adding employees without threads...");

        var startTime = DateTime.Now;

        foreach (var emp in employees)
        {
            dbService.AddEmployeeToPayroll(emp);
        }

        var endTime = DateTime.Now;
        Console.WriteLine($"UC1 Time taken: {(endTime - startTime).TotalMilliseconds} ms" ) ;
    }

    // UC2–UC5: Add employees with threads + synchronization
    public void AddEmployeesWithThreads(List<EmployeePayrollData> employees )
    {
        Console.WriteLine("UC2–UC5: Adding employees with threads..." ) ;

        var startTime = DateTime.Now ;

        List<Thread> threads = new List<Thread>();

        foreach (var emp in employees)
        {
            Thread thread = new Thread(() => AddEmployeeThread(emp));
            threads.Add(thread);
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        var endTime = DateTime.Now;
        Console.WriteLine($" UC2–UC5 Time with threads : {(endTime - startTime).TotalMilliseconds} ms");
    }

    private void AddEmployeeThread ( EmployeePayrollData emp)
    {
        lock (dbLock)
        {
            dbService.AddEmployeeToPayroll(emp);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId} : Added {emp.Name} (ID: {emp.EmployeeId})");
        }
    }

    // UC6 : Update multiple salaries with threads
    public void UpdateMultipleSalaries ( Dictionary<int, decimal> updates )
    {
        Console.WriteLine("UC6 : Updating multiple salaries with threads...");

        var startTime = DateTime.Now;

        List<Thread> threads = new List<Thread>();

        foreach (var update in updates)
        {
            Thread thread = new Thread(() => UpdateSalaryThread(update.Key, update.Value));
            threads.Add(thread);
            thread.Start();
        }

        foreach (Thread thread in threads)
        {
            thread.Join();
        }

        var endTime = DateTime.Now;
        Console.WriteLine($"UC6 Time with threads: {(endTime - startTime).TotalMilliseconds} ms");
    }

    private void UpdateSalaryThread(int employeeId, decimal newSalary)
    {
        lock (dbLock)
        {
            dbService.UpdateEmployeeSalary(employeeId, newSalary);
            Console.WriteLine($"Thread {Thread.CurrentThread.ManagedThreadId}: Updated salary for ID {employeeId} to {newSalary}");
        }
    }
}


//  Simple console demo ( no MSTest here — add separately if needed)

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Employee Payroll Service - Multi-threaded Demo\n");

        EmployeePayrollService service = new EmployeePayrollService();

        // Sample data for UC1 & UC2–UC5
        var employees = new List<EmployeePayrollData>
        {
            new EmployeePayrollData { Name = "Rahul", Salary = 60000m, StartDate = DateTime.Now },
            new EmployeePayrollData { Name = "Priya", Salary = 52000m, StartDate = DateTime.Now },
            new EmployeePayrollData { Name = "Aman", Salary = 48000m, StartDate = DateTime.Now }
        };

        Console.WriteLine(" UC1: Without threads ");
        service.AddEmployees(employees);

        Console.WriteLine("\n UC2–UC5: With threads ");
        service.AddEmployeesWithThreads(employees);

        // Sample data for UC6 (assume IDs already exist)
        var salaryUpdates = new Dictionary<int, decimal>
        {
            { 1, 72000m },
            { 2, 68000m },
            { 3, 75000m }
        };

        Console.WriteLine("\n UC6 : Update salaries with threads ");
        service.UpdateMultipleSalaries(salaryUpdates);

        Console.WriteLine("\n Demo finished. Press any key...");
        Console.ReadKey();
    }
}
