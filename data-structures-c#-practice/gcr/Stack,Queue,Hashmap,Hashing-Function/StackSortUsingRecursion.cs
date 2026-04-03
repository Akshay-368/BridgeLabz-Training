using System;
using System.Collections.Generic;

public class stk 
{
    // our main stack to sort
    public static Stack<int> s = new Stack<int>();

    // insert in sorted way , smaller at bottom
    public static void ins(int val) 
    {
        if(s.Count == 0 || s.Peek() <= val)
        {
            s.Push(val);
            return;
        }

        // pop bigger ones first
        int top = s.Pop();
        ins(val); // recurse

        s.Push(top); // put back the bigger one
      // this way val goes below bigger elements
    }

    public static void srt() 
    {
        if(s.Count == 0) return;

        int top = s.Pop(); // take out top

        srt(); // sort the rest first , recursive

        ins(top); // now insert the taken one at right place
      // after this whole stack gets sorted , small at bottom
    }

    public static void printStk() 
    {
        if(s.Count == 0)
        {
            Console.WriteLine("stack empty nothing to print");
            return;
        }

        Console.WriteLine("Stack from top to bottom:");
        Stack<int> tmp = new Stack<int>();

        while(s.Count > 0)
        {
            int v = s.Pop();
            Console.Write(v + " ");
            tmp.Push(v);
        }
        Console.WriteLine();

        // put back everything
        while(tmp.Count > 0)
        {
            s.Push(tmp.Pop());
        }
      // printed top to bottom , stack same again
    }

    public static void Main(string[] args) 
    {
        /*
        Sort a Stack Using Recursion

        * Problem: Given a stack, sort its elements in ascending order using recursion.

        * Hint: Pop elements recursively, sort the remaining stack, and insert the popped element back at the correct position.
        */

        // add some random numbers for testing
        s.Push(34);
        s.Push(3);
        s.Push(31);
        s.Push(98);
        s.Push(92);
        s.Push(23);

        int ch = 0;
        while(ch != 5)
        {
            Console.WriteLine("\nStack Sort Menu:");
            Console.WriteLine("1 Push new value");
            Console.WriteLine("2 Print current stack");
            Console.WriteLine("3 Sort the stack");
            Console.WriteLine("4 Clear stack");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("Enter value to push : ");
                int vl = Convert.ToInt32(Console.ReadLine());
                s.Push(vl);
                Console.WriteLine("Pushed "+vl);
            }
            else if(ch == 2)
            {
                printStk();
            }
            else if(ch == 3)
            {
                Console.WriteLine("Sorting the stack now ...");
                srt();
                Console.WriteLine("Stack sorted (smallest at bottom)");
            }
            else if(ch == 4)
            {
                s.Clear();
                Console.WriteLine("Stack cleared");
            }

            // show after most actions
            if(ch == 1 || ch == 3 || ch == 4) printStk();
        }
    }
}
