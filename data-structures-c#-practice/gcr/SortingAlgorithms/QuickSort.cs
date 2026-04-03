using System;

public class qck 
{
    // helper function to partition around pivot
    public static int partition(int[] pr,int low,int high) 
    {
        int pivot = pr[high]; // choosing last element as pivot
        int i = low-1; // index of smaller element

        for(int j=low; j<high ; j++) 
        {
            if(pr[j] <= pivot) 
            {
                i++; // increment smaller index

                // swap pr[i] and pr[j]
                int tmp = pr[i];
                pr[i] = pr[j];
                pr[j] = tmp;
            }
        }

        // swap pivot with correct position
        int temp = pr[i+1];
        pr[i+1] = pr[high];
        pr[high] = temp;

        return i+1; // return pivot position
      // now all left are <= pivot , all right are > pivot
    }

    // main quick sort function - recursive
    public static void sort(int[] pr,int low,int high) 
    {
        if(low < high) 
        {
            // get partition index
            int pi = partition(pr , low , high);

            // sort elements before partition
            sort(pr , low , pi-1);

            // sort elements after partition
            sort(pr , pi+1 , high);
          // recursive calls on both sides
        }
      // base case when low >= high , single element or empty
    }

    public static void printPrices(int[] pr,int size) 
    {
        Console.WriteLine("Sorted product prices are:");
        for(int i=0; i<size ; i++) 
        {
            Console.WriteLine(pr[i]);
        }
      // printing each price in new line
    }

    public static void Main(string[] args) 
    {
        /*
        4. Quick Sort - Sort Product Prices
        Problem Statement:
        An e-commerce company wants to display product prices in ascending order. Implement Quick Sort in C# to sort the product prices.
        Hint:

        * Pick a pivot element (first, last, or random).

        * Partition the array such that elements smaller than the pivot are on the left and larger ones are on the right.

        * Recursively apply Quick Sort on left and right partitions.
        */

        Console.WriteLine("Quick sort for product prices");

        Console.Write("Waiting , for user to enter how many products : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] price = new int[n];

        for(int i=0; i<n ; i++) 
        {
            Console.Write("Enter price of product "+ (i+1) +" : ");
            price[i] = Convert.ToInt32(Console.ReadLine());
        }

        // just showing before sorting
        Console.WriteLine("\nProduct prices before sort:");
        for(int i=0; i<n; i++) 
        {
            Console.Write(price[i] +" ");
        }
        Console.WriteLine("\n");

        sort(price , 0 , n-1); // call quick sort from 0 to n-1

        printPrices(price , n); // print final sorted prices

      // done , product prices sorted with quick sort
    }
}
