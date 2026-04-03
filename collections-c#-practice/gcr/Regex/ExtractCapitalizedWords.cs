using System;
using System.Text.RegularExpressions;

public class capWord 
{
    // extract words that start with capital letter
    public static void extractCapitalWords(string text)
    {
        // regex: words starting with uppercase
        string pattern = @"\b[A-Z][a-zA-Z]*\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        if(matches.Count == 0)
        {
            Console.WriteLine("no capitalized words found");
            return;
        }

        Console.WriteLine("Capitalized words:");
        foreach(Match m in matches)
        {
            Console.Write(m.Value + ", ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        5. Extract All Capitalized Words from a Sentence
        Example Text: "The Eiffel Tower is in Paris and the Statue of Liberty is in New York."
        Expected Output:
        * Eiffel, Tower, Paris, Statue, Liberty, New, York
        */

        Console.WriteLine("Extract Capitalized Words\n");

        Console.Write("Waiting , for user to enter sentence : ");
        string input = Console.ReadLine();

        extractCapitalWords(input);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
