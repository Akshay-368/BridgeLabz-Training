using System ;
class Km_to_miles
{
    public static void Main ()
    {
        Console.WriteLine ( " Enter the distance in kilometers : " ) ; // Asking user for distance in kilometers
        double km = double.Parse ( Console.ReadLine () ) ; // Taking the value of distance in kilometers that user entered
        // Converting string input to target type which is double here using Parse method
        // Using double here because distance can be in decimal as well

        double mi = km * 0.621371; // Using formula to convert kilometers to miles
        Console.WriteLine ( " The distance in miles is : " + mi + " miles " ) ; // Showing the distance in miles
        Console.WriteLine ( " Or " + (int)mi + " ( approx ) miles " ) ; // Showing approximate distance in miles 
        // using casting to convert double to integer
    }
}
