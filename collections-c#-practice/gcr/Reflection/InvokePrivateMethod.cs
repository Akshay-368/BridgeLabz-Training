using System;
using System.Reflection;

public class calcPriv 
{
    public class Calculator
    {
        private int multiply(int a,int b)
        {
            return a * b;
        }
    }

    public static void invokePrivateMethod()
    {
        Calculator calc = new Calculator();

        // get private method
        MethodInfo mulMethod = typeof(Calculator).GetMethod("multiply", BindingFlags.NonPublic | BindingFlags.Instance);

        if(mulMethod != null)
        {
            // invoke it
            object result = mulMethod.Invoke(calc, new object[] {5, 7});

            Console.WriteLine("5 * 7 = " + result);
        }
        else
        {
            Console.WriteLine("multiply method not found");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        3. Invoke Private Method: Define a class Calculator with a private method Multiply(int a, int b). Use Reflection to invoke this method and display the result.
        */

        Console.WriteLine("Invoke Private Method using Reflection\n");

        invokePrivateMethod();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
