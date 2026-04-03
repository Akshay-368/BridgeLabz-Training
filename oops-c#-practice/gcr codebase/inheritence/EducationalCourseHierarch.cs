using System;

public static class prog
{
    public static void Main(string[] args)
    {
        /*
        Sample Problem 2: Educational Course Hierarchy

        * Description: Model a course system where Course is the base class, OnlineCourse is a subclass, and PaidOnlineCourse extends OnlineCourse.

        * Tasks:

          * Define a superclass Course with attributes like CourseName and Duration.

          * Define OnlineCourse to add attributes such as Platform and IsRecorded.

          * Define PaidOnlineCourse to add Fee and Discount.

        * Goal: Demonstrate how each level of inheritance builds on the previous, adding complexity to the system.
        */
        
        // course hierarchy multilevel
        
        crs c1 = new crs("Math Basics",30);
        onc o1 = new onc("C# Programming",45,"Udemy",true);
        poc p1 = new poc("Advanced Python",60,"Coursera",false,1200,20);
        poc p2 = new poc("Web Dev Bootcamp",90,"Zoom",true,800,10);
        
        // show details
        
        c1.sh();
        Console.WriteLine();
        o1.sh();
        Console.WriteLine();
        p1.sh();
        Console.WriteLine();
        p2.sh();
        
        // each level adds more stuff , thats multilevel inheritance
        
        Console.WriteLine("course hierarchy finished");
    }
}

public class crs
{
    public string cn; // course name
    public int dr; // duration in days
    
    public crs(string n , int d)
    {
        this.cn = n;
        this.dr = d;
    }
    
    public virtual void sh()
    {
        Console.WriteLine("Course Name : " + cn );
        Console.WriteLine("Duration : " + dr + " days");
        Console.WriteLine("Type  : Regular Course");
    }
}

public class onc : crs
{
    public string pl; // platform
    public bool rc; // is recorded
    
    public onc(string n,int d,string p,bool r) : base(n , d)
    {
        this.pl = p;
        this.rc = r;
    }
    
    public override void sh()
    {
        base.sh();
        Console.WriteLine("Platform : " + pl );
        Console.WriteLine("Recorded: " + (rc ? "Yes" : "No") );
        Console.WriteLine("Type : Online Course");
    }
}

public class poc : onc
{
    public double fe; // fee
    public int dc; // discount percent
    
    public poc(string n,int d,string p,bool r,double f,int dis) : base(n,d,p,r)
    {
        this.fe = f;
        this.dc = dis;
    }
    
    public override void sh()
    {
        base.sh(); // gets course and online info
        Console.WriteLine("Fee : $" + fe );
        Console.WriteLine("Discount : " + dc + "%" );
        double af = fe - (fe * dc / 100.0);
        Console.WriteLine("After Discount : $" + af );
        Console.WriteLine("Type  : Paid Online Course");
        // why we calculate here ? just to show extra feature
    }
}
