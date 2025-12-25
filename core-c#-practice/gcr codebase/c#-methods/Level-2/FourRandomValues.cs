using System;

public static class FourRandomValues
{
    public static void Main ()
    {
        /* Q12.
        Write a program that generates five 4 digit random values and then finds
        their average value, and their minimum and maximum value.
        Hint =>
        Use Math.Random(), Math.Min(), and Math.Max()
        a. Write a method that generates array of 4 digit random numbers
        public int[] Generate4DigitRandomArray(int size)
        b. Write a method to find average, min and max value of an array
        public double[] FindAverageMinMax(int[] numbers)
        */

        const int size = 5; // as it is fixed and we don't want it to accidentally get affected . Just a safe practice by standards
        // As per the question we need to generate five 4 digit random numbers

        int [] nums = Generate4DigitRandomArray ( size ); // Using the name that the question itself has provided .
        // Calling the helper method to produce random 5 4-digit numbers

        Console.WriteLine ( " Those 5 four digit numbers are : " );

        for ( int i = 0 ; i < nums.Length ; i++ )
        {
            Console.WriteLine ( nums[i] );
            // Printing each random number generated
        }

        double[] result = FindAverageMinMax ( nums ); // once again using the name provided to us , instead of making a sperate name for the method
        // Calling helper method for finding avg, min and max from nums

        Console.WriteLine ( " Average value : " + result [0] );
        Console.WriteLine ( " Minimum value : " + int.Parse ( result [1].ToString() ) );
        Console.WriteLine ( " Maximum value : " + int.Parse ( result [2].ToString() ) );
        // Converting double to int by  using ToString() and then using Parse() just for practice and nothing more
    }

    private static int[] Generate4DigitRandomArray ( int size )
    {
        // This method generates an array of random 4 digit numbers
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int[] a = new int[size]; // creating an array to store those numbers
        Random r = new Random();
        // Creating Random object to generate random numbers
        // Why we are doing this ? Because we don't want to create an object of the class and 
        // call the method on it , instead we want to call the method directly from the class itself
        // Basically we created an instance of the class Random and which gives us access to the methods such as Next() method which generates a random int
        // and why not use new Random() everywherre ? because it means - multiple Random objects in quick succession,
        // they may use the same seed (based on system time), producing identical sequences. and thus creating a single instance is better and just reusing it.
        // Why we are using Next() method ? Because it generates a random number between 0 and 10000 (exclusive)
        // and we want to generate a number between 1000 and 9999 only as they are four digit and thus following the requirement of the question

        for ( int i = 0 ; i < size ; i++ )
        {
            a[i] = r.Next ( 1000 , 10000 );
            // Generating random  number between 1000 and 9999 only as they are four digit and thus following the requirement of the question
        }

        return a;
        // Returning the  array that we created with this function back to Main function from where the call came
    }

    private static double[] FindAverageMinMax ( int[] n )
    {
        // This method finds the average, minimum and maximum of the given array and returns an array of double values
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double[] res = new double[3];
        // res[0] is for  average , res[1] for min , res[2] for  max

        int min = n[0];
        int max = n[0];
        int sum = 0; // intial value of sum as we are just starting.

        for ( int i = 0 ; i < n.Length ; i++ )
        {
            sum = sum + n[i];
            // Adding all elements to find sum

            min = Math.Min ( min , n[i] );
            // Finding minimum using Math.Min

            max = Math.Max ( max , n[i] );
            // Finding maximum using Math.Max
        }

        double avg = sum / double.Parse ( n.Length.ToString() );
        //Now finidng the  average by converting length to string and then parsing to double

        res[0] = avg;
        res[1] = min;
        res[2] = max;

        return res;
        // Returning the array containing average, min and max
    }
}
