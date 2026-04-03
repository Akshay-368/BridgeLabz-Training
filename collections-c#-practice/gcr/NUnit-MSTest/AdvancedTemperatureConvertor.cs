using System;

public class tempConv 
{
    // celsius to fahrenheit
    public static double CelsiusToFahrenheit(double c)
    {
        return c * 9.0 / 5.0 + 32;
    }

    // fahrenheit to celsius
    public static double FahrenheitToCelsius(double f)
    {
        return (f - 32) * 5.0 / 9.0;
    }

    public static void testConverter()
    {
        Console.WriteLine("=== Temperature Converter Tests ===\n");

        // test 1: 0°C → 32°F
        double res1 = CelsiusToFahrenheit(0);
        if(Math.Abs(res1 - 32) < 0.01)
        {
            Console.WriteLine("0°C → 32°F : PASS");
        }
        else
        {
            Console.WriteLine("0°C test FAIL");
        }

        // test 2: 100°C → 212°F
        double res2 = CelsiusToFahrenheit(100);
        if(Math.Abs(res2 - 212) < 0.01)
        {
            Console.WriteLine("100°C → 212°F : PASS");
        }

        // test 3: 32°F → 0°C
        double res3 = FahrenheitToCelsius(32);
        if(Math.Abs(res3 - 0) < 0.01)
        {
            Console.WriteLine("32°F → 0°C : PASS");
        }

        // test 4: 212°F → 100°C
        double res4 = FahrenheitToCelsius(212);
        if(Math.Abs(res4 - 100) < 0.01)
        {
            Console.WriteLine("212°F → 100°C : PASS");
        }
    }

    public static void Main(string[] args)
    {
        /*
        3. Testing Temperature Converter
        Problem:
        Create a TemperatureConverter class with:
        * CelsiusToFahrenheit(double celsius): Converts Celsius to Fahrenheit.
        * FahrenheitToCelsius(double fahrenheit): Converts Fahrenheit to Celsius.
          ✅ Write unit tests to validate conversions.
        */

        Console.WriteLine("Temperature Converter Tests (manual student style)\n");

        testConverter();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
