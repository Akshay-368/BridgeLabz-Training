using System;
using System.Reflection;

public class logProxy 
{
    public interface IGreeting
    {
        void SayHello(string name);
    }

    public class Greeting : IGreeting
    {
        public void SayHello(string name)
        {
            Console.WriteLine("Hello " + name);
        }
    }

    public static object createProxy(object target)
    {
        return new Proxy(target);
    }

    public class Proxy : IGreeting
    {
        private object real;

        public Proxy(object realObj)
        {
            real = realObj;
        }

        public void SayHello(string name)
        {
            Console.WriteLine("LOG: calling SayHello with " + name);

            MethodInfo method = real.GetType().GetMethod("SayHello");
            method.Invoke(real, new object[] {name});

            Console.WriteLine("LOG: SayHello finished");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        10. Custom Logging Proxy Using Reflection: Implement a Dynamic Proxy that intercepts method calls on an interface (e.g., IGreeting.SayHello()) and logs the method name before executing it.
        */

        Console.WriteLine("Custom Logging Proxy Demo\n");

        IGreeting real = new Greeting();
        IGreeting proxy = (IGreeting)createProxy(real);

        proxy.SayHello("Akshay");

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
