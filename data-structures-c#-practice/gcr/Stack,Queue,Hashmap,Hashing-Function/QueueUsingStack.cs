using System;
using System.Collections.Generic;

public class que 
{
    // two stacks to make queue
    public static Stack<int> enq = new Stack<int>();
    public static Stack<int> deq = new Stack<int>();

    public static void add(int val) 
    {
        enq.Push(val);
      // just push to enq stack , simple enqueue
        Console.WriteLine("Added "+val+" to queue");
    }

    public static int rem() 
    {
        if(deq.Count == 0)
        {
            if(enq.Count == 0)
            {
                Console.WriteLine("queue empty cant remove");
                return -1; // error value
            }

            // move all from enq to deq to reverse order
            while(enq.Count > 0)
            {
                deq.Push(enq.Pop());
            }
          // now deq has elements in proper queue order
        }

        int val = deq.Pop();
        Console.WriteLine("Removed "+val+" from queue");
        return val;
    }

    public static int peek() 
    {
        if(deq.Count == 0)
        {
            if(enq.Count == 0)
            {
                Console.WriteLine("queue empty nothing to peek");
                return -1;
            }

            while(enq.Count > 0)
            {
                deq.Push(enq.Pop());
            }
        }

        int val = deq.Peek();
        Console.WriteLine("Front element is "+val);
        return val;
    }

    public static bool emp() 
    {
        bool isemp = (enq.Count == 0 && deq.Count == 0);
        return isemp;
    }

    public static void printQue() 
    {
        if(emp())
        {
            Console.WriteLine("queue is empty nothing to print");
            return;
        }

        // to print we need to move to deq first
        while(enq.Count > 0)
        {
            deq.Push(enq.Pop());
        }

        Console.WriteLine("Queue from front to back:");
        Stack<int> temp = new Stack<int>();
        while(deq.Count > 0)
        {
            int v = deq.Pop();
            Console.Write(v + " ");
            temp.Push(v);
        }
        Console.WriteLine();

        // put back to deq
        while(temp.Count > 0)
        {
            deq.Push(temp.Pop());
        }
      // printed without losing order , bit verbose but works
    }

    public static void Main(string[] args) 
    {
        /*
        Implement a Queue Using Stacks

        * Problem: Design a queue using two stacks such that enqueue and dequeue operations are performed efficiently.

        * Hint: Use one stack for enqueue and another stack for dequeue. Transfer elements between stacks as needed.
        */

        int ch = 0;
        while(ch != 6)
        {
            Console.WriteLine("\nQueue using Stacks Menu:");
            Console.WriteLine("1 Enqueue (add)");
            Console.WriteLine("2 Dequeue (remove)");
            Console.WriteLine("3 Peek front");
            Console.WriteLine("4 Check if empty");
            Console.WriteLine("5 Print whole queue");
            Console.WriteLine("6 Exit");

            Console.Write("Waiting , for user to enter the choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("Enter value to add : ");
                int vl = Convert.ToInt32(Console.ReadLine());
                add(vl);
            }
            else if(ch == 2)
            {
                rem();
            }
            else if(ch == 3)
            {
                peek();
            }
            else if(ch == 4)
            {
                if(emp())
                    Console.WriteLine("Yes queue is empty");
                else
                    Console.WriteLine("No queue has elements");
            }
            else if(ch == 5)
            {
                printQue();
            }
        }
    }
}
