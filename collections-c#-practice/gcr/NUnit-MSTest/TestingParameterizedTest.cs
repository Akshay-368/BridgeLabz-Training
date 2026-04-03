using System;

public class evenTest 
{
    public static bool isEven(int num)
    {
        return num % 2 == 0;
    }

    public static void testEven()
    {
        int[] testValues = {2, 4, 6, 7, 9};

        foreach(int val in testValues)
        {
            bool result = isEven(val);
            Console.WriteLine(val + " is even? " + result);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        6. Testing Parameterized Tests
        Problem:
        Create a method IsEven(int number) that returns true if a number is even.
        Use NUnit [TestCase] or MSTest [DataRow] to test this method with multiple values like 2, 4, 6, 7, 9.
        */

        Console.WriteLine("Parameterized Even Test ");

        testEven();

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
