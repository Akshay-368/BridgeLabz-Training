using System;
using System.IO;
using System.Collections.Generic;

public class wordCntFile 
{
    // count words in file and show top 5 frequent
    public static void countWords(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Console.WriteLine("file not found : " + filePath);
            return;
        }

        Dictionary<string,int> wordFreq = new Dictionary<string,int>();

        StreamReader reader = null;

        try
        {
            reader = new StreamReader(filePath);

            string line = "";

            while((line = reader.ReadLine()) != null)
            {
                string[] words = line.Split(' ', ',', '.', '!', '?');

                for(int i=0; i<words.Length ; i++)
                {
                    string w = words[i].Trim().ToLower();

                    if(w.Length == 0) continue;

                    if(wordFreq.ContainsKey(w))
                    {
                        wordFreq[w]++;
                    }
                    else
                    {
                        wordFreq[w] = 1;
                    }
                }
            }

            // simple way to find top 5 (not optimal)
            Console.WriteLine("\nTop 5 frequent words:");
            int printed = 0;

            while(printed < 5 && wordFreq.Count > 0)
            {
                string maxWord = "";
                int maxCount = 0;

                foreach(string key in wordFreq.Keys)
                {
                    if(wordFreq[key] > maxCount)
                    {
                        maxCount = wordFreq[key];
                        maxWord = key;
                    }
                }

                if(maxWord != "")
                {
                    Console.WriteLine(maxWord + " : " + maxCount);
                    wordFreq.Remove(maxWord);
                    printed++;
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("error : " + e.Message);
        }
        finally
        {
            if(reader != null) reader.Close();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        7. Count Words in a File 
        📌 Problem Statement: Write a C# program that counts the number of words in a given text file and displays the top 5 most frequently occurring words. 
        Requirements: Use StreamReader to read the file. 
        Use a Dictionary<string, int> to count word occurrences. 
        Sort the words based on frequency and display the top 5.
        */

        Console.WriteLine("Count Words & Top 5 Frequent\n");

        Console.Write("Waiting , for user to enter file path : ");
        string path = Console.ReadLine();

        countWords(path);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
