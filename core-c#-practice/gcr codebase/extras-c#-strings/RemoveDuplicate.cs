using System;
public static class RemoveDuplicate
{
    public static void Main()
    {
        /*4. Remove Duplicates from a String
        Problem:
        Write a C# program to remove all duplicate characters from a given string and return the
        modified string.
        */
        Console.WriteLine ( "Enter a string to remove duplicates : ");
        string input = Console.ReadLine();
        string output = ""; // creating an output string which is currently empty but will contain all the unique elements after our processing
        for (int i = 0; i < input.Length; i++)
        {
            // traversing the string
            if (!output.Contains ( input [ i] ) )
            {
                // if the character is not present in the output string that means it's an unique character and thus we will enter it in output string
                output += input[i];
            }
            // else we will just continue the loop
        }
        Console.WriteLine ("Output string: " + output) ;
    }
}
