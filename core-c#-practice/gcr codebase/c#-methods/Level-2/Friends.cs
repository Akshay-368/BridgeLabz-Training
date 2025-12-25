using System;

public static class Friends
{
    public static void Main ()
    {
        /*Q8.
        Create a program to find the youngest and tallest friend
        among Amar, Akbar and Anthony
        */

        string[] nam = { "Amar", "Akbar", "Anthony" };
        int[] age = new int[3];
        double[] hgt = new double[3];
        // Arrays to store names, ages and heights

        for ( int i = 0 ; i < 3 ; i++ )
        {
            Console.WriteLine ( " Enter age of " + nam[i] + " : " );
            age[i] = int.Parse ( Console.ReadLine() );

            Console.WriteLine ( " Enter height of " + nam[i] + " : " );
            hgt[i] = double.Parse ( Console.ReadLine() );
        }

        int y = yng ( age );
        // Finding index of youngest friend

        int t = tal ( hgt );
        // Finding index of tallest friend

        Console.WriteLine ( " Youngest Friend : " + nam[y] );
        Console.WriteLine ( " Tallest Friend  : " + nam[t] );
    }

    private static int yng ( int[] a )
    {
        // Method to find youngest age
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int idx = 0;

        for ( int i = 1 ; i < a.Length ; i++ )
        {
            if ( a[i] < a[idx] )
            {
                idx = i;
            }
        }

        return idx;
        // Returning index of youngest person
    }

    private static int tal ( double[] h )
    {
        // Method to find tallest height
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int idx = 0;

        for ( int i = 1 ; i < h.Length ; i++ )
        {
            if ( h[i] > h[idx] )
            {
                idx = i;
            }
        }

        return idx;
        // Returning index of tallest person
    }
}
