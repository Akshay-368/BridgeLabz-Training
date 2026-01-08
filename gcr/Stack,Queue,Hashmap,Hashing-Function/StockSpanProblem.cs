using System;

public class spn 
{
    // array for prices
    public static int[] prc;
    public static int[] sp;

    public static void calcSpan() 
    {
        if(prc == null || prc.Length == 0) 
        {
            Console.WriteLine("no prices given cant calculate");
            return;
        }

        int n = prc.Length;
        sp = new int[n];

        Stack<int> stk = new Stack<int>();
        stk.Push(0); // first day index
        sp[0] = 1; // span always 1 for first

        for(int i=1; i<n; i++) 
        {
            // pop smaller or equal prices from stack
            while(stk.Count > 0 && prc[stk.Peek()] <= prc[i])
            {
                stk.Pop();
            }

            if(stk.Count == 0)
            {
                sp[i] = i + 1; // all previous days smaller
            }
            else
            {
                sp[i] = i - stk.Peek(); // days since that higher price
            }

            stk.Push(i); // push current index
          // stack keeps indices in decreasing price order kinda
        }
    }

    public static void printRes() 
    {
        if(sp == null)
        {
            Console.WriteLine("first calculate span");
            return;
        }

        Console.WriteLine("Day   Price   Span");
        for(int i=0; i<prc.Length; i++)
        {
            Console.WriteLine((i+1)+"     "+prc[i]+"       "+sp[i]);
        }
      // printed in nice way with spaces
    }

    public static void setPrc(int[] arr) 
    {
        prc = arr;
        Console.WriteLine("Prices set for "+arr.Length+" days");
    }

    public static void Main(string[] args) 
    {
        /*
        Stock Span Problem

        * Problem: For each day in a stock price array, calculate the span (number of consecutive days the price was less than or equal to the current day's price).

        * Hint: Use a stack to keep track of indices of prices in descending order.
        */

        // some test data
        int[] test = {100, 80, 60, 70, 60, 75, 85};
        setPrc(test);

        int ch = 0;
        while(ch != 5)
        {
            Console.WriteLine("\nStock Span Calculator");
            Console.WriteLine("1 Set new prices (manual)");
            Console.WriteLine("2 Calculate span");
            Console.WriteLine("3 Print result");
            Console.WriteLine("4 Use default test data");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("How many days ? ");
                int nd = Convert.ToInt32(Console.ReadLine());
                int[] nw = new int[nd];

                for(int i=0; i<nd; i++)
                {
                    Console.Write("Enter price for day "+(i+1)+" : ");
                    nw[i] = Convert.ToInt32(Console.ReadLine());
                }

                setPrc(nw);
            }
            else if(ch == 2)
            {
                calcSpan();
                Console.WriteLine("Span calculated successfully");
            }
            else if(ch == 3)
            {
                printRes();
            }
            else if(ch == 4)
            {
                setPrc(test);
            }

            if(ch == 2 || ch == 3) printRes();
        }
    }
}
