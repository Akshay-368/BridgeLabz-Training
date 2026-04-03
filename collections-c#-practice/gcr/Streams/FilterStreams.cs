using System;
using System.IO;

public class upperToLower 
{
    // read file , convert to lowercase , write to new file
    // using BufferedStream for efficiency
    public static void convertToLower(string srcPath,string destPath)
    {
        if(!File.Exists(srcPath))
        {
            Console.WriteLine("source file not found : " + srcPath);
            return;
        }

        BufferedStream readBuf = null;
        BufferedStream writeBuf = null;

        try
        {
            FileStream readBase = new FileStream(srcPath, FileMode.Open, FileAccess.Read);
            readBuf = new BufferedStream(readBase, 8192); // 8KB buffer

            FileStream writeBase = new FileStream(destPath, FileMode.Create, FileAccess.Write);
            writeBuf = new BufferedStream(writeBase, 8192);

            int singleByte;

            while((singleByte = readBuf.ReadByte()) != -1)
            {
                char ch = (char)singleByte;

                if(char.IsUpper(ch))
                {
                    ch = char.ToLower(ch);
                }

                writeBuf.WriteByte((byte)ch);
            }

            Console.WriteLine("file converted to lowercase");
        }
        catch(Exception e)
        {
            Console.WriteLine("error : " + e.Message);
        }
        finally
        {
            if(readBuf != null) readBuf.Close();
            if(writeBuf != null) writeBuf.Close();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        3. Filter Streams - Convert Uppercase to Lowercase
        📌 Problem Statement: Create a program that reads a text file and writes its contents into another file, converting all uppercase letters to lowercase. 
        Requirements: Use StreamReader and StreamWriter. 
        Use BufferedStream for efficiency. 
        Handle character encoding issues.
        */

        Console.WriteLine("Uppercase to Lowercase File Converter\n");

        Console.Write("Waiting , for user to enter source file path : ");
        string src = Console.ReadLine();

        Console.Write("Waiting , for user to enter destination file path : ");
        string dest = Console.ReadLine();

        convertToLower(src, dest);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
