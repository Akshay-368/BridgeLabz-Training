using System;
using System.IO;

public class csvSort 
{
    // create dummy employees.csv with salaries
    public static string createDummyForSort()
    {
        string fname = "employees_sort.csv";

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(fname);
            w.WriteLine("ID,Name,Department,Salary");

            w.WriteLine("1001,Rahul,IT,65000");
            w.WriteLine("1002,Priya,HR,52000");
            w.WriteLine("1003,Aman,Sales,48000");
            w.WriteLine("1004,Sneha,Finance,70000");
            w.WriteLine("1005,Vikram,IT,82000");
            w.WriteLine("1006,Neha,IT,68000");
            w.WriteLine("1007,Rohit,Sales,95000");
            w.WriteLine("1008,Anjali,Finance,55000");

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

    // read csv → sort by salary descending → print top 5
    public static void sortAndShowTop5(string path)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("file not found");
            return;
        }

        // simple array of records
        string[] lines = new string[100]; // assume max 100 rows
        int lineCount = 0;

        StreamReader r = null;

        try
        {
            r = new StreamReader(path);

            string line;
            bool isHeader = true;

            while((line = r.ReadLine()) != null)
            {
                if(isHeader)
                {
                    isHeader = false;
                    continue;
                }

                lines[lineCount] = line;
                lineCount++;
            }

            // bubble sort by salary (last column)
            for(int i=0; i<lineCount-1 ; i++)
            {
                for(int j=0; j<lineCount-i-1 ; j++)
                {
                    string[] row1 = lines[j].Split(',');
                    string[] row2 = lines[j+1].Split(',');

                    double sal1 = double.Parse(row1[3]);
                    double sal2 = double.Parse(row2[3]);

                    if(sal1 < sal2) // descending
                    {
                        string temp = lines[j];
                        lines[j] = lines[j+1];
                        lines[j+1] = temp;
                    }
                }
            }

            Console.WriteLine("\nTop 5 highest-paid employees:");
            Console.WriteLine("ID   Name          Dept     Salary");


            int limit = lineCount < 5 ? lineCount : 5;

            for(int i=0; i<limit ; i++)
            {
                string[] cols = lines[i].Split(',');
                Console.WriteLine(cols[0] + "  " + cols[1].PadRight(12) + "  " + cols[2].PadRight(8) + "  " + cols[3]);
            }
        }
        catch
        {
            Console.WriteLine("error reading or sorting file");
        }
        finally
        {
            if(r != null) r.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        7. Sort CSV Records by a Column
        * Read a CSV file and sort the records by Salary in descending order.
        * Print the top 5 highest-paid employees.
        */

        Console.WriteLine("Sort Employees by Salary (Top 5)\n");

        string dummy = createDummyForSort();

        Console.WriteLine("\nSorting and showing top 5 highest paid...\n");

        sortAndShowTop5(dummy);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
