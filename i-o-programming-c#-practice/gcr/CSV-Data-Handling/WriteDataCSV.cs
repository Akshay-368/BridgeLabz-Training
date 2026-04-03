using System;
using System.IO;

public class csvWrite 
{
    // write employee data to CSV file
    public static void writeEmployeesToCSV(string filePath)
    {
        StreamWriter writer = null;

        try
        {
            writer = new StreamWriter(filePath);

            // header
            writer.WriteLine("ID,Name,Department,Salary");

            // 5 dummy employees
            writer.WriteLine("1001,Rahul Kumar,IT,65000");
            writer.WriteLine("1002,Priya Sharma,HR,52000");
            writer.WriteLine("1003,Aman Singh,Sales,48000");
            writer.WriteLine("1004,Sneha Verma,Finance,70000");
            writer.WriteLine("1005,Vikram Patel,IT,82000");

            Console.WriteLine("CSV file created successfully: " + filePath);
            Console.WriteLine("5 employee records written");
        }
        catch(Exception e)
        {
            Console.WriteLine("error writing CSV: " + e.Message);
        }
        finally
        {
            if(writer != null) writer.Close();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        2. Write Data to a CSV File
        * Create a CSV file with employee details (ID, Name, Department, Salary).
        * Write at least 5 records to the file.
        */

        Console.WriteLine("CSV Writer - Employee Records\n");

        Console.Write("Waiting , for user to enter filename to create ( default: employees.csv ) : ");
        string fileName = Console.ReadLine();

        if(string.IsNullOrEmpty(fileName))
        {
            fileName = "employees.csv";
        }

        writeEmployeesToCSV(fileName);

        Console.WriteLine("\nYou can now open " + fileName + " in Excel or Notepad");

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
