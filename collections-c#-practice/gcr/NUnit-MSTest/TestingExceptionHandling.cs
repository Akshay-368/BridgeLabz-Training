using System;

public class exTest 
{
    public static double divide(int a,int b)
    {
        if(b == 0)
        {
            throw new ArithmeticException("cannot divide by zero");
        }
        return (double)a / b;
    }

    public static void testDivide()
    {
        try
        {
            double res = divide(10,2);
            Console.WriteLine("10 / 2 = " + res);
        }
        catch(ArithmeticException ae)
        {
            Console.WriteLine("caught divide by zero: " + ae.Message);
        }

        try
        {
            divide(5,0);
            Console.WriteLine("this should not print");
        }
        catch(ArithmeticException ae)
        {
            Console.WriteLine("PASS: divide by zero exception thrown");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        4. Testing Exception Handling
        Problem:
        Create a method Divide(int a, int b) that throws an ArithmeticException if b is zero. 
        Write a unit test to verify that the exception is thrown properly.
        */

        Console.WriteLine("Exception Handling Test\n");

        testDivide();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
