using System;
public static class RemovingSpecificCharacter
{
    public static void Main()
    {
        /*10. Remove a Specific Character from a String
        Problem:
        Write a C# program to remove all occurrences of a specific character from a string.
        Example Input:
        String: "Hello World"
        Character to Remove: 'l'
        Expected Output:
        Modified String: "Heo Word"
        */

        Console.WriteLine ( "Enter a string  : "); //Asking user to input the string
        string s = Console.ReadLine();

        Console.WriteLine ( "Enter a character to remove : "); // Asking for the character to be removed
        char c = Convert.ToChar(Console.ReadLine());

        string result = s.Replace( c.ToString() , String.Empty ); // using the built in function of the string to replace a character to another character
        // The method takes either a string ( to be replaced by , old one) and string ( to be replaced with , newone) or a char ( old char to be replaced ) and a new char to replace with
        Console.WriteLine ( " Modified String : " + result ) ;


        
    }
}
