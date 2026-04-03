using System;
using System.Collections.Generic;

public class lcs 
{
    // array of nums
    public static int[] ar;

    public static int findLong() 
    {
        if(ar == null || ar.Length == 0) 
        {
            Console.WriteLine("array empty no sequence");
            return 0;
        }

        HashSet<int> st = new HashSet<int>();

        // put all numbers in set
        for(int i=0; i<ar.Length; i++) 
        {
            st.Add(ar[i]);
        }

        int mxln = 0;

        foreach(int num in st) 
        {
            // only start if this is beginning of sequence
            if(!st.Contains(num - 1)) 
            {
                int cur = num;
                int cln = 1;

                // keep going forward while next exists
                while(st.Contains(cur + 1)) 
                {
                    cur++;
                    cln++;
                }

                if(cln > mxln) 
                {
                    mxln = cln;
                }
            }
          // this way we skip non-starting numbers , efficient
        }

        Console.WriteLine("Longest consecutive sequence length is "+mxln);
        return mxln;
      // hash set helps check in O(1) time
    }

    public static void printAr() 
    {
        if(ar == null || ar.Length == 0) 
        {
            Console.WriteLine("array is empty cant print");
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
        Longest Consecutive Sequence

        * Problem: Given an unsorted array, find the length of the longest consecutive elements sequence.

        * Hint: Use a hash map to store elements and check for consecutive elements efficiently.
        */

        // test data for which I hardcoded the values
        ar = new int[] {100, 4, 200, 1, 3, 2, 5, 101, 102};

        int ch = 0;
        while(ch != 5) 
        {
            Console.WriteLine("\nLongest Consecutive Sequence Finder");
            Console.WriteLine("1 Set new array");
            Console.WriteLine("2 Print current array");
            Console.WriteLine("3 Find longest sequence length");
            Console.WriteLine("4 Use test data");
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
                Console.WriteLine("New array set");
            }
            else if(ch == 2) 
            {
                printAr();
            }
            else if(ch == 3) 
            {
                findLong();
            }
            else if(ch == 4) 
            {
                ar = new int[] {100, 4, 200, 1, 3, 2, 5, 101, 102};
                Console.WriteLine("Test data loaded");
            }

            if(ch == 3) 
            {
                findLong();
            }
        }
    }
}
