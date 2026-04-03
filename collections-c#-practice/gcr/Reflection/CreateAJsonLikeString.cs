using System;
using System.Reflection;

public class jsonGen 
{
    // simple object to JSON-like string using reflection
    public static string toJsonLike(object obj)
    {
        Type t = obj.GetType();
        string json = "{\n";

        FieldInfo[] fields = t.GetFields(BindingFlags.Public | BindingFlags.Instance);

        for(int i=0; i<fields.Length ; i++)
        {
            string name = fields[i].Name;
            object value = fields[i].GetValue(obj);

            json += "  \"" + name + "\": \"" + value + "\"";

            if(i < fields.Length-1) json += ",";
            json += "\n";
        }

        json += "}";
        return json;
    }

    public class Student
    {
        public string name = "Priya";
        public int age = 22;
    }

    public static void Main(string[] args) 
    {
        /*
        9. Generate a JSON Representation: Write a program that converts an object to a JSON-like string using Reflection by inspecting its fields and values.
        */

        Console.WriteLine("Object to JSON-like String\n");

        Student s = new Student();
        string json = toJsonLike(s);

        Console.WriteLine("JSON-like output:");
        Console.WriteLine(json);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
