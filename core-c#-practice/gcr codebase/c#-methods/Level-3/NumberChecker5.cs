using System;

public class NumChk5
{
    public static void Main ()
    {
        /*
        6.  Extend or Create a NumberChecker utility class and perform the following task. Call from the main() method the different methods and display results. Make sure all are static methods
        Hint => 
        a. Method to find factors of a number and return them as an array. Note there are 2 for loops one for the count and another for finding the factor and storing in the array
        b. Method to find the greatest factor of a Number using the factors array
        c. Method to find the sum of the factors using factors array and return the sum
        d. Method to find the product of the factors using factors array and return the product
        e. Method to find product of cube of the factors using the factors array. Use Math.Pow() 
        f. Method to Check if a number is a perfect number. Perfect numbers are positive integers that are equal to the sum of their proper divisors
        g.  Method to find the number is an abundant number. A number is called an abundant number if the sum of its proper divisors is greater than the number itself
        h.Method to find the number is a deficient number. A number is called a deficient number if the sum of its proper divisors is less than the number itself
        i. Method to Check if a number is a strong number. A number is called a strong number if the sum of the factorial of its digits is equal to the number itself
        */

        Console.WriteLine ( " Enter a number : " );
        int n = int.Parse ( Console.ReadLine () );

        int[] f = getFac ( n );

        int g = getMax ( f );
        int s = getSum ( f );
        int p = getPro ( f );
        double c = getCub ( f );

        bool per = isPer ( n , f );
        bool abu = isAbu ( n , f );
        bool def = isDef ( n , f );
        bool str = isStr ( n );

        Console.WriteLine ( " Factors : " );
        for ( int i = 0 ; i < f.Length ; i++ )
        {
            Console.Write ( f[i] + " " );
        }

        Console.WriteLine ();
        Console.WriteLine ( " Greatest Factor : " + g );
        Console.WriteLine ( " Sum of Factors : " + s );
        Console.WriteLine ( " Product of Factors : " + p );
        Console.WriteLine ( " Product of Cube of Factors : " + c );

        Console.WriteLine ( " Perfect Number : " + per );
        Console.WriteLine ( " Abundant Number : " + abu );
        Console.WriteLine ( " Deficient Number : " + def );
        Console.WriteLine ( " Strong Number : " + str );
    }

    private static int[] getFac ( int n )
    {
        // First loop → count factors
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int c = 0;

        for ( int i = 1 ; i <= n ; i++ )
        {
            if ( n % i == 0 )
            {
                c++;
            }
        }

        // Create array with exact size
        int[] f = new int[c];
        int j = 0;

        // Second loop → store factors
        for ( int i = 1 ; i <= n ; i++ )
        {
            if ( n % i == 0 )
            {
                f[j] = i;
                j++;
            }
        }

        return f;
    }

    public static int getMax ( int[] f )
    {
        int m = Int32.MinValue;

        for ( int i = 0 ; i < f.Length ; i++ )
        {
            if ( f[i] > m )
            {
                m = f[i];
            }
        }

        return m;
    }

    public static int getSum ( int[] f )
    {
        int s = 0;

        for ( int i = 0 ; i < f.Length ; i++ )
        {
            s = s + f[i];
        }

        return s;
    }

    public static int getPro ( int[] f )
    {
        int p = 1;

        for ( int i = 0 ; i < f.Length ; i++ )
        {
            p = p * f[i];
        }

        return p;
    }

    public static double getCub ( int[] f )
    {
        double p = 1;

        for ( int i = 0 ; i < f.Length ; i++ )
        {
            p = p * Math.Pow ( f[i] , 3 );
        }

        return p;
    }

    public static bool isPer ( int n , int[] f )
    {
        // Sum of proper divisors == number

        int s = 0;

        for ( int i = 0 ; i < f.Length - 1 ; i++ )
        {
            s = s + f[i];
        }

        return s == n;
    }

    public static bool isAbu ( int n , int[] f )
    {
        int s = 0;

        for ( int i = 0 ; i < f.Length - 1 ; i++ )
        {
            s = s + f[i];
        }

        return s > n;
    }

    public static bool isDef ( int n , int[] f )
    {
        int s = 0;

        for ( int i = 0 ; i < f.Length - 1 ; i++ )
        {
            s = s + f[i];
        }

        return s < n;
    }

    public static bool isStr ( int n )
    {
        // Strong number
        // Sum of factorial of digits == number

        int t = n;
        int s = 0;

        while ( t != 0 )
        {
            int d = t % 10;
            s = s + getFacD ( d );
            t = t / 10;
        }

        return s == n;
    }

    public static int getFacD ( int d )
    {
        int f = 1;

        for ( int i = 1 ; i <= d ; i++ )
        {
            f = f * i;
        }

        return f;
    }
}
