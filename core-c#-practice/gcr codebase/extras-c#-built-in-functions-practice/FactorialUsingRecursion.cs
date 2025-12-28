using System;

public class Factorial
{
   public static int getn()
   {
       // Waiting for user to type the number
       Console.Write("Enter a number for factorial: ");
       string t = Console.ReadLine();
       int n = Convert.ToInt32(t);
       return n;
   }

   public static long fac(int n)
   {
       // recursive factorial , base cases first
       if(n < 0)
       {
           return -1; // error kinda
       }
       if(n == 0 || n == 1)
       {
           return 1;
       }
       // recurse here
       return n * fac(n - 1);
   }

   public static void show(long res, int orig)
   {
       if(res == -1)
       {
           Console.WriteLine ( " cant do factorial for negative nums sorry " ) ;
           return;
       }
       // printing the result
       Console.WriteLine(" Factorial of " + orig + " is " + res)  ;
   }

   public static void run()
   {
       Console.WriteLine ( "Factorial with recursion");

       int val = getn();

       long ans = fac(val);

       show(ans, val);
   }

   public static void Main() 
   {
       /*
       6. Factorial Using Recursion:
       Write a program that calculates the factorial of a number using a recursive function.
       ● Include modular code to separate input, calculation, and output processes.

       No extra hints.
       */

       run();

       Console.Write ( " Press any key to exit.." ) ;
       Console.ReadKey() ;
   }
}
