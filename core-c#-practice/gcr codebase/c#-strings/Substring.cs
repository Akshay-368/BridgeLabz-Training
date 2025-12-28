using System;

public class prog
{
   public static string getstr()
   {
       // Waiting , for user to enter the string
       Console.Write("Type the main string: ");
       string x = Console.ReadLine();
       return x;
   }

   public static int getidx(string prompt)
   {
       Console.Write(prompt);
       string num = Console.ReadLine();
       int idx = Convert.ToInt32(num);
       return idx;
   }

   public static string mysub(string s, int beg, int fin)
   {
       // create substring using charAt idea , loop and index
       string part = "";

       if(beg < 0 || fin > s.Length || beg >= fin)
       {
           return part; // empty if bad
       }

       for(int pos = beg; pos < fin; pos = pos + 1)
       {
           part = part + s[pos]; // add each char
       }

       return part;
   }

   public static void go()
   {
       Console.WriteLine("Substring maker with manual way");

       string main = getstr();

       int start = getidx("Start index pls: ");
       int end = getidx("End index pls (exclusive): ");

       string mine = mysub(main, start, end);

       string real = "";
       try
       {
           real = main.Substring(start, end - start);
       }
       catch
       {
           real = "error with indices";
       }

       // printing both versions
       Console.WriteLine("Manual version: \"" + mine + "\"");
       Console.WriteLine("Real Substring: \"" + real + "\"");

       if(mine == real)
       {
           Console.WriteLine("they match , cool");
       }
       else
       {
           Console.WriteLine("different , maybe indices wrong");
       }
   }

   public static void Main()
   {
       /*
       2. Create a Substring Using charAt()
       Hint => 
       * Take user input using Console.ReadLine() for string, start index, and end index.
       * Write a method to create a substring using charAt() (string[index] in C#).
       * Use string.Substring() to generate the substring and compare the results.
       */

       go();

       Console.WriteLine("Press key to close..");
       Console.ReadKey();
   }
}
