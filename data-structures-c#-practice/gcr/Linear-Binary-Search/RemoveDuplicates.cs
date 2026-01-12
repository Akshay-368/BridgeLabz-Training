using System;
using System.Text;

public class strDupRemover 
{
    // this function takes a string and returns it without any duplicate characters
    // we keep the first occurrence of each char and remove later duplicates
    // we use StringBuilder cuz its mutable - meaning we can change it without creating new strings every time
    // StringBuilder is better than normal string cuz string is immutable (cant change once made)
    // StringBuilder stores characters in an internal char[] array , it has a capacity that grows automatically
    // when we add more chars , it allocates more memory if needed (like double the size usually)
    // key points: efficient for building strings , Append() adds to end , ToString() converts to string
    // why we use it: avoids creating many temporary strings in memory , faster and less garbage collection
    public static string removeDuplicateChars(string originalInput) 
    {
        // first check if input is empty or null , if yes just return empty
        if (originalInput == null || originalInput.Length == 0) 
        {
            Console.WriteLine("nothing to remove duplicates from , returning empty string");
            return "";
        }

        // create a new StringBuilder to build our result string
        // we start with empty , capacity default is 16 but it will grow as we add
        StringBuilder uniqueCharsBuilder = new StringBuilder();

        // we will loop through each character in the original string
        int inputLength = originalInput.Length;

        for (int position = 0; position < inputLength ; position++) 
        {
            // get the current character
            char currentCharacter = originalInput[position];

            // now check if this character is already in our StringBuilder
            // we use brute force way - loop through the builder and check

            bool alreadyPresent = false;

            // check every char in builder
            for (int builderIndex = 0; builderIndex < uniqueCharsBuilder.Length ; builderIndex++) 
            {
                if (uniqueCharsBuilder[builderIndex] == currentCharacter) 
                {
                    alreadyPresent = true;
                    break; // no need to check further
                }
            }

            // if not present , add it to the end
            if (!alreadyPresent) 
            {
                uniqueCharsBuilder.Append(currentCharacter);
                // Console.WriteLine("added new char: " + currentCharacter); // optional for better understanding
            }
            // else we skip it cuz its duplicate
        }

        // now convert StringBuilder to normal string and return
        string finalResultWithoutDuplicates = uniqueCharsBuilder.ToString();


        Console.WriteLine(" removed all duplicates while keeping order");

        return finalResultWithoutDuplicates;
    }

    public static void Main(string[] args) 
    {
        /*
        StringBuilder Problem 2: Remove Duplicates from a String Using StringBuilder
        Problem: Write a program that uses StringBuilder to remove all duplicate characters from a given string while maintaining the original order.
        */

        Console.WriteLine(" Remove Duplicate Characters using StringBuilder ");
        Console.WriteLine("this will keep first occurrence of each char and remove later duplicates");

        // ask user for input
        Console.Write("Waiting , for user to enter the text to remove duplicates from : ");
        string userTextInput = Console.ReadLine();

        // call the function
        string resultAfterRemovingDuplicates = removeDuplicateChars(userTextInput);

        // print results
        Console.WriteLine("Original text was : " + userTextInput);
        Console.WriteLine("Text without duplicates : " + resultAfterRemovingDuplicates);

        // pause before close
        Console.WriteLine("Press any key to exit...");
        Console.ReadKey();
    }
}
