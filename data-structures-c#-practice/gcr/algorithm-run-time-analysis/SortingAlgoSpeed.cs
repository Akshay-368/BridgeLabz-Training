using System;
using System.Diagnostics;

public class Program
{
    /*
        PROBLEM: 2. Sorting Large Data Efficiently
        Objective
        Compare sorting algorithms Bubble Sort (O(N²)), Merge Sort (O(N log N)), and Quick Sort (O(N log N)).
        
        Approach
        * Bubble Sort: Repeated swapping (inefficient for large data).
        * Merge Sort: Divide & Conquer approach (stable).
        * Quick Sort: Partition-based approach (fast but unstable).
        
        Dataset Size (N)     Bubble Sort     Merge Sort     Quick Sort
        1,000                50ms            5ms            3ms
        10,000               5s              50ms           30ms
        1,000,000            Unfeasible      3s             2s
        
        Expected Result
        Bubble Sort is impractical for large datasets. 
        Merge Sort & Quick Sort perform well.
        
        We will try to show this with real timings 
    */

    public static void Main(string[] args)
    {
        Console.WriteLine("Starting sorting comparison... hold tight! ");

        // small size first
        DoSortingTest(1000);

        // medium size
        DoSortingTest(10000);

        // big size - bubble will cry here :(
        DoSortingTest(100000);   // 1 million is too painful for bubble, so using 0.1 M
        Console.WriteLine(" Finished! You saw how bubble becomes dinosaur on big data ? ");
        Console.ReadLine();
    }

 
    // main test function for one size

    public static void DoSortingTest(int n)
    {
        Console.WriteLine("  Testing for " + n + " elements ");

        int[] original = MakeRandomArray(n);

        //  BUBBLE SORT 
        Console.WriteLine("Bubble sort starting...");
        int[] bubbleArr = (int[])original.Clone(); // copy so others not affected

        Stopwatch sw = new Stopwatch();
        sw.Start();
        BubbleSortVerySlow(bubbleArr);
        sw.Stop();

        double bubbleTime = sw.Elapsed.TotalMilliseconds;
        Console.WriteLine("Bubble sort time = " + bubbleTime + " ms");
        // Console.WriteLine("   (sorted? " + IsSorted(bubbleArr) + ")");  // uncomment ,only if want check


        //  MERGE SORT
        Console.WriteLine(" Merge sort starting...");
        int[] mergeArr = (int[])original.Clone();

        sw.Restart();
        MergeSort(mergeArr, 0, mergeArr.Length - 1);
        sw.Stop();

        double mergeTime = sw.Elapsed.TotalMilliseconds;
        Console.WriteLine("Merge sort time   = " + mergeTime + " ms");


        // QUICK SORT 
        Console.WriteLine(" Quick sort starting...");
        int[] quickArr = (int[])original.Clone();

        sw.Restart();
        QuickSort(quickArr, 0, quickArr.Length - 1);
        sw.Stop();

        double quickTime = sw.Elapsed.TotalMilliseconds;
        Console.WriteLine("Quick sort time   = " + quickTime + " ms\n");

        Console.WriteLine("Summary for N = " + n + ":");
        Console.WriteLine("Bubble : " + bubbleTime + " ms");
        Console.WriteLine("Merge  : " + mergeTime + " ms");
        Console.WriteLine("Quick  : " + quickTime + " ms");

    }


    // make big random array

    public static int[] MakeRandomArray(int size)
    {
        int[] a = new int[size];
        Random rnd = new Random();

        for (int i = 0; i < size; i = i + 1)
        {
            a[i] = rnd.Next(1, size * 5);   // some duplicates ok
        }

        return a;
    }

    //  bubble sort

    public static void BubbleSortVerySlow(int[] arr)
    {
        int n = arr.Length;

        for (int i = 0; i < n - 1; i = i + 1)
        {
            for (int j = 0; j < n - i - 1; j = j + 1)
            {
                if (arr[j] > arr[j + 1])
                {
                    // swap
                    int temp = arr[j];
                    arr[j] = arr[j + 1];
                    arr[j + 1] = temp;
                }
            }
        }
    }


    // merge sort - recursive style

    public static void MergeSort(int[] arr, int l, int r)
    {
        if (l >= r) return;

        int m = l + (r - l) / 2;

        MergeSort(arr, l, m);
        MergeSort(arr, m + 1, r);

        MergeTwoHalves(arr, l, m, r);
    }

    public static void MergeTwoHalves(int[] arr, int l, int m, int r)
    {
        int n1 = m - l + 1;
        int n2 = r - m;

        int[] left = new int[n1];
        int[] right = new int[n2];

        for (int i = 0; i < n1; i++) left[i] = arr[l + i];
        for (int j = 0; j < n2; j++) right[j] = arr[m + 1 + j];

        int ii = 0, jj = 0, k = l;

        while (ii < n1 && jj < n2)
        {
            if (left[ii] <= right[jj])
            {
                arr[k] = left[ii];
                ii++;
            }
            else
            {
                arr[k] = right[jj];
                jj++;
            }
            k++;
        }

        while (ii < n1)
        {
            arr[k] = left[ii];
            ii++; k++;
        }

        while (jj < n2)
        {
            arr[k] = right[jj];
            jj++; k++;
        }
    }


    // quick sort - classic lomuto partition

    public static void QuickSort(int[] arr, int low, int high)
    {
        if (low < high)
        {
            int pi = Partition(arr, low, high);

            QuickSort(arr, low, pi - 1);
            QuickSort(arr, pi + 1, high);
        }
    }

    public static int Partition(int[] arr, int low, int high)
    {
        int pivot = arr[high];
        int i = low - 1;

        for (int j = low; j < high; j = j + 1)
        {
            if (arr[j] < pivot)
            {
                i++;
                // swap
                int temp = arr[i];
                arr[i] = arr[j];
                arr[j] = temp;
            }
        }

        // final swap with pivot
        int temp2 = arr[i + 1];
        arr[i + 1] = arr[high];
        arr[high] = temp2;

        return i + 1;
    }

    // just for testing (optional)
    public static bool IsSorted(int[] a)
    {
        for (int i = 1; i < a.Length; i++)
        {
            if (a[i - 1] > a[i]) return false;
        }
        return true;
    }
}
