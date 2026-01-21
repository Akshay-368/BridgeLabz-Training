using System;
using System.IO;

public class fileCopy 
{
    // this function reads from source file and writes to destination file
    // using FileStream only (byte by byte)
    public static void copyFileContent(string sourceFilePath,string destFilePath)
    {
        // first check if source file really exists
        if (!File.Exists(sourceFilePath))
        {
            Console.WriteLine("sorry source file not found : " + sourceFilePath);
            return;
        }

        FileStream readStream = null;
        FileStream writeStream = null;

        try
        {
            // open source file for reading (byte mode)
            readStream = new FileStream(sourceFilePath, FileMode.Open, FileAccess.Read);

            // open destination file for writing
            // if file not exist → it will create automatically
            writeStream = new FileStream(destFilePath, FileMode.Create, FileAccess.Write);

            Console.WriteLine("copying file... please wait");

            int singleByte;
            int totalBytesCopied = 0;

            // read one byte at a time and write immediately
            // this is slow but very simple & clear (student style)
            while ((singleByte = readStream.ReadByte()) != -1)
            {
                writeStream.WriteByte((byte)singleByte);
                totalBytesCopied++;

                // little progress feel (optional)
                // if(totalBytesCopied % 1000 == 0)
                // {
                //     Console.Write(".");
                // }
            }

            Console.WriteLine("\nfile copied successfully!");
            Console.WriteLine("total bytes copied: " + totalBytesCopied);
        }
        catch (IOException ioError)
        {
            // catch only IOException as required
            Console.WriteLine("io error happened while copying file");
            Console.WriteLine("error message: " + ioError.Message);
        }
        catch (Exception anyError)
        {
            // just in case something else happens
            Console.WriteLine("some other error: " + anyError.Message);
        }
        finally
        {
            // always close files - very important
            if (readStream != null)
            {
                readStream.Close();
                Console.WriteLine("source file stream closed");
            }

            if (writeStream != null)
            {
                writeStream.Close();
                Console.WriteLine("destination file stream closed");
            }
        }
    }

    public static void Main(string[] args) 
    {
        /*
        1. File Handling - Read and Write a Text File 
        📌 Problem Statement: Write a C# program that reads the contents of a text file and writes it into a new file. 
        If the source file does not exist, display an appropriate message. 
        Requirements: 
        Use FileStream for reading and writing. 
        Handle IOException properly. 
        Ensure that the destination file is created if it does not exist.
        */

        Console.WriteLine(" File Copy using FileStream \n");

        Console.Write("Waiting , for user to enter source file full path\n(example: C:\\test\\input.txt) : ");
        string sourcePath = Console.ReadLine();

        Console.Write("Waiting , for user to enter destination file full path\n(example: C:\\test\\output.txt) : ");
        string destPath = Console.ReadLine();

        // call copy function
        copyFileContent(sourcePath, destPath);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
