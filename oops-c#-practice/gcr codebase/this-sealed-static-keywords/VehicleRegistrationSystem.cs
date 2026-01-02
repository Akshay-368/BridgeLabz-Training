using System;

public static class prog
{
    public static void Main()
    {
        /*
        Sample Program 6: Vehicle Registration System
        Create a Vehicle class with the following features:

        * static: 
          * A static variable RegistrationFee common for all vehicles.
          * A static method UpdateRegistrationFee() to modify the fee.

        * this: 
          * Use this to initialize OwnerName, VehicleType, and RegistrationNumber in the constructor.

        * readonly: 
          * Use a readonly variable RegistrationNumber to uniquely identify each vehicle.

        * is operator: 
          * Check if an object belongs to the Vehicle class before displaying its registration details.
        */
        
        veh.rf = 5000; // starting fee
        
        veh v1 = new veh("john","car","ABC123");
        veh v2 = new veh("sara","bike","XYZ987");
        
        Console.WriteLine("Current reg fee : " + veh.rf );
        
        object ob = v2;
        
        if(ob is veh )
        {
            veh vv = (veh)ob;
            vv.dsp(); // display only if its a vehicle
        }
        
        veh.ur(6000); // update fee now
        
        Console.WriteLine("New registration fee is " + veh.rf );
    }
}

public static class veh
{
    public static int rf; // reg fee same for all
    
    public readonly string rn; // registration number readonly
    public string on; // owner name
    public string tp; // type
    
    public veh(string o,string t,string r)
    {
        this.on = o;
        this.tp = t;
        this.rn = r; // set once here
    }
    
    public static void ur(int nf)
    {
        rf = nf;
        // why static method ? coz fee is common , no need object
    }
    
    public void dsp()
    {
        Console.WriteLine("Owner : " + this.on );
        Console.WriteLine("Type  : " + this.tp );
        Console.WriteLine("Reg no: " + this.rn );
        Console.WriteLine("Fee   : " + rf );
    }
}
