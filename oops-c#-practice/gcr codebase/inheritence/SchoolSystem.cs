using System;

public static class prog
{
    public static void Main()
    {
        /*
        Sample Problem 2: School System with Different Roles

        * Description: Create a hierarchy for a school system where Person is the superclass, and Teacher, Student, and Staff are subclasses.

        * Tasks:

          * Define a superclass Person with common attributes like Name and Age.

          * Define subclasses Teacher, Student, and Staff with specific attributes (e.g., Subject for Teacher and Grade for Student).

          * Each subclass should have a method like DisplayRole() that describes the role.

        * Goal: Demonstrate hierarchical inheritance by modeling different roles in a school, each with shared and unique characteristics.
        */
        
        // school roles with hierarchical inheritance
        
        ps p1 = new tc("mr raj",45,"Math");
        ps p2 = new st("aman",15,10);
        ps p3 = new sf("mohan",35,"Admin");
        
        p1.dr();
        Console.WriteLine();
        p2.dr();
        Console.WriteLine();
        p3.dr();
        
        // all are persons but different roles
        
        Console.WriteLine("school system part over");
    }
}

public class ps
{
    public string nm;
    public int ag;
    
    public ps(string n , int a)
    {
        this.nm = n;
        this.ag = a;
    }
    
    public virtual void dr()
    {
        Console.WriteLine("Name : " + nm );
        Console.WriteLine("Age : " + ag );
    }
}

public class tc : ps
{
    public string sb; // subject
    
    public tc(string n,int a,string s) : base(n , a)
    {
        this.sb = s;
    }
    
    public override void dr()
    {
        base.dr();
        Console.WriteLine("Role : Teacher");
        Console.WriteLine("Subject : " + sb );
    }
}

public class st : ps
{
    public int gr; // grade
    
    public st(string n,int a,int g) : base(n,a)
    {
        this.gr = g;
    }
    
    public override void dr()
    {
        base.dr();
        Console.WriteLine("Role : Student");
        Console.WriteLine("Grade : " + gr );
    }
}

public class sf : ps
{
    public string dp; // department
    
    public sf(string n,int a,string d) : base(n,a)
    {
        this.dp = d;
    }
    
    public override void dr()
    {
        base.dr();
        Console.WriteLine("Role : Staff");
        Console.WriteLine("Department : " + dp );
    }
}
