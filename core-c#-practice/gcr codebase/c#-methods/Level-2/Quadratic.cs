using System;

public static class Quadratic
{
    public static void Main ()
    {
        /* Q11.
        Write a program Quadratic to find the roots of the equation
        ax^2 + bx + c = 0 using Math functions.
        Hint =>
        Take a, b, and c as input values
        delta = b^2 - 4*a*c
        If delta > 0 -> two real roots
        If delta == 0 -> one real root
        If delta < 0 -> no real roots
        Write a method to find the roots and return them
        */

        Console.WriteLine("The general equation of the quadratic is ax^2 + bX + c = 0 ; so enter the values accordingly to find roots");

        Console.WriteLine ( " Enter value of a : " );
        double a = double.Parse ( Console.ReadLine() );
        // coefficient of x^2

        Console.WriteLine ( " Enter value of b : " ) ;
        double b = double.Parse ( Console.ReadLine() ) ;
        // coefficient of x

        Console.WriteLine ( " Enter value of c : " ) ;
        double c = double.Parse ( Console.ReadLine() ) ;
        //  value of constant

        double[] roots = Find ( a , b , c );
        // Calling the helper method to find roots of quadratic equation

        if ( roots.Length == 0 )
        {
            Console.WriteLine ( " No real roots exist for the given equation." );
        }
        else if ( roots.Length == 1 )
        {
            Console.WriteLine ( " Only one real root exists." );
            Console.WriteLine ( " Root is : " + roots[0].ToString("F2") );
        }
        else
        {
            Console.WriteLine ( " Two real roots exist." );
            Console.WriteLine ( " Root 1 : " + roots[0].ToString("F2") );
            Console.WriteLine ( " Root 2 : " + roots[1].ToString("F2") );
        }
    }

    private static double[] Find ( double a , double b , double c )
    {
        // This method finds the roots of a quadratic equation
        // and returns them as an array
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double delta = Math.Pow ( b , 2 ) - ( 4 * a * c );
        //  the value of delta using formula b^2 - 4ac

        if ( delta > 0 )
        {
            // Two real and distinct roots exist

            double sqrtd = Math.Sqrt ( delta );
            //  square root of delta

            double root1 = ( -b + sqrtd ) / ( 2 * a );
            double root2 = ( -b - sqrtd ) / ( 2 * a );

            return new double[] { root1 , root2 };
            // Returning both roots in an array
        }
        else if ( delta == 0 )
        {
            // Only one real root exists

            double r = -b / ( 2 * a );

            return new double[] { r };
            //  single root in array
        }
        else
        {
            // Delta is negative, so no real root will exist

            return new double[0];
            // Returning empty array as mentioned in the question
        }
    }
}
