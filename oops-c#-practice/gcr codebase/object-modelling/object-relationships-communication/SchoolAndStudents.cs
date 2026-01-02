using System;
using System.Collections.Generic;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        Self Problems
        Problem 1: School and Students with Courses (Association and Aggregation)
        Description: Model a School with multiple Student objects, where each student can enroll in multiple courses, and each course can have multiple students.
        Tasks:

        * Define School, Student, and Course classes.

        * Model an association between Student and Course to show that students can enroll in multiple courses.

        * Model an aggregation relationship between School and Student.

        * Demonstrate how a student can view the courses they are enrolled in and how a course can show its enrolled students.

        Goal: Practice association by modeling many-to-many relationships between students and courses.
        */
        
        sch s = new sch("City School");
        
        stu st1 = new stu("aman");
        stu st2 = new stu("rita");
        
        s.as(st1);
        s.as(st2); // aggregation , students can exist without school but school has them
        
        crs c1 = new crs("math");
        crs c2 = new crs("science");
        crs c3 = new crs("english");
        
        // many to many association
        st1.en(c1);
        st1.en(c2);
        st2.en(c2);
        st2.en(c3);
        st1.en(c3);
        
        // show what student has
        st1.sc();
        
        // show who is in a course
        c2.ss();
        
        Console.WriteLine("done with school stuff");
    }
}

public static class sch
{
    public string nm;
    public List<stu> sl; // aggregation
    
    public sch(string n)
    {
        this.nm = n;
        sl = new List<stu>();
    }
    
    public void as(stu st)
    {
        sl.Add(st);
    }
}

public static class stu
{
    public string nm;
    public List<crs> cl; // many courses
    
    public stu(string n)
    {
        this.nm = n;
        cl = new List<crs>();
    }
    
    public void en(crs c)
    {
        cl.Add(c);
        c.sl.Add(this); // both sides know each other , association
        Console.WriteLine(nm + " enrolled in " + c.nm );
    }
    
    public void sc()
    {
        Console.WriteLine(nm + " courses :");
        foreach(crs c in cl)
        {
            Console.WriteLine("  " + c.nm );
        }
    }
}

public static class crs
{
    public string nm;
    public List<stu> sl; // many students
    
    public crs(string n)
    {
        this.nm = n;
        sl = new List<stu>();
    }
    
    public void ss()
    {
        Console.WriteLine("Students in " + nm + " :");
        foreach(stu s in sl)
        {
            Console.WriteLine("  " + s.nm );
        }
    }
}
