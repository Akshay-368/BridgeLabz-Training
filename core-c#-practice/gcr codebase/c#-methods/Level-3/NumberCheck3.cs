using System;

public static class NumChk3
{
    public static void Main ()
    {
        /*
        4.  Extend or Create a NumberChecker utility class and perform the following task.
        Call from the main() method the different methods and display results. Make sure all are static methods
        Hint => 
        a.  Method to find the count of digits in the number and a Method to Store the digits of the number in a digits array
        b.  Method to reverse the digits array 
        c. Method to compare two arrays and check if they are equal
        d.Method to check if a number is a palindrome using the Digits. A palindrome number is a number that remains the same when its digits are reversed. 
        e.  Method to Check if a number is a duck number using the digits array. A duck number is a number that has a non-zero digit present in it
        */

        Console.WriteLine ( " Enter a number : " );
        int n = int.Parse ( Console.ReadLine () );

        int c = cnt ( n );
        // Counting digits

        int[] d1 = dig ( n , c );
        // Original digits array

        int[] d2 = rev ( d1 );
        // Reversed digits array

        Console.WriteLine ( " Original digits : " );
        show ( d1 );

        Console.WriteLine ( " Reversed digits : " );
        show ( d2 );

        bool eq = cmp ( d1 , d2 );
        // Comparing both arrays

        bool pal = isPal ( d1 , d2 );
        bool duck = isDuck ( d1 );

        Console.WriteLine ( " Palindrome Number : " + pal );
        Console.WriteLine ( " Duck Number : " + duck );
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

    public static int[] rev ( int[] a )
    {
        // Method to reverse digits array

        int[] r = new int[a.Length];
        int j = 0; // which will work as an index for the rev array we will create

        for ( int i = a.Length - 1 ; i >= 0 ; i-- )
        {
            // Going from the end of the original array we will copy the elements to the reversed array
            r[j] = a[i];
            j = j + 1;
        }

        return r; // Returning the reversed array
    }

    public static bool cmp ( int[] a , int[] b )
    {
        // Method to compare two arrays
        // we coulbe be Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( a.Length != b.Length )
        {
            // Checking their length if it is equal or not
            return false;
        }

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            // Just doing a simple comparision from the array elements of both arrays , compairing them one by one and if any of them are not equal then we return false
            if ( a[i] != b[i] )
            {
                return false;
            }
        }

        return true;
    }

    public static bool isPal ( int[] a , int[] b )
    {
        // Palindrome check using digit arrays

        bool r = cmp ( a , b );
        return r;
    }

    public static bool isDuck ( int[] a )
    {
        // Duck number means at least one zero digit present

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            // Traversing through the array from the start to end
            if ( a[i] == 0 )
            {
                // If we found a zero digit then return with a true
                return true;
            }
        }

        return false; // else false , as this condition will only run if the array does not contain any zero digit
    }

    public static void show ( int[] a )
    {
        // Method to display array elements

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            Console.Write ( a[i] + " " );
        }
        Console.WriteLine ();
    }
}
