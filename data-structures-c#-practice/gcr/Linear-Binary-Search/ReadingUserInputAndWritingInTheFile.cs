using System;
using System.IO;

public class inputToFile 
{
    // this function reads lines from console and writes them to file
    // we use StreamReader for console input (though Console.ReadLine is also fine)
    // but we follow problem and use StreamReader
    public static void saveInputToFile(string filePathToSave) 
    {
        // we will read from console using StreamReader
        StreamReader consoleReader = new StreamReader(Console.OpenStandardInput());

        StreamWriter fileWriter = null;

        try 
        {
            // open file for writing
            fileWriter = new StreamWriter(filePathToSave);

            Console.WriteLine("type your text (type 'exit' on new line to stop)");

            string oneLineInput = "";

            // keep reading till user types exit
            while ((oneLineInput = consoleReader.ReadLine()) != null) 
            {
                if (oneLineInput.ToLower() == "exit") 
                {
                    Console.WriteLine("got exit command , stopping");
                    break;
                }

                // write this line to file
                fileWriter.WriteLine(oneLineInput);

                // also print to console so user sees what the user wrote
                Console.WriteLine("saved: " + oneLineInput);
            }
        }
        catch (Exception err) 
        {
            Console.WriteLine("something wrong : " + err.Message);
        }
        finally 
        {
            // close file writer
            if (fileWriter != null) 
            {
                fileWriter.Close();
                Console.WriteLine("file saved and closed");
            }


        }
      // done writing user input to file
    }

    public static void Main(string[] args) 
    {
        /*
        Problem 2: Read User Input and Write to File Using StreamReader
        Problem: Write a program that reads user input from the console and writes it to a file.
        */

        Console.WriteLine(" Read Console Input and Save to File ");

        Console.Write("Waiting , for user to enter file path to save (like C:\\output.txt) : ");
        string savePath = Console.ReadLine();

        saveInputToFile(savePath);

        Console.WriteLine(" Press any key to close...");
        Console.ReadKey();
    }
}
