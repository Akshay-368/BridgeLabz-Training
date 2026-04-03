using System;

public class repWord 
{
    // find words that repeat (simple brute force)
    public static void findRepeatingWords(string sentence)
    {
        string[] words = sentence.Split(' ');

        Console.WriteLine("Repeating words (appears more than once):");

        for(int i=0; i<words.Length ; i++)
        {
            string current = words[i].Trim(',', '.', '!', '?');

            if(current.Length == 0) continue;

            bool printed = false;

            for(int j=i+1; j<words.Length ; j++)
            {
                string next = words[j].Trim(',', '.', '!', '?');

                if(current.ToLower() == next.ToLower())
                {
                    if(!printed)
                    {
                        Console.Write(current + " ");
                        printed = true;
                    }
                }
            }
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        14. Find Repeating Words in a Sentence
        Example Input: "This is is a repeated repeated word test."
        Expected Output:
        * is, repeated
        */

        Console.WriteLine("Find Repeating Words\n");

        Console.Write("Waiting , for user to enter sentence : ");
        string input = Console.ReadLine();

        findRepeatingWords(input);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
