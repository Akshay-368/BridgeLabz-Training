using System;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        3. Vehicle and Transport System
        Description:
        Design a vehicle hierarchy where Vehicle is the superclass, and Car, Truck, and Motorcycle are subclasses with unique attributes.
        Tasks:

         Define a superclass Vehicle:
           * Add two attributes: MaxSpeed (integer) and FuelType (string).
           * Add a method DisplayInfo() to display the vehicle's information.

         Define subclasses Car, Truck, and Motorcycle that inherit from Vehicle:
           * Car: Add an additional attribute SeatCapacity (integer).
           * Truck: Add an additional attribute PayloadCapacity (integer).
           * Motorcycle: Add an additional attribute HasSidecar (boolean).

         Demonstrate polymorphism:
           * Store objects of type Car, Truck, and Motorcycle in an array of Vehicle type.
           * Call the DisplayInfo() method on each object in the array and observe dynamic method dispatch.

        Goal: Understand how inheritance helps in organizing shared and unique features across subclasses and use polymorphism for dynamic method calls.
        */
        
        // vehicle hierarchy with polymorphism
        
        vh[] va = new vh[4]; // array of base type
        
        va[0] = new cr(200,"Petrol",5);
        va[1] = new tk(120,"Diesel",10000);
        va[2] = new mc(180,"Petrol",false);
        va[3] = new cr(220,"Electric",4); // another car
        
        // now loop and call display , it will call correct override
        foreach(vh v in va)
        {
            v.di();
            Console.WriteLine("----------------");
        }
        
        // why array of base ? so we can treat all as vehicle but still get unique info , thats polymorphism
        
        Console.WriteLine("vehicle demo finished");
    }
}

public class vh
{
    public int ms; // max speed
    public string ft; // fuel type
    
    public vh(int m , string f)
    {
        this.ms = m;
        this.ft = f;
    }
    
    public virtual void di()
    {
        Console.WriteLine("Max Speed : " + ms + " km/h");
        Console.WriteLine("Fuel Type : " + ft );
    }
}

public class cr : vh
{
    public int sc; // seats
    
    public cr(int m,string f,int s) : base(m,f)
    {
        this.sc = s;
    }
    
    public override void di()
    {
        base.di();
        Console.WriteLine("Type : Car");
        Console.WriteLine("Seats : " + sc );
    }
}

public class tk : vh
{
    public int pc; // payload
    
    public tk(int m,string f,int p) : base(m,f)
    {
        this.pc = p;
    }
    
    public override void di()
    {
        base.di();
        Console.WriteLine("Type : Truck");
        Console.WriteLine("Payload Capacity : " + pc + " kg");
    }
}

public class mc : vh
{
    public bool hs; // has sidecar
    
    public mc(int m,string f,bool h) : base(m,f)
    {
        this.hs = h;
    }
    
    public override void di()
    {
        base.di();
        Console.WriteLine("Type : Motorcycle");
        Console.WriteLine("Has Sidecar : " + (hs ? "Yes" : "No") );
    }
}
