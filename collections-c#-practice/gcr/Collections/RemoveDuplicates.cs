using System;
using System.Collections.Generic;

public class dupRem 
{
    // remove duplicates but keep first occurrence order
    // simple way - use another list to track seen
    public static void removeDuplicates(List<int> numList)
    {
        // list to store unique elements in order
        List<int> unique = new List<int>();

        // set to track seen elements (fast check)
        HashSet<int> seen = new HashSet<int>();

        for(int i=0; i<numList.Count ; i++)
        {
            int current = numList[i];

            // if not seen before
            if(!seen.Contains(current))
            {
                seen.Add(current);
                unique.Add(current);
            }
        }

        // copy back to original
        numList.Clear();
        for(int i=0; i<unique.Count ; i++)
        {
            numList.Add(unique[i]);
        }

        Console.WriteLine("duplicates removed , order preserved");
    }

    public static void Main(string[] args) 
    {
        /*
        4. Remove Duplicates While Preserving Order
        Remove duplicate elements from a list while maintaining the original order.
        Example:
        Input: [3, 1, 2, 2, 3, 4]
        Output: [3, 1, 2, 4]
        */

        Console.WriteLine("Remove Duplicates Preserving Order\n");

        Console.Write("Waiting , for user to enter how many numbers : ");
        int n = Convert.ToInt32(Console.ReadLine());

        List<int> numbers = new List<int>();

        Console.WriteLine("enter numbers (with duplicates ok):");
        for(int i=0; i<n ; i++)
        {
            Console.Write("number " + (i+1) + " : ");
            numbers.Add(Convert.ToInt32(Console.ReadLine()));
        }

        Console.WriteLine(" Before removing duplicates:");
        foreach(int x in numbers) Console.Write(x + " ");
        Console.WriteLine();

        removeDuplicates(numbers);

        Console.WriteLine("After removing:");
        foreach(int x in numbers) Console.Write(x + " ");
        Console.WriteLine();

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
