using System;
using System.Threading;

public class timeOut 
{
    // long running task - sleeps 3 seconds
    public static void longRunningTask()
    {
        Console.WriteLine("starting long task...");
        Thread.Sleep(3000);
        Console.WriteLine("task finished");
    }

    public static void Main(string[] args) 
    {
        /*
        7. Performance Testing Using Timeout
        Problem:
        Create a method LongRunningTask() that sleeps for 3 seconds before returning a result.
        Use NUnit [Timeout(2000)] or MSTest [Timeout(2000)] to fail the test if the method takes more than 2 seconds.
        */

        Console.WriteLine("Timeout Performance Test (manual)\n");

        long start = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;

        longRunningTask();

        long end = DateTime.Now.Ticks / TimeSpan.TicksPerMillisecond;
        long timeTaken = end - start;

        Console.WriteLine("time taken: " + timeTaken + " ms");

        if(timeTaken > 2000)
        {
            Console.WriteLine("FAIL: took more than 2 seconds");
        }
        else
        {
            Console.WriteLine("PASS: within time limit");
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
