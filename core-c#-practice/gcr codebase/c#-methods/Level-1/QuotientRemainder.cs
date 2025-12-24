using System;

public static class QuotientRemainder
{
    public static void Main ()
    {
        /*
        9. Write a program to take 2 numbers and print their quotient and remainder.
        Hint =>
        Take user input as integer
        Use division operator (/) for quotient
        Use moduli operator (%) for remainder
        Write a method to find the remainder and the quotient of a number
        */

        Console.WriteLine ( " Enter the first number ( dividend ) : " );
        int number = int.Parse ( Console.ReadLine() );
        // Taking the first integer input from the user
        // This will be the number to be divided

        Console.WriteLine ( " Enter the second number ( divisor ) : " );
        int divisor = int.Parse ( Console.ReadLine() );
        // Taking the second integer input from the user
        // This will be the number by which division is done

        int[] result = Find ( number , divisor );
        // Calling the method which returns an integer array
        // result[0] contains the quotient
        // result[1] contains the remainder
        // Since the variable caling the method is an array of int , we need a method to retun int array ( that is in[] ) as well and not just simple int
        // SInce the method returns an integer array, we can directly access the elements
        // The method should take the int values and return int array

        Console.WriteLine ( " Quotient is : " + result[0] );
        Console.WriteLine ( " Remainder is : " + result[1] );
    }

    public static int[] Find ( int number , int divisor )
    {
        // This method finds quotient and remainder of a number-dividend divided by a divisor


        int quotient = number / divisor;
        // Using division operator (/) to get the quotient

        int remainder = number % divisor;
        // Using moduli operator (%) to get the remainder

        int[] arr = new int[2];
        // Creating an integer array of size 2
        // arr[0] will store quotient
        // arr[1] will store remainder

        arr[0] = quotient;
        arr[1] = remainder;

        return arr;
        // Returning the array which contains quotient and remainder
    }
}
