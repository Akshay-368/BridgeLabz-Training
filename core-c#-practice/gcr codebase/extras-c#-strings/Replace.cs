using System;
public static class Replace
{
    public static void Main()
    {
        /* 12. Write a replace method in C# that replaces a given word with another word in a sentence . */

        Console.WriteLine ( "Enter a string (sentence) : "); //Asking user to input the string
        string s = Console.ReadLine();

        Console.WriteLine ( "Enter another string ( the word that you want to change ) : "); // Asking for another string ( for the old word )
        string c = Console.ReadLine() ;

        Console.WriteLine ( "Enter another string ( the word that you want to change with ) : "); // Asking for the new word
        string n = Console.ReadLine() ;

        Console.WriteLine ( s.Replace ( c , n ) );
        // Once again using the replace method of string class which takes the old substring(or char) and gives the new substring ( or char)

        
    }
}
