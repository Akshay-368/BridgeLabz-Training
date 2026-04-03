using System;

public static class prog
{
    public static void Main(string[] args)
    {
        /*
        2. Employee Management System
        Description:
        Create an Employee hierarchy for different employee types such as Manager, Developer, and Intern.
        Tasks:

         Define a base class Employee:
           * Add three attributes: Name (string), Id (integer), and Salary (double).
           * Add a method DisplayDetails() to display the details of an employee.

         Define subclasses Manager, Developer, and Intern:
           * Manager: Add an additional attribute TeamSize (integer).
           * Developer: Add an additional attribute ProgrammingLanguage (string).
           * Intern: Add an additional attribute InternshipDuration (string).

         Goal:
           * Practice inheritance by creating subclasses with specific attributes and overriding superclass methods (e.g., DisplayDetails()) to display details specific to each type of employee
        */
        
        // employee system with inheritance
        
        emp e1 = new mgr("rajesh",101,90000,15);
        emp e2 = new dev("priya",102,70000,"C#");
        emp e3 = new itn("aman",103,20000,"6 months");
        
        e1.dd(); // manager details
        Console.WriteLine();
        e2.dd(); // dev details
        Console.WriteLine();
        e3.dd(); // intern details
        
        // we override display so each type shows extra info
        
        Console.WriteLine("employee hierarchy over");
    }
}

public class emp
{
    public string nm;
    public int id;
    public double sl;
    
    public emp(string n , int i , double s)
    {
        this.nm = n;
        this.id = i;
        this.sl = s;
    }
    
    public virtual void dd()
    {
        Console.WriteLine("Name: " + nm );
        Console.WriteLine("ID  : " + id );
        Console.WriteLine("Salary : " + sl );
    }
}

public class mgr : emp
{
    public int ts; // team size
    
    public mgr(string n,int i,double s,int t) : base(n,i,s)
    {
        this.ts = t;
    }
    
    public override void dd()
    {
        base.dd(); // first print common stuff
        Console.WriteLine("Type  : Manager");
        Console.WriteLine("Team Size : " + ts );
    }
}

public class dev : emp
{
    public string pl; // programming lang
    
    public dev(string n,int i,double s,string p) : base(n,i,s)
    {
        this.pl = p;
    }
    
    public override void dd()
    {
        base.dd();
        Console.WriteLine("Type : Developer");
        Console.WriteLine("Language : " + pl );
    }
}

public class itn : emp
{
    public string dr; // duration
    
    public itn(string n,int i,double s,string d) : base(n,i,s)
    {
        this.dr = d;
    }
    
    public override void dd()
    {
        base.dd();
        Console.WriteLine("Type : Intern");
        Console.WriteLine("Duration : " + dr );
    }
}
