using System;

public class emp
{
    public int eid;            // public
    protected string dept;     // protected
    private double sal;        // private
    
    public emp(int id, string d, double s)
    {
        eid = id;
        dept = d;
        sal = s;
    }
    
    public void setsal(double newsal)
    {
        if (newsal >= 0)
        {
            sal = newsal;
        }
    }
    
    public double getsal()
    {
        return sal;
    }
    
    public void disp()
    {
        Console.WriteLine("Employee ID : " + eid);
        Console.WriteLine("Department  : " + dept);
        Console.WriteLine("Salary      : " + sal);
    }
}

public class mgr : emp
{
    public mgr(int id, string d, double s) : base(id, d, s)
    {
    }
    
    public void showdept()
    {
        // accessing protected dept
        Console.WriteLine ( " Manager accessing department: " + dept);
        Console.WriteLine ( " Employee ID (public): " + eid);
    }
}

public class rec
{
    public static void Main()
    {
        /*
        Problem 4: Employee Records

        * Develop an Employee class with:

          * employeeID (public)

          * department (protected)

          * salary (private)

        * Implement methods to:

          * Modify salary using a public method.

          * Create a subclass Manager to access employeeID and department.
        */
        
        emp e = new emp(501, "IT", 60000);
        e.disp();
        
        Console.WriteLine();
        e.setsal(75000);
        Console.WriteLine(" after salary update");
        e.disp();
        
        Console.WriteLine();
        mgr m = new mgr(301, "Sales", 120000);
        m.showdept();
        m.disp();
        
        Console.WriteLine ( " finished, press enter...");
        Console.ReadLine();
    }
}
