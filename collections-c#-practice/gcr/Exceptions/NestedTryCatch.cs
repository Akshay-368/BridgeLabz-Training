using System;

public class nestTry 
{
    public static void nestedTryExample(int[] arr,int index,int divisor)
    {
        try
        {
            // inner try - check array index
            try
            {
                int value = arr[index];
                Console.WriteLine("value at index " + index + " : " + value);

                // now divide
                int result = value / divisor;
                Console.WriteLine("division result : " + result);
            }
            catch(IndexOutOfRangeException ioor)
            {
                Console.WriteLine("Invalid array index!");
            }
            catch(DivideByZeroException dbz)
            {
                Console.WriteLine("Cannot divide by zero!");
            }
        }
        catch(Exception any)
        {
            Console.WriteLine("some outer error : " + any.Message);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        9. Using Nested try-catch Blocks
        💡 Problem Statement:
        Write a C# program that:
        * Takes an array and a divisor as input.
        * Tries to access an element at an index.
        * Tries to divide that element by the divisor.
        * Uses nested try-catch to handle:
          * IndexOutOfRangeException if the index is invalid.
          * DivideByZeroException if the divisor is zero.
        Expected Behavior:
        * If valid, print the division result.
        * If the index is invalid, catch and display "Invalid array index!".
        * If division by zero, catch and display "Cannot divide by zero!".
        */

        Console.WriteLine("Nested try-catch Demo\n");

        int[] numbers = {10, 20, 30, 40, 50};

        Console.Write("Waiting , for user to enter index (0 to 4) : ");
        int idx = Convert.ToInt32(Console.ReadLine());

        Console.Write("Waiting , for user to enter divisor : ");
        int div = Convert.ToInt32(Console.ReadLine());

        nestedTryExample(numbers , idx , div);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
