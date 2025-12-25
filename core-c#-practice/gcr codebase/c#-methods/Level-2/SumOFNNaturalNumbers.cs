using System;

public class SumOfNaturalNumbers
{
    public static void Main ()
    {
        /*
        Q2. Write a program to find the sum of n natural numbers using recursive method and compare the result with the formulae n*(n+1)/2
        and show the result from both computations is correct. 
        Hint => 
        a. Take the user input number and check whether it's a Natural number, if not exit
        b.Write a Method to find the sum of n natural numbers using recursion
        c.  Write a Method to find the sum of n natural numbers using the formulae   n*(n+1)/2 
        d.Compare the two results and print the result
        */

        Console.WriteLine ( " Enter a natural number : " );
        int n = int.Parse ( Console.ReadLine () );
        // Getting input from user and converting it to inte

        if ( n <= 0 )
        {
            // Natural numbers start from 1
            Console.WriteLine ( " Not a natural number. " );
            return;
        }

        int s1 = rec ( n );
        // Calling recursive helper method to find sum

        int s2 = frm ( n );
        // Calling formula method to find sum

        Console.WriteLine ( " Sum using recursion : " + s1 );
        Console.WriteLine ( " Sum using formula   : " + s2 );

        if ( s1 == s2 )
        {
            Console.WriteLine ( " Both results are SAME and CORRECT " );
        }
        else
        {
            Console.WriteLine ( " Results are DIFFERENT " );
        }
    }

    private static int rec ( int n )
    {
        // Recursive method to find sum of n natural numbers
        // Base case : if n == 1 return 1
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( n == 1 )
        {
            return 1;
        }

        return n + rec ( n - 1 );
        // Recursive call reducing the value of n
    }

    private static int frm ( int n )
    {
        // Method to find sum using formula
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int s = n * ( n + 1 ) / 2;
        return s;
    }
}
