using System;

public class bin2 
{
    // find any peak element (greater than both neighbors)
    // using binary search approach
    public static int findPeak(int[] arr,int size) 
    {
        int left = 0;
        int right = size-1;

        while(left < right) 
        {
            int mid = left + (right - left)/2;

            // if mid is peak
            if((mid == 0 || arr[mid] >= arr[mid-1]) && 
               (mid == size-1 || arr[mid] >= arr[mid+1])) 
            {
                return mid;
            }

            // decide side
            if(mid > 0 && arr[mid] < arr[mid-1]) 
            {
                right = mid - 1;
            }
            else 
            {
                left = mid + 1;
            }
        }

        return left; // last element could be peak
      // binary search for peak element
    }

    public static void Main(string[] args) 
    {
        /*
        Binary Search Problem 2: Find the Peak Element in an Array
        Problem: A peak element is an element that is greater than its neighbors. Write a program that performs Binary Search to find a peak element in an array.
        */

        Console.WriteLine("find peak element");

        Console.Write("Waiting , for user to enter size : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] nums = new int[n];

        for(int i=0; i<n ; i++) 
        {
            Console.Write("enter number " + (i+1) + " : ");
            nums[i] = Convert.ToInt32(Console.ReadLine());
        }

        int peakIndex = findPeak(nums , n);

        Console.WriteLine("peak element found at index " + peakIndex);
        Console.WriteLine("value = " + nums[peakIndex]);

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
