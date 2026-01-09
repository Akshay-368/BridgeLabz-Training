using System;

public class ins 
{
    // simple insertion sort for employee ids
    public static void sort(int[] ids,int size) 
    {
        // first one is already sorted , start from second
        for(int i=1; i<size ; i++) 
        {
            int key = ids[i]; // the one we want to insert
            int j = i-1; // last of sorted part

            // move bigger elements one step right
            while(j>=0 && ids[j] > key) 
            {
                ids[j+1] = ids[j]; // shift right
                j--; // go left
            }

            ids[j+1] = key; // put key at right place
          // now sorted part has one more element
        }
      // array is sorted now , very simple insertion way
    }

    public static void printids(int[] ids,int size) 
    {
        Console.WriteLine("Sorted employee ids are:");
        for(int i=0; i<size ; i++) 
        {
            Console.WriteLine(ids[i]);
        }
      // printing each id in new line
    }

    public static void Main(string[] args) 
    {
        /*
        2. Insertion Sort - Sort Employee IDs
        Problem Statement:
        A company stores employee IDs in an unsorted array. Implement Insertion Sort in C# to sort the employee IDs in ascending order.
        Hint:

        * Divide the array into sorted and unsorted parts.

        * Pick an element from the unsorted part and insert it into its correct position in the sorted part.

        * Repeat for all elements.
        */

        Console.WriteLine("Insertion sort for employee IDs");

        Console.Write("Waiting , for user to enter how many employees : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] emp = new int[n];

        for(int i=0; i<n ; i++) 
        {
            Console.Write("Enter employee id "+ (i+1) +" : ");
            emp[i] = Convert.ToInt32(Console.ReadLine());
        }

        // just showing before sorting
        Console.WriteLine("Employee IDs before sort:");
        for(int i=0; i<n; i++) 
        {
            Console.Write(emp[i] +" ");
        }
        Console.WriteLine("\n");

        sort(emp , n); // call insertion sort

        printids(emp , n); // print final sorted list

      // done , employee ids sorted with insertion sort
    }
}
