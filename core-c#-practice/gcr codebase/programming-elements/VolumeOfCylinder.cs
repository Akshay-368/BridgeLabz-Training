using System;
class Vol_Cyl
{
    public static void Main ()
    {
        Console.WriteLine ("ENter the radius of the cylinder ( you want to find the volume of ) : " ) ;
        double r = double.Parse ( Console.ReadLine ()); // Taking radius input from user
        // Converting string input to target type which is double here using Parse (static ) method
        // Using double here because radius and height can be in decimal as well

        Console.WriteLine ("ENter the height of the cylinder ( you want to find the volume of ) : " ) ;
        double h = double.Parse ( Console.ReadLine ()); // Taking height input from user
        // Converting string input to target type which is double here using Parse ( static ) method
        // Using double here because radius and height can be in decimal as well

        double v = 3.14 * r * r * h; // Using forula of vol of cyinder
        Console.WriteLine ("The volume of the cylinder is : " + v);
        Console.WriteLine ( "Or " + (int)v + "(approx )" ); // approximate vol in integer value using type-casting
    }
}
