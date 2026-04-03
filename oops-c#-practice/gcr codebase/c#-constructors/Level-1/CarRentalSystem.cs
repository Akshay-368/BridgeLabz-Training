using System;

public class carrent
{
    string cust;
    string model;
    int days;
    double costperday = 2000.0 ; // fixed rate
    
    public carrent(string c , string m , int d)
    {
        cust = c;
        model = m;
        days = d;
    }
    
    public double totalcost()
    {
        return days * costperday;
    }
    
    public void receipt()
    {
        Console.WriteLine(" Car Rental Receipt : ");
        Console.WriteLine("Customer : " + cust);
        Console.WriteLine("Car Model : " + model);
        Console.WriteLine("Days     : " + days);
        Console.WriteLine("Rate/day : " + costperday);
        Console.WriteLine("Total    : " + totalcost());

    }
    
    public static void Main(string[] args)
    {
        /*
        6. Car Rental System
           * Create a CarRental class with attributes customerName, carModel, and rentalDays.
           * Add constructors to initialize the rental details and calculate total cost.
        */
        
        Console.WriteLine ( "enter customer name");
        string name = Console.ReadLine();
        
        Console.WriteLine ( " enter car model");
        string car = Console.ReadLine();
        
        Console.WriteLine ("enter number of days");
        int d = int.Parse(Console.ReadLine());
        
        carrent rental = new carrent(name , car , d);
        
        Console.WriteLine() ;
        rental.receipt();
        
        Console.WriteLine (" thank you, press enter to exit");
        Console.ReadLine();
    }
}
