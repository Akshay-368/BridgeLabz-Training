using System;
using System.IO;

public class csvCount 
{
    // create dummy CSV file (same as program 1)
    public static string createDummyCSV()
    {
        string fileName = "students_count.csv";

        StreamWriter writer = null;

        try
        {
            writer = new StreamWriter(fileName);

            writer.WriteLine("ID,Name,Age,Marks"); // header

            // 8 dummy rows
            writer.WriteLine("101,Rahul,20,85");
            writer.WriteLine("102,Priya,19,92");
            writer.WriteLine("103,Aman,21,78");
            writer.WriteLine("104,Sneha,18,88");
            writer.WriteLine("105,Vikram,22,65");
            writer.WriteLine("106,Anjali,20,90");
            writer.WriteLine("107,Rohit,19,72");
            writer.WriteLine("108,Neha,21,95");

            Console.WriteLine("Dummy CSV created: " + fileName);
        }
        catch(Exception e)
        {
            Console.WriteLine("error creating file: " + e.Message);
        }
        finally
        {
            if(writer != null) writer.Close();
        }

        return fileName;
    }

    // count rows excluding header
    public static void countRowsInCSV(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Console.WriteLine("file not found: " + filePath);
            return;
        }

        StreamReader reader = null;
        int rowCount = 0;

        try
        {
            reader = new StreamReader(filePath);

            // skip header
            reader.ReadLine();

            string line;
            while((line = reader.ReadLine()) != null)
            {
                rowCount++;
            }

            Console.WriteLine("Total student records (excluding header): " + rowCount);
        }
        catch(Exception e)
        {
            Console.WriteLine("error counting rows: " + e.Message);
        }
        finally
        {
            if(reader != null) reader.Close();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        3. Read and Count Rows in a CSV File
        * Read a CSV file and count the number of records (excluding the header row).
        */

        Console.WriteLine("CSV Row Counter (excluding header)\n");

        string dummyFile = createDummyCSV();

        Console.WriteLine("\nCounting rows in dummy file...\n");

        countRowsInCSV(dummyFile);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
