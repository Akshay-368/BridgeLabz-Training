using System;
using System.Collections.Generic;

public class ts 
{
    // arr for nums and tgt for target sum
    public static int[] ar;
    public static int tgt;

    public static void fndTwo() 
    {
        if(ar == null || ar.Length < 2) 
        {
            Console.WriteLine("ar too smal , need at least 2 nums to find pair");
            return;
        }

        Dictionary<int,int> mp = new Dictionary<int,int>(); // ky num val index

        for(int i=0; i<ar.Length; i++) 
        {
            int need = tgt - ar[i]; // what we need to reach tgt

            if(mp.ContainsKey(need)) 
            {
                int idx1 = mp[need]; // first index found
                int idx2 = i; // current index

                Console.WriteLine("Found pair at indices "+idx1+" and "+idx2);
                Console.WriteLine("Values: "+ar[idx1]+" + "+ar[idx2]+" = "+tgt);
                return; // found one pair , done
            }

            // store current num and its index if not there already
            if(!mp.ContainsKey(ar[i])) 
            {
                mp[ar[i]] = i;
            }
          // hash map stores seen nums with first index , O(1) lookup why fast
        }

        Console.WriteLine("No two sum pair found for target "+tgt);
      // if loop ends no pair exists
    }

    public static void prntAr() 
    {
        if(ar == null || ar.Length == 0) 
        {
            Console.WriteLine("ar is empty , nothing to printing");
            return;
        }

        Console.WriteLine("Current array elements :");
        for(int i=0; i<ar.Length ; i++) 
        {
            Console.Write(ar[i]+" ");
        }
        Console.WriteLine(); // new line after print
      // prints all nums with space separation simple way
    }

    public static void setAr(int[] nw) 
    {
        ar = nw;
        Console.WriteLine("Array set with "+nw.Length+" elements");
    }

    public static void setTgt(int t) 
    {
        tgt = t;
        Console.WriteLine("Target sum set to "+t);
    }

    public static void Main(string[] args) 
    {
        /*
        Two Sum Problem

        * Problem: Given an array and a target sum, find two indices such that their values add up to the target.

        * Hint: Use a hash map to store the index of each element as you iterate. Check if target - current_element exists in the map.
        */

        // test data with known pair 2+7=9 indices 1,3
        ar = new int[]{2,7,11,15};
        tgt = 9;

        int ch=0;
        while(ch !=6 ) 
        {
            Console.WriteLine("\n=== Two Sum Problem ===");
            Console.WriteLine("1 Set new array");
            Console.WriteLine("2 Set new target sum");
            Console.WriteLine("3 Printing current array");
            Console.WriteLine("4 Find two sum indices");
            Console.WriteLine("5 Use test data");
            Console.WriteLine("6 Exit");

            Console.Write("Waiting , for user to enter the inupt : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch ==1) 
            {
                Console.Write("How many nums in ar ? ");
                int nn = Convert.ToInt32(Console.ReadLine());
                ar = new int[nn];

                for(int i=0; i<nn; i++) 
                {
                    Console.Write("Enter num at pos "+i+" : ");
                    ar[i] = Convert.ToInt32(Console.ReadLine());
                }
                Console.WriteLine("Ar updated succesfuly");
            }
            else if(ch ==2 ) 
            {
                Console.Write("Enter target sum value : ");
                tgt = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Tgt set ok");
            }
            else if(ch ==3) 
            {
                prntAr();
                Console.WriteLine("Target is : "+tgt);
            }
            else if(ch ==4) 
            {
                fndTwo();
            }
            else if(ch ==5) 
            {
                ar = new int[]{2,7,11,15};
                tgt = 9;
                Console.WriteLine("Test data loaded (2+7=9 at indices 1,3)");
                prntAr();
            }
        }
    }
}
