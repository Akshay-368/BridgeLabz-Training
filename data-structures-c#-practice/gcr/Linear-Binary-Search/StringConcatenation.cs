using System;
using System.Text;

public class strConcat 
{
    // this function takes array of strings and joins them all into one big string
    // we use StringBuilder because normal string + would create new string each time
    // which is slow and wastes memory , StringBuilder is smart - it uses internal buffer
    // StringBuilder stores characters in a char array , it has a capacity
    // when we add more text and capacity is full , it makes bigger array automatically
    // thats why its efficient for joining many strings
    // key points about StringBuilder to remember would be :
    // mutable (can change without making new object)
    // Append() adds text at the end
    // ToString() converts it to normal string
    // better than string concatenation in loop
    public static string joinAllStrings(string[] wordsArray) 
    {
        // first check if array is null or empty
        if (wordsArray == null || wordsArray.Length == 0) 
        {
            Console.WriteLine("no strings given to join , returning empty");
            return "";
        }

        // create StringBuilder to collect all text
        // we can give initial capacity to make it faster 
        // but here we keep it simple
        StringBuilder finalCombinedText = new StringBuilder();

        // now going through each string in array one by one
        int totalWords = wordsArray.Length;

        for (int i = 0; i < totalWords ; i++) 
        {
            // get current word/string
            string currentWord = wordsArray[i];

            // add it to our StringBuilder
            finalCombinedText.Append(currentWord);

            //  add space after each word except last one
            // this makes output look better , we can remove if not wanted
            if (i < totalWords - 1) 
            {
                finalCombinedText.Append(" ");
            }

            // little debug message that we can comment , for better understanding but not required
            // Console.WriteLine("added word: " + currentWord);
        }

        // now convert everything to normal string
        string completeJoinedString = finalCombinedText.ToString();

        // tell user we finished
        Console.WriteLine("all strings joined successfully using StringBuilder");

        return completeJoinedString;
    }

    public static void Main(string[] args) 
    {
        /*
        Problem 1: Concatenate Strings Efficiently Using StringBuilder
        Problem: You are given an array of strings. Write a program that uses StringBuilder to concatenate all the strings in the array efficiently.
        */

        Console.WriteLine(" String Concatenation using StringBuilder ");
        Console.WriteLine("this program will join multiple words/strings into one");

        // ask how many words/strings user wants to join
        Console.Write("Waiting , for user to enter how many strings to join : ");
        int numberOfStrings = Convert.ToInt32(Console.ReadLine());

        // make array to store all input strings
        string[] allWords = new string[numberOfStrings];

        // take input from user for each string
        for (int i = 0; i < numberOfStrings ; i++) 
        {
            Console.Write("Enter string/word " + (i + 1) + " : ");
            allWords[i] = Console.ReadLine();
        }

        // call our join function
        string finalCombinedResult = joinAllStrings(allWords);

        // show the result
        Console.WriteLine(" All strings joined together:");
        Console.WriteLine(finalCombinedResult);

        // juts a little pause at end for proper vibe
        Console.WriteLine(" Press any key to close the program...");
        Console.ReadKey();
    }
}
