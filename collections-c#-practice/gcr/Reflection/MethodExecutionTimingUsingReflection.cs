using System;
using System.Diagnostics;
using System.Reflection;

public class timeMeth 
{
    // example class with methods to time
    public class DemoClass
    {
        public void FastMethod()
        {
            for(int i=0; i<100 ; i++)
            {
                // do nothing
            }
        }

        public void SlowMethod()
        {
            for(int i=0; i<1000000 ; i++)
            {
                // waste some time
            }
        }
    }

    // measure execution time of any method using reflection
    public static void measureMethodTime(string className,string methodName)
    {
        try
        {
            // find the type
            Type t = Type.GetType(className);

            if(t == null)
            {
                Console.WriteLine("class not found: " + className);
                return;
            }

            // create instance
            object instance = Activator.CreateInstance(t);

            // find method
            MethodInfo method = t.GetMethod(methodName);

            if(method == null)
            {
                Console.WriteLine("method not found: " + methodName);
                return;
            }

            Console.WriteLine("timing method: " + methodName);

            Stopwatch watch = new Stopwatch();
            watch.Start();

            // invoke method
            method.Invoke(instance, null);

            watch.Stop();

            Console.WriteLine("execution time: " + watch.ElapsedMilliseconds + " ms");
        }
        catch(Exception e)
        {
            Console.WriteLine("error timing method : " + e.Message);
        }
    }

    public static void Main(string[] args)
    {
        /*
        Method Execution Timing: Use Reflection to measure the execution time of methods in a given class dynamically.
        */

        Console.WriteLine("Method Execution Timing using Reflection\n");

        string classFullName = "timeMeth+DemoClass"; // because it's nested

        Console.WriteLine("available methods: FastMethod, SlowMethod");

        Console.Write("Waiting , for user to enter method name to time : ");
        string methName = Console.ReadLine();

        measureMethodTime(classFullName, methName);

        Console.WriteLine("Press any key...");
        Console.ReadKey();
    }
}
