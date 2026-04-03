using System;

public class MaximumOfThreeNumbers
{
   public static int inp()
   {
       // Waiting for user to type a number
       Console.Write("Enter a number pls: ");
       string s = Console.ReadLine();
       int n = Convert.ToInt32(s);
       return n;
   }

   public static int max3 (int a , int b , int c)
   {
       // find the biggest of three nums
       int m = a ;
       if(b > m)
       {
           m =   b; // b is bigger
       }
       if(c > m) 
       {
           m = c; // c is even bigger
       }
       return m;
   }

   public static void run()
   {
       Console.WriteLine("This will find max of three numbers");

       int x = inp(); // first num
       int y = inp(); // second
       int z = inp(); // third

       int big = max3(x,y,z);

       // printing the result
       Console.WriteLine("The maximum is " + big);
   }

   public static void Main(string[] args) 
   {
       /*
       2. Maximum of Three Numbers:
       Write a program that takes three integer inputs from the user and finds the maximum of the
       three numbers.
       ● Ensure your program follows best practices for organizing code into modular
       functions, such as separate functions for taking input and calculating the maximum
       value.

       No extra hints.
       */

       run();

       Console.WriteLine("Press key to exit...");
       Console.ReadKey();
   }
}
