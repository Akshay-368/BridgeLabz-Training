using System;

public class TemperatureConversion
{
   public static double f2c(double f)
   {
       // convert fahrenheit to celsius
       double c = (f - 32) * 5 / 9;
       return c;
   }

   public static double c2f(double c)
   {
       // convert celsius to fahrenheit
       double f = c * 9 / 5 + 32;
       return f;
   }

   public static int choice()
   {
       Console.WriteLine("1. Fahrenheit to Celsius");
       Console.WriteLine("2. Celsius to Fahrenheit");
       Console.Write("Pick 1 or 2: ");
       string s = Console.ReadLine();
       int ch = Convert.ToInt32 (s);
       return ch;
   }

   public static double temp()
   {
       // Waiting for user to enter the temp value
       Console.Write("Enter the temperature: ");
       string t = Console.ReadLine();
       double v = Convert.ToDouble(t);
       return v;
   }

   public static void run()
   {
       Console.WriteLine("Temperature converter here");

       int opt = choice();

       double val = temp();

       if(opt == 1)
       {
           double res = f2c(val);
           // printing result
           Console.WriteLine(val + " F is " + res + " C");
       }
       else if (opt == 2)
       {
           double res = c2f(val) ;
           Console.WriteLine  ( val + " C is " + res + " F");
       }
       else
       {
           Console.WriteLine( " wrong choice dude , only 1 or 2" ) ;
         
       }
   }

   public static void Main() 
   {
       /*
       8. Temperature Converter:
       Write a program that converts temperatures between Fahrenheit and Celsius.
       ● The program should have separate functions for converting from Fahrenheit to
       Celsius and from Celsius to Fahrenheit.

       No extra hints.
       */

       run();

       Console.Write ( " Press any key to quit.. " ) ;
       Console.ReadKey();
   }
}
