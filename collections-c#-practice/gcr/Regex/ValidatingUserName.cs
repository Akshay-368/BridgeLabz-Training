using System;

public class userVal 
{
    // check if username is valid
    // rules:
    // - only letters, numbers, underscore
    // - start with letter
    // - 5 to 15 chars long
    public static bool isValidUsername(string uname)
    {
        // check length first
        if(uname.Length < 5 || uname.Length > 15)
        {
            Console.WriteLine("username must be 5 to 15 chars");
            return false;
        }

        // must start with letter
        if(!char.IsLetter(uname[0]))
        {
            Console.WriteLine("must start with letter");
            return false;
        }

        // check each character
        for(int i=0; i<uname.Length ; i++)
        {
            char c = uname[i];

            if(!char.IsLetterOrDigit(c) && c != '_')
            {
                Console.WriteLine("only letters, numbers, _ allowed");
                return false;
            }
        }

        Console.WriteLine("username is valid");
        return true;
    }

    public static void Main(string[] args) 
    {
        /*
        1. Validate a Username
        A valid username:
        * Can only contain letters (a-z, A-Z), numbers (0-9), and underscores (_)
        * Must start with a letter
        * Must be between 5 to 15 characters long
        Example Inputs & Outputs:
        * ✅ "user_123" → Valid
        * ❌ "123user" → Invalid (starts with a number)
        * ❌ "us" → Invalid (too short)
        */

        Console.WriteLine("Username Validator\n");

        while(true)
        {
            Console.Write("Waiting , for user to enter username (or empty to exit) : ");
            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input)) break;

            isValidUsername(input);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
