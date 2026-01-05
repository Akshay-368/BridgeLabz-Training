

// interface for GPS
public interface igps
{
   string getloc();
   void uploc(string newl);
}

// abstract Vehicle class
public abstract class veh
{
   private int id;          
   private string drv;      
   private double rate;     
   private string loc = "Unknown" ;   // current location

   // properties for encapsulation
   public int idi
   { 
      get { return id;}
      set { id = value;}
   }

   public string drnm
   { 
      get { return drv;}
      set { drv = value;}
   }

   public double rat
   { 
      get { return rate;}
      set { rate = value;}
   }

   protected string curloc
   {
      get { return loc;}
      set { loc = value;}
   }

   // abstract fare calc
   public abstract double calf(double dist);

   // concrete details
   public void getdet()
   {
      Console.WriteLine("Vehicle ID: "+id);
      Console.WriteLine("Driver: "+drv);
      Console.WriteLine("Rate per KM: "+rate);
      Console.WriteLine("Current Location: "+loc);
   }
}

// Car subclass
public class car : veh , igps
{
   public override double calf(double dist)
   {
      // base + little surge
      return rat * dist * 1.1;
   }

   public string getloc()
   {
      return curloc;
   }

   public void uploc(string newl)
   {
      curloc = newl;
   }
}

// Bike subclass
public class bike : veh , igps
{
   public override double calf(double dist)
   {
      // cheaper than car
      return rat * dist * 0.8;
   }

   public string getloc()
   {
      return curloc;
   }

   public void uploc(string newl)
   {
      curloc = newl;
   }
}

// Auto subclass
public class auto : veh , igps
{
   public override double calf(double dist)
   {
      return rat * dist;
   }

   public string getloc()
   {
      return curloc;
   }

   public void uploc(string newl)
   {
      curloc = newl;
   }
}

public class rideapp
{
   public static void Main(string[] args)
   {
      /*
      8. Ride-Hailing Application
      Description: Develop a ride-hailing application.
      Abstract Class:
      Define an abstract class Vehicle with fields: vehicleId, driverName, and ratePerKm.
      Add an abstract method CalculateFare(double distance).
      Implement a concrete method GetVehicleDetails().
      Subclasses:
      Extend Vehicle into Car, Bike, and Auto.
      Override CalculateFare() based on type-specific rates.
      Interface:
      Implement an interface IGPS.
      Define methods GetCurrentLocation() and UpdateLocation().
      Encapsulation:
      Secure driver and vehicle details using private fields and properties.
      Polymorphism:
      Create a method that processes multiple vehicle types dynamically.
      Calculate fares based on the Vehicle reference..
      */

      List<veh> vlist = new List<veh>();

      car c1 = new car();
      c1.idi = 1001;
      c1.drnm = "Rajesh";
      c1.rat = 15;
      c1.uploc("Downtown");

      bike b1 = new bike();
      b1.idi = 2001;
      b1.drnm = "Mohan";
      b1.rat = 8;
      b1.uploc("Market Area");

      auto a1 = new auto();
      a1.idi = 3001;
      a1.drnm = "Suresh";
      a1.rat = 12;
      a1.uploc("Railway Station");

      vlist.Add(c1);
      vlist.Add(b1);
      vlist.Add(a1);

      double dist = 12.5;   // ride distance in km

      Console.WriteLine("Ride Fares for "+dist+" km distance:\n");

      // polymorphism processing
      foreach(veh v in vlist)
      {
         v.getdet();

         double fare = v.calf(dist);   // correct fare
         Console.WriteLine("Calculated Fare: "+fare);

         if(v is igps)
         {
            igps gp = (igps)v;
            Console.WriteLine("GPS Location: "+gp.getloc());
         }


      }

      // waitng , for user to press somethng before exitng
      Console.WriteLine("Press any key to close ride-hailing app...");
      Console.ReadKey();
   }
}
