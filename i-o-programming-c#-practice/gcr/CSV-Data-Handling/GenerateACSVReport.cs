using System;
using System.IO;

public class csvReport 
{
    // simulate "database" with dummy employee data
    public static void generateCSVFromDatabase(string filePath)
    {
        // pretend these come from a real database query
        string[] employees = new string[]
        {
            "101,Rahul Kumar,IT,65000",
            "102,Priya Sharma,HR,52000",
            "103,Aman Singh,Sales,48000",
            "104,Sneha Verma,Finance,70000",
            "105,Vikram Patel,IT,82000"
        };

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(filePath);

            // write header
            w.WriteLine("Employee ID,Name,Department,Salary");

            // write each employee row
            for(int i=0; i<employees.Length ; i++)
            {
                w.WriteLine(employees[i]);
            }

            Console.WriteLine("CSV report generated successfully: " + filePath);
            Console.WriteLine("Total employees written: " + employees.Length);
        }
        catch(Exception e)
        {
            Console.WriteLine("error generating CSV: " + e.Message);
        }
        finally
        {
            if(w != null) w.Close();
            Console.WriteLine("file writer closed");
        }
    }

    public static void Main(string[] args)
    {
        /*
        13. Generate a CSV Report from Database
        * Fetch employee records from a database and write them into a CSV file.
        * Include headers: Employee ID, Name, Department, Salary.
        */

        Console.WriteLine("Generate CSV Report from Database (simulated)\n");

        Console.Write("Waiting , for user to enter output file path (default: employees_report.csv) : ");
        string path = Console.ReadLine();

        if(string.IsNullOrEmpty(path))
        {
            path = "employees_report.csv";
        }

        generateCSVFromDatabase(path);

        Console.WriteLine("\nYou can now open " + path + " in Excel/Notepad");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
