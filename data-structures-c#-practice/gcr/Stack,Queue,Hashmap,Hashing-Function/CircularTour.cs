using System;
using System.Collections.Generic;

public class cir 
{
    // petrol and dist arrays
    public static int[] pet;
    public static int[] dis;
    public static int n;

    public static int findStart() 
    {
        if(pet == null || dis == null || pet.Length != dis.Length)
        {
            Console.WriteLine("invalid data cant find");
            return -1;
        }

        n = pet.Length;
        Queue<int> q = new Queue<int>();

        int sur = 0; // surplus petrol
        int st = 0;  // possible start

        for(int i=0; i<n; i++) 
        {
            q.Enqueue(i); // add all pumps first

            sur += pet[i] - dis[i]; // petrol gain or loss

            // if surplus negative , cant start from previous ones
            while(sur < 0 && q.Count > 0)
            {
                int rem = q.Dequeue();
                sur -= pet[rem] - dis[rem]; // remove that pump effect
                st = (rem + 1) % n; // new possible start next one
            }
        }

        // after full tour if surplus >=0 then ok
        if(sur >= 0)
        {
            return st;
        }
        else
        {
            return -1; // no possible tour
        }
      // queue helps simulate removing failed starts
    }

    public static void printTour(int start) 
    {
        if(start == -1)
        {
            Console.WriteLine("No possible circular tour");
            return;
        }

        Console.WriteLine("Starting pump index: "+start);
        Console.WriteLine("Tour order:");

        int curpet = 0;
        for(int i=0; i<n; i++)
        {
            int idx = (start + i) % n;
            curpet += pet[idx];
            Console.WriteLine("Visit pump "+idx+" (petrol "+pet[idx]+") current petrol "+curpet);
            curpet -= dis[idx];
            if(curpet < 0)
            {
                Console.WriteLine("Failed but we already checked it works");
                break;
            }
        }
      // just printing the tour step by step
    }

    public static void setData(int[] p,int[] d) 
    {
        pet = p;
        dis = d;
        Console.WriteLine("Data set for "+n+" pumps");
    }

    public static void Main(string[] args) 
    {
        /*
        Circular Tour Problem

        * Problem: Given a set of petrol pumps with petrol and distance to the next pump, determine the starting point for completing a circular tour.

        * Hint: Use a queue to simulate the tour, keeping track of surplus petrol at each pump
        */

        // test case that works
        int[] petrol = {4, 6, 7, 4};
        int[] distance = {6, 5, 3, 5};
        setData(petrol, distance);

        int ch = 0;
        while(ch != 5)
        {
            Console.WriteLine("\nCircular Tour Problem");
            Console.WriteLine("1 Set new pump data");
            Console.WriteLine("2 Find starting point");
            Console.WriteLine("3 Print tour");
            Console.WriteLine("4 Use test data");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter the choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("How many pumps ? ");
                n = Convert.ToInt32(Console.ReadLine());
                pet = new int[n];
                dis = new int[n];

                for(int i=0; i<n; i++)
                {
                    Console.Write("Enter petrol at pump "+i+" : ");
                    pet[i] = Convert.ToInt32(Console.ReadLine());
                    Console.Write("Enter distance to next from pump "+i+" : ");
                    dis[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("New data entered");
            }
            else if(ch == 2 || ch == 3)
            {
                int str = findStart();
                printTour(str);
            }
            else if(ch == 4)
            {
                setData(petrol, distance);
            }

            if(ch == 2 || ch == 3)
            {
                int str = findStart();
                printTour(str);
            }
        }
    }
}
