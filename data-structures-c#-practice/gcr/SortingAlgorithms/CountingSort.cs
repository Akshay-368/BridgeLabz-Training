using System;

public class cnt 
{
    // counting sort for student ages (10 to 18 only)
    public static void sort(int[] age,int n) 
    {
        // since ages 10 to 18 , range is small
        int max = 18;
        int min = 10;
        int range = max - min + 1; // 9 possible ages

        int[] count = new int[range]; // count how many of each age

        // step 1 : count frequency of each age
        for(int i=0; i<n ; i++) 
        {
            count[age[i] - min]++;
        }

        // step 2 : make it cumulative (position where each age should start)
        for(int i=1; i<range ; i++) 
        {
            count[i] = count[i] + count[i-1];
        }

        // step 3 : create output array and place ages from right to left
        int[] output = new int[n];

        for(int i=n-1; i>=0 ; i--) 
        {
            int pos = count[age[i] - min] - 1; // position to place
            output[pos] = age[i];
            count[age[i] - min]--; // decrease count for next same age
        }

        // copy back to original array
        for(int i=0; i<n ; i++) 
        {
            age[i] = output[i];
        }
      // now ages are sorted in ascending order
    }

    public static void prnt(int[] age,int n) 
    {
        Console.WriteLine("Sorted student ages are:");
        for(int i=0; i<n ; i++) 
        {
            Console.WriteLine(age[i]);
        }
      // printing each age in new line
    }

    public static void Main(string[] args) 
    {
        /*
        7. Counting Sort - Sort Student Ages
        Problem Statement:
        A school collects students’ ages (ranging from 10 to 18) and wants them sorted. Implement Counting Sort in C# for this task.
        Hint:

        * Create a count array to store the frequency of each age.

        * Compute cumulative frequencies to determine positions.

        * Place elements in their correct positions in the output array.
        */

        Console.WriteLine("Counting sort for student ages (10-18)");

        Console.Write("Waiting , for user to enter how many students : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] ages = new int[n];

        Console.WriteLine("Enter ages only between 10 to 18");

        for(int i=0; i<n ; i++) 
        {
            Console.Write("Enter age of student "+ (i+1) +" : ");
            int ag = Convert.ToInt32(Console.ReadLine());

            if(ag < 10 || ag > 18) 
            {
                Console.WriteLine("Invalid age , using 15 as default");
                ag = 15;
            }

            ages[i] = ag;
        }

        // show before sorting
        Console.WriteLine("\nAges before sort:");
        for(int i=0; i<n; i++) 
        {
            Console.Write(ages[i] +" ");
        }
        Console.WriteLine("\n");

        sort(ages , n); // call counting sort

        prnt(ages , n); // print final sorted ages

      // done , student ages sorted with counting sort
    }
}
