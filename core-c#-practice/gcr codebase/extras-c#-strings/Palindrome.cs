using System;
public static class Palindrome
{
    public static void Main()
    {
        /*3. Palindrome String Check
        Problem:
        Write a C# program to check if a given string is a palindrome (a string that reads the
        same forward and backward).
        */
        Console.WriteLine ( "Enter a string to reverse : ");
        string input = Console.ReadLine();
        bool isPalindrome = true;
        int length = input.Length;

        for (int i = 0; i < length / 2; i++)
        {
            // comparing character from start to end with the characters at similar position
            if (input[i] != input[length - 1 - i])
            {
                // Here -i is an offset  As i increases (moving right from the start), subtracting i moves us an equal distance left from the end.
                isPalindrome = false;
                break;
            }
        }
        if (isPalindrome)
            Console.WriteLine("The string is a palindrome.");
        else
            Console.WriteLine("The string is not a palindrome.");
    }
}
