using System;
using System.Collections.Generic;

public class prs 
{
    // array of numbers
    public static int[] ar;
    public static int tgt; // target sum

    public static bool hasPair() 
    {
        if(ar == null || ar.Length < 2) 
        {
            Console.WriteLine("array too small cant have pair");
            return false;
        }

        Dictionary<int,int> seen = new Dictionary<int,int>();

        for(int i=0; i<ar.Length; i++) 
        {
            int need = tgt - ar[i];

            if(seen.ContainsKey(need)) 
            {
                Console.WriteLine("Yes found pair: "+need+" and "+ar[i]+" (sum = "+tgt+")");
                return true;
            }

            // add current number to seen
            if(!seen.ContainsKey(ar[i])) 
            {
                seen[ar[i]] = 1;
            }
          // we only store once , no need count
        }

        Console.WriteLine("No pair found that sums to "+tgt);
        return false;
      // hash map makes it fast , check complement
    }

    public static void printAr() 
    {
        if(ar == null || ar.Length == 0) 
        {
            Console.WriteLine("array empty nothing to print");
            return;
        }

        Console.WriteLine("Current array:");
        for(int i=0; i<ar.Length; i++) 
        {
            Console.Write(ar[i] + " ");
        }
        Console.WriteLine();
      // simple print with spaces
    }

    public static void Main(string[] args) 
    {
        /*
        Check for a Pair with Given Sum in an Array

        * Problem: Given an array and a target sum, find if there exists a pair of elements whose sum is equal to the target.

        * Hint: Store visited numbers in a hash map and check if target - current_number exists in the map.
        */

        // some test data
        ar = new int[] {10, 5, 3, 7, 12, 1};
        tgt = 10;

        int ch = 0;
        while(ch != 5) 
        {
            Console.WriteLine("\nPair Sum Checker");
            Console.WriteLine("1 Set new array");
            Console.WriteLine("2 Set target sum");
            Console.WriteLine("3 Check for pair");
            Console.WriteLine("4 Print array and target");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter the choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1) 
            {
                Console.Write("How many numbers ? ");
                int nn = Convert.ToInt32(Console.ReadLine());
                ar = new int[nn];

                for(int i=0; i<nn; i++) 
                {
                    Console.Write("Enter number "+(i+1)+" : ");
                    ar[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Array updated");
            }
            else if(ch == 2) 
            {
                Console.Write("Enter new target sum : ");
                tgt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Target set to "+tgt);
            }
            else if(ch == 3) 
            {
                hasPair();
            }
            else if(ch == 4) 
            {
                printAr();
                Console.WriteLine("Target sum: "+tgt);
            }

            if(ch == 3) 
            {
                hasPair();
            }
        }
    }
}
