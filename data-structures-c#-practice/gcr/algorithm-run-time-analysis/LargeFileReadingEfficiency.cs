using System;
using System.Diagnostics;
using System.IO;
using System.Text;

public class Program
{
    /*
        QUESTION 4 : Large File Reading Efficiency
        Objective
        Compare StreamReader and FileStream when reading a large file (500MB).
        
        Approach
        * StreamReader: Reads character by character (slower for binary files).
        * FileStream: Reads bytes and converts to characters (more efficient).
        
        File Size         StreamReader Time     FileStream Time
        1MB               50ms                  30ms
        100MB             3s                    1.5s
        500MB             10s                   5s
        
        Expected Result
        FileStream is more efficient for large files. 
        StreamReader is preferable for text-based data.
        
        Note : 
        - I can't really create 500MB file here every time 
        - So I will make one big text file (around 50-100MB) once 
        - Then read it many times to see difference
        - For real 500MB you just increase loop count or file size
    */

    public static void Main(string[] args)
    {
        Console.WriteLine("Starting large file reading test... get ready bro! ");

        string bigFile = "bigtestfile.txt";

        // only create file if not exists (takes time so we do once)
        if (!File.Exists(bigFile))
        {
            Console.WriteLine("Creating big file first time... please wait 10-30 sec");
            MakeBigFile(bigFile, 80000000);  // ~80MB (adjust if want bigger)
        }
        else
        {
            Console.WriteLine("Big file already there, size = " + new FileInfo(bigFile).Length / 1024 / 1024 + " MB");
        }

        Console.WriteLine("\nNow reading same file many times...\n");

        // we will do 5 reads and average (more realistic)
        TestReading(bigFile, 5);

        Console.WriteLine(" Finished! See how FileStream wins on big files? ");
        // Console.ReadLine();   // pause if want
    }

    // make one big dummy text file

    public static void MakeBigFile(string path, long targetBytes)
    {
        using (StreamWriter sw = new StreamWriter(path, false))
        {
            string line = "This is dummy line number {0} for testing file reading speed bro   ";
            long written = 0;
            int count = 1;

            while (written < targetBytes)
            {
                string toWrite = string.Format(line, count) + new string('x', 120) + "\n";
                sw.Write(toWrite);
                written += toWrite.Length;
                count++;

                if (count % 50000 == 0)
                {
                    Console.Write(".");   // show progress
                }
            }
        }
        Console.WriteLine(" Big file created!");
    }


    // main test function - read file multiple times

    public static void TestReading(string filePath, int times)
    {
        double totalStreamReader = 0;
        double totalFileStream = 0;

        for (int t = 1; t <= times; t = t + 1)
        {
            Console.WriteLine("   Pass " + t + " of " + times + "...");

            //  StreamReader way 
            Stopwatch sw1 = new Stopwatch();
            sw1.Start();

            using (StreamReader sr = new StreamReader(filePath))
            {
                string dummy;
                while ((dummy = sr.ReadLine()) != null)
                {
                    // we do nothing, just read
                }
            }

            sw1.Stop();
            double timeSr = sw1.Elapsed.TotalMilliseconds;
            totalStreamReader += timeSr;

            //  FileStream + byte[] way 
            Stopwatch sw2 = new Stopwatch();
            sw2.Start();

            using (FileStream fs = new FileStream(filePath, FileMode.Open, FileAccess.Read))
            {
                byte[] buffer = new byte[8192];   // 8KB chunks - good size
                int bytesRead;

                while ((bytesRead = fs.Read(buffer, 0, buffer.Length)) > 0)
                {
                    // we can convert to string if want but here just read bytes
                    // string s = Encoding.UTF8.GetString(buffer, 0, bytesRead);   // uncomment if want
                }
            }

            sw2.Stop();
            double timeFs = sw2.Elapsed.TotalMilliseconds;
            totalFileStream += timeFs;

            Console.WriteLine("      StreamReader  :  " + timeSr + " ms");
            Console.WriteLine("      FileStream    :  " + timeFs + " ms");

        }

        // average time
        double avgSr = totalStreamReader / times;
        double avgFs = totalFileStream / times;

        Console.WriteLine(" Final Average for file (~" + new FileInfo(filePath).Length / 1024 / 1024 + " MB):");
        Console.WriteLine("   StreamReader average   :   " + avgSr + " ms");
        Console.WriteLine("   FileStream average     :   " + avgFs + " ms");
        Console.WriteLine("   Difference             :   " + (avgSr - avgFs) + " ms faster with FileStream!");
    }
}
