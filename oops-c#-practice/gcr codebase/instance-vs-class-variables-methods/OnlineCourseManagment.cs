using System;

public class crs
{
    string cname;
    int dur;
    double fee;
    
    static string inst = "Tech Academy"; // class variable, same for all
    
    public crs(string cn, int d, double f)
    {
        cname = cn;
        dur = d;
        fee = f;
    }
    
    public void dispcrs()
    {
        // instance method printing course info
        Console.WriteLine("Course Name : " +    cname);
        Console.WriteLine("Duration  : " + dur + " months" );
        Console.WriteLine("Fee : " + fee);
        Console.WriteLine("Institute : " +  inst) ;
    }
    
    public static void upinst(string newname)
    {
        // class method to change institute name for everyone
        inst = newname;
        Console.WriteLine("Institute name updated to: " + inst);
    }
    
    public static void Main ()
    {
        /*
        Problem 2: Online Course Management

        * Design a Course class with:

          * Instance Variables: courseName, duration, fee.

          * Class Variable: instituteName (common for all courses).

        * Implement the following methods:

          * An instance method DisplayCourseDetails() to display course details.

          * A class method UpdateInstituteName() to modify the institute name for all courses.
        */
        
        crs c1 = new crs("C# Programming", 3, 12000);
        crs c2 = new crs("Web Development", 6, 25000);
        
        Console.WriteLine("courses before update");
        Console.WriteLine();
        c1.dispcrs();
        Console.WriteLine();
        c2.dispcrs();
        Console.WriteLine();
        
        crs.upinst ("  Global Tech Institute");
        Console.WriteLine();
        
        Console.WriteLine(  "  courses after institute name change");
        Console.WriteLine();
        c1.dispcrs();
        Console.WriteLine();
        c2.dispcrs();
        
        Console.WriteLine("done, press enter to quit..");
        Console.ReadLine();
    }
}
