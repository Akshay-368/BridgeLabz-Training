using System;

public class Program
{
    public static string CleanseAndInvert(string input)
    {
        //  Input must not be null and must be at least 6 characters long
        if (string.IsNullOrEmpty(input) || input.Length < 6)
        {
            return "";
        }

        //  Input must not contain any space, digit, or special character
        // (only letters a-z A-Z allowed)
        for (int i = 0; i < input.Length; i++)
        {
            char c = input[i];
            if (!char.IsLetter(c))
            {
                return ""; // space, digit, or special char → invalid
            }
        }

        //  Convert to lowercase
        string lower = input.ToLower();

        //  Remove characters with even ASCII values
        string filtered = "";
        for (int i = 0; i < lower.Length; i++)
        {
            char c = lower[i];
            int ascii = (int)c;

            // Keep only odd ASCII values
            if (ascii % 2 == 1)
            {
                filtered += c;
            }
        }

        // If after filtering nothing is left → return empty
        if (filtered.Length == 0)
        {
            return "";
        }

        // Step 3: Reverse the filtered string
        char[] chars = filtered.ToCharArray();
        Array.Reverse(chars);
        string reversed = new string(chars);

        // In reversed string, convert even-positioned chars (0-based) to uppercase
        string final = "";
        for (int i = 0; i < reversed.Length; i++)
        {
            char c = reversed[i];
            if (i % 2 == 0)
            {
                final += char.ToUpper(c);
            }
            else
            {
                final += c;
            }
        }

        return final;
    }

    public static void Main(string[] args)
    {
        /*
        Aeroplane -> EaOeA
        Cowages   -> SeGaWoC
        Magic      -> Invalid Input (length < 6)
        Kinder World -> Invalid Input (space)
        B@rbie     -> Invalid Input (special char)
        */

        Console.WriteLine("CleanseAndInvert - ASCII Puzzle");


        Console.Write("Enter the word : ");
        string word = Console.ReadLine().Trim();

        string result = CleanseAndInvert(word);

        if (string.IsNullOrEmpty(result))
        {
            Console.WriteLine(word + " is an invalid word");
        }
        else
        {
            Console.WriteLine("The generated key is - " + result);
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
