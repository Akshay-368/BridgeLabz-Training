using System;

public class Calculator
{
   public static double add(double x, double y)
   {
       return x + y;
   }

   public static double sub(double x, double y)
   {
       return x - y;
   }

   public static double mul(double x, double y)
   {
       return x * y;
   }

   public static double div(double x, double y)
   {
       if(y == 0)
       {
           Console.WriteLine("cant divide by zero sorry");
           return 0;
       }
       return x / y;
   }

   public static int opt()
   {
       Console.WriteLine("Simple calculator");
       Console.WriteLine("1. Add");
       Console.WriteLine("2. Subtract");
       Console.WriteLine("3. Multiply");
       Console.WriteLine("4. Divide");
       Console.Write("Choose operation (1-4): ");
       string s = Console.ReadLine();
       int c = Convert.ToInt32(s);
       return c;
   }

   public static double num()
   {
       // Waiting , for user to type a number
       Console.Write("Enter number: ");
       string t = Console.ReadLine();
       double n = Convert.ToDouble(t);
       return n;
   }

   public static void calc()
   {
       int op = opt();

       double a = num(); // first num
       double b = num(); // second

       double res = 0;
       bool ok = true;

       if(op == 1)
       {
           res = add(a, b);
       }
       else if(op == 2)
       {
           res = sub(a,b);
       }
       else if (op == 3)
       {
           res = mul(a,b);
       }
       else if (op == 4)
       {
           res = div(a,b);
           if(b == 0) ok = false;
       }
       else
       {
           Console.WriteLine("invalid option man");
           ok = false;
       }

       if(ok)
       {
           // printing the answer
           Console.WriteLine("Result is " + res);
       }
   }

   public static void Main()
   {
       /*
       9. Basic Calculator:
       Write a program that performs basic mathematical operations (addition, subtraction,
       multiplication, division) based on user input.
       ● Each operation should be performed in its own function, and the program should
       prompt the user to choose which operation to perform.

       No extra hints.
       */

       calc();

       Console.WriteLine("Press key to exit...");
       Console.ReadKey();
   }
}
