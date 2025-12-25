using System;

public class NumChk
{
    public static void Main ()
    {
        /*
        2. Extend or Create a NumberChecker utility class and perform the following task. Call from the main() method
        the different methods and display results. Make sure all are static methods
        Hint =>
        a.  Method to Find the count of digits in the number
        b. Method to Store the digits of the number in a digits array
        c. Method to Check if a number is a duck number using the digits array. A duck number is a number that has a non-zero digit present in it
        d. Method to check if the number is an armstrong number using the digits array. ​​Armstrong number is a number that is equal to the
        sum of its own digits raised to the power of the number of digits. Eg: 153 = 1^3 + 5^3 + 3^3
        e.  Method to find the largest and second largest elements in the digits array. Use Int32.MinValue to initialize the variable.
        f.  Method to find the smallest and second smallest elements in the digits array. Use Int32.MaxValue to initialize the variable.
        */

        Console.WriteLine ( " Enter a number : " );
        int n = int.Parse ( Console.ReadLine () );
        // Taking input number from user

        int cnt = cntDig ( n );
        // Counting digits

        int[] dig = getDig ( n , cnt );
        // Storing digits in array

        Console.WriteLine ( " Digits are : " );
        for ( int i = 0 ; i < dig.Length ; i++ )
        {
            Console.Write ( dig[i] + " " );
        }
        Console.WriteLine ();

        bool duck = isDuck ( dig );
        bool arm = isArm ( dig , cnt );

        Console.WriteLine ( " Digit count : " + cnt );
        Console.WriteLine ( " Duck Number : " + duck );
        Console.WriteLine ( " Armstrong Number : " + arm );

        int[] lg = big ( dig );
        Console.WriteLine ( " Largest digit : " + lg[0] );
        Console.WriteLine ( " Second largest digit : " + lg[1] );

        int[] sm = sml ( dig );
        Console.WriteLine ( " Smallest digit : " + sm[0] );
        Console.WriteLine ( " Second smallest digit : " + sm[1] );
    }

    private static int cntDig ( int n )
    {
        // Method to count digits
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int c = 0;
        int t = n;

        while ( t != 0 )
        {
            c = c + 1;
            t = t / 10;
        }

        return c;
    }

    public static int[] getDig ( int n , int c )
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

    private static bool isDuck ( int[] a )
    {
        // Duck number means at least one zero digit present
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            if ( a[i] == 0 )
            {
                return true;
            }
        }

        return false;
    }

    public static bool isArm ( int[] a , int c )
    {
        // Armstrong number check

        int s = 0;

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            s = s + ( int.Parse ( Math.Pow ( a[i] , c ).ToString() ) );
            // Using Math.Pow and then converting double to int
        }

        int num = 0;
        for ( int i = 0 ; i < a.Length ; i++ )
        {
            num = num * 10 + a[i];
        }

        if ( s == num )
        {
            return true;
        }

        return false;
    }

    public static int[] big ( int[] a )
    {
        // Method to find largest and second largest digit

        int mx1 = Int32.MinValue;  // -2147483648 , equivalent to -2^31
        int mx2 = Int32.MinValue; // This MinValue is a constant defined in C# in System32 and is the smallest value possible that a 32‑bit signed integer can hold.

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            if ( a[i] > mx1 )
            {
                mx2 = mx1;
                mx1 = a[i];
            }
            else if ( a[i] > mx2 && a[i] != mx1 )
            {
                mx2 = a[i];
            }
        }

        int[] r = new int[2];
        r[0] = mx1;
        r[1] = mx2;

        return r;
    }

    private static int[] sml ( int[] a )
    {
        // Method to find smallest and second smallest digit
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int mn1 = Int32.MaxValue; // 2147483647  equivalent  to 2^{31} - 1
        int mn2 = Int32.MaxValue; // This MaxValue is a constant defined in C# in System32 and is the largest value possible that a 32‑bit signed integer can hold.

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            if ( a[i] < mn1 )
            {
                mn2 = mn1;
                mn1 = a[i];
            }
            else if ( a[i] < mn2 && a[i] != mn1 )
            {
                mn2 = a[i];
            }
        }

        int[] r = new int[2];
        r[0] = mn1;
        r[1] = mn2;

        return r;
    }
}
