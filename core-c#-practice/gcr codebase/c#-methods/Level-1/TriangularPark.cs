using System;

public static class TriangularPark
{
    public static void Main ()
    {
        /*
        4. An athlete runs in a triangular park with sides provided as input by the user in meters.
        If the athlete wants to complete a 5 km run, then how many rounds must the athlete complete.
        Hint =>
        Take user input for 3 sides of a triangle
        The perimeter of a triangle is the addition of all sides
        Number of rounds = total distance / perimeter
        Write a Method to compute the number of rounds
        */

        //Asking user for the input of the triangle park sides

        Console.WriteLine ( " Enter the length of side 1 ( in meters only ) : " );
        double s1 = double.Parse ( Console.ReadLine() );


        Console.WriteLine ( " Enter the length of side 2 ( in metre ): " );
        double s2 = double.Parse ( Console.ReadLine() );


        Console.WriteLine ( " Enter the length of side 3 ( in m ) : " );
        double s3 = double.Parse ( Console.ReadLine() );


        double rounds = Fun ( s1 , s2 , s3 );
        // Calling the helper method to find number of rounds needed which has to take three double values as arguments and return the double value

        Console.WriteLine ( " Number of rounds required to complete 5 km run is : " + rounds.ToString("F2") );
        // PRINTING with 2 decimal places as F2 is a format specifier
    }

    private static double Fun ( double a , double b , double c )
    {
        // This method calculates how many rounds are required
        // to complete a total distance of 5 kilometers
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double p  = a + b + c ; // perimeter
        //the perimeter of the triangule park is just sum of all of its 3 sides

        double td = 5000.0; // total distance
        // 5 km as in meter ( as input sides are in meters )

        double rounds = td / p ;
        // no. of rounds using formula

        return rounds ;
        // Return no. of rounds
    }
}
