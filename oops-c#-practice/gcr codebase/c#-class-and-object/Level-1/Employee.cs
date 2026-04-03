using System;

public class emp
{
  
  public static void Main()
  {
    /*
    
    1. Program to Display Employee Details
    Problem Statement: Write a program to create an Employee class with attributes name, id, and salary. Add a method to display the details.
    
    */
    
    // wait for user to give emp details
    Console.WriteLine("enter employee name: ");
    string nm = Console.ReadLine();
    
    Console.WriteLine("enter employee id: ");
    string idstr = Console.ReadLine();
    int id = 0;
    if (int.TryParse(idstr, out id) == false)
    {
      id = 0; // default if bad input
    }
    
    Console.WriteLine("enter employee salary: ");
    string salstr = Console.ReadLine();
    double sal = 0.0;
    if (double.TryParse(salstr, out sal) == false)
    {
      sal = 0.0;
    }
    
    // create emp object
    Employee e = new Employee(nm, id, sal);
    
    Console.WriteLine();
    Console.WriteLine("employee details:");
    
    e.print(); // call the method to show everything
    
    Console.WriteLine();
    Console.WriteLine("press enter to finish...");
    Console.ReadLine();
  }
}

public class Employee
{
  string name;
  int id;
  double salary;
  
  public Employee(string n, int i, double s)
  {
    name = n;
    id = i;
    salary = s;
  }
  
  public void print()
  {
    // this prints the emp info
    Console.WriteLine("name: " + name);
    Console.WriteLine("id  : " + id);
    Console.WriteLine("salary: " + salary);
  }
}
