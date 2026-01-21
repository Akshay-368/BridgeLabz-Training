using System;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

[Serializable]
public class Employee
{
    public int id;
    public string name;
    public string dept;
    public double salary;

    public Employee(int i,string n,string d,double s)
    {
        id = i;
        name = n;
        dept = d;
        salary = s;
    }

    public void print()
    {
        Console.WriteLine("ID: " + id + " Name: " + name + " Dept: " + dept + " Salary: " + salary);
    }
}

public class empSer 
{
    // save list of employees to file using binary serialization
    public static void saveEmployees(string filePath,Employee[] emps,int count)
    {
        FileStream fs = null;
        BinaryFormatter bf = new BinaryFormatter();

        try
        {
            fs = new FileStream(filePath, FileMode.Create);
            bf.Serialize(fs, emps);
            Console.WriteLine("employees saved to file");
        }
        catch(Exception e)
        {
            Console.WriteLine("error saving file : " + e.Message);
        }
        finally
        {
            if(fs != null) fs.Close();
        }
    }

    // read back from file
    public static void loadEmployees(string filePath)
    {
        if(!File.Exists(filePath))
        {
            Console.WriteLine("file not found : " + filePath);
            return;
        }

        FileStream fs = null;
        BinaryFormatter bf = new BinaryFormatter();

        try
        {
            fs = new FileStream(filePath, FileMode.Open);
            Employee[] loaded = (Employee[])bf.Deserialize(fs);

            Console.WriteLine("loaded employees:");
            for(int i=0; i<loaded.Length ; i++)
            {
                if(loaded[i] != null)
                {
                    loaded[i].print();
                }
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("error loading file : " + e.Message);
        }
        finally
        {
            if(fs != null) fs.Close();
        }
    }

    public static void Main(string[] args) 
    {
        /*
        1. Serialization - Save and Retrieve an Object 
        📌 Problem Statement: Design a C# program that allows a user to store a list of employees in a file using Object Serialization and later retrieve the data from the file. 
        Requirements: Create an Employee class with fields: id, name, department, salary. 
        Serialize the list of employees into a file (BinaryFormatter / JSON Serialization). 
        Deserialize and display the employees from the file. 
        Handle exceptions properly.
        */

        Console.WriteLine("Employee Serialization - Save & Load\n");

        Console.Write("Waiting , for user to enter how many employees : ");
        int n = Convert.ToInt32(Console.ReadLine());

        Employee[] emps = new Employee[n];

        for(int i=0; i<n ; i++)
        {
            Console.WriteLine("Employee " + (i+1) + ":");
            Console.Write("id : ");
            int id = Convert.ToInt32(Console.ReadLine());
            Console.Write("name : ");
            string name = Console.ReadLine();
            Console.Write("department : ");
            string dept = Console.ReadLine();
            Console.Write("salary : ");
            double sal = Convert.ToDouble(Console.ReadLine());

            emps[i] = new Employee(id, name, dept, sal);
        }

        Console.Write("Waiting , for user to enter file path to save (like C:\\emps.bin) : ");
        string savePath = Console.ReadLine();

        saveEmployees(savePath, emps, n);

        Console.Write("Waiting , for user to enter file path to load : ");
        string loadPath = Console.ReadLine();

        loadEmployees(loadPath);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
