using System;
using System.Reflection;

public class config 
{
    public class Configuration
    {
        private static string API_KEY = "secret123";
    }

    public static void modifyStaticField()
    {
        Type t = typeof(Configuration);

        FieldInfo keyField = t.GetField("API_KEY", BindingFlags.NonPublic | BindingFlags.Static);

        if(keyField != null)
        {
            Console.WriteLine("old value: " + keyField.GetValue(null));

            keyField.SetValue(null, "newsecret456");

            Console.WriteLine("new value: " + keyField.GetValue(null));
        }
        else
        {
            Console.WriteLine("API_KEY field not found");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        7. Access and Modify Static Fields: Create a Configuration class with a private static field API_KEY. Use Reflection to modify its value and print it.
        */

        Console.WriteLine("Modify Static Field using Reflection\n");

        modifyStaticField();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
