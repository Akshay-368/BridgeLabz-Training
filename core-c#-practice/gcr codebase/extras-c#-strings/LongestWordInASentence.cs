using System;
public static class LongestWordInASentence
{
    public static void Main()
    {
        /*5. Find the Longest Word in a Sentence
        Problem:
        Write a C# program that takes a sentence as input and returns the longest word in the
        sentence.
        */
        Console.WriteLine ( "Enter a string to find the longest word in the sentence ( thus use space seperator to segregate words ) : ");
        string input = Console.ReadLine();
        string[] words = input.Split(); // This is for the words that we will come across in the given sentence
        // That's why it's an array and not just some normal string.
        string longestWord = words[0]; // This will store the longest word and initializing it with the current first word as who knows maybe that will be the longest word
        // Infact maybe that word alone is the longest word.
        foreach (string w in words)
        {
            // Checking if the word is longer than the current longest word
            if ( w.Length > longestWord.Length )
            {
                // if we find a word that is longer that our current longest word then we will have to stroe it in the longestWord
                longestWord = w;
            }
            // else we will continue in the loop
        }
        Console.WriteLine ("The longest word in the sentence is: " + longestWord) ;
        
    }
}
