using System;

public static class prog
{
    public static void Main(string[] args)
    {
        /*
        Sample Problem 2: Vehicle Management System with Hybrid Inheritance

        * Description: Model a vehicle system where Vehicle is the superclass and ElectricVehicle and PetrolVehicle are subclasses. Additionally, create a Refuelable interface implemented by PetrolVehicle.

        * Tasks:

          * Define a superclass Vehicle with attributes like MaxSpeed and Model.

          * Create an interface Refuelable with a method Refuel().

          * Define subclasses ElectricVehicle and PetrolVehicle. PetrolVehicle should implement Refuelable, while ElectricVehicle include a Charge() method.

        * Goal: Use hybrid inheritance by having PetrolVehicle implement both Vehicle and Refuelable, demonstrating how Java interfaces allow adding multiple behaviors.
        */
        
        // hybrid with class + interface
        
        ev e1 = new ev("Tesla X",250);
        pv p1 = new pv("Honda Civic",180);
        
        e1.sh();
        e1.ch(); // only electric can charge
        Console.WriteLine();
        p1.sh();
        p1.rf(); // only petrol can refuel
        
        // petrol vehicle gets both inheritance and interface behavior
        
        Console.WriteLine("vehicle hybrid finished");
    }
}

public class vh
{
    public string md; // model
    public int ms; // max speed
    
    public vh(string m , int s)
    {
        this.md = m;
        this.ms = s;
    }
    
    public virtual void sh()
    {
        Console.WriteLine("Model: " + md );
        Console.WriteLine("Max Speed: " + ms + " km/h");
    }
}

public interface rf
{
    void rf(); // refuel
}

public class ev : vh
{
    public ev(string m,int s) : base(m , s)
    {
    }
    
    public void ch()
    {
        Console.WriteLine(md + " is charging battery now");
        // electric specific
    }
    
    public override void sh()
    {
        base.sh();
        Console.WriteLine("Type: Electric Vehicle");
    }
}

public class pv : vh , rf
{
    public pv(string m,int s) : base(m,s)
    {
    }
    
    public void rf()
    {
        Console.WriteLine(md + " is refueling at petrol pump");
        // implements interface
    }
    
    public override void sh()
    {
        base.sh();
        Console.WriteLine("Type : Petrol Vehicle");
    }
}
