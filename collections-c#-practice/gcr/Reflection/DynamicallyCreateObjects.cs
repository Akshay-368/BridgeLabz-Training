using System;
using System.Reflection;

public class dynObj 
{
    public class Student
    {
        public string name;
        public int roll;

        public Student()
        {
            name = "Unknown";
            roll = 0;
        }

        public void print()
        {
            Console.WriteLine("Student: " + name + " Roll: " + roll);
        }
    }

    public static void createObjectDynamically()
    {
        // get type
        Type studentType = typeof(Student);

        // create instance without new keyword
        object obj = Activator.CreateInstance(studentType);

        // set fields using reflection
        FieldInfo nameField = studentType.GetField("name");
        FieldInfo rollField = studentType.GetField("roll");

        if(nameField != null && rollField != null)
        {
            nameField.SetValue(obj, "Rahul");
            rollField.SetValue(obj, 101);
        }

        // call print method
        MethodInfo printMethod = studentType.GetMethod("print");
        if(printMethod != null)
        {
            printMethod.Invoke(obj, null);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        4. Dynamically Create Objects: Write a program to create an instance of a Student class dynamically using Reflection without using the new keyword.
        */

        Console.WriteLine("Dynamic Object Creation using Reflection\n");

        createObjectDynamically();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
