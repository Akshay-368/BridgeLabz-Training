using System;

public static class prog
{
    public static void Main(  )
    {
        /*
        Sample Program 5: University Student Management
        Create a Student class to manage student data with the following features:

        * static: 
          * A static variable UniversityName shared across all students.
          * A static method DisplayTotalStudents() to show the number of students enrolled.

        * this: 
          * Use this in the constructor to initialize Name, RollNumber, and Grade.

        * readonly: 
          * Use a readonly variable RollNumber for each student that cannot be changed.

        * is operator: 
          * Check if a given object is an instance of the Student class before performing operations like displaying or updating grades.
        */
        
        stu.un = "Global University";
        
        Console.WriteLine("Welcome to " + stu.un );
        
        stu s1 = new stu("aman",1001,"A");
        stu s2 = new stu("rita",1002,"B+");
        
        stu.dt(); // display total students
        
        object o = s1;
        
        if(o is stu )
        {
            stu ss = (stu)o;
            ss.pr(); // print only if its a student
        }
        
        Console.WriteLine("done with students");
    }
}

public static class stu
{
    public static string un; // university name same for all
    public static int tot = 0; // total students
    
    public readonly int rn; // roll number readonly
    public string nm;
    public string gr;
    
    public stu(string n,int r,string g)
    {
        this.nm = n;
        this.rn = r; // set once
        this.gr = g;
        
        tot++; // count increases
        // we do this here so every new student is counted
    }
    
    public static void dt()
    {
        Console.WriteLine("Total students enrolled : " + tot );
    }
    
    public void pr()
    {
        Console.WriteLine("Student name : " + this.nm );
        Console.WriteLine("Roll number : " + this.rn );
        Console.WriteLine("Grade : " + this.gr );
    }
}
