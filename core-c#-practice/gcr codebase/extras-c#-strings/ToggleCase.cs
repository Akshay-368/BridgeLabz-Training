using System;
public static class ToggleCase
{
    public static void Main()
    {
        /*7. Toggle Case of Characters
        Problem:
        Write a C# program to toggle the case of each character in a given string. Convert
        uppercase letters to lowercase and vice versa.
        */

        Console.WriteLine ( "Enter a string  : ");
        string s = Console.ReadLine();

        // By the use of built in functions to convert to uppercase (ToUpper) and to lowercase (ToLower) and using a for loop to iterate through the string
        for (int i = 0; i < s.Length; i++)
        {
            if (char.IsUpper(s[i]))
            {
                // we mentioned char. because IsUpper is a method that belongs to char class
                Console.Write(char.ToLower(s[i]));
            }
            else
            {
                Console.Write(char.ToUpper(s[i]));
            }
        }
        
        
    }
}
