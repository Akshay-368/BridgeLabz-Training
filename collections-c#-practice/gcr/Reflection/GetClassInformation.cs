using System;
using System.Reflection;

public class classInfo 
{
    public static void showClassInfo(string className)
    {
        try
        {
            // find the type by name
            Type t = Type.GetType(className);

            if(t == null)
            {
                Console.WriteLine("class not found : " + className);
                return;
            }

            Console.WriteLine("Class found: " + t.FullName);


            // show constructors
            Console.WriteLine("Constructors:");
            ConstructorInfo[] cons = t.GetConstructors();
            for(int i=0; i<cons.Length ; i++)
            {
                Console.WriteLine(cons[i].ToString());
            }

            // show fields
            Console.WriteLine("\nFields:");
            FieldInfo[] fields = t.GetFields(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for(int i=0; i<fields.Length ; i++)
            {
                Console.WriteLine(fields[i].Name + " (" + fields[i].FieldType.Name + ")");
            }

            // show methods
            Console.WriteLine("\nMethods:");
            MethodInfo[] methods = t.GetMethods(BindingFlags.Public | BindingFlags.NonPublic | BindingFlags.Instance);
            for(int i=0; i<methods.Length ; i++)
            {
                Console.WriteLine(methods[i].Name);
            }
        }
        catch(Exception e)
        {
            Console.WriteLine("error getting class info : " + e.Message);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        1. Get Class Information: Write a program to accept a class name as input and display its methods, fields, and constructors using Reflection.
        */

        Console.WriteLine("Get Class Information using Reflection\n");

        Console.Write("Waiting , for user to enter full class name (example: System.String) : ");
        string className = Console.ReadLine();

        showClassInfo(className);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
