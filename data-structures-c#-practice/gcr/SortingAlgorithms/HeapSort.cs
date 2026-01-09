using System;

public class hp 
{
    // helper to heapify a subtree rooted at idx
    public static void heapify(int[] sal,int n,int idx) 
    {
        int largest = idx;        // assume root is largest
        int l = 2 * idx + 1;      // left child
        int r = 2 * idx + 2;      // right child

        // check if left child is bigger
        if(l < n && sal[l] > sal[largest]) 
        {
            largest = l;
        }

        // check if right child is bigger
        if(r < n && sal[r] > sal[largest]) 
        {
            largest = r;
        }

        // if largest is not root
        if(largest != idx) 
        {
            // swap
            int temp = sal[idx];
            sal[idx] = sal[largest];
            sal[largest] = temp;

            // heapify the affected subtree
            heapify(sal , n , largest);
        }
      // now subtree is max-heap again
    }

    // main function to do heap sort
    public static void sort(int[] sal,int n) 
    {
        // first build max heap
        for(int i=n/2-1; i>=0 ; i--) 
        {
            heapify(sal , n , i);
        }

        // one by one extract max element
        for(int i=n-1; i>0 ; i--) 
        {
            // move current root (max) to end
            int temp = sal[0];
            sal[0] = sal[i];
            sal[i] = temp;

            // heapify the reduced heap
            heapify(sal , i , 0);
          // now last i elements are sorted
        }
      // array is sorted now , smallest to largest
    }

    public static void printSal(int[] sal,int n) 
    {
        Console.WriteLine("Sorted salary demands (ascending):");
        for(int i=0; i<n ; i++) 
        {
            Console.WriteLine(sal[i]);
        }
      // printing each salary in new line
    }

    public static void Main(string[] args) 
    {
        /*
        6. Heap Sort - Sort Job Applicants by Salary
        Problem Statement:
        A company receives job applications with different expected salary demands. Implement Heap Sort in C# to sort these salary demands in ascending order.
        Hint:

        * Build a Max Heap from the array.

        * Extract the largest element (root) and place it at the end.

        * Reheapify the remaining elements and repeat until sorted.
        */

        Console.WriteLine("Heap sort for job applicants salary demands");

        Console.Write("Waiting , for user to enter how many applicants : ");
        int n = Convert.ToInt32(Console.ReadLine());

        int[] salary = new int[n];

        for(int i=0; i<n ; i++) 
        {
            Console.Write("Enter expected salary of applicant "+ (i+1) +" : ");
            salary[i] = Convert.ToInt32(Console.ReadLine());
        }

        // showing before sorting
        Console.WriteLine("\nSalary demands before sort:");
        for(int i=0; i<n; i++) 
        {
            Console.Write(salary[i] +" ");
        }
        Console.WriteLine("\n");

        sort(salary , n); // call heap sort

        printSal(salary , n); // print final sorted salaries

      // done , salaries sorted with heap sort
    }
}
