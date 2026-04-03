using System;

public static class NumChk2
{
    public static void Main ()
    {
        /*
        3.  Extend or Create a NumberChecker utility class and perform the following task. Call from the main() method
        the different methods and display results. Make sure all are static methods
        Hint => 
        a.  Method to find the count of digits in the number and a Method to Store the digits of the number in a digits array
        b.  Method to find the sum of the digits of a number using the digits array
        c. Method to find the sum of the squares of the digits of a number using the digits array. Use Math.Pow() method
        d. Method to Check if a number is a Harshad number using a digits array. A number is called a Harshad number if it is divisible by the sum of its digits. For e.g. 21
        e.Method to find the frequency of each digit in the number. Create a 2D array to store the frequency with digit in the first column and frequency in the second column.
        */

        Console.WriteLine ( " Enter a number : " );
        int n = int.Parse ( Console.ReadLine () );

        int c = cnt ( n );
        // Count of digits

        int[] d = dig ( n , c );
        // Storing digits in array

        Console.WriteLine ( " Digits are : " );
        for ( int i = 0 ; i < d.Length ; i++ )
        {
            Console.Write ( d[i] + " " );
        }
        Console.WriteLine ();

        int s = sum ( d );
        double sq = sumSq ( d );
        bool h = isHar ( n , d );

        Console.WriteLine ( " Sum of digits : " + s );
        Console.WriteLine ( " Sum of squares of digits : " + sq );
        Console.WriteLine ( " Harshad Number : " + h );

        int[][] f = freq ( d );
        // Getting frequency of digits

        Console.WriteLine ( " Digit Frequency : " );
        for ( int i = 0 ; i < f.Length ; i++ )
        {
            if ( f[i][1] > 0 )
            {
                Console.WriteLine ( " Digit " + f[i][0] + " is " + f[i][1] );
            }
        }
    }

    public static int cnt ( int n )
    {
        // Method to count digits

        int c = 0;
        int t = n;

        while ( t != 0 )
        {
            c = c + 1;
            t = t / 10;
        }

        return c;
    }

    public static int[] dig ( int n , int c )
    {
        // Method to store digits in array

        int[] a = new int[c];
        int t = n;

        for ( int i = c - 1 ; i >= 0 ; i-- )
        {
            a[i] = t % 10;
            t = t / 10;
        }

        return a;
    }

    public static int sum ( int[] a )
    {
        // Method to find sum of digits

        int s = 0;

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            s = s + a[i];
        }

        return s;
    }

    public static double sumSq ( int[] a )
    {
        // Method to find sum of squares of digits

        double s = 0;

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            s = s + Math.Pow ( a[i] , 2 );
        }

        return s;
    }

    public static bool isHar ( int n , int[] a )
    {
        // Harshad number check
        // Number divisible by sum of its digits

        int s = sum ( a );

        if ( s == 0 )
        {
            return false;
        }

        if ( n % s == 0 )
        {
            return true;
        }

        return false;
    }

    private static int[][] freq ( int[] a )
    {
        // Method to find frequency of each digit
        // Using 2D array to store digit | frequency
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int[][] f = new int[10][];

        for ( int i = 0 ; i < 10 ; i++ )
        {
            f[i] = new int[2];
            f[i][0] = i;   // digit
            f[i][1] = 0;   // frequency
        }

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            int d = a[i];
            f[d][1] = f[d][1] + 1;
        }

        return f;
    }
}
