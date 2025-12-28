using System;

public class GCDAndLCDCalculator
{
   public static int inp()
   {
       // Waiting , for user to enter a num
       Console.Write ( " Type a number: " ) ;
       string s = Console.ReadLine();
       int x = Convert.ToInt32(s);
       return x;
   }

   public static int gcd(int a, int b)
   {
       // euclidean algo , simple recursive way
       a = Math.Abs(a);
       b = Math.Abs(b);

       if(b == 0)
       {
           return a;
       }
       return gcd(b, a % b); // recurse
   }

   public static long lcm(int a, int b, int g)
   {
       // lcm = (a * b) / gcd but careful with overflow
       long prod = (long)a * b;
       long res = prod / g;
       return res;
   }

   public static void calc()
   {
       Console.WriteLine("GCD and LCM calculator");

       int x = inp(); // first num
       int y = inp(); // second

       if(x == 0 && y == 0)
       {
           Console.WriteLine("both zero? cant really compute");
           return;
       }

       int g = gcd(x, y);

       long l = lcm(x, y, g);

       // printing results
       Console.WriteLine("GCD of " + x + " and " + y + " is " + g);
       Console.WriteLine("LCM of " + x + " and " + y + " is " + l);
   }

   public static void Main()
   {
       /*
       7. GCD and LCM Calculator:
       Create a program that calculates the Greatest Common Divisor (GCD) and Least Common
       Multiple (LCM) of two numbers using functions.
       ● Use separate functions for GCD and LCM calculations, showcasing how modular code
       works.

       No extra hints.
       */

       calc();

       Console.WriteLine (" Press key to close...");
       Console.ReadKey();
   }
}
