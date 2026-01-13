using System;
using System.Diagnostics;

public class Program
{

    // PROBLEM: Compare Linear Search vs Binary Search on different sizes
    // hints: 
    // - linear = O(N)  scan one by one
    // - binary = must sort first O(N log N) then O(log N) search
    // - we will test on 1000, 10000, 1000000 elements
    // - target will be random so sometimes found sometimes not
    // - we measure time in milliseconds


    public static void Main(string[] args)
    {
        // we will make dataset here
        Console.WriteLine("Starting comparison ...");

        TestOneSize(1000);
        TestOneSize(10000);
        TestOneSize(1000000);   // this one will take some time to sort

        Console.WriteLine(" Done! Binary is good on big data ");
    }

    // function to make big random array

    public static int[] MakeBigArray(int size)
    {
        int[] arr = new int[size];

        Random r = new Random(); // for random numbers

        for (int i = 0; i < size; i = i + 1)
        {
            arr[i] = r.Next(1, size * 10);  // numbers from 1 to 10x size (some duplicates ok)
        }

        return arr;
    }

    // simple linear search - no need sorted

    public static bool LinearFind(int[] arr, int target)
    {
        for (int i = 0; i < arr.Length; i++)
        {
            if (arr[i] == target)
            {
                return true; // found it!
            }
        }
        return false; // not found sad
    }


    // binary search - array MUST be sorted first!

    public static bool BinaryFind(int[] arr, int target)
    {
        int left = 0;
        int right = arr.Length - 1;

        while (left <= right)
        {
            int mid = left + (right - left) / 2; // avoid overflow style

            if (arr[mid] == target)
            {
                return true;
            }

            if (arr[mid] < target)
            {
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }

        return false;
    }

    // main test function for one size

    public static void TestOneSize(int n)
    {
        Console.WriteLine("Testing for N = " + n + " elements...");

        int[] data = MakeBigArray(n);

        // pick random target (50% chance it exists roughly)
        Random rand = new Random();
        int target = data[rand.Next(0, n)];   // we take one existing value


        // Linear search timing

        Stopwatch watch = new Stopwatch();
        watch.Start();

        bool foundLinear = LinearFind(data, target);

        watch.Stop();
        double timeLinear = watch.Elapsed.TotalMilliseconds;


        // Binary search timing

        // first we must sort ! (this takes time)
        watch.Restart();
        Array.Sort(data);   // O(n log n) part
        watch.Stop();
        double timeSort = watch.Elapsed.TotalMilliseconds;

        watch.Restart();
        bool foundBinary = BinaryFind(data, target);
        watch.Stop();
        double timeBinarySearchOnly = watch.Elapsed.TotalMilliseconds;

        double timeBinaryTotal = timeSort + timeBinarySearchOnly;

        // printing results 
        Console.WriteLine("    Linear search time       :  " + timeLinear + " ms");
        Console.WriteLine("    Binary search total time :  " + timeBinaryTotal + " ms  (sort = " + timeSort + " + search = " + timeBinarySearchOnly + ")");
        Console.WriteLine("    Found ? linear = " + foundLinear + "   binary = " + foundBinary);

    }
}
