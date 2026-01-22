using System;

public class propEx 
{
    // method 1 - throws exception
    public static void method1()
    {
        Console.WriteLine("inside method1 - about to divide by zero");
        int result = 10 / 0; // this will throw ArithmeticException
    }

    // method 2 - calls method1 , no catch here
    public static void method2()
    {
        Console.WriteLine("inside method2 - calling method1");
        method1();
    }

    public static void Main(string[] args) 
    {
        /*
        8. Propagating Exceptions Across Methods
        💡 Problem Statement:
        Create a C# program with three methods:
        1. Method1(): Throws an ArithmeticException (10 / 0).
        2. Method2(): Calls Method1().
        3. Main(): Calls Method2() and handles the exception.
        Expected Behavior:
        * The exception propagates from Method1() → Method2() → Main().
        * Catch and handle it in Main(), printing "Handled exception in Main".
        */

        Console.WriteLine("Exception Propagation Demo\n");

        try
        {
            Console.WriteLine("in Main - calling method2");
            method2();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Handled exception in Main");
            Console.WriteLine("Error was: " + ex.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
