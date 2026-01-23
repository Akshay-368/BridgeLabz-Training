using System;

public class spaceFix 
{
    // replace multiple spaces with single space
    public static string fixMultipleSpaces(string text)
    {
        string result = "";

        bool lastWasSpace = false;

        for(int i=0; i<text.Length ; i++)
        {
            char c = text[i];

            if(c == ' ')
            {
                if(!lastWasSpace)
                {
                    result += ' ';
                    lastWasSpace = true;
                }
            }
            else
            {
                result += c;
                lastWasSpace = false;
            }
        }

        return result.Trim();
    }

    public static void Main(string[] args) 
    {
        /*
        8. Replace Multiple Spaces with a Single Space
        Example Input: "This is an example with multiple spaces."
        Expected Output: "This is an example with multiple spaces."
        */

        Console.WriteLine("Replace Multiple Spaces\n");

        Console.Write("Waiting , for user to enter text : ");
        string input = Console.ReadLine();

        string fixedText = fixMultipleSpaces(input);

        Console.WriteLine("\nFixed text:");
        Console.WriteLine(fixedText);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
