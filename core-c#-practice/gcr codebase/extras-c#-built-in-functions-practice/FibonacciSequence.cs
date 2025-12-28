using System;

public class FibonnaciGenerator
{
   public static int num()
   {
       // Waiting for user to enter how many terms
       Console.Write("How many Fibonacci numbers u want? ");
       string s = Console.ReadLine();
       int n = Convert.ToInt32(s);
       return n;
   }

   public static void fib(int cnt)
   {
       // this prints the fib sequence up to cnt terms
       if(cnt <= 0)
       {
           Console.WriteLine("nothin to print lol");
           return;
       }

       int a = 0;
       int b = 1;

       Console.Write("Fib sequence: " + a);

       if(cnt > 1)
       {
           Console.Write(" " + b);
       }

       for(int i = 2; i < cnt; i = i + 1)
       {
           int c = a + b; // next one
           Console.Write(" " + c);

           a = b; // shift them
           b = c;
       }

       Console.WriteLine(); // new line at end
   }

   public static void go()
   {
       Console.WriteLine("Fibonacci generator thing");

       int terms = num();

       if(terms < 0)
       {
           Console.WriteLine("no negative pls");
           return;
       }

       fib(terms);
   }

   public static void Main() 
   {
       /*
       4. Fibonacci Sequence Generator:
       Write a program that generates the Fibonacci sequence up to a specified number of terms
       entered by the user.
       ● Organize the code by creating a function that calculates and prints the Fibonacci
       sequence.

       No extra hints.
       */

       go() ;

       Console.WriteLine ( " Press any key to quit.. " ) ;
       Console.ReadKey();
   }
}
