using System;
using System.IO;

public class usingFile 
{
    // read first line of file using using statement
    // using auto closes file even if error happens
    public static void readFirstLine(string filePath)
    {
        try
        {
            // using block - file auto closed at end
            using (StreamReader reader = new StreamReader(filePath))
            {
                string firstLine = reader.ReadLine();

                if(firstLine != null)
                {
                    Console.WriteLine("First line of file:");
                    Console.WriteLine(firstLine);
                }
                else
                {
                    Console.WriteLine("file is empty");
                }
            }
        }
        catch(IOException io)
        {
            Console.WriteLine("Error reading file");
            Console.WriteLine("(details: " + io.Message + ")");
        }
        catch(Exception e)
        {
            Console.WriteLine("some other error : " + e.Message);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        5. Using using Statement for File Handling
        💡 Problem Statement:
        Write a C# program that reads the first line of a file named "info.txt" using StreamReader.
        * Use using to ensure the file is automatically closed after reading.
        * Handle any IOException that may occur.
        Expected Behavior:
        * If the file exists, print its first line.
        * If the file does not exist, catch IOException and print "Error reading file".
        */

        Console.WriteLine("Read First Line using 'using' statement\n");

        string fileName = "info.txt";
        Console.WriteLine("trying to read file: " + fileName);

        readFirstLine(fileName);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
