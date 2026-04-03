using System;

public class missAndSearch 
{
    // this function finds first missing positive integer
    // using linear search with negative marking trick
    // we assume array has only positive numbers , but we handle negatives too
    public static int findFirstMissingPositive(int[] nums,int size) 
    {
        // step 1: ignore negatives and zeros , make them 1 or something
        // we will use negative marking method
        for(int i=0; i<size ; i++) 
        {
            if(nums[i] <= 0) 
            {
                nums[i] = 1; // treat as 1 , so we dont get confused
            }
        }

        // step 2: mark visited numbers as negative
        // if number is between 1 and size , mark that index negative
        for(int i=0; i<size ; i++) 
        {
            int absValue = Math.Abs(nums[i]);

            // only mark if within range
            if(absValue >= 1 && absValue <= size) 
            {
                // mark the index absValue-1 as negative
                int indexToMark = absValue - 1;

                if(nums[indexToMark] > 0) 
                {
                    nums[indexToMark] = -nums[indexToMark];
                }
            }
        }

        // step 3: find first positive index (means missing)
        for(int i=0; i<size ; i++) 
        {
            if(nums[i] > 0) 
            {
                Console.WriteLine("first missing positive is " + (i+1));
                return i+1;
            }
        }

        // if all 1 to n present , next missing is n+1
        Console.WriteLine("all numbers 1 to " + size + " present , missing is " + (size+1));
        return size + 1;
      // linear search done with marking , simple and works in O(n) time
    }

    // simple binary search for target in sorted array
    public static int binarySearchTarget(int[] nums,int size,int target) 
    {
        int leftSide = 0;
        int rightSide = size - 1;

        while(leftSide <= rightSide) 
        {
            int middle = leftSide + (rightSide - leftSide)/2;

            if(nums[middle] == target) 
            {
                Console.WriteLine("target " + target + " found at index " + middle);
                return middle;
            }

            if(nums[middle] < target) 
            {
                leftSide = middle + 1;
            }
            else 
            {
                rightSide = middle - 1;
            }
        }

        Console.WriteLine("target " + target + " not found");
        return -1;
      // binary search needs sorted array , returns index or -1
    }

    public static void Main(string[] args) 
    {
        /*
        Challenge Problem (for both Linear and Binary Search)
        Problem:
        You are given a list of integers. Write a program that uses Linear Search to find the first missing positive integer in the list and Binary Search to find the index of a given target number.
        Approach:

        1. Linear Search for the first missing positive integer:

           * Iterate through the list and mark each number in the list as visited (you can use negative marking or a separate array).

           * Traverse the array again to find the first positive integer that is not marked.

        2. Binary Search for the target index:

           * After sorting the array, perform binary search to find the index of the given target number.

           * Return the index if found, otherwise return -1.
        */

        Console.WriteLine(" Missing Positive + Binary Search Challenge ");

        Console.Write("Waiting , for user to enter how many numbers in array : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[n];

        Console.WriteLine("enter numbers (can have negatives, zeros, duplicates)");
        for(int i=0; i<n ; i++) 
        {
            Console.Write("number " + (i+1) + " : ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        // part 1: first missing positive
        Console.WriteLine(" Finding first missing positive...");
        int missing = findFirstMissingPositive(numbers , n);

        // note: after this function , array is modified (some negatives) , so we make copy for binary search
        int[] copyForBinary = new int[n];
        for(int i=0; i<n ; i++) 
        {
            copyForBinary[i] = numbers[i];
        }

        // sort the copy for binary search
        Array.Sort(copyForBinary);

        Console.Write(" Waiting , for user to enter target number to search : ");
        int target = Convert.ToInt32(Console.ReadLine());

        // part 2: binary search
        Console.WriteLine(" Searching target in sorted array...");
        int foundIndex = binarySearchTarget(copyForBinary , n , target);

        Console.WriteLine(" Press any key to exit...");
        Console.ReadKey();
    }
}
