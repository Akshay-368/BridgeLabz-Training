using System;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        Sample Problem 1: Restaurant Management System with Hybrid Inheritance

        * Description: Model a restaurant system where Person is the superclass and Chef and Waiter are subclasses. Both Chef and Waiter should implement a Worker interface that requires a PerformDuties() method.

        * Tasks:

          * Define a superclass Person with attributes like Name and Id.

          * Create an interface Worker with a method PerformDuties().

          * Define subclasses Chef and Waiter that inherit from Person and implement the Worker interface, each providing a unique implementation of PerformDuties().

        * Goal: Practice hybrid inheritance by combining inheritance and interfaces, giving multiple behaviors to the same objects.
        */
        
        // hybrid using inheritance + interface
        
        ch c1 = new ch("ram",101);
        wt w1 = new wt("sita",201);
        
        c1.pd(); // chef duty
        Console.WriteLine();
        w1.pd(); // waiter duty
        
        // both are person and worker , thats hybrid
        
        Console.WriteLine("restaurant hybrid done");
    }
}

public class ps
{
    public string nm;
    public int id;
    
    public ps(string n , int i)
    {
        this.nm = n;
        this.id = i;
    }
}

public interface wk
{
    void pd(); // perform duties
}

public class ch : ps , wk
{
    public ch(string n,int i) : base(n , i)
    {
    }
    
    public void pd()
    {
        Console.WriteLine("Chef " + nm + " (ID: " + id + ") is cooking tasty food");
        Console.WriteLine("preparing dishes , checking ingredients");
        // chef specific duties
    }
}

public class wt : ps , wk
{
    public wt(string n,int i) : base(n,i)
    {
    }
    
    public void pd()
    {
        Console.WriteLine("Waiter " + nm + " (ID: " + id + ") is serving customers");
        Console.WriteLine("taking orders , serving food , cleaning tables");
        // waiter duties
    }
}
