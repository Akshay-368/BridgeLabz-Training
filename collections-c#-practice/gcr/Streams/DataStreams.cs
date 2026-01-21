using System;
using System.IO;

public class primData 
{
    // save student details using BinaryWriter
    public static void saveStudent(string filePath,int roll,string name,double gpa)
    {
        BinaryWriter writer = null;

        try
        {
            writer = new BinaryWriter(new FileStream(filePath, FileMode.Create));

            writer.Write(roll);
            writer.Write(name);
            writer.Write(gpa);

            Console.WriteLine("student data saved");
        }
        catch(Exception e)
        {
            Console.WriteLine("error saving : " + e.Message);
        }
        finally
        {
            if(writer != null) writer.Close();
        }
    }

    // read back using BinaryReader
    public static void loadStudent(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Console.WriteLine("file not found");
            return;
        }

        BinaryReader reader = null;

        try
        {
            reader = new BinaryReader(new FileStream(filePath, FileMode.Open));

            int roll = reader.ReadInt32();
            string name = reader.ReadString();
            double gpa = reader.ReadDouble();

            Console.WriteLine("Roll: " + roll);
            Console.WriteLine("Name: " + name);
            Console.WriteLine("GPA: " + gpa);
        }
        catch(Exception e)
        {
            Console.WriteLine("error reading : " + e.Message);
        }
        finally
        {
            if(reader != null) reader.Close();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        4. Data Streams - Store and Retrieve Primitive Data 
        📌 Problem Statement: Write a C# program that stores student details (roll number, name, GPA) in a binary file and retrieves it later. 
        Requirements: Use BinaryWriter to write primitive data. 
        Use BinaryReader to read data. 
        Ensure proper closing of resources.
        */

        Console.WriteLine("Save & Load Student Data (Binary)\n");

        Console.Write("Waiting , for user to enter file path to save/load : ");
        string path = Console.ReadLine();

        Console.Write("enter roll number : ");
        int roll = Convert.ToInt32(Console.ReadLine());

        Console.Write("enter name : ");
        string name = Console.ReadLine();

        Console.Write("enter GPA : ");
        double gpa = Convert.ToDouble(Console.ReadLine());

        saveStudent(path, roll, name, gpa);
        loadStudent(path);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
