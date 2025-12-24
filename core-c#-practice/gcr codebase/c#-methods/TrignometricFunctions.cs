using System;

class TrigonometricFunctions
{
    public static void Main ()
    {
        /*
        Write a program to calculate various trigonometric functions
        using Math class given an angle in degrees.
        Hint =>
        Method to calculate various trigonometric functions
        Firstly convert angle from degrees to radians
        Then use Math.Sin(), Math.Cos() and Math.Tan() methods
        */

        Console.WriteLine ( " Enter the angle in degrees : " ); 
        double angleDeg = double.Parse ( Console.ReadLine() ); 
        // Taking input from user in degrees and converting it from string to double
        // Using double here because angle can also be in decimal values

        double[] result = calculatetrigfun ( angleDeg ) ; // the storing containger is of array type
        // Calling the method which returns an array of trigonometric values

        Console.WriteLine ( " Sine value is : " + result[0] );
        Console.WriteLine ( " Cosine value is : " + result[1] );
        Console.WriteLine ( " Tangent value is : " + result[2] );
    }

    private static double[] calculatetrigfun ( double angle )
    {
        // This method has return type as double array because it is returning more than one value at a time which is not possible . Thus we will use an array to pack it up
        // This method will calculate sine, cosine and tangent
        // First converting degrees into radians

        double radians = ( angle * Math.PI ) / 180 ;
        // Formula used : radians = degrees * pi / 180

        double sinVal = Math.Sin ( radians );
        double cosVal = Math.Cos ( radians );
        double tanVal = Math.Tan ( radians );
        // Using Math class methods to calculate trigonometric values , which already has those trig functions in it

        double[] arr = new double[3];
        // arr[0] - sine
        // arr[1] - cosine
        // arr[2] - tangent

        arr[0] = sinVal;
        arr[1] = cosVal;
        arr[2] = tanVal;

        return arr;
        // Returning the array which contains all the calculated values
    }
}
