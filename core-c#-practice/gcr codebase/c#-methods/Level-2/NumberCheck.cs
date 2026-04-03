using System;

public static class NumberCheck
{
    public static void Main ()
    {
        /* Q9.
        Write a program to take user input for 5 numbers and check whether a number
        is positive or negative. Further for positive numbers check if the number
        is even or odd. Finally compare the first and last elements of the array.
        */

        int[] arr = new int[5];
        // Array to store 5 numbers

        for ( int i = 0 ; i < arr.Length ; i++ )
        {
            Console.WriteLine ( " Enter number " + ( i + 1 ) + " : " );
            arr[i] = int.Parse ( Console.ReadLine() );
            // Taking input from user and storing in array
        }

        Console.WriteLine ( " Checking numbers : " );

        for ( int i = 0 ; i < arr.Length ; i++ )
        {
            int res = isPos ( arr[i] );
            // Checking whether number is positive or negative

            if ( res == 1 )
            {
                int ev = isEven ( arr[i] );
                // Number is positive, so now checking even or odd

                if ( ev == 1 )
                {
                    Console.WriteLine ( arr[i] + " is Positive and Even" );
                }
                else
                {
                    Console.WriteLine ( arr[i] + " is Positive and Odd" );
                }
            }
            else
            {
                Console.WriteLine ( arr[i] + " is Negative" );
            }
        }

        int cmp = cmpNum ( arr[0] , arr[arr.Length - 1] );
        // Comparing the first and the last element of array

        if ( cmp == 1 )
        {
            Console.WriteLine ( " First element is Greater than last element" );
        }
        else if ( cmp == 0 )
        {
            Console.WriteLine ( " First and last elements are Equal" );
        }
        else
        {
            Console.WriteLine ( " First element is Less than last element" );
        }
    }

    private static int isPos ( int n )
    {
        // Method to check if the given number is positive or negative
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( n >= 0 )
        {
            return 1;
            // Returning 1 for positive number
        }
        else
        {
            return -1;
            // Returning -1 for negative number
        }
    }

    private static int isEven ( int n )
    {
        // Method to check if num is even or odd
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( n % 2 == 0 )
        {
            return 1;
            // Returning 1 for even
        }
        else
        {
            return 0;
            // Returning 0 for odd
        }
    }

    private static int cmpNum ( int a , int b )
    {
        // Method to compare two nos.
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( a > b )
        {
            return 1;
            // a is greater than b
        }
        else if ( a == b )
        {
            return 0;
            // both are equal
        }
        else
        {
            return -1;
            // a is less than b
        }
    }
}
