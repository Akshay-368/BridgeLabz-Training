using System;

public class userReg 
{
    // simple user registration validator
    public static bool RegisterUser(string username,string email,string password)
    {
        if(string.IsNullOrEmpty(username) || username.Length < 3)
        {
            Console.WriteLine("username too short or empty");
            return false;
        }

        if(!email.Contains("@") || !email.Contains("."))
        {
            Console.WriteLine("invalid email format");
            return false;
        }

        if(password.Length < 6)
        {
            Console.WriteLine("password too short - min 6 chars");
            return false;
        }

        Console.WriteLine("registration successful for " + username);
        return true;
    }

    public static void testRegistration()
    {
        Console.WriteLine("User Registration Tests:\n");

        // valid case
        if(RegisterUser("john123", "john@example.com", "pass1234"))
        {
            Console.WriteLine("Valid registration: PASS");
        }

        // invalid username
        if(!RegisterUser("jo", "test@example.com", "pass1234"))
        {
            Console.WriteLine("Short username test: PASS");
        }

        // invalid email
        if(!RegisterUser("alice", "alice.com", "pass1234"))
        {
            Console.WriteLine("Invalid email test: PASS");
        }

        // short password
        if(!RegisterUser("bob", "bob@example.com", "123"))
        {
            Console.WriteLine("Short password test: PASS");
        }
    }

    public static void Main(string[] args)
    {
        /*
        5. Testing User Registration
        Problem:
        Create a UserRegistration class with:
        * RegisterUser(string username, string email, string password).
        Throws ArgumentException for invalid inputs.
        ✅ Write unit tests to verify valid and invalid user registrations.
        */

        Console.WriteLine("User Registration Tests (manual student style)\n");

        testRegistration();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
