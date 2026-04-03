using System;

public class mrg 
{
    // helper to merge two sorted parts
    public static void merge(int[] a,int left,int mid,int right) 
    {
        int n1 = mid - left + 1; // size of left part
        int n2 = right - mid;    // size of right part

        int[] lft = new int[n1];
        int[] rgt = new int[n2];

        // copy data to temp arrays
        for(int i=0; i<n1 ; i++) 
        {
            lft[i] = a[left + i];
        }
        for(int j=0; j<n2 ; j++) 
        {
            rgt[j] = a[mid + 1 + j];
        }

        // merge them back
        int ii = 0; // index for left
        int jj = 0; // index for right
        int kk = left; // main array index

        while(ii < n1 && jj < n2) 
        {
            if(lft[ii] <= rgt[jj]) 
            {
                a[kk] = lft[ii];
                ii++;
            }
            else 
            {
                a[kk] = rgt[jj];
                jj++;
            }
            kk++;
        }

        // copy remaining left if any
        while(ii < n1) 
        {
            a[kk] = lft[ii];
            ii++;
            kk++;
        }

        // copy remaining right if any
        while(jj < n2) 
        {
            a[kk] = rgt[jj];
            jj++;
            kk++;
        }
      // now both halves are merged and sorted
    }

    // main merge sort recursive function
    public static void sort(int[] a,int left,int right) 
    {
        if(left < right) 
        {
            int mid = left + (right - left) / 2; // avoid overflow

            sort(a , left , mid);       // sort left half
            sort(a , mid+1 , right);    // sort right half

            merge(a , left , mid , right); // merge them
          // recursive magic happens here
        }
      // base case when left >= right , single element already sorted
    }

    public static void print(int[] a,int size) 
    {
        Console.WriteLine("Sorted book prices are:");
        for(int i=0; i<size ; i++) 
        {
            Console.WriteLine(a[i]);
        }
      // printing each price in new line
    }

    public static void Main(string[] args) 
    {
        /*
        3. Merge Sort - Sort an Array of Book Prices
        Problem Statement:
        A bookstore maintains a list of book prices in an array. Implement Merge Sort in C# to sort the prices in ascending order.
        Hint:

        * Divide the array into two halves recursively.

        * Sort both halves individually.

        * Merge the sorted halves by comparing elements.
        */

        Console.WriteLine("Merge sort for book prices");

        Console.Write("Waiting , for user to enter how many books : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] pr = new int[n];

        for(int i=0; i<n ; i++) 
        {
            Console.Write("Enter price of book "+ (i+1) +" : ");
            pr[i] = Convert.ToInt32(Console.ReadLine());
        }

        // show before sorting
        Console.WriteLine("\nBook prices before sort:");
        for(int i=0; i<n; i++) 
        {
            Console.Write(pr[i] +" ");
        }
        Console.WriteLine("\n");

        sort(pr , 0 , n-1); // call merge sort from 0 to n-1

        print(pr , n); // print final sorted prices

      // done , book prices sorted with merge sort
    }
}
