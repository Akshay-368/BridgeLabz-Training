using System;
using System.Collections.Generic;

public static class prog
{
    public static void Main()
    {
        /*
        Problem 2: University with Faculties and Departments (Composition and Aggregation)
        Description: Create a University with multiple Faculty members and Department objects. Model it so that the University and its Departments are in a composition relationship (deleting a university deletes all departments), and the Faculty members are in an aggregation relationship (faculty can exist outside of any specific department).
        Tasks:

        * Define a University class with Department and Faculty classes.

        * Demonstrate how deleting a University also deletes its Departments.

        * Show that Faculty members can exist independently of a Department.

        Goal: Understand the differences between composition and aggregation in modeling complex hierarchical relationships.
        */
        
        uni u = new uni("Global Uni");
        
        dep d1 = u.cd("CS");
        dep d2 = u.cd("Physics"); // composition with depts
        
        fac f1 = new fac("dr smith");
        fac f2 = new fac("prof lee");
        fac f3 = new fac("mr jones"); // faculty exist alone first , aggregation
        
        u.af(f1);
        u.af(f2);
        u.af(f3);
        
        u.sh();
        
        // if uni gone , depts gone but faculty still exist somewhere
        Console.WriteLine("faculty can move to other uni , but depts cant");
        Console.WriteLine("example independent faculty : " + f3.nm );
    }
}

public static class uni
{
    public string nm;
    public List<dep> dl; // composition
    public List<fac> fl; // aggregation
    
    public uni(string n)
    {
        this.nm = n;
        dl = new List<dep>();
        fl = new List<fac>();
    }
    
    public dep cd(string dn)
    {
        dep d = new dep(dn);
        dl.Add(d);
        return d;
    }
    
    public void af(fac f)
    {
        fl.Add(f);
    }
    
    public void sh()
    {
        Console.WriteLine("University : " + nm );
        Console.WriteLine("Departments :");
        foreach(dep d in dl)
        {
            Console.WriteLine("  " + d.nm );
        }
        Console.WriteLine("Faculty :");
        foreach(fac f in fl)
        {
            Console.WriteLine("  " + f.nm );
        }
    }
}

public static class dep
{
    public string nm;
    
    public dep(string n)
    {
        this.nm = n;
        // created only inside uni , dies with it
    }
}

public static class fac
{
    public string nm;
    
    public fac(string n)
    {
        this.nm = n;
        // can be created outside
    }
}
