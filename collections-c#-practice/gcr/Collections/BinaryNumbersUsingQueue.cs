using System;
using System.Collections.Generic;

public class binGen 
{
    // generate first n binary numbers using queue
    public static void generateBinary(int countN)
    {
        if(countN <= 0)
        {
            Console.WriteLine("nothing to generate");
            return;
        }

        Queue<string> q = new Queue<string>();

        // start with "1"
        q.Enqueue("1");

        Console.WriteLine("First " + countN + " binary numbers:");
        for(int i=0; i<countN ; i++)
        {
            string current = q.Dequeue();
            Console.Write(current + " ");

            // add 0 and 1 at end
            q.Enqueue(current + "0");
            q.Enqueue(current + "1");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        Queue Interface Problems
        2. Generate Binary Numbers Using a Queue
        Generate the first N binary numbers using a queue.
        Example:
        Input: N=5
        Output: {"1", "10", "11", "100", "101"}
        */

        Console.WriteLine("Generate first N binary numbers using queue\n");

        Console.Write("Waiting , for user to enter value of N : ");
        int n = Convert.ToInt32(Console.ReadLine());

        generateBinary(n);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
