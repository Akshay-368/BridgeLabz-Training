using System;
using System.Text.RegularExpressions;

public class dateExt 
{
    // extract dates in dd/mm/yyyy format
    public static void extractDates(string text)
    {
        // pattern for dd/mm/yyyy
        string pattern = @"\b\d{2}/\d{2}/\d{4}\b";

        MatchCollection matches = Regex.Matches(text, pattern);

        if(matches.Count == 0)
        {
            Console.WriteLine("no dates found in dd/mm/yyyy format");
            return;
        }

        Console.WriteLine("Found dates:");
        foreach(Match m in matches)
        {
            Console.Write(m.Value + ", ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        6. Extract Dates in dd/mm/yyyy Format
        Example Text: "The events are scheduled for 12/05/2023, 15/08/2024, and 29/02/2020."
        Expected Output:
        * 12/05/2023, 15/08/2024, 29/02/2020
        */

        Console.WriteLine("Extract Dates (dd/mm/yyyy)\n");

        Console.Write("Waiting , for user to enter text : ");
        string input = Console.ReadLine();

        extractDates(input);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
