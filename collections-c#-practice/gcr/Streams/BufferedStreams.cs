using System;
using System.IO;
using System.Diagnostics;

public class buffCopy 
{
    // this function copies file using normal FileStream (no buffer)
    // we read/write byte by byte → very slow for large files
    public static long copyWithoutBuffer(string srcPath,string destPath)
    {
        if(!File.Exists(srcPath))
        {
            Console.WriteLine("source file not found : " + srcPath);
            return 0;
        }

        FileStream readNoBuf = null;
        FileStream writeNoBuf = null;

        Stopwatch timer = new Stopwatch();
        timer.Start();

        try
        {
            readNoBuf = new FileStream(srcPath, FileMode.Open, FileAccess.Read);
            writeNoBuf = new FileStream(destPath, FileMode.Create, FileAccess.Write);

            int singleByte;
            long totalBytes = 0;

            while((singleByte = readNoBuf.ReadByte()) != -1)
            {
                writeNoBuf.WriteByte((byte)singleByte);
                totalBytes++;
            }

            Console.WriteLine("normal copy done , bytes: " + totalBytes);
        }
        catch(Exception e)
        {
            Console.WriteLine("error in normal copy : " + e.Message);
        }
        finally
        {
            if(readNoBuf != null) readNoBuf.Close();
            if(writeNoBuf != null) writeNoBuf.Close();
        }

        timer.Stop();
        return timer.ElapsedMilliseconds;
    }

    // this function uses BufferedStream → reads/writes in chunks (4KB default)
    // much faster for large files cuz less disk access
    public static long copyWithBuffer(string srcPath,string destPath)
    {
        if(!File.Exists(srcPath))
        {
            Console.WriteLine("source file not found : " + srcPath);
            return 0;
        }

        FileStream readBase = null;
        BufferedStream readBuf = null;
        FileStream writeBase = null;
        BufferedStream writeBuf = null;

        Stopwatch timer = new Stopwatch();
        timer.Start();

        try
        {
            readBase = new FileStream(srcPath, FileMode.Open, FileAccess.Read);
            readBuf = new BufferedStream(readBase, 4096); // 4KB buffer

            writeBase = new FileStream(destPath, FileMode.Create, FileAccess.Write);
            writeBuf = new BufferedStream(writeBase, 4096); // 4KB buffer

            byte[] buffer = new byte[4096];
            int bytesRead;

            long totalBytes = 0;

            while((bytesRead = readBuf.Read(buffer, 0, buffer.Length)) > 0)
            {
                writeBuf.Write(buffer, 0, bytesRead);
                totalBytes += bytesRead;
            }

            Console.WriteLine("buffered copy done , bytes: " + totalBytes);
        }
        catch(Exception e)
        {
            Console.WriteLine("error in buffered copy : " + e.Message);
        }
        finally
        {
            if(readBuf != null) readBuf.Close();
            if(readBase != null) readBase.Close();
            if(writeBuf != null) writeBuf.Close();
            if(writeBase != null) writeBase.Close();
        }

        timer.Stop();
        return timer.ElapsedMilliseconds;
    }

    public static void Main(string[] args) 
    {
        /*
        1. Buffered Streams - Efficient File Copy 
        📌 Problem Statement: Create a C# program that copies a large file (e.g., 100MB) from one location to another using Buffered Streams (BufferedStream). 
        Compare the performance with normal file streams. 
        Requirements: 
        Read and write in chunks of 4 KB (4096 bytes). 
        Use Stopwatch to measure execution time. 
        Compare execution time with unbuffered streams.
        */

        Console.WriteLine("Buffered vs Normal File Copy Comparison\n");

        Console.Write("Waiting , for user to enter source file path\n(example: C:\\bigfile.zip) : ");
        string source = Console.ReadLine();

        Console.Write("Waiting , for user to enter destination path\n(example: C:\\copy.zip) : ");
        string dest = Console.ReadLine();

        Console.WriteLine("\nStarting normal (unbuffered) copy...");
        long timeNormal = copyWithoutBuffer(source, dest + "_normal");

        Console.WriteLine("\nStarting buffered copy...");
        long timeBuffered = copyWithBuffer(source, dest + "_buffered");

        Console.WriteLine("\nPerformance comparison:");
        Console.WriteLine("Normal copy time   : " + timeNormal + " ms");
        Console.WriteLine("Buffered copy time : " + timeBuffered + " ms");

        if(timeNormal > 0)
        {
            double faster = (double)timeNormal / timeBuffered;
            Console.WriteLine("Buffered was about " + faster.ToString("F1") + " times faster!");
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
