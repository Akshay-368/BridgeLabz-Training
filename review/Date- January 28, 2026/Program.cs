// See https://aka.ms/new-console-template for more information

using System;

using ReviewQuestions ;


// created using dotnet new console -n Playground
class Program
{
    public static void Main()
    {
        
        Console.WriteLine(" Now this is a Simple Queue  Reversal using Recursion ");

        SimpleQueue q = new SimpleQueue(10); // creating the queue

        // add some numbers
        q.Enqueue(10);
        q.Enqueue(20);
        q.Enqueue(30);
        q.Enqueue(40);
        q.Enqueue(50);

        Console.WriteLine(" Original queue : "); // display the original queue
        q.Print();

        Console.WriteLine(" Reversing queue using recursion... ");

        q.Reverse(); // calling the function for doing the recursion

        Console.Write("Reversed queue : ");
        q.Print();

        Console.WriteLine(" Press any key to exit...");
        Console.ReadKey();
    }
}

