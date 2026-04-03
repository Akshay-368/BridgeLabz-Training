using System;

public class cir
{
    double rad;
    
    // default constructor
    public cir() : this(1.0)
    {
        // fixing to parametered, sets default radius 1
    }
    
    // parameterized
    public cir(double r)
    {
        rad = r;
    }
    
    public void info()
    {
        Console.WriteLine("Circle radius: " + rad);
        Console.WriteLine("Area: " + (3.14 * rad * rad));
    }
    
    public static void Main(string[] args)
    {
        /*
        2. Circle Class
           * Write a Circle class with a radius attribute.
           * Use constructor chaining to initialize radius with both default and user-provided values.
        */
        
        cir c1 = new cir(); // default
        c1.info();
        
        Console.WriteLine();
        
        Console.WriteLine ( "  enter radius for second circle");
        double val = double.Parse(Console.ReadLine() );
        
        cir c2 = new cir(val);
        c2.info();
        
        Console.WriteLine("done, press enter");
        Console.ReadLine();
    }
}
