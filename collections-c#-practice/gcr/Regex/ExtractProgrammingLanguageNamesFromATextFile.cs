using System;

public class langExt 
{
    // extract common programming languages from text
    // simple word matching
    public static void extractLanguages(string text)
    {
        string[] knownLangs = {"Java", "Python", "JavaScript", "Go", "C#", "C++", "Ruby", "PHP", "Swift", "Kotlin"};

        Console.WriteLine("Found programming languages:");
        bool foundAny = false;

        for(int i=0; i<knownLangs.Length ; i++)
        {
            if(text.Contains(knownLangs[i]) || text.Contains(knownLangs[i].ToLower()))
            {
                Console.Write(knownLangs[i] + ", ");
                foundAny = true;
            }
        }

        if(!foundAny)
        {
            Console.WriteLine("no known languages found");
        }
        else
        {
            Console.WriteLine();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        12. Extract Programming Language Names from a Text
        Example Text: "I love Java, Python, and JavaScript, but I haven't tried Go yet."
        Expected Output:
        * Java, Python, JavaScript, Go
        */

        Console.WriteLine("Extract Programming Languages from Text\n");

        Console.Write("Waiting , for user to enter text : ");
        string input = Console.ReadLine();

        extractLanguages(input);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
