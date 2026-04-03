using System;

public class LeapYear
{
    public static void Main ()
    {
        /*
        Q3. Program to check whether a given year is a Leap Year or not
        Conditions :
        1. Year must be greater than or equal to 1582 (Gregorian calendar)
        2. Leap year is divisible by 4 and not divisible by 100 OR divisible by 400
        */

        Console.WriteLine ( " Enter a year : " );
        int y = int.Parse ( Console.ReadLine () );
        // Getting a year input from user and then converting it to int

        bool res = chk ( y );
        // Calling the helper method to check leap year condition

        if ( res == true )
        {
            Console.WriteLine ( " Year is a Leap Year " );
        }
        else
        {
            Console.WriteLine ( " Year is NOT a Leap Year " );
        }
    }

    private static bool chk ( int y )
    {
        // This method checks whether the given year is a Leap Year or not
        // Returning true if leap year else returning false
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( y < 1582 )
        {
            // Gregorian calendar starts from year 1582 thus we can't have any year before that into consideration
            return false;
        }

        if ( ( y % 4 == 0 && y % 100 != 0 ) || ( y % 400 == 0 ) )
        {
            return true;
            // Leap year condition satisfied
        }
        else
        {
            return false;
            // Leap year condition not satisfied
        }
    }
}
