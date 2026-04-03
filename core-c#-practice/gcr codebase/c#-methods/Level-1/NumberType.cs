using System;

public static class NumberType
{
    public static void Main ()
    {
        /*
        5. Write a program to check whether a number is positive, negative, or zero.
        Hint =>
        Get integer input from the user
        Write a Method to return :
        -1 for negative number
        1 for positive number
        0 if the number is zero
        */

        Console.WriteLine ( " Enter an int number : " );
        int num = int.Parse ( Console.ReadLine() ) ;
        

        int r = Fun ( num );
        // Calling the helper method to check whether the number is positive, negative or zero

        if ( r == 1 )
        {
            Console.WriteLine ( " The number is +ve." );
        }
        else if ( r == -1 )
        {
            Console.WriteLine ( " The number is -ve." );
        }
        else
        {
            Console.WriteLine ( " The number is zero." );
        }
    }

    private  static int Fun ( int n )
    {
        // This method checks the nature of the number
        // and returns the required value as per the question
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( n > 0 )
        {
            return 1;
            // Return 1 if the number is positive
        }
        else if ( n < 0 )
        {
            return -1;
            // Return -1 if the number is negative
        }
        else
        {
            return 0;
            // Return 0 if the number is zero
        }
    }
}
