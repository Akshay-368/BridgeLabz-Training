using System;
using System.Reflection;

// custom attribute to mark fields for injection
[AttributeUsage(AttributeTargets.Field)]
public class InjectAttribute : Attribute
{
    // just marker - no extra data needed
}

// example service classes
public class Logger
{
    public void Log(string msg)
    {
        Console.WriteLine("LOG: " + msg);
    }
}

public class Database
{
    public void Save(string data)
    {
        Console.WriteLine("Saved to DB: " + data);
    }
}

// class that needs dependencies
public class UserService
{
    [Inject]
    private Logger logger;

    [Inject]
    private Database db;

    public void CreateUser(string name)
    {
        logger.Log("creating user: " + name);
        db.Save("user: " + name);
        Console.WriteLine("user created: " + name);
    }
}

// simple DI container using reflection
public class SimpleDI
{
    // store registered types (type -> instance)
    private static Dictionary<Type, object> container = new Dictionary<Type, object>();

    // register a type with its instance
    public static void Register<T>(object instance)
    {
        container[typeof(T)] = instance;
        Console.WriteLine("registered: " + typeof(T).Name);
    }

    // build object and inject dependencies
    public static T Resolve<T>()
    {
        Type t = typeof(T);

        // create instance
        object obj = Activator.CreateInstance(t);

        // find all fields with [Inject]
        FieldInfo[] fields = t.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);

        foreach(FieldInfo field in fields)
        {
            // check if has Inject attribute
            object[] attrs = field.GetCustomAttributes(typeof(InjectAttribute), false);
            if(attrs.Length > 0)
            {
                Type fieldType = field.FieldType;

                // check if we have registered instance for this type
                if(container.ContainsKey(fieldType))
                {
                    field.SetValue(obj, container[fieldType]);
                    Console.WriteLine("injected " + fieldType.Name + " into " + t.Name);
                }
                else
                {
                    Console.WriteLine("no registration found for " + fieldType.Name);
                }
            }
        }

        return (T)obj;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        /*
        1. Dependency Injection using Reflection: Implement a simple DI container that scans classes with [Inject] attribute and injects dependencies dynamically.
        */

        Console.WriteLine("Simple Dependency Injection with Reflection\n");

        // register services
        SimpleDI.Register<Logger>(new Logger());
        SimpleDI.Register<Database>(new Database());

        // resolve and use
        UserService service = SimpleDI.Resolve<UserService>();

        Console.Write("Waiting , for user to enter username to create : ");
        string user = Console.ReadLine();

        service.CreateUser(user);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
