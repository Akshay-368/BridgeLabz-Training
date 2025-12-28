using System;

public class PalendromeCheck
{
   public static string inp()
   {
       // Waiting , for user to type the string
       Console.Write("Enter a word or phrase to check palindrome: ");
       string txt = Console.ReadLine();
       return txt;
   }

   public static bool pal(string s)
   {
       // clean the string first , remove spaces and make lower
       string clean = "";
       for(int i = 0;i < s.Length; i++)
       {
           char ch = s[i];
           if(char.IsLetterOrDigit(ch))
           {
               clean = clean + char.ToLower(ch);
           }
       }

       // now check if same forward and backward
       int left = 0;
       int right = clean.Length - 1;

       while(left < right)
       {
           if(clean[left] != clean[right])
           {
               return false; // not same
           }
           left = left + 1;
           right = right - 1;
       }
       return true; // all good
   }

   public static void res(string orig, bool ispal)
   {
       // printing the result
       Console.Write("The text: \"" + orig + "\" ");

       if(ispal)
       {
           Console.WriteLine("is a palindrome yay");
       }
       else
       {
           Console.WriteLine("is not a palindrome sorry");
       }
   }

   public static void run()
   {
       Console.WriteLine("Palindrome checker here");

       string str = inp();

       if(str == "")
       {
           Console.WriteLine("u entered nothing dude");
           return;
       }

       bool ans = pal(str);

       res(str, ans);
   }

   public static void Main()
   {
       /*
       5. Palindrome Checker:
       Write a program that checks if a given string is a palindrome (a word, phrase, or sequence
       that reads the same backward as forward).
       ● Break the program into functions for input, checking the palindrome condition, and
       displaying the result.

       No extra hints.
       */

       run();

       // wait a sec
       Console.Write ( " Press key to exit...");
       Console.ReadKey () ;
   }
}
