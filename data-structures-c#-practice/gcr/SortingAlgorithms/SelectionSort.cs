using System;

public class sel 
{
    // simple selection sort for exam scores
    public static void srt(int[] sc,int sz) 
    {
        // for each position , find the smallest in remaining part
        for(int i=0; i<sz-1 ; i++) 
        {
            int minidx = i; // assume current is smallest

            // look for smaller in unsorted part
            for(int j=i+1; j<sz ; j++) 
            {
                if(sc[j] < sc[minidx]) 
                {
                    minidx = j; // found smaller
                }
            }

            // swap if we found smaller one
            if(minidx != i) 
            {
                int temp = sc[i];
                sc[i] = sc[minidx];
                sc[minidx] = temp;
            }
          // now position i is fixed with smallest value
        }
      // whole array is sorted now , simple selection sort
    }

    public static void prnt(int[] sc,int sz) 
    {
        Console.WriteLine("Sorted exam scores are:");
        for(int i=0; i<sz ; i++) 
        {
            Console.WriteLine(sc[i]);
        }
      // printing each score in new line
    }

    public static void Main(string[] args) 
    {
        /*
        5. Selection Sort - Sort Exam Scores
        Problem Statement:
        A university needs to sort students’ exam scores in ascending order. Implement Selection Sort in C# to achieve this.
        Hint:

        * Find the minimum element in the array.

        * Swap it with the first unsorted element.

        * Repeat the process for the remaining elements.
        */

        Console.WriteLine("Selection sort for exam scores");

        Console.Write("Waiting , for user to enter how many students : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] score = new int[n];

        for(int i=0; i<n ; i++) 
        {
            Console.Write("Enter exam score of student "+ (i+1) +" : ");
            score[i] = Convert.ToInt32(Console.ReadLine());
        }

        // just showing marks before sorting
        Console.WriteLine("\nExam scores before sort:");
        for(int i=0; i<n; i++) 
        {
            Console.Write(score[i] +" ");
        }
        Console.WriteLine("\n");

        srt(score , n); // call selection sort

        prnt(score , n); // print final sorted scores

      // done , exam scores sorted with selection sort
    }
}
