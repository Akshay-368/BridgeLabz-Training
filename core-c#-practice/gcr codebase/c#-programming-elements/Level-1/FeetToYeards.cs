using System ;
class FeetToYards
{
    static void Main()
    {
        /*
        14. Write a program to find the distance in yards and miles for the distance provided by the user in feet
Hint: 1 mile = 1760 yards and 1 yard is 3 feet
I/P => distanceInFeet
O/P => Your Height in cm is ___ while in feet is ___ and inches is ___
        */
        Console.Write(" Enter distance in feet : " ) ;
        double feet = double.Parse(Console.ReadLine() ) ;
        // Keeping values in double to not loose precision during division and then converting to float while displaying for simplification
        double yards = feet / 3.0;
        double miles = yards / 1760.0;
        Console.WriteLine(" {0} feet is equal to {1} yards and {2} miles . " , Convert.ToSingle(feet), Convert.ToSingle( yards ) , Convert.ToSingle( miles ) ) ;
    }
}