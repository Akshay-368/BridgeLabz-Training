using System;
public static class TimeZone
{
    public static void Main()
    {
        /* 2. Problem 2: Date Arithmetic
        Create a program that:
        ● Takes a date input and adds 7 days, 1 month, and 2 years to it.
        ● Then subtracts 3 weeks from the result.
        Hint: Use DateTime.AddDays(), DateTime.AddMonths(), DateTime.AddYears(),
        and DateTime.AddWeeks() methods. */

        DateTime date = new DateTime(2023, 1, 1);
        DateTime nd = date.AddDays(7).AddMonths(1).AddYears(2).AddWeeks(-3);
        Console.WriteLine(nd);
        
        
    }
}
