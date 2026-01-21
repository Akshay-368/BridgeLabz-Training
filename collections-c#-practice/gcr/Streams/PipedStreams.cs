using System;
using System.IO;
using System.Threading;

public class pipeComm 
{
    public static void writerThread(PipeStream pipe)
    {
        StreamWriter writer = new StreamWriter(pipe);
        writer.AutoFlush = true;

        for(int i=1; i<=10 ; i++)
        {
            string msg = "Message " + i + " from writer";
            writer.WriteLine(msg);
            Console.WriteLine("Writer sent: " + msg);
            Thread.Sleep(500); // slow down a bit
        }

        writer.Close();
    }

    public static void readerThread(PipeStream pipe)
    {
        StreamReader reader = new StreamReader(pipe);

        string line = "";
        while((line = reader.ReadLine()) != null)
        {
            Console.WriteLine("Reader received: " + line);
        }

        reader.Close();
    }

    public static void Main(string[] args) 
    {
        /*
        5. Piped Streams - Inter-Thread Communication 
        📌 Problem Statement: Implement a C# program where one thread writes data into a PipeStream and another thread reads data from it. 
        Requirements: Use two threads for reading and writing. 
        Synchronize properly to prevent data loss. 
        Handle IOException.
        */

        Console.WriteLine("PipeStream - Thread Communication\n");

        PipeStream pipeRead = null;
        PipeStream pipeWrite = null;

        try
        {
            // anonymous pipe for local communication
            AnonymousPipeServerStream server = new AnonymousPipeServerStream(PipeDirection.Out);
            pipeRead = new AnonymousPipeClientStream(PipeDirection.In, server.GetClientHandleAsString());
            pipeWrite = server;

            // start writer thread
            Thread writer = new Thread(() => writerThread(pipeWrite));
            writer.Start();

            // start reader thread
            Thread reader = new Thread(() => readerThread(pipeRead));
            reader.Start();

            writer.Join();
            reader.Join();
        }
        catch(Exception e)
        {
            Console.WriteLine("pipe error : " + e.Message);
        }
        finally
        {
            if(pipeRead != null) pipeRead.Close();
            if(pipeWrite != null) pipeWrite.Close();
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
