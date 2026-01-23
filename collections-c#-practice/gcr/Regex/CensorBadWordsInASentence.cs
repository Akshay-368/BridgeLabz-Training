using System;

public class censor 
{
    // censor bad words with ****
    public static string censorBadWords(string text,string[] badWords)
    {
        string result = text;

        foreach(string bad in badWords)
        {
            string censor = new string('*', bad.Length);
            result = result.Replace(bad, censor);
            result = result.Replace(bad.ToLower(), censor);
            result = result.Replace(bad.ToUpper(), censor);
        }

        return result;
    }

    public static void Main(string[] args) 
    {
        /*
        9. Censor Bad Words in a Sentence
        Given a list of bad words, replace them with ****.
        Example Input: "This is a damn bad example with some stupid words."
        Expected Output: "This is a **** bad example with some **** words."
        */

        Console.WriteLine("Bad Word Censor\n");

        string[] badList = {"damn", "stupid"};

        Console.Write("Waiting , for user to enter sentence : ");
        string input = Console.ReadLine();

        string censored = censorBadWords(input, badList);

        Console.WriteLine("\nCensored text:");
        Console.WriteLine(censored);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
