using System;
using System.Text.RegularExpressions;

public class emailExt 
{
    // simple email extraction using regex
    // pattern: word@word.word
    public static void extractEmails(string text)
    {
        // regex for basic email
        string pattern = @"\b[A-Za-z0-9._%+-]+@[A-Za-z0-9.-]+\.[A-Za-z]{2,}\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        if(matches.Count == 0)
        {
            Console.WriteLine("no emails found");
            return;
        }

        Console.WriteLine("Found emails:");
        foreach(Match m in matches)
        {
            Console.WriteLine(m.Value);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        4. Extract All Email Addresses from a Text
        Example Text: "Contact us at support@example.com and info@company.org"
        Expected Output:
        * support@example.com
        * info@company.org
        */

        Console.WriteLine("Extract Emails from Text\n");

        Console.Write("Waiting , for user to enter text (paste paragraph) : ");
        string inputText = Console.ReadLine();

        extractEmails(inputText);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
