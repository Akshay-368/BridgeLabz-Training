using System;

public class program
{
  
  public static void Main ()
  {
    /*
    
    2. Program to Compute Area of a Circle
    Problem Statement: Write a program to create a Circle class with an attribute radius. Add methods to calculate and display the area and circumference of the circle.
    
    */
    
    Console.WriteLine("enter radius of circle: ");
    string rstr = Console.ReadLine();
    
    double r = 0.0;
    if (double.TryParse(rstr, out r) == false)
    {
      r = 0.0;
    }
    
    Circle c = new Circle(r);
    
    Console.WriteLine();
    Console.WriteLine("circle details:");
    c.showarea();
    c.showcircum();
    
    Console.WriteLine();
    Console.WriteLine("hit enter to close...");
    Console.ReadLine();
  }
}

public class Circle
{
  double radius;
  
  public Circle(double r)
  {
    radius = r ;
  }
  
  public double area()
  {
    // area = pi * r^2
    return 3.14159 * radius * radius;
  }
  
  public double circum()
  {
    // circumference = 2 * pi * r
    return 2 * 3.14159 * radius;
  }
  
  public void showarea()
  {
    Console.WriteLine("area: " + area());
  }
  
  public void showcircum()
  {
    Console.WriteLine("circumference: " + circum());
  }
}
