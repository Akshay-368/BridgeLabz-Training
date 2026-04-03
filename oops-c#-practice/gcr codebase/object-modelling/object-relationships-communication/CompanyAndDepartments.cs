using System;
using System.Collections.Generic;

public static class prog
{
    public static void Main( )
    {
        /*
        Problem 3: Company and Departments (Composition)
        Description: A Company has several Department objects, and each department contains Employee objects. Model this using composition, where deleting a Company should also delete all departments and employees.
        Tasks:

        * Define a Company class that contains multiple Department objects.

        * Define an Employee class within each Department.

        * Show the composition relationship by ensuring that when a Company object is deleted, all associated Department and Employee objects are also removed.

        Goal: Understand composition by implementing a relationship where Department and Employee objects cannot exist without a Company.
        */
        
        // composition means parts die with whole
        
        cmp c = new cmp("Big Corp");
        
        dep d1 = c.ad("IT");
        dep d2 = c.ad("HR");
        
        d1.ae("raj","dev");
        d1.ae("priya","tester");
        d2.ae("mohan","manager");
        
        c.sh();
        
        // now if company is gone (set to null in real life) , depts and emps also gone
        // we cant access them outside company , thats composition
        Console.WriteLine("if company closes , all depts and employees gone");
    }
}

public static class cmp
{
    public string nm;
    public List<dep> dl; // owns the departments , composition
    
    public cmp(string n)
    {
        this.nm = n;
        dl = new List<dep>();
    }
    
    public dep ad(string dn)
    {
        dep d = new dep(dn , this); // dept knows company but created inside
        dl.Add(d);
        return d;
    }
    
    public void sh()
    {
        Console.WriteLine("Company : " + nm );
        foreach(dep d in dl)
        {
            d.sh();
        }
    }
}

public static class dep
{
    public string nm;
    public cmp c; // belongs to company
    public List<emp> el; // owns employees , composition again
    
    public dep(string n , cmp com)
    {
        this.nm = n;
        this.c = com;
        el = new List<emp>();
    }
    
    public void ae(string en , string pos)
    {
        emp e = new emp(en , pos);
        el.Add(e);
        // employee created inside dept , cant live outside
    }
    
    public void sh()
    {
        Console.WriteLine("  Dept : " + nm );
        foreach(emp e in el)
        {
            e.pr();
        }
    }
}

public static class emp
{
    public string nm;
    public string ps; // position
    
    public emp(string n , string p)
    {
        this.nm = n;
        this.ps = p;
    }
    
    public void pr()
    {
        Console.WriteLine("    Employee : " + nm + " - " + ps );
    }
}
