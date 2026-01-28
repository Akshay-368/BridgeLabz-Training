using System;
using System.IO;
using System.Collections.Generic;

public class csvMerge 
{
    // create two dummy CSV files
    public static void createDummyFiles()
    {
        // file 1: ID, Name, Age
        StreamWriter w1 = null;
        try
        {
            w1 = new StreamWriter("students1.csv");
            w1.WriteLine("ID,Name,Age");
            w1.WriteLine("101,Rahul,20");
            w1.WriteLine("102,Priya,19");
            w1.WriteLine("103,Aman,21");
        }
        catch { }
        finally { if(w1 != null) w1.Close(); }

        // file 2: ID, Marks, Grade
        StreamWriter w2 = null;
        try
        {
            w2 = new StreamWriter("students2.csv");
            w2.WriteLine("ID,Marks,Grade");
            w2.WriteLine("101,85,A");
            w2.WriteLine("102,92,A+");
            w2.WriteLine("103,78,B");
        }
        catch { }
        finally { if(w2 != null) w2.Close(); }

        Console.WriteLine("Dummy files created: students1.csv & students2.csv");
    }

    // merge by ID
    public static void mergeCSVByID(string path1,string path2,string outputPath)
    {
        if(!File.Exists(path1) || !File.Exists(path2))
        {
            Console.WriteLine("one or both files missing");
            return;
        }

        // store file1 data: ID → (Name, Age)
        Dictionary<string,string> file1Data = new Dictionary<string,string>();

        StreamReader r1 = null;
        try
        {
            r1 = new StreamReader(path1);
            r1.ReadLine(); // skip header

            string line;
            while((line = r1.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if(cols.Length >= 3)
                {
                    string id = cols[0];
                    string info = cols[1] + "," + cols[2];
                    file1Data[id] = info;
                }
            }
        }
        catch { }
        finally { if(r1 != null) r1.Close(); }

        // now read file2 and merge
        StreamReader r2 = null;
        StreamWriter w = null;

        try
        {
            r2 = new StreamReader(path2);
            w = new StreamWriter(outputPath);

            w.WriteLine("ID,Name,Age,Marks,Grade"); // new header

            r2.ReadLine(); // skip header

            string line;
            while((line = r2.ReadLine()) != null)
            {
                string[] cols = line.Split(',');
                if(cols.Length >= 3)
                {
                    string id = cols[0];
                    string marks = cols[1];
                    string grade = cols[2];

                    if(file1Data.ContainsKey(id))
                    {
                        string info = file1Data[id];
                        w.WriteLine(id + "," + info + "," + marks + "," + grade);
                    }
                }
            }

            Console.WriteLine("Merged file created: " + outputPath);
        }
        catch
        {
            Console.WriteLine("error merging files");
        }
        finally
        {
            if(r2 != null) r2.Close();
            if(w != null) w.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        10. Merge Two CSV Files
        * You have two CSV files:
          * students1.csv (contains ID, Name, Age)
          * students2.csv (contains ID, Marks, Grade)
        * Merge both files based on ID and create a new file containing all details.
        */

        Console.WriteLine("Merge Two CSV Files by ID\n");

        createDummyFiles();

        string output = "merged_students.csv";

        Console.WriteLine("\n Merging files...\n");

        mergeCSVByID("students1.csv", "students2.csv", output);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
