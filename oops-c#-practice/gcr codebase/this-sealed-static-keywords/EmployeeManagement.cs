using System;

public static class prog
{
   
   public static void Main( string[] args )
   {
       /*
       Sample Program 3: Employee Management System
       Design an Employee class with the following features:

       * static: 
         * A static variable CompanyName shared by all employees.
         * A static method DisplayTotalEmployees() to show the total number of employees.

       * this: 
         * Use this to initialize Name, Id, and Designation in the constructor.

       * readonly: 
         * Use a readonly variable Id for the employee ID, which cannot be modified after assignment.

       * is operator: 
         * Check if a given object is an instance of the Employee class before printing the employee details.
       */
       
       // this is for sample program 3 , employee thingy
       
       emp.cn = "Tech Corp Ltd"; // company name for all
       
       Console.WriteLine( "Company is " + emp.cn );
       
       emp e1 = new emp( "raj" , 101 , "dev" );
       emp e2 = new emp( "priya",102,"tester");
       
       emp.sh(); // show total emps
       
       object obj = e1;
       
       if( obj is emp )
       {
           emp ex = (emp)obj;
           ex.pr(); // printing details only if its really an emp
       }
       
       Console.WriteLine(" thats all for emp part");
   }
}

public static class emp
{
    public static string cn; // company name , shared by everyone
    public static int tc = 0; // total count of emps
    
    public readonly int id; // cant change this later
    public string nm; // name
    public string ds; // designation
    
    public emp( string n , int i , string d )
    {
        this.nm = n; // using this to set name
        this.id = i; // readonly id set here
        this.ds = d; // designation
        
        tc++; // one more emp added
        // why we do tc++ here ? coz every time we make new emp , count goes up
    }
    
    public static void sh()
    {
        // this shows total employees
        Console.WriteLine( "Total employees right now : " + tc );
    }
    
    public void pr()
    {
        // printing the details of one emp
        Console.WriteLine("Name : " + this.nm );
        Console.WriteLine("ID   : " + this.id );
        Console.WriteLine("Job  : " + this.ds );
    }
}
