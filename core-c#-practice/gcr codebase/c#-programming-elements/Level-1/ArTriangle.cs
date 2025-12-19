using System ;
class ArTriangle
{
    public static void Main ()
    {
        /*
        12. Write a program that takes the base and height to find the area of a triangle in square inches and square centimeters
Hint: Area of a Triangle is ½ * base * height
I/P => base, height
O/P => Your Height in cm is ___ while in feet is ___ and inches is ___
        */

        Console.WriteLine ( " Enter the base of the traingle for which area is to be calculated : ( in cm ) " ) ;
        double bas = double.Parse ( Console.ReadLine () ) ;
        Console.WriteLine ( " Enter the height of the traingle for which area is to be calculated : ( in cm ) " ) ;
        double height = double.Parse ( Console.ReadLine () ) ;

        double area_cm = 0.5 * bas * height ;
        double area_inch = area_cm / 6.4516 ; // as per online conversion 1 square inch = 6.4516 square cm
        Console.WriteLine ( " The area of the triangle is {0} square centimeters and {1} square inches . " , area_cm , (float) area_inch ) ;


    }

}