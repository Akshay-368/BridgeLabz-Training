using System ;
class Area_circle
{
    public static void Main()
    {
        Console.WriteLine ( " Enter the radius of the circle : " ) ; // Asking user for radius of circle 
        double r = double.Parse ( Console.ReadLine () ) ; // Taking the value of radius that user entered and
        //  converting it to double using Parse method
        // Using double here because radius can be in decimal as well
        // Used Parse method ( static ) to convert string input to target type which is double here

        // Now using formula to calculate area of circle which is A = π * r * r
        double a =  3.14 * r * r ; 
        Console.WriteLine ( " The area of the circle for the given radius is : " + a + " square units " ) ; // Showing the area of circle

        // Also showing the approximate area in integer value
        Console.WriteLine ( " Or " + (int)a + " (approx ) square units ") ; // using casting to convert double to integer

    }
}
