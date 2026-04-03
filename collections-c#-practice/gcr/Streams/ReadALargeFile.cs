using System;
using System.IO;

public class largeRead 
{
    // read large file line by line , print only lines with "error"
    public static void readLargeFile(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Console.WriteLine("file not found : " + filePath);
            return;
        }

        StreamReader reader = null;

        try
        {
            reader = new StreamReader(filePath);

            string line = "";
            int lineNum = 1;

            while((line = reader.ReadLine()) != null)
            {
                if(line.ToLower().Contains("error"))
                {
                    Console.WriteLine("Line " + lineNum + ": " + line);
                }

                lineNum++;
            }

            Console.WriteLine("finished scanning file");
        }
        catch(Exception e)
        {
            Console.WriteLine("error reading large file : " + e.Message);
        }
        finally
        {
            if(reader != null) reader.Close();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        6. Read a Large File Line by Line
        📌 Problem Statement: Develop a C# program that efficiently reads a large text file (500MB+) line by line and prints only lines containing the word "error". 
        Requirements: Use StreamReader for efficient reading. 
        Read line-by-line instead of loading the entire file. 
        Display only lines containing "error" (case insensitive).
        */

        Console.WriteLine("Read Large File - Show Error Lines\n");

        Console.Write("Waiting , for user to enter large file path : ");
        string path = Console.ReadLine();

        readLargeFile(path);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
