using System;

public class bin4 
{
    // find first and last position of target in sorted array
    public static void findFirstAndLast(int[] arr,int size,int target) 
    {
        int first = -1;
        int last = -1;

        // find first occurrence
        int left = 0;
        int right = size-1;

        while(left <= right) 
        {
            int mid = left + (right - left)/2;

            if(arr[mid] == target) 
            {
                first = mid;
                right = mid - 1; // look left for earlier
            }
            else if(arr[mid] < target) 
            {
                left = mid + 1;
            }
            else 
            {
                right = mid - 1;
            }
        }

        // find last occurrence
        left = 0;
        right = size-1;

        while(left <= right) 
        {
            int mid = left + (right - left)/2;

            if(arr[mid] == target) 
            {
                last = mid;
                left = mid + 1; // look right for later
            }
            else if(arr[mid] < target) 
            {
                left = mid + 1;
            }
            else 
            {
                right = mid - 1;
            }
        }

        if(first == -1) 
        {
            Console.WriteLine("target not found");
        }
        else 
        {
            Console.WriteLine("first occurrence at " + first);
            Console.WriteLine("last occurrence at " + last);
        }
      // two binary searches for first and last
    }

    public static void Main(string[] args) 
    {
        /*
        Binary Search Problem 4: Find the First and Last Occurrence of an Element in a Sorted Array
        Problem: Given a sorted array and a target element, write a program that uses Binary Search to find the first and last occurrence of the target element in the array.
        */

        Console.WriteLine("find first and last position of target");

        Console.Write("Waiting , for user to enter size : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];

        Console.WriteLine("enter sorted array");

        for(int i=0; i<n ; i++) 
        {
            Console.Write("enter number " + (i+1) + " : ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Waiting , for user to enter target : ");
        int tgt = Convert.ToInt32(Console.ReadLine());

        findFirstAndLast(arr , n , tgt);

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
