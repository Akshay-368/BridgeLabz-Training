using System;

public class stu
{
    public int roll;         // public roll number
    protected string nm;     // protected name
    private double cg;       // private CGPA
    
    public stu(int r, string n, double c)
    {
        roll = r;
        nm = n;
        cg = c;
    }
    
    public double getcg()
    {
        // getter for CGPA
        return cg;
    }
    
    public void setcg(double newcg)
    {
        // setter with little check
        if (newcg >= 0 && newcg <= 10)
        {
            cg = newcg;
        }
        else
        {
            Console.WriteLine("invalid CGPA, must be 0-10");
        }
    }
    
    public void dispbasic()
    {
        Console.WriteLine("Roll Number: " + roll);
        Console.WriteLine("Name       : " + nm);
        Console.WriteLine("CGPA       : " + cg);
    }
}

public class poststu : stu
{
    // subclass to show protected access
    public poststu(int r, string n, double c) : base(r, n, c)
    {
    }
    
    public void showprot()
    {
        // can access protected nm here
        Console.WriteLine("inside postgraduate, accessing protected name: " + nm);
    }
}

public class uni
{
    public static void Main(string[] args)
    {
        /*
        Problem 1: University Management System

        * Create a Student class with:

          * rollNumber (public)

          * name (protected)

          * CGPA (private)

        * Implement methods to:

          * Access and modify CGPA using public methods.

          * Create a subclass PostgraduateStudent to demonstrate the use of protected members.
        */
        
        stu s = new stu(101, "Amit Kumar", 8.7);
        Console.WriteLine("basic student details");
        s.dispbasic();
        
        Console.WriteLine();
        Console.WriteLine("CGPA from getter: " + s.getcg());
        
        s.setcg(9.2);
        Console.WriteLine("after update");
        s.dispbasic();
        
        Console.WriteLine();
        poststu ps = new poststu(201, "Riya Sharma", 9.5);
        ps.dispbasic();
        ps.showprot();  // using protected member
        
        Console.WriteLine("press enter to finish..");
        Console.ReadLine();
    }
}
