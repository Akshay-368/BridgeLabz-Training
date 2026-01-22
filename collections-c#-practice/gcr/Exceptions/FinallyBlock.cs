using System;

public class finallyDemo 
{
    // simple division function
    public static void doDivision()
    {
        Console.Write("Waiting , for user to enter first number : ");
        int a = Convert.ToInt32(Console.ReadLine());

        Console.Write("Waiting , for user to enter second number : ");
        int b = Convert.ToInt32(Console.ReadLine());

        try
        {
            int result = a / b;
            Console.WriteLine("Division result: " + result);
        }
        catch(DivideByZeroException dbz)
        {
            Console.WriteLine("Cannot divide by zero!");
            Console.WriteLine("(details: " + dbz.Message + ")");
        }
        finally
        {
            // this always runs - even if error or no error
            Console.WriteLine("Operation completed");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        7. Demonstrating finally Block Execution
        💡 Problem Statement:
        Write a program that performs integer division and demonstrates the finally block execution.
        * The program should:
          * Take two integers from the user.
          * Perform division.
          * Handle DivideByZeroException (if dividing by zero).
          * Ensure "Operation completed" is always printed using finally.
        Expected Behavior:
        * If valid, print the result.
        * If an exception occurs, handle it and still print "Operation completed".
        */

        Console.WriteLine("Division with finally block demo\n");

        doDivision();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
