using System;

public class NumberGuessing 
{
   // this is random thingy
   static Random rnd = new Random();

   public static int gues()
   {
       // makin a random guess betwen 1 and 100
       int x = rnd.Next(1,101);
       return x;
   }

   public static string feed()
   {
       // Waiting for user to enter the feedback
       Console.Write("is my guess high (h), low (l) or correct (c)? ");
       string f = Console.ReadLine();
       // make it lower case cuz easier
       f = f.ToLower();
       return f;
   }

   public static void play()
   {
       Console.WriteLine( "Think of a number between 1 and 100 ok?");
       Console.WriteLine("I will try to guess it haha ");

       int low = 1;
       int hi = 100;
       int trys = 0;

       bool done = false;

       while(done == false)
       {
           int myg = gues(); // get new guess , but wait actually we can do better but nah simple is good
           // wait no , lets use range to make it faster but keep it simple with random for now
           // nah user said random guesses so ok

           Console.WriteLine("My guess is: " + myg);
           trys = trys + 1;

           string fb = feed(); // get feedback

           if(fb == "c")
           {
               // yay won
               Console.WriteLine("Yesss I got it in " + trys + " tries!");
               done = true;
           }
           else if (fb == "h")
           {
               // guess was too high so next time lower maybe
               Console.WriteLine("Ok too high , will try lower");
               // but since random we dont change range , just keep guessing random
           }
           else if (fb == "l")
           {
               Console.WriteLine("Ok too low , will try higher next");
           }
           else
           {
               // bad inupt
               Console.WriteLine("pls type h or l or c only thx");
               trys = trys - 1; // dont count bad one
           }
       }
   }

   public static void Main() 
   {
       /*
       1. Number Guessing Game:
       Write a program where the user thinks of a number between 1 and 100, and the computer
       tries to guess the number by generating random guesses.
       ● The user provides feedback by indicating whether the guess is high, low, or correct.
       ● The program should be modular, with different functions for generating guesses,
       receiving user feedback, and determining the next guess.

       No extra hints given.
       */

       // start the game
       play();

       // wait bit so user can see result
       Console.WriteLine("Press any key to exit..");
       Console.ReadKey();
   }
}
