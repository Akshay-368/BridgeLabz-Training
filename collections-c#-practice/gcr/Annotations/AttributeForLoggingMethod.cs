using System;
using System.Diagnostics;
using System.Reflection;

// custom attribute to log execution time
[AttributeUsage(AttributeTargets.Method)]
public class LogExecutionTimeAttribute : Attribute
{
    // no extra fields needed
}

// example class with methods
public class DemoTasks
{
    [LogExecutionTime]
    public void FastTask()
    {
        for(int i=0; i<1000 ; i++) { } // quick
        Console.WriteLine("Fast task done");
    }

    [LogExecutionTime]
    public void SlowTask()
    {
        for(int i=0; i<5000000 ; i++) { } // slow
        Console.WriteLine("Slow task done");
    }
}

public class logTime 
{
    // run method and measure time using reflection
    public static void runWithTimer(string methodName)
    {
        DemoTasks tasks = new DemoTasks();

        MethodInfo method = typeof(DemoTasks).GetMethod(methodName);

        if(method == null)
        {
            Console.WriteLine("method not found: " + methodName);
            return;
        }

        // check if has LogExecutionTime attribute
        object[] attrs = method.GetCustomAttributes(typeof(LogExecutionTimeAttribute), false);
        if(attrs.Length == 0)
        {
            Console.WriteLine("no LogExecutionTime attribute on " + methodName);
            return;
        }

        Stopwatch watch = new Stopwatch();
        watch.Start();

        method.Invoke(tasks, null);

        watch.Stop();

        Console.WriteLine(methodName + " took " + watch.ElapsedMilliseconds + " ms");
    }

    public static void Main(string[] args) 
    {
        /*
        Create an Attribute for Logging Method Execution Time
        Problem Statement: Define an attribute LogExecutionTime to measure method execution time.
        Requirements:
        * Apply LogExecutionTime to a method.
        * Use Stopwatch before and after execution.
        * Print execution time.
        * Apply it to different methods and compare the time taken.
        */

        Console.WriteLine("Method Execution Time Logging Attribute\n");

        Console.WriteLine("Testing FastTask:");
        runWithTimer("FastTask");

        Console.WriteLine("\nTesting SlowTask:");
        runWithTimer("SlowTask");

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
