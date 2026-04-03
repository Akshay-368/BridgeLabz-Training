using System;
using System.IO;

public class fileRd 
{
    // this function reads file line by line using StreamReader
    // and prints each line to console
    public static void readFileLines(string filePath) 
    {
        // check if file exists first
        if (!File.Exists(filePath)) 
        {
            Console.WriteLine("file not found bro : " + filePath);
            return;
        }

        // we use StreamReader to read text file safely
        // StreamReader is good cuz it reads line by line without loading whole file
        // it uses buffer so memory friendly
        StreamReader reader = null;

        try 
        {
            reader = new StreamReader(filePath);

            string currentLine = "";
            int lineNumber = 1;

            // keep reading till end of file
            while ((currentLine = reader.ReadLine()) != null) 
            {
                // print line with number
                Console.WriteLine("Line " + lineNumber + " : " + currentLine);
                lineNumber++;
            }

            Console.WriteLine("finished reading all lines");
        }
        catch (Exception ex) 
        {
            Console.WriteLine("something went wrong while reading file : " + ex.Message);
        }
        finally 
        {
            // always close the reader if it was opened
            if (reader != null) 
            {
                reader.Close();
                Console.WriteLine("reader closed safely");
            }
        }
      // done reading file
    }

    public static void Main(string[] args) 
    {
        /*
        Problem 1: Read a File Line by Line Using StreamReader
        Problem: Write a program that uses StreamReader to read a text file line by line and print each line to the console.
        */

        Console.WriteLine(" Read File Line by Line ");

        Console.Write("Waiting , for user to enter full file path (like C:\\test.txt) : ");
        string pathGiven = Console.ReadLine();

        // call the read function
        readFileLines(pathGiven);

        Console.WriteLine(" Press any key to exit...");
        Console.ReadKey();
    }
}
