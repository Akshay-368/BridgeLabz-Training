using System;
public static class DateComparision
{
    public static void Main()
    {
        /* 4. Problem 4: Date Comparison
        Write a program that:
        ● Takes two date inputs and compares them to check if the first date is
        before, after, or the same as the second date.

        Hint: Use DateTime.Compare(), DateTime.CompareTo(), or direct comparison
        using DateTime methods. */

        DateTime d1 = DateTime.Parse(Console.ReadLine());
        DateTime d2 = DateTime.Parse(Console.ReadLine());
        Console.WriteLine(d1.CompareTo(d2)); // here CompareTo () is an instance method
        int r = DateTime.Comparer(d1 , d2); // While Compare() is a static method

        if (r < 0)
        {
            Console.WriteLine ( " The first date - {0} is before the second date : {1}." , d1, d2 ) ;
        }
        else if (r > 0)
        {
            Console.WriteLine ( $" The first date -{d1} is after the second date - {d2}. " ) ;
        }
        else
        {
            Console.WriteLine ( "Both dates are the same. ");
        }

        
    }
}
