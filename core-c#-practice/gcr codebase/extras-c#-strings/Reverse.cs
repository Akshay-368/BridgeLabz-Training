using System;
public static class Reverse
{
    public static void Main()
    {
        /*2. Reverse a String
        Problem:
        Write a C# program to reverse a given string without using any built-in reverse functions.
        */
        Console.WriteLine ( "Enter a string to reverse : ");
        string input = Console.ReadLine();
        string reversed = ""; // creating a new string which will store the reversed string
        for (int i = input.Length - 1; i >= 0; i--)
        {
            reversed += input[i];
        }
        Console.WriteLine("Reversed string: " + reversed);
    }
}
