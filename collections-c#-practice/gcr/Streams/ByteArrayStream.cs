using System;
using System.IO;

public class imgByte 
{
    // read image file to byte array using FileStream
    public static byte[] imageToByteArray(string imgPath)
    {
        if(!File.Exists(imgPath))
        {
            Console.WriteLine("image file not found : " + imgPath);
            return null;
        }

        FileStream fs = null;
        byte[] imgBytes = null;

        try
        {
            fs = new FileStream(imgPath, FileMode.Open, FileAccess.Read);
            imgBytes = new byte[fs.Length];

            int bytesRead = fs.Read(imgBytes, 0, imgBytes.Length);

            Console.WriteLine("read " + bytesRead + " bytes from image");
        }
        catch(Exception e)
        {
            Console.WriteLine("error reading image : " + e.Message);
        }
        finally
        {
            if(fs != null) fs.Close();
        }

        return imgBytes;
    }

    // write byte array back to new image file
    public static void byteArrayToImage(byte[] bytes,string destPath)
    {
        if(bytes == null || bytes.Length == 0)
        {
            Console.WriteLine("no bytes to write");
            return;
        }

        FileStream fs = null;

        try
        {
            fs = new FileStream(destPath, FileMode.Create, FileAccess.Write);
            fs.Write(bytes, 0, bytes.Length);
            Console.WriteLine("image saved to : " + destPath);
        }
        catch(Exception e)
        {
            Console.WriteLine("error writing image : " + e.Message);
        }
        finally
        {
            if(fs != null) fs.Close();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        2. ByteArray Stream - Convert Image to ByteArray 
        📌 Problem Statement: Write a C# program that converts an image file into a byte array and then writes it back to another image file. 
        Requirements: Use MemoryStream to handle byte arrays. 
        Verify that the new file is identical to the original image. 
        Handle IOException.
        */

        Console.WriteLine("Image to ByteArray & Back\n");

        Console.Write("Waiting , for user to enter source image path\n(example: C:\\photo.jpg) : ");
        string srcImg = Console.ReadLine();

        Console.Write("Waiting , for user to enter destination image path\n(example: C:\\copy.jpg) : ");
        string destImg = Console.ReadLine();

        byte[] imgData = imageToByteArray(srcImg);

        if(imgData != null)
        {
            byteArrayToImage(imgData, destImg);
            Console.WriteLine("new file should be identical to original");
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
