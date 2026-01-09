using System;
using System.Collections.Generic;

public class swm 
{
    // array of numbers
    public static int[] arr;
    public static int ksz; // window size

    public static int[] getMax() 
    {
        if(arr == null || arr.Length == 0 || ksz <= 0 || ksz > arr.Length)
        {
            Console.WriteLine("invalid input cant calculate");
            return new int[0];
        }

        int n = arr.Length;
        int[] res = new int[n - ksz + 1];

        Deque<int> dq = new Deque<int>(); // to keep indices

        // first window setup
        for(int i=0; i<ksz; i++) 
        {
            // remove smaller elements from back
            while(dq.Count > 0 && arr[dq.Back()] <= arr[i])
            {
                dq.PopBack();
            }
            dq.PushBack(i);
        }

        res[0] = arr[dq.Front()]; // max for first window

        // now for rest of windows
        for(int i=ksz; i<n; i++) 
        {
            // remove out of window index
            if(dq.Count > 0 && dq.Front() <= i - ksz)
            {
                dq.PopFront();
            }

            // remove smaller than current from back
            while(dq.Count > 0 && arr[dq.Back()] <= arr[i])
            {
                dq.PopBack();
            }

            dq.PushBack(i);

            res[i - ksz + 1] = arr[dq.Front()];
          // front always has index of max in current window
        }

        return res;
    }

    public static void printRes(int[] mx) 
    {
        if(mx.Length == 0)
        {
            Console.WriteLine("no result to print");
            return;
        }

        Console.WriteLine("Sliding window maximums:");
        for(int i=0; i<mx.Length; i++)
        {
            Console.WriteLine("Window "+(i+1)+" max = "+mx[i]);
        }
      // printed each window max nicely
    }

    // simple deque using list , cuz no built in deque
    public class Deque<T> 
    {
        public LinkedList<T> lst = new LinkedList<T>();

        public void PushBack(T val) 
        {
            lst.AddLast(val);
        }

        public void PopBack() 
        {
            lst.RemoveLast();
        }

        public void PushFront(T val) 
        {
            lst.AddFirst(val);
        }

        public void PopFront() 
        {
            lst.RemoveFirst();
        }

        public T Front() 
        {
            return lst.First.Value;
        }

        public T Back() 
        {
            return lst.Last.Value;
        }

        public int Count 
        {
            get { return lst.Count; }
        }
    }

    public static void Main(string[] args) 
    {
        /*
        Sliding Window Maximum

        * Problem: Given an array and a window size k, find the maximum element in each sliding window of size k.

        * Hint: Use a deque (double-ended queue) to maintain indices of useful elements in each window.
        */

        // test data
        arr = new int[] {1, 3, -1, -3, 5, 3, 6, 7};
        ksz = 3;

        int ch = 0;
        while(ch != 5)
        {
            Console.WriteLine("\nSliding Window Maximum");
            Console.WriteLine("1 Set new array and k");
            Console.WriteLine("2 Calculate maximums");
            Console.WriteLine("3 Print results");
            Console.WriteLine("4 Use default test data");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter the choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("How many elements ? ");
                int nn = Convert.ToInt32(Console.ReadLine());
                arr = new int[nn];

                for(int i=0; i<nn; i++)
                {
                    Console.Write("Enter element "+(i+1)+" : ");
                    arr[i] = Convert.ToInt32(Console.ReadLine());
                }

                Console.Write("Enter window size k : ");
                ksz = Convert.ToInt32(Console.ReadLine());
            }
            else if(ch == 2)
            {
                int[] mx = getMax();
                printRes(mx);
            }
            else if(ch == 3)
            {
                int[] mx = getMax();
                printRes(mx);
            }
            else if(ch == 4)
            {
                arr = new int[] {1, 3, -1, -3, 5, 3, 6, 7};
                ksz = 3;
                Console.WriteLine("Default test data set");
            }

            if(ch == 2 || ch == 3) 
            {
                int[] mx = getMax();
                printRes(mx);
            }
        }
    }
}
