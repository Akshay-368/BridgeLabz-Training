using System;
using System.IO;
using System.Collections.Generic;

public class csvDup 
{
    // create dummy CSV with duplicates
    public static string createDummyWithDup()
    {
        string fname = "students_dup.csv";

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(fname);
            w.WriteLine("ID,Name,Age,Marks");

            w.WriteLine("101,Rahul,20,85");
            w.WriteLine("102,Priya,19,92");
            w.WriteLine("101,Rahul,20,85"); // duplicate ID
            w.WriteLine("103,Aman,21,78");
            w.WriteLine("102,Priya,19,92"); // duplicate ID

            Console.WriteLine("Dummy CSV with duplicates created: " + fname);
        }
        catch
        {
            Console.WriteLine("could not create file");
        }
        finally
        {
            if(w != null) w.Close();
        }

        return fname;
    }

    // detect duplicates by ID
    public static void detectDuplicates(string path)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("file not found");
            return;
        }

        Dictionary<string,int> idCount = new Dictionary<string,int>();

        StreamReader r = null;

        try
        {
            r = new StreamReader(path);

            r.ReadLine(); // skip header

            string line;
            while((line = r.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if(cols.Length < 1) continue;

                string id = cols[0].Trim();

                if(idCount.ContainsKey(id))
                {
                    idCount[id]++;
                }
                else
                {
                    idCount[id] = 1;
                }
            }

            Console.WriteLine("\nDuplicate IDs found:");
            foreach(KeyValuePair<string,int> pair in idCount)
            {
                if(pair.Value > 1)
                {
                    Console.WriteLine("ID " + pair.Key + " appears " + pair.Value + " times");
                }
            }
        }
        catch
        {
            Console.WriteLine("error detecting duplicates");
        }
        finally
        {
            if(r != null) r.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        12. Detect Duplicates in a CSV File
        * Read a CSV file and detect duplicate entries based on the ID column.
        * Print all duplicate records.
        */

        Console.WriteLine("Detect Duplicates by ID in CSV\n");

        string dummy = createDummyWithDup();

        Console.WriteLine("\nDetecting duplicates...\n");

        detectDuplicates(dummy);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
