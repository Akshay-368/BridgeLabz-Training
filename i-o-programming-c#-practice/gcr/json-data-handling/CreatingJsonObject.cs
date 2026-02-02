using System;
using Newtonsoft.Json;

public class studentJson 
{
    public class Student
    {
        public string name;
        public int age;
        public string[] subjects;
    }

    public static void Main(string[] args)
    {
        /*
        1. Create a JSON object for a Student with fields: name, age, and subjects (array).
        */

        Console.WriteLine("Create Student JSON\n");

        Student s = new Student();
        s.name = "Rahul";
        s.age = 21;
        s.subjects = new string[] { "Maths", "Physics", "Chemistry", "Computer Science" };

        string json = JsonConvert.SerializeObject(s, Formatting.Indented);

        Console.WriteLine("Student JSON:");
        Console.WriteLine(json);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
