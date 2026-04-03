using System;
using System.Text.RegularExpressions;

public class currExt 
{
    // extract currency values like $45.99 or 10.50
    public static void extractCurrency(string text)
    {
        // pattern for $ or just number with decimal
        string pattern = @"(\$?\d+\.\d{2})";

        MatchCollection matches = Regex.Matches(text, pattern);

        if(matches.Count == 0)
        {
            Console.WriteLine("no currency values found");
            return;
        }

        Console.WriteLine("Found currency values:");
        foreach(Match m in matches)
        {
            Console.Write(m.Value + ", ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        13. Extract Currency Values from a Text
        Example Text: "The price is $45.99, and the discount is $ 10.50."
        Expected Output:
        * $45.99, 10.50
        */

        Console.WriteLine("Extract Currency Values\n");

        Console.Write("Waiting , for user to enter text : ");
        string input = Console.ReadLine();

        extractCurrency(input);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
