using System;
using System.Text.RegularExpressions;

public class linkExt 
{
    // extract http/https links
    public static void extractLinks(string text)
    {
        // pattern for urls
        string pattern = @"https?://[^\s]+";

        MatchCollection matches = Regex.Matches(text, pattern);

        if(matches.Count == 0)
        {
            Console.WriteLine("no links found");
            return;
        }

        Console.WriteLine("Found links:");
        foreach(Match m in matches)
        {
            Console.Write(m.Value + ", ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        7. Extract Links from a Web Page
        Example Text: "Visit https://www.google.com and http://example.org for more info."
        Expected Output:
        * https://www.google.com, http://example.org
        */

        Console.WriteLine("Extract Links from Text\n");

        Console.Write("Waiting , for user to enter text : ");
        string input = Console.ReadLine();

        extractLinks(input);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
