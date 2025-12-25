using System;

public static class Cal
{
    public static void Main()
    {
        // asking user for month
        Console.Write("Enter month (1-12): ");
        int m = int.Parse(Console.ReadLine());

        // asking user for year
        Console.Write("Enter year: ");
        int y = int.Parse(Console.ReadLine());

        // getting month name
        string mn = nam(m);

        // getting days in month
        int dm = day(m, y);

        // getting first day of month
        int fd = fst(1, m, y);

        // printing heading
        Console.WriteLine("\n    " + mn + " " + y);
        Console.WriteLine("Sun Mon Tue Wed Thu Fri Sat");

        // calling method to display calendar
        sho(fd, dm);
    }



    // returns name of month
    //  uses array of month names
    //  calendar header needs readable month

    public static string nam(int m)
    {
        string[] arr = { "January","February","March","April", "May","June","July","August","September","October","November","December" };

        // month index is m-1
        return arr[m - 1];
    }

    //  checks leap year
    //  uses leap year rules
    // Feb days depend on this

    public static bool lep(int y)
    {
        if (y % 400 == 0)
            return true;
        else if (y % 100 == 0)
            return false;
        else if (y % 4 == 0)
            return true;
        else
            return false;
    }

    //  returns number of days in month
    // array + leap year check
    //  calendar length depends on this
    public static int day(int m, int y)
    {
        int[] arr = { 31,28,31,30,31,30,31,31,30,31,30,31 };

        // checking for february
        if (m == 2)
        {
            if (lep(y))
                return 29;
            else
                return 28;
        }

        return arr[m - 1];
    }


    //  finds first day of month
    //  Gregorian calendar formula
    //  needed for indentation

    public static int fst(int d, int m, int y)
    {
        // using given formula 
        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (d + x + (31 * m0) / 12) % 7;

        return d0;
    }


    //  prints calendar layout
    //  two for loops
    //  formatting requirement

    static void sho(int fd, int dm)
    {
        int i;

        //  for indentation before day 1
        for (i = 0; i < fd; i++)
        {
            Console.Write("    ");
        }

        // to print all days
        for (int d = 1; d <= dm; d++)
        {
            // printing day with width of 3
            Console.Write(String.Format("{0,3} ", d));

            // moving to next line after saturday
            if ((fd + d) % 7 == 0)
            {
                Console.WriteLine();
            }
        }

        Console.WriteLine();
    }
}
