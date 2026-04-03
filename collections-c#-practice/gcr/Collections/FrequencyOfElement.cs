using System;
using System.Collections.Generic;

public class freq 
{
    // count frequency of each string in list
    // return as Dictionary<string,int>
    public static Dictionary<string,int> countFrequency(List<string> wordsList)
    {
        // create dictionary to store count
        // dictionary is key-value pair , key is word , value is count
        Dictionary<string,int> frequencyMap = new Dictionary<string,int>();

        // go through each word
        for(int i=0; i<wordsList.Count ; i++)
        {
            string currentWord = wordsList[i];

            // if already in map , increase count
            if(frequencyMap.ContainsKey(currentWord))
            {
                frequencyMap[currentWord]++;
            }
            else
            {
                // first time , add with count 1
                frequencyMap[currentWord] = 1;
            }
        }

        Console.WriteLine("frequency count done");
        return frequencyMap;
    }

    public static void Main(string[] args) 
    {
        /*
        List Interface Problems
        2. Find Frequency of Elements
        Given a list of strings, count the frequency of each element and return the results in a Dictionary<string, int>.
        Example:
        Input: {"apple", "banana", "apple", "orange"}
        Output: { "apple": 2, "banana": 1, "orange": 1 }
        */

        Console.WriteLine("Count frequency of words\n");

        Console.Write("Waiting , for user to enter how many words : ");
        int n = Convert.ToInt32(Console.ReadLine());

        List<string> wordList = new List<string>();

        Console.WriteLine("enter words:");
        for(int i=0; i<n ; i++)
        {
            Console.Write("word " + (i+1) + " : ");
            string w = Console.ReadLine();
            wordList.Add(w);
        }

        // get frequency
        Dictionary<string,int> freqResult = countFrequency(wordList);

        Console.WriteLine(" Frequency result:");
        foreach(KeyValuePair<string,int> pair in freqResult)
        {
            Console.WriteLine(pair.Key + " : " + pair.Value);
        }

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
