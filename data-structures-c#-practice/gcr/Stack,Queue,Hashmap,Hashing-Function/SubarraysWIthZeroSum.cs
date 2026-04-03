using System;
using System.Collections.Generic;

public class zsub 
{
    // array of nums
    public static int[] ar;

    public static void fndZero() 
    {
        if(ar == null || ar.Length == 0) 
        {
            Console.WriteLine("array empty cant find anything");
            return;
        }

        Dictionary<int,int> mp = new Dictionary<int,int>();
        int csum = 0; // cumulative sum

        List<string> res = new List<string>();

        mp.Add(0,1); // for subarray starting from 0

        for(int i=0; i<ar.Length; i++) 
        {
            csum += ar[i];

            if(mp.ContainsKey(csum)) 
            {
                // means from previous positions to here sum zero
                // actually we need all previous occurrences
                // but since we want all subarrays , we collect them
                // wait no , frequency not needed for positions , we need indices

                // wait i think i did it wrong , better to store list of indices
            }
        }

        // redo properly with list of indices
        Dictionary<int,List<int>> smp = new Dictionary<int,List<int>>();

        csum = 0;
        smp[0] = new List<int>();
        smp[0].Add(-1); // before start

        Console.WriteLine("Zero sum subarrays found:");

        bool fndany = false;

        for(int i=0; i<ar.Length; i++) 
        {
            csum += ar[i];

            if(!smp.ContainsKey(csum))
            {
                smp[csum] = new List<int>();
            }

            // for each previous same sum , subarray from prev+1 to i
            if(smp[csum].Count > 0) 
            {
                foreach(int prev in smp[csum]) 
                {
                    int st = prev + 1;
                    int en = i;

                    string sub = "";
                    for(int j=st; j<=en; j++) 
                    {
                        sub += ar[j] + " ";
                    }

                    Console.WriteLine("From index "+st+" to "+en+" : "+sub);
                    fndany = true;
                }
            }

            smp[csum].Add(i); // add current index
          // this way we catch all possible zero sum subarrays
        }

        if(!fndany) 
        {
            Console.WriteLine("No zero sum subarray found");
        }
    }

    public static void printAr() 
    {
        if(ar == null || ar.Length == 0) 
        {
            Console.WriteLine("array is empty");
            return;
        }

        Console.WriteLine("Current array:");
        foreach(int v in ar) 
        {
            Console.Write(v + " ");
        }
        Console.WriteLine();
      // simple printing with space
    }

    public static void Main(string[] args) 
    {
        /*
        Find All Subarrays with Zero Sum

        * Problem: Given an array, find all subarrays whose elements sum up to zero.

        */

        // test array with multiple zero sums
        ar = new int[] {4, 2, -3, 1, 6, -3, 2, 0, 5, -2};

        int ch = 0;
        while(ch != 5) 
        {
            Console.WriteLine("\nZero Sum Subarray Finder");
            Console.WriteLine("1 Set new array");
            Console.WriteLine("2 Print current array");
            Console.WriteLine("3 Find all zero sum subarrays");
            Console.WriteLine("4 Use test data");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter the choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1) 
            {
                Console.Write("How many elements ? ");
                int nn = Convert.ToInt32(Console.ReadLine());
                ar = new int[nn];

                for(int i=0; i<nn; i++) 
                {
                    Console.Write("Enter element "+(i+1)+" : ");
                    ar[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("New array set");
            }
            else if(ch == 2) 
            {
                printAr();
            }
            else if(ch == 3) 
            {
                fndZero();
            }
            else if(ch == 4) 
            {
                ar = new int[] {4, 2, -3, 1, 6, -3, 2, 0, 5, -2};
                Console.WriteLine("Test data loaded");
            }

            if(ch == 3) 
            {
                fndZero();
            }
        }
    }
}
