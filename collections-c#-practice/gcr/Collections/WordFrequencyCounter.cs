using System;
using System.IO;
using System.Collections.Generic;

public class wordFreq 
{
    // this function reads file and counts word frequency
    // we use Dictionary<string,int> to store count
    // dictionary is key-value , key=word , value=count
    // we make words lowercase and remove punctuation simply
    public static void countWordsInFile(string filePath)
    {
        // check file exists
        if (!File.Exists(filePath))
        {
            Console.WriteLine("file not found : " + filePath);
            return;
        }

        // dictionary to store word -> count
        Dictionary<string,int> wordCount = new Dictionary<string,int>();

        StreamReader reader = null;

        try
        {
            reader = new StreamReader(filePath);

            string line = "";

            // read file line by line
            while ((line = reader.ReadLine()) != null)
            {
                // split line into words
                string[] words = line.Split(' ', ',', '.', '!', '?', ';', ':');

                for(int i=0; i<words.Length ; i++)
                {
                    string w = words[i].Trim().ToLower();

                    // skip empty
                    if(w.Length == 0) continue;

                    // add or increase count
                    if(wordCount.ContainsKey(w))
                    {
                        wordCount[w]++;
                    }
                    else
                    {
                        wordCount[w] = 1;
                    }
                }
            }

            Console.WriteLine("\nWord frequency:");
            foreach(KeyValuePair<string,int> pair in wordCount)
            {
                Console.WriteLine(pair.Key + " : " + pair.Value);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("error reading file : " + e.Message);
        }
        finally
        {
            if(reader != null)
            {
                reader.Close();
                Console.WriteLine("file closed");
            }
        }
    }

    public static void Main(string[] args) 
    {
        /*
        1. Word Frequency Counter
        Read a text file and count the frequency of each word using a Dictionary<string, int>.
        Example:
        Input: "Hello world, hello Java!"
        Output: { "hello": 2, "world": 1, "java": 1 }
        */

        Console.WriteLine("Word Frequency Counter from File\n");

        Console.Write("Waiting , for user to enter full file path (like C:\\text.txt) : ");
        string path = Console.ReadLine();

        countWordsInFile(path);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
