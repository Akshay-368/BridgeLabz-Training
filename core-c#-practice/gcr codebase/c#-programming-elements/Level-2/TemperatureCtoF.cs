using System ;
class TemperatureCtoF
{
    public static void Main()
    {
        /*4. Write a TemperatureConversion program, given the temperature in Celsius as input that outputs the temperature in Fahrenheit
Hint:
Create a celsius variable and take the temperature as user input.
Use the formula: Celsius to Fahrenheit: (°C × 9/5) + 32 = °F
Assign the result to fahrenheitResult and print the result.
I/P => celsius
O/P => The ___ Celsius is ___ Fahrenheit

        */

        Console.WriteLine("Enter the temperature in Celsius that you want to convert to Fahrenheit : " );
        double c = double.Parse(Console.ReadLine());
        // Now using the formula for conversion : (°C × 9/5) + 32 = °F
        double F = ( ( c * 9 ) / 5.0 ) + 32 ;
        Console.WriteLine ( $" The temperature from Celsius  which was given as {c} in Fahrenheit is : {F}") ;
    }
}