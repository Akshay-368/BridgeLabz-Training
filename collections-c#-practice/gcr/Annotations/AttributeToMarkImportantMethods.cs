using System;
using System.Reflection;

public class impMeth 
{
    [AttributeUsage(AttributeTargets.Method)]
    public class ImportantMethodAttribute : Attribute
    {
        public string Level { get; set; } = "HIGH";

        public ImportantMethodAttribute(string level = "HIGH")
        {
            Level = level;
        }
    }

    public class TaskList
    {
        [ImportantMethod("CRITICAL")]
        public void BackupDatabase()
        {
            Console.WriteLine("Backing up database...");
        }

        [ImportantMethod]
        public void SendEmailReminder()
        {
            Console.WriteLine("Sending reminder email...");
        }
    }

    public static void showImportantMethods()
    {
        Type t = typeof(TaskList);

        MethodInfo[] methods = t.GetMethods();

        foreach(MethodInfo m in methods)
        {
            object[] attrs = m.GetCustomAttributes(typeof(ImportantMethodAttribute), false);

            foreach(object attr in attrs)
            {
                ImportantMethodAttribute imp = (ImportantMethodAttribute)attr;
                Console.WriteLine("Important Method: " + m.Name + " (Level: " + imp.Level + ")");
            }
        }
    }

    public static void Main(string[] args) 
    {
        /*
        1️⃣ Create an Attribute to Mark Important Methods
        Problem Statement: Define a custom attribute ImportantMethod that can be applied to methods to indicate their importance.
        Requirements:
        1. Define ImportantMethod with an optional Level parameter (default: "HIGH").
        2. Apply it to at least two methods.
        3. Retrieve and print annotated methods using Reflection.
        */

        Console.WriteLine("Important Method Attribute Demo\n");

        showImportantMethods();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
