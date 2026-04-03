using System;
using System.IO;

public class csvRead 
{
    // this function creates a dummy CSV file with student data
    public static string createDummyStudentFile()
    {
        string fileName = "students.csv";

        StreamWriter writer = null;

        try
        {
            writer = new StreamWriter(fileName);

            // header row
            writer.WriteLine("ID,Name,Age,Marks");

            // 5 dummy students
            writer.WriteLine("101,Rahul,20,85");
            writer.WriteLine("102,Priya,19,92");
            writer.WriteLine("103,Aman,21,78");
            writer.WriteLine("104,Sneha,18,88");
            writer.WriteLine("105,Vikram,22,65");

            Console.WriteLine("Dummy file created: " + fileName);
        }
        catch(Exception e)
        {
            Console.WriteLine("error creating dummy file: " + e.Message);
        }
        finally
        {
            if(writer != null) writer.Close();
        }

        return fileName;
    }

    // read and print CSV file line by line
    public static void readAndPrintCSV(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Console.WriteLine("file not found: " + filePath);
            return;
        }

        StreamReader reader = null;

        try
        {
            reader = new StreamReader(filePath);

            string line;
            int rowNum = 0;

            Console.WriteLine("\nReading CSV file: " + filePath);


            while((line = reader.ReadLine()) != null)
            {
                rowNum++;

                // split by comma
                string[] columns = line.Split(',');

                Console.Write("Row " + rowNum + ": ");

                for(int i=0; i<columns.Length ; i++)
                {
                    Console.Write(columns[i].Trim() + "  ");
                }

                Console.WriteLine();
            }

            Console.WriteLine("Total rows read: " + rowNum);
        }
        catch(Exception e)
        {
            Console.WriteLine("error reading file: " + e.Message);
        }
        finally
        {
            if(reader != null) reader.Close();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        1. Read a CSV File and Print Data
        * Read a CSV file containing student details (ID, Name, Age, Marks).
        * Print each record in a structured format.
        */

        Console.WriteLine("CSV Reader - Student Details\n");

        // create dummy file first
        string dummyFile = createDummyStudentFile();

        Console.WriteLine("\n Now reading the dummy file...\n");

        readAndPrintCSV(dummyFile);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
