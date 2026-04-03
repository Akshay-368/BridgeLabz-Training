using System;

public static class WindChill
{
    public static void Main ()
    {
        /*
        11. Write a program to calculate the wind chill temperature
        given the temperature and wind speed.
        Hint =>
        Write a method to calculate the wind chill temperature
        using the formula :
        windChill = 35.74 + 0.6215 * temp + (0.4275 * temp - 35.75) * windSpeed^0.16
        */

        Console.WriteLine ( " Enter the temperature value : " );
        double temp = double.Parse ( Console.ReadLine() );
        // Taking temperature from user
        // Using double because temperature values can be in decimal

        Console.WriteLine ( " Enter the wind speed value : " );
        double windSpeed = double.Parse ( Console.ReadLine() );
        // Taking wind speed from user
        // Again using double because wind speed can also be decimal

        double result = CalculateWindChill ( temp , windSpeed );
        // Calling the method to calculate wind chill temperature which has to return a double value and should take double values as parameters

        Console.WriteLine ( " The wind chill temperature is : " + $"{result:F4}" );
        Console.WriteLine ( " Or approximately , we can say ( in int ): " + int.Parse ( result.ToString() ) );
        // Converting double to int using ToString() and Parse() method
        // This gives an approximate integer value of wind chill temperature
    }

    private static double CalculateWindChill ( double temperature , double windSpeed )
    {
        // This method calculates the wind chill temperature
        // Using the formula provided in the question
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double powerValue = Math.Pow ( windSpeed , 0.16 );
        // Calculating windSpeed raised to the power of 0.16
        // Using Math.Pow method for power calculation

        double windChill = 35.74 + ( 0.6215 * temperature ) + ( ( 0.4275 * temperature - 35.75 ) * powerValue );
        // Applying the complete wind chill formula step by step
        // Split across lines to make it more readable

        return windChill;
        // Returning the calculated wind chill temperature
    }
}
