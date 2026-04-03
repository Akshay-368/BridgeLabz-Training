using System;
using System.IO;

public class wordCnt 
{
    // this function counts how many times a word appears in file
    // we read line by line and check each line
    public static void countWordInFile(string filePath,string wordToFind) 
    {
        // first check file exists
        if (!File.Exists(filePath)) 
        {
            Console.WriteLine("sorry file not found : " + filePath);
            return;
        }

        // make word lowercase for case insensitive search
        string wordLower = wordToFind.ToLower();

        int totalCount = 0; // how many times word found

        StreamReader fileReader = null;

        try 
        {
            fileReader = new StreamReader(filePath);

            string oneLine = "";
            int currentLineNum = 1;

            // read file line by line
            while ((oneLine = fileReader.ReadLine()) != null) 
            {
                // split line into words (simple split by space)
                string[] wordsInLine = oneLine.Split(' ');

                // check each word in this line
                foreach (string singleWord in wordsInLine) 
                {
                    // remove punctuation roughly
                    string cleanWord = singleWord.Trim('.', ',', '!', '?').ToLower();

                    if (cleanWord == wordLower) 
                    {
                        totalCount++;
                        Console.WriteLine("found at line " + currentLineNum + " : " + singleWord);
                    }
                }

                currentLineNum++;
            }

            Console.WriteLine("\ntotal times '" + wordToFind + "' found : " + totalCount);
        }
        catch (Exception err) 
        {
            Console.WriteLine("error while reading file : " + err.Message);
        }
        finally 
        {
            if (fileReader != null) 
            {
                fileReader.Close();
                Console.WriteLine("file reader closed");
            }
        }
      // done counting word
    }

    public static void Main(string[] args) 
    {
        /*
        Problem 2: Count the Occurrence of a Word in a File Using StreamReader
        Problem: Write a program that reads a file and counts how many times a specific word appears in the file.
        */

        Console.WriteLine(" Count Word Occurrences in File ");

        Console.Write("Waiting , for user to enter full file path : ");
        string filePathInput = Console.ReadLine();

        Console.Write("Waiting , for user to enter word to search : ");
        string searchWord = Console.ReadLine();

        // call the count function
        countWordInFile(filePathInput , searchWord);

        Console.WriteLine(" Press any key to exit...");
        Console.ReadKey();
    }
}
