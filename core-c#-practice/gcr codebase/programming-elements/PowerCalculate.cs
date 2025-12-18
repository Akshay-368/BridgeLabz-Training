using System;
class Power
{
    public static void Main ()
    {
        Console.WriteLine ( " Enter the base value of the number to be calculated : " ) ;
        double a = double.Parse ( Console.ReadLine () ) ; // Taking the base value input from user and converting it to double
        Console.WriteLine ( " Enter the exponent or power value to which the base is to be raised : " ) ;
        double e = double.Parse ( Console.ReadLine () ) ;

        // Now using Math.Pow method to get the final value
        double ans = Math.Pow ( a , e ) ;
        Console.WriteLine ( " The ansewer is " + ans);
        Console.WriteLine ( "Or " + (int)ans + "(approx)"); // approximate answer in int using casting
    }
}
