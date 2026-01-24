using System;
using System.Reflection;

public class attrDemo 
{
    // custom attribute
    [AttributeUsage(AttributeTargets.Method)]
    public class TaskInfoAttribute : Attribute
    {
        public string Priority { get; set; }
        public string AssignedTo { get; set; }

        public TaskInfoAttribute(string pri,string person)
        {
            Priority = pri;
            AssignedTo = person;
        }
    }

    public class TaskManager
    {
        [TaskInfo("High", "Rahul")]
        public void FixLoginBug()
        {
            Console.WriteLine("Fixing login bug...");
        }

        [TaskInfo("Medium", "Priya")]
        public void UpdateUI()
        {
            Console.WriteLine("Updating UI...");
        }
    }

    public static void showAttributes()
    {
        Type t = typeof(TaskManager);

        MethodInfo[] methods = t.GetMethods();

        foreach(MethodInfo m in methods)
        {
            object[] attrs = m.GetCustomAttributes(typeof(TaskInfoAttribute), false);

            foreach(object attr in attrs)
            {
                TaskInfoAttribute task = (TaskInfoAttribute)attr;
                Console.WriteLine("Method: " + m.Name);
                Console.WriteLine("Priority: " + task.Priority);
                Console.WriteLine("Assigned to: " + task.AssignedTo);
                Console.WriteLine("---");
            }
        }
    }

    public static void Main(string[] args) 
    {
        /*
        4. Create a Custom Attribute and Use It
        Problem Statement: Create a custom attribute TaskInfo to mark tasks with priority and assigned person.
        Steps to Follow:
        1. Define an attribute TaskInfo with fields Priority and AssignedTo.
        2. Apply this attribute to a method in TaskManager class.
        3. Retrieve the attribute details using Reflection.
        */

        Console.WriteLine("Custom Attribute TaskInfo Demo\n");

        showAttributes();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
