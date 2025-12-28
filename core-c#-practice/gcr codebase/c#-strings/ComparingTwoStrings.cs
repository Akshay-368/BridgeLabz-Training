using System;

public class ComparingTwoStrings
{
   public static string inp()
   {
       // Waiting for user to type something
       Console.Write("Enter a string: ");
       string s = Console.ReadLine();
       return s;
   }

   public static bool cmp(string a, string b)
   {
       // compare two strings using charAt logic , meaning index
       if(a.Length != b.Length)
       {
           return false; // different length cant be same
       }

       for(int i = 0; i < a.Length; i = i + 1)
       {
           if(a[i] != b[i]) // using charAt kinda
           {
               return false;
           }
       }
       return true; // all chars match
   }

   public static void run1()
   {
       Console.WriteLine("Compare two strings manually");

       string s1 = inp(); // first string
       string s2 = inp(); // second one

       bool man = cmp(s1, s2);

       bool built = string.Equals(s1, s2); // built in way

       // printing results
       Console.WriteLine("My manual compare says: " + man);
       Console.WriteLine("Built-in Equals says: " + built);

       if(man == built)
       {
           Console.WriteLine("both same , good");
       }
       else
       {
           Console.WriteLine("uh oh something wrong");
       }
   }



   public static int geti(string msg)
   {
       Console.Write(msg);
       string t = Console.ReadLine();
       int v = Convert.ToInt32(t);
       return v;
   }

   

   public static void Main(string[] args) 
   {
       /*
       1. Compare Two Strings Using charAt()
       Hint => 
       * Take user input using Console.ReadLine().
       * Create a method to compare two strings using CharAt() logic (string[index] in C#).
       * Compare the result with the built-in string.Equals()..
       */

       Console.WriteLine("Program is going to run");
      

           run1();

       

       Console.Write("Press any key to exit...");
       Console.ReadKey();
   }
}
