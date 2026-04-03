using System;
using System.IO;

public class csvFilter 
{
    // create dummy students.csv with some marks
    public static string createDummyStudents()
    {
        string fname = "students_filter.csv";

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(fname);
            w.WriteLine("ID,Name,Age,Marks"); // header

            w.WriteLine("101,Rahul,20,85");
            w.WriteLine("102,Priya,19,92");
            w.WriteLine("103,Aman,21,78");
            w.WriteLine("104,Sneha,18,88");
            w.WriteLine("105,Vikram,22,65");
            w.WriteLine("106,Anjali,20,79");
            w.WriteLine("107,Rohit,19,82");

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

    // read file and print only students with marks > 80
    public static void filterHighScorers(string path)
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

            Console.WriteLine("\nStudents with Marks > 80:");


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
                string age  = cols[2];
                string marksStr = cols[3];

                int marks = 0;
                if(int.TryParse(marksStr, out marks) && marks > 80)
                {
                    Console.WriteLine(id + " | " + name + " | Age: " + age + " | Marks: " + marks);
                }
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
        4. Filter Records from CSV
        * Read a CSV file and filter students who have scored more than 80 marks.
        * Print only the qualifying records.
        */

        Console.WriteLine ( " Filter Students with Marks > 80\n");

        string dummy = createDummyStudents();

        Console.WriteLine("\n Filtering high scorers...\n");

        filterHighScorers(dummy);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
