using System;
using System.Collections.Generic;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        Problem 5: University Management System
        Description: Model a university system with Student, Professor, and Course classes. Students enroll in courses, and professors teach courses. Ensure students and professors can communicate through methods like EnrollCourse() and AssignProfessor().
        Goal: Use association and aggregation to create a university system that emphasizes relationships and interactions among students, professors, and courses.
        */
        
        crs c1 = new crs("C# Programming");
        crs c2 = new crs("Data Structures");
        
        pro p1 = new pro("prof kim");
        pro p2 = new pro("dr raj");
        
        stu s1 = new stu("neha");
        stu s2 = new stu("vikas");
        
        // assign prof to course
        c1.ap(p1);
        c2.ap(p2);
        
        // students enroll
        s1.ec(c1);
        s1.ec(c2);
        s2.ec(c1);
        
        // show stuff
        c1.sc();
        c1.sp();
        
        s1.mc();
        
        Console.WriteLine("university system demo done");
    }
}

public static class crs
{
    public string nm;
    public pro pf; // one prof teaches
    public List<stu> sl; // many students
    
    public crs(string n)
    {
        this.nm = n;
        sl = new List<stu>();
    }
    
    public void ap(pro p)
    {
        this.pf = p;
        Console.WriteLine(p.nm + " assigned to teach " + nm );
    }
    
    public void sc()
    {
        Console.WriteLine("Students in " + nm + " :");
        foreach(stu s in sl)
        {
            Console.WriteLine("  " + s.nm );
        }
    }
    
    public void sp()
    {
        if(pf != null)
        {
            Console.WriteLine("Taught by : " + pf.nm );
        }
    }
}

public static class pro
{
    public string nm;
    
    public pro(string n)
    {
        this.nm = n;
    }
}

public static class stu
{
    public string nm;
    public List<crs> cl;
    
    public stu(string n)
    {
        this.nm = n;
        cl = new List<crs>();
    }
    
    public void ec(crs c)
    {
        cl.Add(c);
        c.sl.Add(this);
        Console.WriteLine(nm + " enrolled in " + c.nm );
    }
    
    public void mc()
    {
        Console.WriteLine(nm + " courses :");
        foreach(crs c in cl)
        {
            Console.WriteLine("  " + c.nm );
        }
    }
}
