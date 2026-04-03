using System;
using System.IO;

public class fileNotFound 
{
    // this function tries to read file "data.txt"
    // if file not exist → catch IOException and show message
    public static void readDataFile()
    {
        string fileName = "data.txt";

        StreamReader reader = null;

        try
        {
            // try to open file
            reader = new StreamReader(fileName);

            Console.WriteLine("file found! reading contents...\n");

            string line = "";

            // read and print line by line
            while((line = reader.ReadLine()) != null)
            {
                Console.WriteLine(line);
            }
        }
        catch(IOException ioEx)
        {
            // this catch is for file not found or other IO problems
            // IOException is thrown when file missing, no permission, etc
            Console.WriteLine("File not found");
            Console.WriteLine("(error details: " + ioEx.Message + ")");
        }
        catch(Exception anyEx)
        {
            // just in case something else goes wrong
            Console.WriteLine("some other error : " + anyEx.Message);
        }
        finally
        {
            // always close file if it was opened
            if(reader != null)
            {
                reader.Close();
                Console.WriteLine("file closed safely");
            }
        }
    }

    public static void Main(string[] args) 
    {
        /*
        1. Handling File Not Found Exception
        💡 Problem Statement:
        Create a C# program that reads a file named "data.txt". 
        If the file does not exist, handle the IOException properly and display a user-friendly message.
        Expected Behavior:
        * If the file exists, print its contents.
        * If the file does not exist, catch the IOException and print "File not found".
        */

        Console.WriteLine("Read data.txt file (if it exists)\n");

        Console.WriteLine("program will try to read 'data.txt' in current folder");
        Console.WriteLine("if file not exist → will show message\n");

        readDataFile();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
