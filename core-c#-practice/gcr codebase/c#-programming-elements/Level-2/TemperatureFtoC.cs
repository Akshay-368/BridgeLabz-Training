using System ;
class TemperatureFtoC
{
    public static void Main()
    {
        /*5. Write a TemperatureConversion program, given the temperature in Fahrenheit as input that outputs the temperature in Celsius
Hint:
Create a fahrenheit variable and take the user's input.
Use the formula: Fahrenheit to Celsius: (°F − 32) x 5/9 = °C
Assign the result to celsiusResult and print the result.
I/P => fahrenheit
O/P => The ___ Fahrenheit is ___ Celsius

        */

        Console.WriteLine("Enter the temperature in Fahrenheit that you want to convert to Celsius : " );
        double f = double.Parse(Console.ReadLine());
        // Now using the formula for conversion : (°F − 32) x 5/9 = °C
        double c = ( (f - 32 ) * 5 ) / 9.0 ;
        Console.WriteLine ( $" The temperature in Celsius   {c}  and in  Fahrenheit which was given as is : {f}") ;
    }
}