using System;

public static class UnitConvertor
{
    public static void Main ()
    {
        /*
        Q6.Extend or Create a UnitConvertor utility class similar to the one shown in the notes to do the following.  
        Please define static methods for all the UnitConvertor class methods. E.g. 
        public static double convertFarhenheitToCelsius(double farhenheit) => 
        a.  Method to convert Fahrenheit to Celsius and return the value. Use the following code  double farhenheit2celsius = (farhenheit - 32) * 5 / 9;
        b.Method to convert Celsius to Fahrenheit and return the value. Use the following code  double celsius2farhenheit = (celsius * 9 / 5) + 32;
        c. Method to convert pounds to kilograms and return the value. Use the following code  double pounds2kilograms = 0.453592;
        d. Method to convert kilograms to pounds and return the value. Use the following code  double kilograms2pounds = 2.20462; 
        e. Method to convert gallons to liters and return the value. Use following code to convert   double gallons2liters = 3.78541; 
        f. Method to convert liters to gallons and return the value. Use following code to convert  double liters2gallons = 0.264172; 
        */

        Console.WriteLine ( " Fahrenheit to Celsius : " + f2c ( 98.6 ) );
        Console.WriteLine ( " Celsius to Fahrenheit : " + c2f ( 37 ) );
        Console.WriteLine ( " Pounds to Kilograms : " + p2k ( 150 ) );
        Console.WriteLine ( " Kilograms to Pounds : " + k2p ( 68 ) );
        Console.WriteLine ( " Gallons to Liters : " + g2l ( 5 ) );
        Console.WriteLine ( " Liters to Gallons : " + l2g ( 10 ) );
    }

    private static double f2c ( double f )
    {
        // Converts Fahrenheit to Celsius
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = ( f - 32 ) * 5 / 9;
        return r;
    }

    private static double c2f ( double c )
    {
        // Converts Celsius to Fahrenheit
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = ( c * 9 / 5 ) + 32;
        return r;
    }

    private static double p2k ( double p )
    {
        // Converts Pounds to Kilograms
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = p * 0.453592;
        return r;
    }

    private static double k2p ( double k )
    {
        // Converts Kilograms to Pounds
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = k * 2.20462;
        return r;
    }

    private static double g2l ( double g )
    {
        // Converts Gallons to Liters
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = g * 3.78541;
        return r;
    }

    private static double l2g ( double l )
    {
        // Converts Liters to Gallons
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        double r = l * 0.264172;
        return r;
    }
}
