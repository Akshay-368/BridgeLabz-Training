using System;
using System.IO;

public class largeCsv 
{
    // create a very large dummy CSV (simulated)
    public static string createLargeDummy()
    {
        string fname = "large_students.csv";

        StreamWriter w = null;

        try
        {
            w = new StreamWriter(fname);
            w.WriteLine("ID,Name,Age,Marks");

            // simulate 1000 rows
            for(int i=1; i<=1000 ; i++)
            {
                w.WriteLine(i + ",Student" + i + "," + (18 + i%10) + "," + (50 + i%50));
            }

            Console.WriteLine("Large dummy CSV created: " + fname + " (1000 rows)");
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

    // read in chunks of 100 lines
    public static void readLargeCSVInChunks(string path,int chunkSize)
    {
        if(!File.Exists(path))
        {
            Console.WriteLine("file not found");
            return;
        }

        StreamReader r = null;

        try
        {
            r = new StreamReader(path);

            string line;
            int totalProcessed = 0;
            int chunkCount = 0;

            while(!r.EndOfStream)
            {
                chunkCount++;
                Console.WriteLine("Processing chunk " + chunkCount + "...");

                for(int i=0; i<chunkSize && !r.EndOfStream ; i++)
                {
                    line = r.ReadLine();
                    totalProcessed++;

                    // here you can process line (e.g. parse, filter)
                    // we just count
                }

                Console.WriteLine("Processed so far: " + totalProcessed + " lines");
            }

            Console.WriteLine("\nTotal records processed: " + totalProcessed);
        }
        catch
        {
            Console.WriteLine("error reading large file");
        }
        finally
        {
            if(r != null) r.Close();
        }
    }

    public static void Main(string[] args)
    {
        /*
        11. Read Large CSV File Efficiently
        * Given a large CSV file (500MB+), implement a memory-efficient way to read it in chunks.
        * Process only 100 lines at a time and display the count of records processed.
        */

        Console.WriteLine("Read Large CSV in Chunks\n");

        string dummy = createLargeDummy();

        Console.WriteLine("\nReading large file in chunks of 100 lines...\n");

        readLargeCSVInChunks(dummy, 100);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
