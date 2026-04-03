using System;

public class veh
{
    string owner;
    string type;
    
    static double regfee = 5000.00 ; // class variable, same for all vehicles
    
    public veh (string o, string t)
    {
        owner = o;
        type = t;
    }
    
    public void dispveh()
    {
        // instance method to print vehicle details
        Console.WriteLine("Owner Name: " + owner);
        Console.WriteLine("Vehicle Type : " + type);
        Console.WriteLine("Registration Fee  : " + regfee);
    }
    
    public static void upreg(double newfee)
    {
        // class method to update fee for all
        regfee = newfee;
        Console.WriteLine(" Registration fee updated to: " + regfee);
    }
    
    public static void Main()
    {
        /*
        Problem 3: Vehicle Registration

        * Create a Vehicle class to manage vehicle details:

          * Instance Variables: ownerName, vehicleType.

          * Class Variable: registrationFee (fixed for all vehicles).

        * Implement the following methods:

          * An instance method DisplayVehicleDetails() to display owner and vehicle details.

          * A class method UpdateRegistrationFee() to change the registration fee.
        */
        
        veh v1 = new veh("Rahul Sharma", "Car");
        veh v2 = new veh("Priya Singh", "Bike");
        
        Console.WriteLine("vehicles with old fee");
        Console.WriteLine();
        v1.dispveh();
        Console.WriteLine();
        v2.dispveh();
        Console.WriteLine();
        
        veh.upreg(7500.00);
        Console.WriteLine();
        
        Console.WriteLine("vehicles after fee update");
        Console.WriteLine();
        v1.dispveh();
        Console.WriteLine();
        v2.dispveh();
        
        Console.WriteLine("all done, hit enter to close...");
        Console.ReadLine();
    }
}
