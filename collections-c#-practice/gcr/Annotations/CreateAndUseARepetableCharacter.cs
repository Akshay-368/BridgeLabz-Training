using System;
using System.Reflection;

public class repeatAttr 
{
    // repeatable attribute
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class BugReportAttribute : Attribute
    {
        public string Description { get; set; }

        public BugReportAttribute(string desc)
        {
            Description = desc;
        }
    }

    public class BuggyCode
    {
        [BugReport("Login button not working")]
        [BugReport("Crashes on invalid input")]
        public void LoginFunction()
        {
            Console.WriteLine("Login function running...");
        }
    }

    public static void showBugReports()
    {
        Type t = typeof(BuggyCode);

        MethodInfo method = t.GetMethod("LoginFunction");

        object[] attrs = method.GetCustomAttributes(typeof(BugReportAttribute), false);

        Console.WriteLine("Bug reports for LoginFunction:");
        foreach(BugReportAttribute bug in attrs)
        {
            Console.WriteLine("- " + bug.Description);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        5. Create and Use a Repeatable Attribute
        Problem Statement: Define an attribute BugReport that can be applied multiple times on a method.
        Steps to Follow:
        1. Define BugReport with a Description field.
        2. Use AllowMultiple = true to allow multiple bug reports.
        3. Apply it twice on a method.
        4. Retrieve and print all bug reports.
        */

        Console.WriteLine("Repeatable BugReport Attribute Demo\n");

        showBugReports();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
