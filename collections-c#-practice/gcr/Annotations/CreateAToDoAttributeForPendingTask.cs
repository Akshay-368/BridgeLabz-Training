using System;
using System.Reflection;

public class todoAttr 
{
    [AttributeUsage(AttributeTargets.Method, AllowMultiple = true)]
    public class TodoAttribute : Attribute
    {
        public string Task { get; set; }
        public string AssignedTo { get; set; }
        public string Priority { get; set; } = "MEDIUM";

        public TodoAttribute(string task,string assigned,string pri = "MEDIUM")
        {
            Task = task;
            AssignedTo = assigned;
            Priority = pri;
        }
    }

    public class ProjectTasks
    {
        [Todo("Fix login bug", "Rahul", "HIGH")]
        [Todo("Add dark mode", "Priya")]
        public void LoginSystem()
        {
            Console.WriteLine("Login system code...");
        }
    }

    public static void showPendingTasks()
    {
        Type t = typeof(ProjectTasks);

        MethodInfo method = t.GetMethod("LoginSystem");

        object[] attrs = method.GetCustomAttributes(typeof(TodoAttribute), false);

        Console.WriteLine("Pending tasks for LoginSystem:");
        foreach(TodoAttribute todo in attrs)
        {
            Console.WriteLine("Task: " + todo.Task);
            Console.WriteLine("Assigned to: " + todo.AssignedTo);
            Console.WriteLine("Priority: " + todo.Priority);
            Console.WriteLine("---");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        2️⃣ Create a Todo Attribute for Pending Tasks
        Problem Statement: Define an attribute Todo to mark pending features in a project.
        Requirements:
        * The attribute should have fields: 
          * Task (string) → Description of the task
          * AssignedTo (string) → Developer responsible
          * Priority (default: "MEDIUM")
        * Apply it to multiple methods.
        * Retrieve and print all pending tasks using Reflection.
        */

        Console.WriteLine("Todo Attribute for Pending Tasks\n");

        showPendingTasks();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
