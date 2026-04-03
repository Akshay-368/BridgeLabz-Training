using System;
using System.Reflection;

public class person 
{
    public class Person
    {
        private int age;

        public Person(int a)
        {
            age = a;
        }

        public void printAge()
        {
            Console.WriteLine("age: " + age);
        }
    }

    public static void accessPrivateField()
    {
        Person p = new Person(25);

        Console.WriteLine("before change:");
        p.printAge();

        // get private field using reflection
        FieldInfo ageField = typeof(Person).GetField("age", BindingFlags.NonPublic | BindingFlags.Instance);

        if(ageField != null)
        {
            // change value
            ageField.SetValue(p, 30);
            Console.WriteLine("age changed using reflection");

            Console.WriteLine("after change:");
            p.printAge();
        }
        else
        {
            Console.WriteLine("age field not found");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        2. Access Private Field: Create a class Person with a private field age. Use Reflection to modify and retrieve its value.
        */

        Console.WriteLine("Access Private Field using Reflection\n");

        accessPrivateField();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
