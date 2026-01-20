using System;
using System.Collections.Generic;

public class subSet 
{
    // check if setA is subset of setB
    // means every element of setA must be in setB
    public static bool isSubset(HashSet<int> setA,HashSet<int> setB)
    {
        // if setA is bigger than setB , cannot be subset
        if(setA.Count > setB.Count)
        {
            Console.WriteLine("setA bigger than setB , cannot be subset");
            return false;
        }

        // check every element of setA
        foreach(int num in setA)
        {
            if(!setB.Contains(num))
            {
                Console.WriteLine("element " + num + " not found in setB");
                return false;
            }
        }

        Console.WriteLine("setA is subset of setB");
        return true;
    }

    public static void Main(string[] args) 
    {
        /*
        5. Find Subsets
        Check if one set is a subset of another.
        Example:
        Input: {2, 3}, {1, 2, 3, 4}
        Output: true
        */

        Console.WriteLine("Check if one set is subset of another\n");

        Console.Write("Waiting , for user to enter size of first set (subset) : ");
        int s1 = Convert.ToInt32(Console.ReadLine());
        HashSet<int> smallSet = new HashSet<int>();

        Console.WriteLine("enter first set elements:");
        for(int i=0; i<s1 ; i++)
        {
            Console.Write("element " + (i+1) + " : ");
            smallSet.Add(Convert.ToInt32(Console.ReadLine()));
        }

        Console.Write("Waiting , for user to enter size of second set (bigger) : ");
        int s2 = Convert.ToInt32(Console.ReadLine());
        HashSet<int> bigSet = new HashSet<int>();

        Console.WriteLine("enter second set elements:");
        for(int i=0; i<s2 ; i++)
        {
            Console.Write("element " + (i+1) + " : ");
            bigSet.Add(Convert.ToInt32(Console.ReadLine()));
        }

        bool result = isSubset(smallSet , bigSet);

        Console.WriteLine("Result: " + result);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
