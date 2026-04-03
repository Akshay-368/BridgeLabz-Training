using System;
using System.IO;

public class csvSearch 
{
    // create dummy employees.csv
    public static string createDummyEmployees()
    {
        string fname = "employees_search.csv";

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(fname);
            w.WriteLine("ID,Name,Department,Salary");

            w.WriteLine("1001,Rahul Kumar,IT,65000");
            w.WriteLine("1002,Priya Sharma,HR,52000");
            w.WriteLine("1003,Aman Singh,Sales,48000");
            w.WriteLine("1004,Sneha Verma,Finance,70000");
            w.WriteLine("1005,Vikram Patel,IT,82000");

            Console.WriteLine("Dummy file created: " + fname);
        }
        catch
        {
            Console.WriteLine("could not create dummy file");
        }
        finally
        {
            if(w != null) w.Close();
        }

        return fname;
    }

    // search employee by name (case insensitive)
    public static void searchEmployeeByName(string path,string searchName)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("file not found: " + path);
            return;
        }

        StreamReader r = null;

        try
        {
            r = new StreamReader(path);

            string line;
            bool isHeader = true;
            bool found = false;

            while((line = r.ReadLine()) != null)
            {
                if(isHeader)
                {
                    isHeader = false;
                    continue;
                }

                string[] cols = line.Split(',');

                if(cols.Length < 4) continue;

                string id   = cols[0];
                string name = cols[1];
                string dept = cols[2];
                string sal  = cols[3];

                if(name.ToLower().Contains(searchName.ToLower()))
                {
                    found = true;
                    Console.WriteLine("Found employee:");
                    Console.WriteLine("ID: " + id);
                    Console.WriteLine("Name: " + name);
                    Console.WriteLine("Department: " + dept);
                    Console.WriteLine("Salary: " + sal);

                }
            }

            if(!found)
            {
                Console.WriteLine("No employee found with name containing: " + searchName);
            }
        }
        catch
        {
            Console.WriteLine("error while reading file");
        }
        finally
        {
            if(r != null) r.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        5. Search for a Record in CSV
        * Read an employees.csv file and search for an employee by name.
        * Print their department and salary.
        */

        Console.WriteLine("Search Employee by Name in CSV\n ");

        string dummy = createDummyEmployees();

        Console.Write("Waiting , for user to enter name (or part of name) to search : " );
        string search = Console.ReadLine();

        if(string.IsNullOrEmpty(search))
        {
            Console.WriteLine("no name entered -> showing all employees");
            search = "";
        }

        searchEmployeeByName(dummy, search);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
