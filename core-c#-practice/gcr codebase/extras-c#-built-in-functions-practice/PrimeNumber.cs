using System;

public class PrimeNumber
{
   public static int get()
   {
       // Waiting , for user to enter the inupt number
       Console.Write ("Give me a number to check if prime: ");
       string t = Console.ReadLine();
       int num = Convert.ToInt32(t);
       return num;
   }

   public static bool chk(int n)
   {
       // check if n is prime , return true if yes
       if(n <= 1)
       {
           return false; // 1 and below not prime
       }
       if(n == 2)
       {
           return true; // 2 is prime
       }
       if(n % 2 == 0)
       {
           return false; // even numbers bigger than 2 not prime
       }

       // check odd divisors up to sqrt kinda but simple loop
       for(int i = 3; i * i <= n; i = i + 2)
       {
           if(n % i == 0)
           {
               return false; // found divisor , not prime
           }
       }
       return true; // no divisors found , its prime
   }

   public static void go()
   {
       Console.WriteLine("Prime checker thingy");

       int val = get();

       if(val < 0)
       {
           Console.WriteLine("Negative numbers cant be prime dude");
           return;
       }

       bool res = chk(val);

       if(res)
       {
           // printing yes prime
           Console.WriteLine(val + " is a prime number yay");
       }
       else
       {
           Console.WriteLine(val + " is not prime sorry");
       }
   }

   public static void Main()
   {
       /*
       3. Prime Number Checker:
       Create a program that checks whether a given number is a prime number.
       ● The program should use a separate function to perform the prime check and return
       the result.

       No extra hints.
       */

       go();

       // wait so user sees answer
       Console.Write("Press any key to close..");
       Console.ReadKey();
   }
}
