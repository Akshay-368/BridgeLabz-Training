using System;

public static class NumChk4
{
    public static void Main ()
    {
        /*
        5. Extend or Create a NumberChecker utility class and perform the following task.
        Call from the main() method the different methods and display results. Make sure all are static methods
        Hint => 
        a.  Method to Check if a number is a prime number. A prime number is a number greater than 1 that has no positive divisors other than 1 and itself. 
        b.  Method to Check if a number is a neon number. A neon number is a number where the sum of digits of the square of the number is equal to the number itself 
        c.  Method to Check if a number is a spy number. A number is called a spy number if the sum of its digits is equal to the product of its digits
        d.  Method to Check if a number is an automorphic number. An automorphic number is a number whose square ends with the number itself. E.g. 5 is an automorphic number
        e.  Method to Check if a number is a buzz number. A buzz number is a number that is either divisible by 7 or ends with 7
        */

        Console.WriteLine ( " Enter a number : " );
        int n = int.Parse ( Console.ReadLine () );

        bool p = isPri ( n );
        bool ne = isNeo ( n );
        bool sp = isSpy ( n );
        bool au = isAuto ( n );
        bool bz = isBuzz ( n );

        Console.WriteLine ( " Prime Number : " + p );
        Console.WriteLine ( " Neon Number : " + ne );
        Console.WriteLine ( " Spy Number : " + sp );
        Console.WriteLine ( " Automorphic Number : " + au );
        Console.WriteLine ( " Buzz Number : " + bz );
    }

    private static bool isPri ( int n )
    {
        // Prime number check
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( n <= 1 )
        {
            return false;
        }

        for ( int i = 2 ; i <= n / 2 ; i++ )
        {
            if ( n % i == 0 )
            {
                return false;
            }
        }

        return true;
    }

    public static bool isNeo ( int n )
    {
        // Neon number check
        // Sum of digits of square == number

        int sq = n * n;
        int s = 0;

        while ( sq != 0 )
        {
            s = s + ( sq % 10 );
            sq = sq / 10;
        }

        if ( s == n )
        {
            return true;
        }

        return false;
    }

    public static bool isSpy ( int n )
    {
        // Spy number check
        // Sum of digits == product of digits

        int s = 0; // this is the current sum we are starting off with
        int p = 1; // this is the current product we are starting off with
        int t = n; // storing the original number in a backup variable

        while ( t != 0 )
        {
            // We are going to divide the number by 10 and keep on adding the last digit to the sum and multiplying the last digit to the product
            int d = t % 10;
            s = s + d;
            p = p * d;
            t = t / 10;
        }

        if ( s == p )
        {
            // If the sum of digits is equal to the product of digits, it's a spy number
            return true;
        }

        return false;
    }

    public static bool isAuto ( int n )
    {
        // Automorphic number check
        // Square ends with the number itself

        int sq = n * n;
        int t = n; // storing it in a backup variable

        while ( t != 0 )
        {
            if ( sq % 10 != t % 10 )
            {
                // If any digit doesn't match, it's not an automorphic number
                // we check from the end of the digits in this loop
                return false;
            }

            sq = sq / 10;
            t = t / 10;
        }

        return true;
    }

    public static bool isBuzz ( int n )
    {
        // Buzz number check
        // Divisible by 7 or ends with 7

        if ( n % 7 == 0 || n % 10 == 7 )
        {
            // if not divisble by 7 or ends with 7, it's not a buzz number and we return false otherwise we return true
            return true;
        }

        return false;
    }
}
