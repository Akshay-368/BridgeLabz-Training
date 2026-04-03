using System;
using System.Collections.Generic;

public class setEq 
{
    // check if two sets have same elements (ignore order)
    public static bool areSetsEqual(HashSet<int> set1,HashSet<int> set2)
    {
        // first check size
        if(set1.Count != set2.Count)
        {
            Console.WriteLine("sizes different , not equal");
            return false;
        }

        // check every element of set1 in set2
        foreach(int val in set1)
        {
            if(!set2.Contains(val))
            {
                Console.WriteLine("element " + val + " not in second set");
                return false;
            }
        }

        Console.WriteLine("both sets are equal");
        return true;
    }

    public static void Main(string[] args) 
    {
        /*
        Set Interface Problems
        1. Check if Two Sets Are Equal
        Compare two sets and determine if they contain the same elements, regardless of order.
        Example:
        Set1: {1, 2, 3}, Set2: {3, 2, 1}
        Output: true
        */

        Console.WriteLine("Check if two sets are equal\n");

        Console.Write("Waiting , for user to enter size of set1 : ");
        int s1 = Convert.ToInt32(Console.ReadLine());
        HashSet<int> setOne = new HashSet<int>();

        Console.WriteLine("enter set1 elements:");
        for(int i=0; i<s1 ; i++)
        {
            Console.Write("element " + (i+1) + " : ");
            setOne.Add(Convert.ToInt32(Console.ReadLine()));
        }

        Console.Write("Waiting , for user to enter size of set2 : ");
        int s2 = Convert.ToInt32(Console.ReadLine());
        HashSet<int> setTwo = new HashSet<int>();

        Console.WriteLine("enter set2 elements:");
        for(int i=0; i<s2 ; i++)
        {
            Console.Write("element " + (i+1) + " : ");
            setTwo.Add(Convert.ToInt32(Console.ReadLine()));
        }

        bool equal = areSetsEqual(setOne , setTwo);

        Console.WriteLine("Result: " + equal);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
