using System;

public static class UnitConv
{
    public static void Main ()
    {
        /*
        Q4. Extend or Create a UnitConvertor utility class similar to the one shown in the notes to do the following.
        Please define static methods for all the UnitConvertor class methods. E.g. 
        public static double ConvertKmToMiles(double km) => 
        a. Method To convert kilometers to miles and return the value. Use the following code  double km2miles = 0.621371;
        b.Method to convert miles to kilometers and return the value. Use the following code  double miles2km = 1.60934;
        c. Method to convert meters to feet and return the value. Use the following code to convert  double meters2feet = 3.28084;
        d. Method to convert feet to meters and return the value. Use the following code to convert  double feet2meters = 0.3048;
        */

        Console.WriteLine ( " Km to Miles : " + k2m ( 10 ) );
        Console.WriteLine ( " Miles to Km : " + m2k ( 5 ) );
        Console.WriteLine ( " Meters to Feet : " + mt2f ( 3 ) );
        Console.WriteLine ( " Feet to Meters : " + f2mt ( 10 ) );
    }

    public static double k2m ( double k )
    {
        // Converts Kilometers to Miles

        double r = k * 0.621371;
        return r;
    }

    public static double m2k ( double m )
    {
        // Converts Miles to Kilometers

        double r = m * 1.60934;
        return r;
    }

    public static double mt2f ( double m )
    {
        // Converts Meters to Feet

        double r = m * 3.28084;
        return r;
    }

    private static double f2mt ( double f )
    {
        // Converts Feet to Meters
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = f * 0.3048;
        return r; // returning the answer in result variable - r , which contains comverted value in type double converted from feet to meters
    }
}
