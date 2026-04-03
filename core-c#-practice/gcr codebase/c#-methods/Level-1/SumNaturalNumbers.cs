using System;

class SumNaturalNumbers
{
    public static void Main ()
    {
        /*
        7. Write a program to find the sum of n natural numbers using loop.
        Hint =>
        Get integer input from the user
        Write a Method to find the sum of n natural numbers using loop
        */

        Console.WriteLine ( " Enter the value of n : " );
        int n = int.Parse ( Console.ReadLine() );
        // Taking input from the user for the number until which
        // natural numbers should be added

        int result = Fun ( n );
        // Calling the method which finds the sum
        // and stores the ans value in result variable to help us print the result later

        Console.WriteLine ( " The sum of first " + n + " natural numbers is : " + result );
    }

    private static int Fun ( int n )
    {
        // This method finds the sum of first n natural numbers
        // using a loop
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int sum = 0 ;
        // Initializing sum variable to 0
        // This variable will store the running total

        for ( int i = 1 ; i <= n ; i++ )
        {
            sum = sum + i ;
            // Adding the current value of i to sum
            // This loop runs from 1 to n to help us find the sum of the n natural numbers as per question
        }

        return sum ;
        // Return the sum we find
    }
}
