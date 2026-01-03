using System;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        1. Animal Hierarchy
        Description:
        Create a hierarchy where Animal is the superclass, and Dog, Cat, and Bird are subclasses. Each subclass has a unique behavior.
        Tasks:

          Define a superclass Animal:
           * Add two attributes: Name (string) and Age (integer).
           * Add a method MakeSound() that provides a generic sound message (e.g., "Animal makes a sound").

         Define subclasses Dog, Cat, and Bird:
           * Each subclass should override the MakeSound() method to provide its unique behavior (e.g., "Dog barks", "Cat meows", "Bird chirps").

         Goal:
           * Learn basic inheritance, method overriding, and polymorphism by calling MakeSound() on instances of different subclasses.
        */
        
        // animal hierarchy demo here
        
        an a1 = new an("generic beast",5);
        dg d1 = new dg("bruno",3);
        ct c1 = new ct("mimi",2);
        bd b1 = new bd("tweety",1);
        
        a1.ms(); // generic one
        d1.ms(); // dog sound
        c1.ms(); // cat sound
        b1.ms(); // bird sound
        
        // why override ? so each animal makes its own sound , thats polymorphism
        
        Console.WriteLine("animal part done");
    }
}

public class an
{
    public string nm;
    public int ag;
    
    public an(string n , int a)
    {
        this.nm = n;
        this.ag = a;
    }
    
    public virtual void ms()
    {
        Console.WriteLine( nm + " makes a sound");
        // basic sound for all animals
    }
}

public class dg : an
{
    public dg(string n , int a) : base(n , a)
    {
    }
    
    public override void ms()
    {
        Console.WriteLine( nm + " barks woof woof !");
    }
}

public class ct : an
{
    public ct(string n , int a) : base(n,a)
    {
    }
    
    public override void ms()
    {
        Console.WriteLine(nm + " meows meoww");
        // cat sound here
    }
}

public class bd : an
{
    public bd(string n,int a) : base(n , a)
    {
    }
    
    public override void ms()
    {
        Console.WriteLine(nm + " chirps tweet tweet");
    }
}
