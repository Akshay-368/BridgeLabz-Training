using System ;
class Cel_to_fah
{
    public static void Main ()
    {
        Console.WriteLine ( " Enter the temperature in Celsius : " ) ;// asking user for tem in celsius
        double c = double.Parse ( Console.ReadLine () ) ; // Taking the value and converting it to double using Parse method
        // Used Parse method ( static ) to convert string input to target type which is double here
        // Using double here because temperature can be in decimal as well

        double f = ( c * 9 / 5 ) + 32 ; // Using formula to get fahrenheit from celsius
        Console.WriteLine ( " The temperature in Fahrenheit is  ( for given Celsius ) : " + f + "degree f") ; // Showing the temperature
        Console.WriteLine ( " Or " + (int)f + " ( approx) degree f  " ) ; // Showing approximate temp in int value using type-casting
    }
}
