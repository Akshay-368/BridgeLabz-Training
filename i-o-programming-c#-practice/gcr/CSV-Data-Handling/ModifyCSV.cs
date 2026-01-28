using System;
using System.IO;
using System.Collections.Generic;

public class csvUpdate 
{
    // create dummy employees.csv
    public static string createDummyForUpdate()
    {
        string fname = "employees_update.csv";

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
            w.WriteLine("1006,Neha Gupta,IT,68000");

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

    // read csv → increase salary of IT by 10% → write to new file
    public static void updateITSalary(string srcPath,string destPath)
    {
        if(!File.Exists(srcPath))
        {
            Console.WriteLine("source file not found");
            return;
        }

        List<string> lines = new List<string>();

        StreamReader r = null;
        StreamWriter w = null;

        try
        {
            r = new StreamReader(srcPath);

            string line;
            bool isHeader = true;

            while((line = r.ReadLine()) != null)
            {
                if(isHeader)
                {
                    lines.Add(line); // keep header
                    isHeader = false;
                    continue;
                }

                string[] cols = line.Split(',');

                if(cols.Length < 4)
                {
                    lines.Add(line);
                    continue;
                }

                string id   = cols[0];
                string name = cols[1];
                string dept = cols[2];
                string salStr = cols[3];

                double sal = 0;
                if(double.TryParse(salStr, out sal) && dept.ToLower() == "it")
                {
                    sal = sal * 1.10; // 10% increase
                    salStr = sal.ToString("F2"); // 2 decimal places
                }

                string newLine = id + "," + name + "," + dept + "," + salStr;
                lines.Add(newLine);
            }

            // write updated lines to new file
            w = new StreamWriter(destPath);

            foreach(string ln in lines)
            {
                w.WriteLine(ln);
            }

            Console.WriteLine("IT salaries increased by 10%");
            Console.WriteLine("Updated file saved as: " + destPath);
        }
        catch
        {
            Console.WriteLine("error updating file");
        }
        finally
        {
            if(r != null) r.Close();
            if(w != null) w.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        6. Modify a CSV File (Update a Value)
        * Read a CSV file and increase the salary of employees from the "IT" department by 10%.
        * Save the updated records back to a new CSV file.
        */

        Console.WriteLine("Update IT Department Salary by 10%\n");

        string src = createDummyForUpdate();

        string dest = "employees_updated.csv";

        Console.WriteLine(" Updating IT salaries...\n");

        updateITSalary(src, dest);

        Console.WriteLine("\n  Press any key to exit...");
        Console.ReadKey();
    }
}
