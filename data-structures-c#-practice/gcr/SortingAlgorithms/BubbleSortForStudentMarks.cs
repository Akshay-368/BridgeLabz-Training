using System;

public class bub 
{
    public static void srt(int[] a,int len) 
    {
        // bubble sort , going again and again till no swap
        // compare next one and swap if big
        for(int i = 0; i < len-1 ; i++ ) 
        {
            bool swpd = false; // to check if swapped this time

            for(int j=0; j < len-i-1 ; j++) 
            {
                if(a[j] > a[j+1]) 
                {
                    // swap them cuz wrong order
                    int tmp = a[j] ;
                    a[j] = a[j+1];
                    a[j+1] = tmp;
                    swpd = true; // yes we swapped
                }
            }

            if(!swpd) 
            {
                // no swap means already sorted , can stop early
                break;
            }
        }
      // now array is sorted ascending , simple bubble way
    }

    public static void prn(int[] a,int len) 
    {
        Console.WriteLine("Sorted student marks are:");
        for(int i=0; i<len ; i++) 
        {
            Console.WriteLine(a[i]);
        }
      // printing each mark in new line
    }

    public static void Main(string[] args) 
    {
        /*
        1. Bubble Sort - Sort Student Marks
        Problem Statement:
        A school maintains student marks in an array. Implement Bubble Sort in C# to sort the student marks in ascending order.
        Hint:

        * Traverse through the array multiple times.

        * Compare adjacent elements and swap them if needed.

        * Repeat the process until no swaps are required
        */

        Console.WriteLine("Bubble sort for student marks");

        Console.Write("Waiting , for user to enter how many students : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] mk = new int[n];

        for(int i=0; i < n ; i++) 
        {
            Console.Write("Enter marks for student "+ (i+1) +" : ");
            mk[i] = Convert.ToInt32(Console.ReadLine());
        }

        // print before sorting , optional but good
        Console.WriteLine("Marks before bubble sort:");
        for(int i=0; i<n; i++) 
        {
            Console.Write(mk[i] +" ");
        }
        Console.WriteLine();

        srt(mk , n); // call the sort function

        prn(mk , n); // print after sort

      // done , marks sorted with bubble sort
    }
}
