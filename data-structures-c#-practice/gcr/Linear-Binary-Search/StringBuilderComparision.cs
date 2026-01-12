using System;
using System.Text;
using System.Diagnostics;

public class perfTest 
{
    // this function shows how slow normal string + is when we join many times
    // we do it in a very simple and slow way on purpose
    public static string normalStringJoin(int howManyTimes) 
    {
        // start with empty normal string
        string resultNormal = "";

        // loop many times and keep adding text
        // each time + creates a COMPLETELY NEW string in memory
        // this is very slow and uses lots of memory
        for (int i = 0; i < howManyTimes ; i++) 
        {
            resultNormal = resultNormal + "hello" + i + " ";
            // Console.WriteLine("normal string size now: " + resultNormal.Length);
        }

        return resultNormal;
    }

    // this function does the same thing but using StringBuilder
    // StringBuilder is smart - it does NOT create new string each time
    // it uses internal buffer (char array) and only grows when needed
    // so much faster and uses way less memory
    public static string stringBuilderJoin(int howManyTimes) 
    {
        // create StringBuilder , it starts with some capacity
        // when full it makes bigger buffer automatically
        StringBuilder resultSmart = new StringBuilder();

        // add text in loop - very fast
        for (int i = 0; i < howManyTimes ; i++) 
        {
            resultSmart.Append("hello");
            resultSmart.Append(i);
            resultSmart.Append(" ");
        }

        // finally convert to normal string only ONCE
        return resultSmart.ToString();
    }

    public static void Main(string[] args) 
    {
        /*
        Problem 2: Compare StringBuilder Performance
        Problem: Write a program that compares the performance of StringBuilder for concatenating strings multiple times.
        */

        Console.WriteLine("StringBuilder vs Normal String Performance Test ");
        Console.WriteLine("this will show how much faster StringBuilder is\n");

        // ask user how many times to join (big number = more difference)
        Console.Write("Waiting , for user to enter how many times to join (try 10000 or more) : ");
        int repeatCount = Convert.ToInt32(Console.ReadLine());

        // make stopwatch to measure time
        Stopwatch timer = new Stopwatch();

        // NORMAL STRING TEST 
        Console.WriteLine(" Starting normal string + test...");
        timer.Start();

        string normalResult = normalStringJoin(repeatCount);

        timer.Stop();
        long normalTimeMs = timer.ElapsedMilliseconds;

        Console.WriteLine("Normal string finished in " + normalTimeMs + " milliseconds");
        // Console.WriteLine("final length: " + normalResult.Length);

        // reset timer
        timer.Reset();

        //  STRINGBUILDER TEST 
        Console.WriteLine(" Starting StringBuilder test...");
        timer.Start();

        string smartResult = stringBuilderJoin(repeatCount);

        timer.Stop();
        long smartTimeMs = timer.ElapsedMilliseconds;

        Console.WriteLine("StringBuilder finished in " + smartTimeMs + " milliseconds");

        // show the huge difference
        Console.WriteLine("Comparison:");
        Console.WriteLine("Normal string time  : " + normalTimeMs + " ms");
        Console.WriteLine("StringBuilder time  : " + smartTimeMs + " ms");

        if (normalTimeMs > 0)
        {
            double timesFaster = (double)normalTimeMs / smartTimeMs;
            Console.WriteLine("StringBuilder was about " + timesFaster.ToString("F1") + " times faster!");
        }

        Console.WriteLine("Conclusion: StringBuilder is MUCH better for joining many strings in a loop");

        Console.WriteLine(" Press any key to close...");
        Console.ReadKey();
    }
}
