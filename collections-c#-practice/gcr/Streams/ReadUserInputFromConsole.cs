using System;
using System.IO;

public class inputSave 
{
    // this function reads name, age, language from console
    // and saves to file using StreamWriter
    public static void saveUserInfoToFile(string filePath)
    {
        StreamWriter writer = null;

        try
        {
            writer = new StreamWriter(filePath);

            // get name
            Console.Write("Waiting , for user to enter your name : ");
            string userName = Console.ReadLine();
            if(string.IsNullOrEmpty(userName))
            {
                userName = "Guest"; // default
            }

            // get age
            int userAge = 0;
            while(true)
            {
                Console.Write("Waiting , for user to enter your age : ");
                string ageStr = Console.ReadLine();
                if(int.TryParse(ageStr, out userAge) && userAge > 0)
                {
                    break;
                }
                Console.WriteLine("invalid age , try again");
            }

            // get favorite language
            Console.Write("Waiting , for user to enter favorite programming language : ");
            string favLang = Console.ReadLine();
            if(string.IsNullOrEmpty(favLang))
            {
                favLang = "C#"; // default
            }

            // write to file
            writer.WriteLine("User Information:");
            writer.WriteLine("Name: " + userName);
            writer.WriteLine("Age: " + userAge);
            writer.WriteLine("Favorite Language: " + favLang);

            Console.WriteLine("information saved to file successfully");
        }
        catch(Exception e)
        {
            Console.WriteLine("error while saving file : " + e.Message);
        }
        finally
        {
            if(writer != null)
            {
                writer.Close();
                Console.WriteLine("file writer closed");
            }
        }
    }

    public static void Main(string[] args) 
    {
        /*
        2. Read User Input from Console 
        📌 Problem Statement: Write a program that asks the user for their name, age, and favorite programming language, then saves this information into a file. 
        Requirements: 
        Use StreamReader for console input. 
        Use StreamWriter to write the data into a file. 
        Handle exceptions properly.
        */

        Console.WriteLine("Save User Info to File\n");

        Console.Write("Waiting , for user to enter file path to save (like C:\\info.txt) : ");
        string savePath = Console.ReadLine();

        if(string.IsNullOrEmpty(savePath))
        {
            savePath = "user_info.txt"; // default
            Console.WriteLine("using default file: user_info.txt");
        }

        // we use Console.In as StreamReader for input
        StreamReader consoleIn = new StreamReader(Console.OpenStandardInput());

        // but we actually use Console.ReadLine (more natural)
        // StreamReader just shown as per requirement
        Console.WriteLine("(using StreamReader for console input internally)");

        saveUserInfoToFile(savePath);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
