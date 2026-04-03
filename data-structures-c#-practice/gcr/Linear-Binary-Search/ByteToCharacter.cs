using System;
using System.IO;

public class byteToChar 
{
    // this function reads file as bytes but uses StreamReader to convert to chars
    // StreamReader takes byte stream from FileStream and turns it into readable chars
    // we print each character one by one (very simple and slow way)
    public static void readBytesAsChars(string filePath) 
    {
        // check if file really exists
        if (!File.Exists(filePath)) 
        {
            Console.WriteLine("cant find file : " + filePath);
            return;
        }

        FileStream fileByteStream = null;
        StreamReader charReader = null;

        try 
        {
            // open file as byte stream
            fileByteStream = new FileStream(filePath , FileMode.Open , FileAccess.Read);

            // now wrap byte stream with StreamReader to get character stream
            charReader = new StreamReader(fileByteStream);

            Console.WriteLine("reading file as characters...");

            int charCount = 0;
            int currentChar;

            // read char by char till end
            while ((currentChar = charReader.Read()) != -1) 
            {
                char thisChar = (char)currentChar;
                Console.Write(thisChar);

                charCount++;

                // just to make it slower and more visible (not optimal)
                if (charCount % 50 == 0) 
                {
                    Console.WriteLine(); // new line every 50 chars
                }
            }

            Console.WriteLine("finished reading " + charCount + " characters");
        }
        catch (Exception ex) 
        {
            Console.WriteLine("error happened : " + ex.Message);
        }
        finally 
        {
            // close both streams safely
            if (charReader != null) 
            {
                charReader.Close();
            }
            if (fileByteStream != null) 
            {
                fileByteStream.Close();
            }
            Console.WriteLine("streams closed");
        }
      // done converting byte stream to char stream
    }

    public static void Main(string[] args) 
    {
        /*
        Problem 1: Convert Byte Stream to Character Stream Using StreamReader
        Problem: Write a program that uses StreamReader to read binary data from a file and print it as characters.
        */

        Console.WriteLine(" Byte to Character Stream using StreamReader ");

        Console.Write("Waiting , for user to enter full file path to read : ");
        string pathInput = Console.ReadLine();

        readBytesAsChars(pathInput);

        Console.WriteLine(" Press any key to exit...");
        Console.ReadKey();
    }
}
