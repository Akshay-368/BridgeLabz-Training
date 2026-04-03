using System;

public static class prog
{
    public static void Main(string[] args)
    {
        /*
        Sample Problem 2: Smart Home Devices

        * Description: Create a hierarchy for a smart home system where Device is the superclass and Thermostat is a subclass.

        * Tasks:

          * Define a superclass Device with attributes like DeviceId and Status.

          * Create a subclass Thermostat with additional attributes like TemperatureSetting.

          * Implement a method DisplayStatus() to show each device's current settings.

        * Goal: Understand single inheritance by adding specific attributes to a subclass, keeping the superclass general.
        */
        
        // smart home devices inheritance
        
        dev d1 = new dev("D001","On");
        thr t1 = new thr("T101","Off",22);
        thr t2 = new thr("T102","On",18);
        
        d1.ds(); // basic device
        Console.WriteLine();
        t1.ds(); // thermostat extra info
        Console.WriteLine();
        t2.ds();
        
        // thermostat gets all from device plus own temp setting
        
        Console.WriteLine("smart home part finished");
    }
}

public class dev
{
    public string did; // device id
    public string st; // status
    
    public dev(string i , string s)
    {
        this.did = i;
        this.st = s;
    }
    
    public virtual void ds()
    {
        Console.WriteLine("Device ID   : " + did );
        Console.WriteLine("Status      : " + st );
    }
}

public class thr : dev
{
    public int ts; // temperature setting
    
    public thr(string i,string s,int temp) : base(i , s)
    {
        this.ts = temp;
    }
    
    public override void ds()
    {
        base.ds(); // first show common stuff
        Console.WriteLine("Type        : Thermostat");
        Console.WriteLine("Temperature : " + ts + " °C");
        // extra for thermostat
    }
}
