using System;
using System.Collections.Generic;

public class setOp 
{
    // compute union and intersection of two sets
    public static void showUnionAndIntersection(HashSet<int> s1,HashSet<int> s2)
    {
        // union = all unique from both
        HashSet<int> unionSet = new HashSet<int>(s1);
        unionSet.UnionWith(s2);

        // intersection = common elements
        HashSet<int> interSet = new HashSet<int>(s1);
        interSet.IntersectWith(s2);

        Console.WriteLine("Union:");
        foreach(int x in unionSet) Console.Write(x + " ");
        Console.WriteLine();

        Console.WriteLine("Intersection:");
        foreach(int x in interSet) Console.Write(x + " ");
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        Set Interface Problems
        2. Union and Intersection of Two Sets
        Compute the union and intersection of two sets.
        Example:
        Set1: {1, 2, 3}, Set2: {3, 4, 5}
        Output:
        Union: {1, 2, 3, 4, 5}
        Intersection: {3}
        */

        Console.WriteLine("Union & Intersection of Sets\n");

        Console.Write("Waiting , for user to enter size of set1 : ");
        int s1 = Convert.ToInt32(Console.ReadLine());
        HashSet<int> setA = new HashSet<int>();

        Console.WriteLine("enter set1:");
        for(int i=0; i<s1 ; i++)
        {
            Console.Write("element " + (i+1) + " : ");
            setA.Add(Convert.ToInt32(Console.ReadLine()));
        }

        Console.Write("Waiting , for user to enter size of set2 : ");
        int s2 = Convert.ToInt32(Console.ReadLine());
        HashSet<int> setB = new HashSet<int>();

        Console.WriteLine("enter set2:");
        for(int i=0; i<s2 ; i++)
        {
            Console.Write("element " + (i+1) + " : ");
            setB.Add(Convert.ToInt32(Console.ReadLine()));
        }

        showUnionAndIntersection(setA , setB);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
