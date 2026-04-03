using System;

public class passVal 
{
    // password validator - student style
    public static bool IsStrongPassword(string pass)
    {
        if(pass.Length < 8)
        {
            Console.WriteLine("too short - need at least 8 chars");
            return false;
        }

        bool hasUpper = false;
        bool hasDigit = false;

        for(int i=0; i<pass.Length ; i++)
        {
            char c = pass[i];

            if(char.IsUpper(c)) hasUpper = true;
            if(char.IsDigit(c)) hasDigit = true;
        }

        if(!hasUpper)
        {
            Console.WriteLine("no uppercase letter found");
            return false;
        }

        if(!hasDigit)
        {
            Console.WriteLine("no digit found");
            return false;
        }

        Console.WriteLine("strong password - good!");
        return true;
    }

    // manual student-style tests
    public static void testPassword()
    {
        Console.WriteLine("=== Password Strength Tests (manual) ===\n");

        string[] testCases = {
            "abc123",               // too short
            "abcdefg1",             // no upper
            "Abcdefgh",             // no digit
            "Abcdefg1",             // valid
            "Abcdefg1#",            // valid with extra
            "A1b2c3d4"              // valid
        };

        for(int i=0; i<testCases.Length ; i++)
        {
            Console.Write("Test " + (i+1) + ": " + testCases[i] + " → ");
            bool result = IsStrongPassword(testCases[i]);

            if(i <= 2 && !result)
            {
                Console.WriteLine(" → PASS (invalid case)");
            }
            else if(i > 2 && result)
            {
                Console.WriteLine(" → PASS (valid case)");
            }
            else
            {
                Console.WriteLine(" → FAIL");
            }
        }
    }

    public static void Main(string[] args)
    {
        /*
        2. Testing Password Strength Validator
        Problem:
        Create a PasswordValidator class with:
        * Passwords must have at least 8 characters, one uppercase letter, and one digit.
          ✅ Write unit tests for valid and invalid passwords.
        */

        Console.WriteLine("Password Strength Validator Tests\n");

        testPassword();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
