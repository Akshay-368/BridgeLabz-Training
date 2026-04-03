using System;
public static class DateFormatting
{
    public static void Main()
    {
        /* 3. Problem 3: Date Formatting
        Write a program that:
        ● Displays the current date in three different formats:
        o dd/MM/yyyy
        o yyyy-MM-dd
        o EEE, MMM dd, yyyy
        Hint: Use DateTime.ToString() with custom date format strings. */

        console.WriteLine(DateTime.Now.ToString("dd/MM/yyyy"));
        console.WriteLine(DateTime.Now.ToString("yyyy-MM-dd"));
        console.WriteLine(DateTime.Now.ToString("EEE, MMM dd, yyyy"));
        
        
        
    }
}
