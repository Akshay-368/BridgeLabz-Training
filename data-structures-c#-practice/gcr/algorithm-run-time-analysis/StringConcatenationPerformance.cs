using System;
using System.Diagnostics;
using System.Text;

public class Program
{
    /*
        QUESTION 3 : String Concatenation Performance
        Objective
        Compare the performance of string (O(N²)), StringBuilder (O(N)), and StringBuffer (O(N)) 
        when concatenating a million strings.
        
        Approach
        * Using string (Immutable, creates a new object each time)
        * Using StringBuilder (Fast, mutable, thread-unsafe)
        * (StringBuffer is java thing, in C# we mostly use StringBuilder only)
        
        Operations Count (N)     string (O(N²))     StringBuilder (O(N))
        1,000                    10ms               1ms
        10,000                   1s                 10ms
        1,000,000                30m (Unusable)     50ms
        
        Expected Result
        StringBuilder is much more efficient than string for concatenation.
        
        Note: we skip 1 million with normal string because it will hang my pc for minutes :(
        so we do upto 50k or 0.1 M only for string
    */

    public static void Main(string[] args)
    {
        Console.WriteLine("Lets see why we should NEVER use string + in loop !!! ");

        TestConcat(1000);
        TestConcat(10000);
        TestConcat(50000);     // string will start crying here

        Console.WriteLine(" Now only StringBuilder for big one (1 million)...");
        TestOnlyBuilder(1000000);

        Console.WriteLine(" See? string is killer slow... always use StringBuilder  ");
        // Console.ReadLine();   // uncomment if want to pause
    }

    // main test function
  
    public static void TestConcat(int n)
    {
        Console.WriteLine("   Testing for " + n + " times...");

        //  using normal string + 
        Stopwatch watch1 = new Stopwatch();
        watch1.Start();

        string result = "";   // very bad idea for big loops

        for (int i = 0 ; i < n ; i = i + 1)
        {
            result = result + "a";   // new string created every time sad
        }

        watch1.Stop();
        double timeString = watch1.Elapsed.TotalMilliseconds;


        //  using StringBuilder 
        Stopwatch watch2 = new Stopwatch();
        watch2.Start();

        StringBuilder sb = new StringBuilder(); // good boy

        for (int i = 0 ; i < n ; i = i + 1)
        {
            sb.Append("a");   // fast and happy
        }

        string final = sb.ToString();   // only at end we make string

        watch2.Stop();
        double timeBuilder = watch2.Elapsed.TotalMilliseconds;


        // printing results 
        Console.WriteLine("      string + time     :   " + timeString + "   ms");
        Console.WriteLine("      StringBuilder time:   " + timeBuilder + "   ms");
        Console.WriteLine(
    }


    // only StringBuilder for very big number

    public static void TestOnlyBuilder(int n)
    {
        Stopwatch w = new Stopwatch();
        w.Start();

        StringBuilder bigsb = new StringBuilder();

        for (int i = 0; i < n; i++)
        {
            bigsb.Append("x");   // still fast even for million
        }

        string done = bigsb.ToString();

        w.Stop();

        Console.WriteLine("   StringBuilder for " + n + " times took:   " + w.Elapsed.TotalMilliseconds + " ms");
        Console.WriteLine("   (done! length = " + done.Length + ") ");
    }
}
