using System;
using System.IO;

public class fileProc 
{
    public static void writeToFile(string filename,string content)
    {
        File.WriteAllText(filename, content);
        Console.WriteLine("written to " + filename);
    }

    public static string readFromFile(string filename)
    {
        if(!File.Exists(filename))
        {
            Console.WriteLine("file not found : " + filename);
            return "";
        }

        string data = File.ReadAllText(filename);
        Console.WriteLine("read from file: " + data);
        return data;
    }

    public static void testFile()
    {
        string testFile = "testfile.txt";
        string testContent = "hello from test";

        writeToFile(testFile, testContent);

        string readBack = readFromFile(testFile);

        if(readBack == testContent)
        {
            Console.WriteLine("test PASS : read same as written");
        }
        else
        {
            Console.WriteLine("test FAIL");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        8. Testing File Handling Methods
        Problem:
        Create a class FileProcessor with the following methods:
        * WriteToFile(string filename, string content): Writes content to a file.
        * ReadFromFile(string filename): Reads content from a file.
        Write unit tests to check if:
        ✅ The content is written and read correctly.
        ✅ The file exists after writing.
        ✅ Handling of IOException when the file does not exist.
        */

        Console.WriteLine("File Handling Test\n");

        testFile();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
