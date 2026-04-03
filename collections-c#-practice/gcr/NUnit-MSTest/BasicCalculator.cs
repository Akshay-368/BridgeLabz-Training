using System;

public class calc 
{
    public static int add(int a,int b)
    {
        return a + b;
    }

    public static int subtract(int a,int b)
    {
        return a - b;
    }

    public static int multiply(int a,int b)
    {
        return a * b;
    }

    public static double divide(int a,int b)
    {
        if(b == 0)
        {
            throw new DivideByZeroException("cannot divide by zero");
        }
        return (double)a / b;
    }

    // simple test runner (student style - no real NUnit)
    public static void testAll()
    {
        Console.WriteLine("Testing Calculator...\n");

        // test add
        int res1 = add(5,3);
        if(res1 == 8)
        {
            Console.WriteLine("Add(5,3) → 8 : PASS");
        }
        else
        {
            Console.WriteLine("Add test FAIL");
        }

        // test subtract
        int res2 = subtract(10,4);
        if(res2 == 6)
        {
            Console.WriteLine("Subtract(10,4) → 6 : PASS");
        }

        // test multiply
        int res3 = multiply(6,7);
        if(res3 == 42)
        {
            Console.WriteLine("Multiply(6,7) → 42 : PASS");
        }

        // test divide
        try
        {
            double res4 = divide(20,5);
            if(res4 == 4)
            {
                Console.WriteLine("Divide(20,5) → 4 : PASS");
            }
        }
        catch(DivideByZeroException)
        {
            
          Console.WriteLine("Divide by zero test : PASS (exception thrown)");
        }

        try
        {
            divide(10,0);
            Console.WriteLine("divide by zero FAIL (no exception)");
        }
        catch
        {
            Console.WriteLine("divide by zero PASS (caught)");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        1. Basic NUnit Test: Testing a Calculator Class
        Problem:
        Create a Calculator class with methods:
        * Add(int a, int b)
        * Subtract(int a, int b)
        * Multiply(int a, int b)
        * Divide(int a, int b)
        Write NUnit or MSTest test cases for each method.
        👉 Bonus: Test for division by zero and handle exceptions properly.
        */

        Console.WriteLine("Calculator Tests \n");

        testAll();

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
