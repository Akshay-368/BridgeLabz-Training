using System;
using System.Collections.Generic;

public class symDiff 
{
    // find symmetric difference
    // means elements in set1 or set2 but not in both
    public static void findSymmetricDifference(HashSet<int> setA,HashSet<int> setB)
    {
        // create new set for result
        HashSet<int> result = new HashSet<int>();

        // add from setA if not in setB
        foreach(int num in setA)
        {
            if(!setB.Contains(num))
            {
                result.Add(num);
            }
        }

        // add from setB if not in setA
        foreach(int num in setB)
        {
            if(!setA.Contains(num))
            {
                result.Add(num);
            }
        }

        Console.WriteLine("Symmetric difference:");
        if(result.Count == 0)
        {
            Console.WriteLine("no unique elements");
        }
        else
        {
            foreach(int x in result)
            {
                Console.Write(x + " ");
            }
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        3. Symmetric Difference
        Find the symmetric difference (elements present in either set but not both).
        Example:
        Input: {1, 2, 3}, {3, 4, 5}
        Output: {1, 2, 4, 5}
        */

        Console.WriteLine("Find Symmetric Difference of Two Sets\n");

        Console.Write("Waiting , for user to enter size of first set : ");
        int s1 = Convert.ToInt32(Console.ReadLine());
        HashSet<int> setOne = new HashSet<int>();

        Console.WriteLine("enter first set elements:");
        for(int i=0; i<s1 ; i++)
        {
            Console.Write("element " + (i+1) + " : ");
            setOne.Add(Convert.ToInt32(Console.ReadLine()));
        }

        Console.Write("Waiting , for user to enter size of second set : ");
        int s2 = Convert.ToInt32(Console.ReadLine());
        HashSet<int> setTwo = new HashSet<int>();

        Console.WriteLine("enter second set elements:");
        for(int i=0; i<s2 ; i++)
        {
            Console.Write("element " + (i+1) + " : ");
            setTwo.Add(Convert.ToInt32(Console.ReadLine()));
        }

        findSymmetricDifference(setOne , setTwo);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
