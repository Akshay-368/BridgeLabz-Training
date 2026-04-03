using System;

public static class UnitConvertorForLength
{
    public static void Main ()
    {
        /*
        Q5. Extend or Create a UnitConvertor utility class similar to the one shown in the notes to do the following.
        Please define static methods for all the UnitConvertor class methods. E.g. 
        public static double ConvertYardsToFeet(double yards) => 
        a.  Method to convert yards to feet and return the value. Use following code to convert  double yards2feet = 3;
        b. Method to convert feet to yards and return the value. Use following code to convert  double feet2yards = 0.333333;
        c. Method to convert meters to inches and return the value. Use following code to convert  double meters2inches = 39.3701;
        d.Method to convert inches to meters and return the value. Use following code to convert  double inches2meters = 0.0254;
        e. Method to convert inches to centimeters and return the value. Use the following code  double inches2cm = 2.54;

        */

        Console.WriteLine ( " Yards to Feet : " + y2f ( 5 ) );
        Console.WriteLine ( " Feet to Yards : " + f2y ( 15 ) );
        Console.WriteLine ( " Meters to Inches : " + m2i ( 2 ) );
        Console.WriteLine ( " Inches to Meters : " + i2m ( 40 ) );
        Console.WriteLine ( " Inches to Centimeters : " + i2c ( 10 ) );
    }

    private static double y2f ( double y )
    {
        // Converts Yards to Feet
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = y * 3;
        return r; // returning the result which is the value in feet from the yards
    }

    private static double f2y ( double f )
    {
        // Converts Feet to Yards
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = f * 0.333333;
        return r;
    }

    private static double m2i ( double m )
    {
        // Converts Meters to Inches
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = m * 39.3701;
        return r;
    }

    private static double i2m ( double i )
    {
        // Converts Inches to Meters
        // Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = i * 0.0254;
        return r;
    }

    public static double i2c ( double i )
    {
        // Converts Inches to Centimeters

        double r = i * 2.54;
        return r; // returning the answer in result variable - called r , which contains the converted value in cm
    }
}
