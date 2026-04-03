using System;
using System.Collections.Generic;

public class atm 
{
    // notes we have , big to small for greedy
    public static int[] not = {500,200,100,50,20,10,5,2,1};

    // for scenario B , we remove 500 temp
    public static int[] notB = {200,100,50,20,10,5,2,1};

    public static void calcBest(int amt,int[] notes,string scen) 
    {
        Console.WriteLine("Scenario "+scen+" for amount "+amt);

        List<string> res = new List<string>();
        int left = amt;

        for(int i=0; i<notes.Length; i++) 
        {
            int cnt = left / notes[i];
            if(cnt > 0) 
            {
                res.Add(cnt+" notes of "+notes[i]);
                left = left - cnt * notes[i];
            }
        }

        if(left == 0) 
        {
            Console.WriteLine("Best combo (min notes):");
            foreach(string s in res) 
            {
                Console.WriteLine(s);
            }
            Console.WriteLine("Total notes used: "+res.Count);
        }
        else 
        {
            Console.WriteLine("Cant make exact amount with these notes , remaining "+left);
            // fallback simple
            fallback(amt);
        }
      // greedy way , works cuz indian notes are good for it
    }

    public static void fallback(int amt) 
    {
        Console.WriteLine("Fallback combo using only small notes:");
        int[] small = {100,50,20,10,5,2,1};
        int lef = amt;
        int totn = 0;

        for(int i=0; i<small.Length; i++) 
        {
            int cn = lef / small[i];
            if(cn > 0) 
            {
                Console.WriteLine(cn+" x "+small[i]);
                lef -= cn * small[i];
                totn += cn;
            }
        }
        Console.WriteLine("Total notes in fallback: "+totn);
      // more notes but always possible
    }

    public static void scenA() 
    {
        int am = 880;
        calcBest(am,not,"A (with all notes including 500)");
    }

    public static void scenB() 
    {
        int am = 880;
        calcBest(am,notB,"B (without 500 note)");
    }

    public static void scenC() 
    {
        int am = 777; // odd amount hard without 1 or 2
        calcBest(am,not,"C (amount that may not be exact)");
    }

    public static void Main(string[] args) 
    {
        /*
        ATM Dispenser Logic
        Context: ATM dispenses minimum number of notes.
         ●  Scenario A: Given ₹1, ₹2, ₹5, ₹10, ₹20, ₹50, ₹100, ₹200, ₹500 notes, find optimal combo for ₹880.
         ●  Scenario B: Remove ₹500 temporarily and update strategy.
         ● Scenario C: Display fallback combo if exact change isn’t possible.
        */

        int ch = 0;
        while(ch != 4) 
        {
            Console.WriteLine("\nATM Dispenser Menu:");
            Console.WriteLine("1 Scenario A (normal with 500)");
            Console.WriteLine("2 Scenario B (no 500 note)");
            Console.WriteLine("3 Scenario C (fallback case)");
            Console.WriteLine("4 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1) 
            {
                scenA();
            }
            else if(ch == 2) 
            {
                scenB();
            }
            else if(ch == 3) 
            {
                scenC();
            }
            else if(ch == 4) 
            {
                Console.WriteLine("bye bye");
            }
            else 
            {
                Console.WriteLine("wrong choice try again");
            }
        }
    }
}
