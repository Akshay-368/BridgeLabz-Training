using System;

public class lin1 
{
    // find first negative number in array using simple linear search
    public static int findFirstNeg(int[] nums,int size) 
    {
        // go through each element one by one
        for(int i=0; i<size ; i++) 
        {
            if(nums[i] < 0) 
            {
                // found first negative , return its index
                Console.WriteLine("first negative found at position " + i);
                return i;
            }
        }

        // if no negative found
        Console.WriteLine("no negative number in array");
        return -1;
      // simple linear search , nothing fancy
    }

    public static void Main(string[] args) 
    {
        /*
        Linear Search Problem 1: Search for the First Negative Number
        Problem: You are given an integer array. Write a program that performs Linear Search to find the first negative number in the array.
        */

        Console.WriteLine("find first negative number in array");

        Console.Write("Waiting , for user to enter how many numbers : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] arr = new int[n];

        for(int i=0; i<n ; i++) 
        {
            Console.Write("enter number " + (i+1) + " : ");
            arr[i] = Convert.ToInt32(Console.ReadLine());
        }

        int resultIndex = findFirstNeg(arr , n);

        if(resultIndex != -1) 
        {
            Console.WriteLine("first negative is " + arr[resultIndex]);
        }

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
