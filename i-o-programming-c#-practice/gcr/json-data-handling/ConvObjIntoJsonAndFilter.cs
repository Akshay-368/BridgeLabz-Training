using System;
using System.Collections.Generic;
using Newtonsoft.Json;

public class jsonListFilter
{
    public class Person
    {
        public string name;
        public int age;
        public string city;
    }

    public static void Main(string[] args)
    {
        /*
        12. Convert a list of C# objects into a JSON array.
            Filter JSON data: Print only users older than 25 years.
        */

        Console.WriteLine("List → JSON Array + Filter age > 25\n");

        List<Person> people = new List<Person>
        {
            new Person { name = "Rahul", age = 28, city = "Mathura" },
            new Person { name = "Priya", age = 22, city = "Agra" },
            new Person { name = "Aman", age = 31, city = "Delhi" },
            new Person { name = "Sneha", age = 19, city = "Vrindavan" },
            new Person { name = "Vikram", age = 27, city = "Lucknow" }
        };

        //  Convert list to JSON array
        string jsonArray = JsonConvert.SerializeObject(people, Formatting.Indented);
        Console.WriteLine("Full JSON Array:");
        Console.WriteLine(jsonArray);

        //  Filter age > 25
        Console.WriteLine("\n People older than 25:");


        foreach (Person p in people)
        {
            if (p.age > 25)
            {
                Console.WriteLine($"{p.name}, Age: {p.age}, City: {p.city}");
            }
        }

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
