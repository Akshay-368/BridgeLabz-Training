using System;

public class per
{
    string nm;
    int age;
    
    public per (string n, int a)
    {
        nm = n;
        age = a;
    }
    
    // copy constructor
    public per( per orig)
    {
        nm = orig.nm;
        age = orig.age;
    }
    
    public void show()
    {
        Console.WriteLine ( " Name: " + nm);
        Console.WriteLine (" Age : " + age);
    }
    
    public static void Main(string[] args)
    {
        /*
        3. Person Class (Copy Constructor)
           * Create a Person class with a copy constructor that clones another person's attributes.
        */
        
        per p1 = new per( " Alex", 25);
        Console.WriteLine( " original person");
        p1.show();
        
        Console.WriteLine();
        
        per p2 = new per(p1); // copy
        Console.WriteLine ( " copied person");
        p2.show();
        
        Console.WriteLine ( " press enter to exit..");
        Console.ReadLine() ;
    }
}
