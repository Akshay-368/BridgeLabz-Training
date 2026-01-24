using System;
using System.Collections;

public class warnSup 
{
    public static void testUnchecked()
    {
        // this will give warning about ArrayList is non-generic
#pragma warning disable CS0618 // disable obsolete warning
        ArrayList list = new ArrayList();
#pragma warning restore CS0618

        list.Add(10);
        list.Add("hello");

        Console.WriteLine("first item: " + list[0]);
        Console.WriteLine("second item: " + list[1]);
    }

    public static void Main(string[] args) 
    {
        /*
        Exercise 3: Suppress Warnings for Unchecked Operations
        Problem Statement:
        Create an ArrayList without generics and use #pragma warning disable to hide compilation warnings.
        */

        Console.WriteLine("Suppress Warnings Demo (ArrayList)\n");

        testUnchecked();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
