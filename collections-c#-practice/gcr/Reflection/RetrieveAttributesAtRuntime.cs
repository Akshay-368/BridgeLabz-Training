using System;

public class attrDemo 
{
    // custom attribute
    [AttributeUsage(AttributeTargets.Class)]
    public class AuthorAttribute : Attribute
    {
        public string Name { get; set; }

        public AuthorAttribute(string name)
        {
            Name = name;
        }
    }

    [Author("Akshay Kumar")]
    public class MyClass
    {
        public void sayHello()
        {
            Console.WriteLine("hello from MyClass");
        }
    }

    public static void showAttribute()
    {
        Type t = typeof(MyClass);

        object[] attrs = t.GetCustomAttributes(false);

        foreach(object attr in attrs)
        {
            if(attr is AuthorAttribute)
            {
                AuthorAttribute a = (AuthorAttribute)attr;
                Console.WriteLine("Author: " + a.Name);
            }
        }
    }

    public static void Main(string[] args) 
    {
        /*
        6. Retrieve Attributes at Runtime: Create a custom attribute [Author("Author Name")]. Apply it to a class and use Reflection to retrieve and display the attribute value at runtime.
        */

        Console.WriteLine("Retrieve Custom Attribute\n");

        showAttribute();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
