using System;
using System.Collections.Generic;

public class revQ 
{
    // reverse queue using only queue operations
    // we use extra queue as helper
    public static void reverseQueue(Queue<int> q)
    {
        // if empty or one element , nothing to reverse
        if(q.Count <= 1)
        {
            Console.WriteLine("nothing to reverse");
            return;
        }

        // create temp queue
        Queue<int> temp = new Queue<int>();

        // empty original into temp (this reverses)
        while(q.Count > 0)
        {
            temp.Enqueue(q.Dequeue());
        }

        // now put back to original
        while(temp.Count > 0)
        {
            q.Enqueue(temp.Dequeue());
        }

        Console.WriteLine("queue reversed using helper queue");
    }

    public static void Main(string[] args) 
    {
        /*
        Queue Interface Problems
        1. Reverse a Queue
        Reverse the elements of a queue using only queue operations.
        Example:
        Input: [10, 20, 30]
        Output: [30, 20, 10]
        */

        Console.WriteLine("Reverse Queue using only queue operations\n");

        Console.Write("Waiting , for user to enter how many numbers : ");
        int n = Convert.ToInt32(Console.ReadLine());

        Queue<int> queue = new Queue<int>();

        Console.WriteLine("enter numbers:");
        for(int i=0; i<n ; i++)
        {
            Console.Write("number " + (i+1) + " : ");
            queue.Enqueue(Convert.ToInt32(Console.ReadLine()));
        }

        Console.WriteLine("\nBefore reverse:");
        foreach(int x in queue) Console.Write(x + " ");
        Console.WriteLine();

        reverseQueue(queue);

        Console.WriteLine("After reverse:");
        foreach(int x in queue) Console.Write(x + " ");
        Console.WriteLine();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
