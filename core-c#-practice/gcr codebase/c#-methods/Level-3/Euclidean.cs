using System;

public class Geo
{
    public static void Main()
    {
        /*9.Write a program Euclidean distance between two points as well as the equation of the line using those two points. Use Math functions Math.Pow() and Math.Sqrt()
        Hint => 
        Take inputs for 2 points x1, y1, and x2, y2 
        Method to find the Euclidean distance between two points and return the distance
        distance = (x2-x1)2 +(y2-y1)2
        d.  Write a Method to find the equation of a line given two points and return the equation which includes the slope and the y-intercept
        The equation of a line is given by the equation y = m*x + b Where m is the slope and b is the y-intercept. So firstly compute the slope using the formulae 
        m = (y2 - y1)/(x2 - x1)
        Post that compute the y-intercept b using the formulae 
        b = y1 - m*x1  
        Finally, return an array having slope m and y-intercept b
        */

        // taking first point values from user
        Console.Write("Enter x1: ");
        double x1 = double.Parse(Console.ReadLine());

        Console.Write("Enter y1: ");
        double y1 = double.Parse(Console.ReadLine());

        // taking second point values from user
        Console.Write("Enter x2: ");
        double x2 = double.Parse(Console.ReadLine());

        Console.Write("Enter y2: ");
        double y2 = double.Parse(Console.ReadLine());

        // calling method to get distance
        double dis = dst(x1, y1, x2, y2);

        // calling method to get slope and intercept
        double[] ln = lin(x1, y1, x2, y2);

        // printing results
        Console.WriteLine("\nDistance between points = " + dis);
        Console.WriteLine("Slope (m) = " + ln[0]);
        Console.WriteLine("Y-intercept (b) = " + ln[1]);
        Console.WriteLine("Line eqn : y = " + ln[0] + "x + " + ln[1]);
    }

    public static double dst(double x1, double y1, double x2, double y2)
    {
        // finding diff between x values
        double dx = x2 - x1;

        // finding diff between y values
        double dy = y2 - y1;

        // squaring the diffs using Math.Pow
        double p1 = Math.Pow(dx, 2);
        double p2 = Math.Pow(dy, 2);

        // adding both parts
        double sm = p1 + p2;

        // final sqrt to get actual distance
        double rs = Math.Sqrt(sm);

        return rs;
    }

    public static double[] lin(double x1, double y1, double x2, double y2)
    {
        //Even if we do end up Making this method private so that only this class can call it , just one of the best practices ( just for practice otherwise we can mke it public as well )
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class
        // creating array to store m and b
        double[] arr = new double[2];

        // calculating slope, hoping x2 != x1 to avoid division by zero
        double m = (y2 - y1) / (x2 - x1);

        // calculating y intercept using formula
        double b = y1 - (m * x1);

        // storing values in array
        arr[0] = m;
        arr[1] = b;

        return arr;
    }
}
