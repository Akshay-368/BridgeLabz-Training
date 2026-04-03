using System;
public static class VowelsAndConsonants
{
    /*1. Count Vowels and Consonants
    Problem:
    Write a C# program to count the number of vowels and consonants in a given string.
    */
    public static void Main()
    {
        Console.WriteLine ("Enter a string :") ;
        string input = Console.ReadLine(); // taking input from the user
        int vowelCount = 0 ; // our current vowel count is at 0
        int consonantCount = 0 ; // our current consonant count is at 0
        foreach (char c in input) // here foreach is a specialized loop designed to traverse collections such as arrays, lists, dictionaries, or other enumerable types.
        // mainly to reduce the need for indexing. just similar to how i do it in python simply with for ... in.
        {
            if (c == 'a' || c == 'e' || c == 'i' || c == 'o' || c == 'u' || c == 'A' || c == 'E' || c == 'I' || c == 'O' || c == 'U')
            {
                // if the character c happens to be matching with any vowel of 'A' or 'E' or 'I' or 'O' or 'U' then we increase vowelCount
                vowelCount++;
            }
            else if ((c >= 'a' && c <= 'z') || (c >= 'A' && c <= 'Z'))
            {
                // and if it is a character between 'a' and 'z' or 'A' and 'Z' then we increase consonantCount
                consonantCount++;
            }
        }
        Console.WriteLine("Vowels: " + vowelCount);
        Console.WriteLine("Consonants: " + consonantCount);
    }
}
