using System;

public class divError 
{
    // this function takes two numbers from user and divides
    // handle divide by zero and wrong input format
    public static void divideTwoNumbers()
    {
        int num1 = 0;
        int num2 = 0;

        // get first number
        while(true)
        {
            Console.Write("Waiting , for user to enter first number : ");
            string input1 = Console.ReadLine();

            if(int.TryParse(input1, out num1))
            {
                break;
            }
            else
            {
                Console.WriteLine("that's not a number , please enter valid integer");
            }
        }

        // get second number
        while(true)
        {
            Console.Write("Waiting , for user to enter second number : ");
            string input2 = Console.ReadLine();

            if(int.TryParse(input2, out num2))
            {
                break;
            }
            else
            {
                Console.WriteLine("that's not a number , please enter valid integer");
            }
        }

        try
        {
            // try division
            int result = num1 / num2;
            Console.WriteLine("Result: " + num1 + " / " + num2 + " = " + result);
        }
        catch(DivideByZeroException dbz)
        {
            // this happens when num2 is 0
            Console.WriteLine("Cannot divide by zero !");
            Console.WriteLine("(error details: " + dbz.Message + ")");
        }
        catch(Exception anyEx)
        {
            // just in case something else happens
            Console.WriteLine("some unexpected error : " + anyEx.Message);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        2. Handling Division and Input Errors
        💡 Problem Statement:
        Write a C# program that asks the user to enter two numbers and divides them. 
        Handle possible exceptions such as:
        * DivideByZeroException if division by zero occurs.
        * FormatException if the user enters a non-numeric value.
        Expected Behavior:
        * If the user enters valid numbers, print the result of the division.
        * If the user enters 0 as the denominator, catch and handle DivideByZeroException.
        * If the user enters a non-numeric value, catch and handle FormatException.
        */

        Console.WriteLine("Division Calculator with Error Handling\n");

        Console.WriteLine("enter two numbers , program will divide them");
        Console.WriteLine("will handle divide by zero & wrong input\n");

        divideTwoNumbers();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
