using System;
public static class Anagrams
{
    public static void Main()
    {
        /*11. Write a C# program that accepts two strings from the user and checks if the two
        strings are anagrams of each other (i.e., whether they contain the same characters in any order ) .
        */

        Console.WriteLine ( "Enter a string  : "); //Asking user to input the string
        string s = Console.ReadLine();

        Console.WriteLine ( "Enter another string : "); // Asking for another string
        string c = Console.ReadLine() ;

        // Now we will check if they contain same character or not in any order
        if (s.Length == c.Length)
        {
            // first checking the length , if they are of uneven length then no need to check further
            // Then building a character array. so that we can easily go element by element to match them using indexing
            char[] s1 = s.ToCharArray();
            char[] c1 = c.ToCharArray();
            // Then we will sort them , as order doesn't matter in anagrams until and unless they have same characters .
            Array.Sort(s1);
            Array.Sort(c1);
            for ( int i = 0; i < s.Length; i++ )
            {
                if (s1[i] != c1[i])
                {
                    // as soon as any charcters don't match we break
                    Console.WriteLine ( "Strings are not anagrams" );
                    break;
                }
                // else continue the search
            }
            Console.WriteLine ( "Strings are anagrams" ) ;
        }
        else
        {
            Console.WriteLine ( "Strings are not anagrams" );
            return ;
        }

        
    }
}
