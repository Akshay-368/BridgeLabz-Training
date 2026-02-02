using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class jsonFromDb
{
    // Simple class to represent one employee
    public class Employee
    {
        public int EmployeeId { get; set; }
        public string Name { get; set; }
        public string Department { get; set; }
        public double Salary { get; set; }
    }

    public static void Main(string[] args)
    {
        Console.WriteLine("Generate JSON Report from Database (simulated)\n");

        // Step 1: Simulate database records (dummy data)
        List<Employee> employees = new List<Employee>
        {
            new Employee { EmployeeId = 1001, Name = "Rahul Kumar",   Department = "IT",       Salary = 65000 },
            new Employee { EmployeeId = 1002, Name = "Priya Sharma",  Department = "HR",       Salary = 52000 },
            new Employee { EmployeeId = 1003, Name = "Aman Singh",    Department = "Sales",    Salary = 48000 },
            new Employee { EmployeeId = 1004, Name = "Sneha Verma",   Department = "Finance",  Salary = 70000 },
            new Employee { EmployeeId = 1005, Name = "Vikram Patel",  Department = "IT",       Salary = 82000 }
        };

        Console.WriteLine("Simulated database records :");
        Console.WriteLine("ID    Name              Dept      Salary");

        foreach (var emp in employees)
        {
            Console.WriteLine($"{emp.EmployeeId}  {emp.Name,-16}  {emp.Department,-8}  {emp.Salary}");
        }

        // Step 2: Convert list to JSON
        string jsonReport = JsonConvert.SerializeObject(employees, Formatting.Indented);

        Console.WriteLine("\n Generated JSON Report:");
        Console.WriteLine(jsonReport);

        // Step 3: Save to file (optional but useful)
        string outputFile = "employee_report.json";
        System.IO.File.WriteAllText(outputFile, jsonReport);
        Console.WriteLine($"\nReport saved to file: {outputFile}");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
