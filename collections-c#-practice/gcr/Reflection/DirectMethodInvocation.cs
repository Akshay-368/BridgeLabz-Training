using System;
using System.Reflection;

public class mathOp 
{
    public class MathOperations
    {
        public int Add(int a,int b) { return a + b; }
        public int Subtract(int a,int b) { return a - b; }
        public int Multiply(int a,int b) { return a * b; }
    }

    public static void dynamicMethodCall(string methodName,int x,int y)
    {
        MathOperations ops = new MathOperations();

        MethodInfo method = typeof(MathOperations).GetMethod(methodName);

        if(method != null)
        {
            object result = method.Invoke(ops, new object[] {x, y});
            Console.WriteLine(methodName + "(" + x + "," + y + ") = " + result);
        }
        else
        {
            Console.WriteLine("method not found: " + methodName);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        5. Dynamic Method Invocation: Define a class MathOperations with multiple public methods (Add, Subtract, Multiply). Use Reflection to dynamically call any method based on user input.
        */

        Console.WriteLine("Dynamic Method Invocation\n");

        Console.Write("Waiting , for user to enter method name (Add/Subtract/Multiply) : ");
        string method = Console.ReadLine();

        Console.Write("enter first number : ");
        int x = Convert.ToInt32(Console.ReadLine());

        Console.Write("enter second number : ");
        int y = Convert.ToInt32(Console.ReadLine());

        dynamicMethodCall(method, x, y);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
