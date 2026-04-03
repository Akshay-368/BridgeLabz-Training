using System;

public static class Football
{
    public static void Main ()
    {
        /*
        Create a program to find the shortest, tallest, and mean height of players present in a football team.
        Hint =>
        a. The formula to calculate the mean is: mean = sum of all elements/number of elements
        b. Create an int array named heights of size 11 and get 3 digits random height in cms for each player in the range 150 cms to 250 cms
        c.  Write the method to Find the sum of all the elements present in the array.
        d.  Write the method to find the mean height of the players on the football team
        e.  Write the method to find the shortest height of the players on the football team
        f.  Write the method to find the tallest height of the players on the football team
        g. Finally display the results
        */

        int[] ht = new int[11];
        // Array to store heights of 11 players

        Random r = new Random ();
        // Random object to generate heights

        for ( int i = 0 ; i < ht.Length ; i++ )
        {
            ht[i] = r.Next ( 150 , 251 );
            // Generating random height between 150 and 250 bascally to return a non negative int value and upper limit is exclusive and only lower limit is inlcusive
        }

        Console.WriteLine ( " Heights of players are : " );
        for ( int i = 0 ; i < ht.Length ; i++ )
        {
            Console.Write ( ht[i] + " " );
        }
        Console.WriteLine ();

        int s = sum ( ht );
        // Sum of all heights

        double m = mean ( ht );
        // Mean height

        int sh = min ( ht );
        // Shortest height

        int th = max ( ht );
        // Tallest height

        Console.WriteLine ( " Sum of heights : " + s );
        Console.WriteLine ( " Mean height : " + m );
        Console.WriteLine ( " Shortest height : " + sh );
        Console.WriteLine ( " Tallest height : " + th );
    }

    private static int sum ( int[] a )
    {
        // Method to find sum of array elements
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int s = 0;

        for ( int i = 0 ; i < a.Length ; i++ )
        {
            s = s + a[i];
        }

        return s;
    }

    private static double mean ( int[] a )
    {
        // Method to calculate mean height
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int s = sum ( a );
        // Reusing sum method instead of writing loop again

        double m = s / ( double.Parse ( a.Length.ToString() ) );
        // Converting length to string and then parsing to double

        return m;
    }

    private static int min ( int[] a )
    {
        // Method to find shortest height
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int mn = a[0];

        for ( int i = 1 ; i < a.Length ; i++ )
        {
            if ( a[i] < mn )
            {
                mn = a[i];
            }
        }

        return mn;
    }

    private static int max ( int[] a )
    {
        // Method to find tallest height
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int mx = a[0] ;
        for ( int i = 1 ; i < a.Length ; i++ )
        {
            if ( a[i] > mx )
            {
                mx = a[i] ;
            }
        }
        return mx;
    }
}
