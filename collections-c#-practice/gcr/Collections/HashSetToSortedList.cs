using System;
using System.Collections.Generic;

public class setToSort 
{
    // convert hashset to sorted list (ascending)
    // hashset has no order , so we need to sort after
    public static void convertSetToSortedList(HashSet<int> inputSet)
    {
        // create list from set
        List<int> tempList = new List<int>(inputSet);

        // simple bubble sort (not fast but easy to understand)
        for(int i=0; i<tempList.Count-1 ; i++)
        {
            for(int j=0; j<tempList.Count-i-1 ; j++)
            {
                if(tempList[j] > tempList[j+1])
                {
                    int swap = tempList[j];
                    tempList[j] = tempList[j+1];
                    tempList[j+1] = swap;
                }
            }
        }

        Console.WriteLine("Sorted list from set:");
        if(tempList.Count == 0)
        {
            Console.WriteLine("empty set");
        }
        else
        {
            foreach(int x in tempList)
            {
                Console.Write(x + " ");
            }
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        4. Convert a Set to a Sorted List
        Convert a HashSet<int> into a sorted list in ascending order.
        Example:
        Input: {5, 3, 9, 1}
        Output: [1, 3, 5, 9]
        */

        Console.WriteLine("Convert HashSet to Sorted List\n");

        Console.Write("Waiting , for user to enter how many numbers in set : ");
        int n = Convert.ToInt32(Console.ReadLine());

        HashSet<int> numSet = new HashSet<int>();

        Console.WriteLine("enter numbers (duplicates will be ignored):");
        for(int i=0; i<n ; i++)
        {
            Console.Write("number " + (i+1) + " : ");
            numSet.Add(Convert.ToInt32(Console.ReadLine()));
        }

        Console.WriteLine("\nOriginal set:");
        foreach(int x in numSet) Console.Write(x + " ");
        Console.WriteLine();

        convertSetToSortedList(numSet);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
