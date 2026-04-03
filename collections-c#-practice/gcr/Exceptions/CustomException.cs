using System;

// our custom exception class
// we inherit from Exception
// this is user-defined exception for invalid age
public class InvalidAgeException : Exception
{
    public InvalidAgeException(string message) : base(message)
    {
        // we can add extra stuff here if needed
    }
}

public class ageCheck 
{
    // this method checks age
    // if age < 18 → throw custom exception
    public static void validateAge(int age)
    {
        if(age < 18)
        {
            // throw our custom exception
            throw new InvalidAgeException("Age must be 18 or above");
        }
        else
        {
            Console.WriteLine("Access granted!");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        3. Creating and Handling a Custom Exception
        💡 Problem Statement:
        * Create a custom exception called InvalidAgeException.
        * Write a method ValidateAge(int age) that throws InvalidAgeException if the age is below 18.
        * In Main(), take user input and call ValidateAge().
        * If an exception occurs, display "Age must be 18 or above".
        Expected Behavior:
        * If the age is >=18, print "Access granted!".
        * If age <18, throw InvalidAgeException and display the message.
        */

        Console.WriteLine("Age Validation with Custom Exception\n");

        while(true)
        {
            Console.Write("Waiting , for user to enter your age : ");
            string ageStr = Console.ReadLine();

            int age = 0;

            if(!int.TryParse(ageStr, out age))
            {
                Console.WriteLine("please enter valid number");
                continue;
            }

            try
            {
                validateAge(age);
                break; // if no exception → exit loop
            }
            catch(InvalidAgeException customEx)
            {
                Console.WriteLine(customEx.Message);
                Console.WriteLine("try again with valid age");
            }
            catch(Exception anyEx)
            {
                Console.WriteLine("some unexpected error : " + anyEx.Message);
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
