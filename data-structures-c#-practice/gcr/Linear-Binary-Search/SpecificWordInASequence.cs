using System;

public class lin2 
{
    // find first sentence that contains given word
    // linear search on array of strings
    public static int findSentenceWithWord(string[] sentences,int size,string word) 
    {
        string wordLower = word.ToLower();

        for(int i=0; i<size ; i++) 
        {
            string currentSentence = sentences[i].ToLower();

            // simple check if word exists in sentence
            if(currentSentence.Contains(wordLower)) 
            {
                Console.WriteLine("found in sentence " + (i+1));
                return i;
            }
        }

        Console.WriteLine("word not found in any sentence");
        return -1;
      // brute force linear search
    }

    public static void Main(string[] args) 
    {
        /*
        Linear Search Problem 2: Search for a Specific Word in a List of Sentences
        Problem: You are given an array of sentences. Write a program that performs Linear Search to find the first sentence containing a specific word.
        */

        Console.WriteLine("find first sentence with given word");

        Console.Write("Waiting , for user to enter how many sentences : ");
        int n = Convert.ToInt32(Console.ReadLine());

        string[] sent = new string[n];

        for(int i=0; i<n ; i++) 
        {
            Console.Write("enter sentence " + (i+1) + " : ");
            sent[i] = Console.ReadLine();
        }

        Console.Write("Waiting , for user to enter word to search : ");
        string searchWord = Console.ReadLine();

        int foundAt = findSentenceWithWord(sent , n , searchWord);

        if(foundAt != -1) 
        {
            Console.WriteLine("sentence is : " + sent[foundAt]);
        }

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
