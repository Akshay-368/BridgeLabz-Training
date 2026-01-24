using System;
using System.Collections.Generic;
using System.Reflection;

public class objMap 
{
    // simple object mapper from dictionary to object
    public static T ToObject<T>(Dictionary<string,object> properties) where T : new()
    {
        T obj = new T();

        Type t = typeof(T);

        foreach(KeyValuePair<string,object> p in properties)
        {
            FieldInfo field = t.GetField(p.Key, BindingFlags.Public | BindingFlags.Instance | BindingFlags.IgnoreCase);

            if(field != null)
            {
                field.SetValue(obj, p.Value);
            }
        }

        return obj;
    }

    public class Person
    {
        public string name;
        public int age;
    }

    public static void Main(string[] args) 
    {
        /*
        8. Create a Custom Object Mapper: Implement a method ToObject<T>(Type clazz, Dictionary<string, object> properties) that uses Reflection to set field values from a given dictionary.
        */

        Console.WriteLine("Custom Object Mapper\n");

        Dictionary<string,object> data = new Dictionary<string,object>();
        data["name"] = "Rahul";
        data["age"] = 25;

        Person p = ToObject<Person>(data);

        Console.WriteLine("Mapped person: " + p.name + " , age " + p.age);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
