

using System;

public class progam
{
    public static void Main(string[] args)
    {
        /*


        4. Demonstrate NullReferenceException

        Hint => 

        - Write a method to demonstrate NullReferenceException by accessing a method on a null string.

        - Use a try-catch block to handle the exception.
        */

        // only the char part here , for separate demo

        Console.WriteLine("Waiting , for user to enter the inupt string");
        string txt = Console.ReadLine();

        char[] cus = makc(txt);

        Console.WriteLine("Chars from my function :");
        foreach (char c in cus)
        {
            Console.Write(c);
            Console.Write(',');
        }
        Console.WriteLine();

        // compare with real one
        if (txt.ToCharArray().Length == cus.Length)
            Console.WriteLine("Lengths match , probably correct");
        else
            Console.WriteLine("Lengths dont match , bug somewhere");
    }

    public static char[] makc(string str)
    {
        // manual way to get all chars
        char[] arr = new char[str.Length];
        int pos = 0;

        while (pos < str.Length)
        {
            arr[pos] = str[pos];
            pos = pos + 1;
        }

        return arr;
    }
}
