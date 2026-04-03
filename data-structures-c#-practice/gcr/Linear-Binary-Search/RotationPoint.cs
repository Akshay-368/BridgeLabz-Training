using System;

public class bin1 
{
    // find smallest element (rotation point) in rotated sorted array
    // using binary search
    public static int findRotationPoint(int[] arr,int size) 
    {
        int left = 0;
        int right = size-1;

        while(left <= right) 
        {
            int mid = left + (right - left)/2;

            // check if mid is rotation point
            if(mid < right && arr[mid] > arr[mid+1]) 
            {
                return mid+1;
            }

            if(mid > left && arr[mid] < arr[mid-1]) 
            {
                return mid;
            }

            // decide which side to go
            if(arr[mid] > arr[left]) 
            {
                left = mid + 1;
            }
            else 
            {
                right = mid - 1;
            }
        }

        return 0; // not rotated
      // binary search for min element in rotated sorted array
    }

    public static void Main(string[] args) 
    {
        /*
        Binary Search Problem 1: Find the Rotation Point in a Rotated Sorted Array
        Problem: You are given a rotated sorted array. Write a program that performs Binary Search to find the index of the smallest element in the array.
        */

        Console.WriteLine("find rotation point (smallest element)");

        Console.Write("Waiting , for user to enter size : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] nums = new int[n];

        for(int i=0; i<n ; i++) 
        {
            Console.Write("enter sorted rotated number " + (i+1) + " : ");
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        int rotIndex = findRotationPoint(nums , n);

        Console.WriteLine("rotation point (smallest) at index " + rotIndex);
        Console.WriteLine("value is " + nums[rotIndex]);

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
