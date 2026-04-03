using System;

public static class prog
{
    public static void Main(  )
    {
        /*
        Sample Program 7: Hospital Management System
        Create a Patient class with the following features:

        * static: 
          * A static variable HospitalName shared among all patients.
          * A static method GetTotalPatients() to count the total patients admitted.

        * this: 
          * Use this to initialize Name, Age, and Ailment in the constructor.

        * readonly: 
          * Use a readonly variable PatientID to uniquely identify each patient.

        * is operator: 
          * Check if an object is an instance of the Patient class before displaying its details.
        */
        
        pat.hn = "City Hospital" ;
        
        Console.WriteLine("Hospital : " + pat.hn );
        
        pat p1 = new pat("mike",45,"fever",5001);
        pat p2 = new pat("lisa",30,"fracture",5002);
        
        pat.gt(); // get total patients
        
        object ox = p1;
        
        if(ox is pat )
        {
            pat px = (pat)ox;
            px.shd(); // show details only if real patient
        }
        
        Console.WriteLine("end of hospital program");
    }
}

public static class pat
{
    public static string hn; // hospital name
    public static int tc = 0; // total count
    
    public readonly int pid; // patient id readonly
    public string nm;
    public int ag;
    public string al; // ailment
    
    public pat(string n,int a,string ail,int id)
    {
        this.nm = n;
        this.ag = a;
        this.al = ail;
        this.pid = id; // set once
        
        tc++; // one more patient
        // we increase count here coz new patient created
    }
    
    public static void gt()
    {
        Console.WriteLine("Total patients admitted : " + tc );
    }
    
    public void shd()
    {
        Console.WriteLine("Patient name : " + this.nm );
        Console.WriteLine("Age : " + this.ag );
        Console.WriteLine("Ailment : " + this.al );
        Console.WriteLine("ID : " + this.pid );
    }
}
