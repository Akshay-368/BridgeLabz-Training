using System;

public static class FactorsNum
{
    public static void Main ()
    {
        /*
        1.Create a program to find the factors of a number taken as user input, store the factors in an array and display the factors.
        Also find the sum, sum of square of factors and product of the factors and display the results
        Hint => 
        Take the input for a number
        Write a static Method to find the factors of the number and save them in an array and return the array.
        To find factors and save to array will have two loops. The first loop to find the count '
        and initialize the array with the count. And the second loop save the factors into the array
        Write a method to find the sum of the factors using factors array
        Write a method to find the product of the factors using factors array
        Write a method to find the sum of square of the factors using Math.Pow() method
        */

        Console.WriteLine ( " Enter a number : " );
        int n = int.Parse ( Console.ReadLine () );
        // Extracting number input from user

        if ( n <= 0 )
        {
            Console.WriteLine ( " Number must be +ve. " );
            return;
        }

        int[] fac = getFac ( n );
        // Calling helper method to get all factors in an array that we just created

        Console.WriteLine ( " Factors are : " );
        for ( int i = 0 ; i < fac.Length ; i++ )
        {
            Console.Write ( fac[i] + " " );
        }
        Console.WriteLine ();

        int s = sum ( fac );
        int p = prod ( fac );
        double sq = sumSq ( fac );

        Console.WriteLine ( " Sum of factors : " + s );
        Console.WriteLine ( " Product of factors : " + p );
        Console.WriteLine ( " Sum of squares of factors : " + sq );
    }

    private static int[] getFac ( int n )
    {
        // This method finds factors and returns them as an array
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int cnt = 0;
        // First loop to count number of factors

        for ( int i = 1 ; i <= n ; i++ )
        {
            if ( n % i == 0 )
            {
                cnt = cnt + 1;
            }
        }

        int[] arr = new int[cnt];
        //  array of exact size to store factors

        int idx = 0;
        // Index to store values in array

        for ( int i = 1 ; i <= n ; i++ )
        {
            if ( n % i == 0 )
            {
                arr[idx] = i;
                idx = idx + 1;
            }
        }

        return arr;
    }

    private static int sum ( int[] arr )
    {
        // Method to find sum of factors
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int s = 0;

        for ( int i = 0 ; i < arr.Length ; i++ )
        {
            s = s + arr[i];
        }

        return s;
    }

    private static int prod ( int[] arr )
    {
        // Method to find product of factors
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int p = 1;

        for ( int i = 0 ; i < arr.Length ; i++ )
        {
            p = p * arr[i];
        }

        return p;
    }

    private static double sumSq ( int[] arr )
    {
        // Method to find sum of squares of factors
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double s = 0;

        for ( int i = 0 ; i < arr.Length ; i++ )
        {
            s = s + Math.Pow ( arr[i] , 2 );
            // Using Math.Pow to calculate square
        }

        return s;
    }
}
