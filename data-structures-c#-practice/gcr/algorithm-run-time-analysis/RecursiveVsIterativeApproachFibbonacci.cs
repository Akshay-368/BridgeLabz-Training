using System;
using System.Diagnostics;

public class Program
{
    /*
        QUESTION 5 : Recursive vs Iterative Fibonacci Computation
        Objective
        Compare Recursive (O(2^N)) vs Iterative (O(N)) Fibonacci solutions.
        
        Approach
        Recursive:
        public static int FibonacciRecursive(int n) {
            if (n <= 1) return n;
            return FibonacciRecursive(n - 1) + FibonacciRecursive(n - 2);
        }
        
        Iterative:
        public static int FibonacciIterative(int n) {
            int a = 0, b = 1, sum;
            for (int i = 2; i <= n; i++) {
                sum = a + b;
                a = b;
                b = sum;
            }
            return b;
        }
        
        Fibonacci (N)       Recursive (O(2^N))     Iterative (O(N))
        10                  1ms                    0.01ms
        30                  5s                     0.05ms
        50                  Unfeasible (>1hr)      0.1ms
        
        Expected Result
        Recursive approach is infeasible for large values of N due to exponential growth. 
        The iterative approach is significantly faster and memory-efficient.
        
        Note bro:
        - recursive will die very fast after n=35-40
        - we will stop recursive at n=40 max to save your pc from hanging forever
    */

    public static void Main(string[] args)
    {
        Console.WriteLine("Fibonacci fight - recursive vs iterative !!! ");

        // small values - both fine
        TestFib(10);
        TestFib(20);

        // medium - recursive starts crying
        TestFib(30);

        // big one - recursive will not finish in your lifetime
        Console.WriteLine("Now for n=40 ... recursive will take loooong time\n");
        TestFib(40);   // good luck recursive lol

        Console.WriteLine(" See? recursive is cute for small n only... after that RIP ");
        // Console.ReadLine();   // pause if you want
    }


    // main test function

    public static void TestFib(int n)
    {
        Console.WriteLine("Testing Fibonacci for n = " + n + " ...");

        //  RECURSIVE WAY 
        Stopwatch watch1 = new Stopwatch();
        watch1.Start();

        long recResult = -1;   // default sad value
        try
        {
            recResult = FibRecursive(n);
        }
        catch (Exception e)
        {
            Console.WriteLine("   Recursive crashed or too slow !");
        }

        watch1.Stop();
        double timeRec = watch1.Elapsed.TotalMilliseconds;

        //  ITERATIVE WAY 
        Stopwatch watch2 = new Stopwatch();
        watch2.Start();

        long iterResult = FibIterative(n);

        watch2.Stop();
        double timeIter = watch2.Elapsed.TotalMilliseconds;

        // printing results (with extra spaces for human look)
        Console.WriteLine("   Recursive time     :  " + timeRec + " ms   (result = " + recResult + ")");
        Console.WriteLine("   Iterative time     :  " + timeIter + " ms   (result = " + iterResult + ")");

        if (timeRec > 5000)   // more than 5 seconds = pain
        {
            Console.WriteLine("    Recursive is already dying here bro...");
        }


    }


    // classic slow recursive fibonacci

    public static long FibRecursive(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        return FibRecursive(n - 1) + FibRecursive(n - 2);   // very expensive calls
    }


    // fast boy - iterative fibonacci

    public static long FibIterative(int n)
    {
        if (n <= 1)
        {
            return n;
        }

        long a = 0;
        long b = 1;
        long sum = 0;

        for (int i = 2 ; i <= n ; i = i + 1)
        {
            sum = a + b;
            a = b;
            b = sum;
        }

        return b;
    }
}
