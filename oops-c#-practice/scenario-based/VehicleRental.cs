

// interface for rent
public interface irent
{
   double calr(int d);
}

// base class vehicle with protected fields
public class veh
{
   protected int id;       
   protected string md;    
   protected double bpr;   // base price per day

   public int idi
   { 
      get { return id ;} 
      set { id = value; } 
   }

   public string mdl
   { 
      get { return md ;} 
      set { md = value ;} 
   }

   public double basep
   { 
      get { return bpr;} 
      set { bpr = value;} 
   }

   public void prnt()
   {
      Console.WriteLine("Vehicle ID: "+id);
      Console.WriteLine("Model : "+md);
      Console.WriteLine("Base Rate per Day: "+bpr);
   }
}

// bike class
public class bike : veh , irent
{
   public double calr(int d)
   {
      // bike rent little less
      return bpr * d * 0.9;
   }
}

// car class
public class car : veh , irent
{
   public double calr(int d)
   {
      return bpr * d;
   }
}

// truck class higher rate
public class truck : veh , irent
{
   public double calr(int d )
   {
      // truck costs more
      return bpr * d * 1.5 ;
   }
}

public class rentapp
{
   public static void Main(string[] args)
   {
      /*
      Vehicle Rental Application
      ● Concepts: Vehicle, Bike, Car, Truck, Customer.
      ● Access Modifiers: protected fields.
      ● Interface: IRentable with CalculateRent(int days).

      Note: Customer class not shown in demo but concept clear.
      No extra hints.
      */

      List<veh> vlist = new List<veh>();

      bike b1 = new bike();
      b1.idi = 901 ;
      b1.mdl = "Hero Splendor";
      b1.basep = 300;

      car c1 = new car();
      c1.idi = 1001;
      c1.mdl = "Swift" ;
      c1.basep = 1500;

      truck t1 = new truck ();
      t1.idi = 1101;
      t1.mdl = "Tata Ace";
      t1.basep = 2000;

      vlist.Add(b1);
      vlist.Add(c1);
      vlist.Add(t1);

      int daysrent = 4 ;   // assuming same days for all in demo

      Console.WriteLine("Vehicle Rental for "+daysrent+" days:\n");

      foreach (veh v in vlist)
      {
         v.prnt();

         if (v is irent)
         {
            irent r = (irent)v;
            double total = r.calr(daysrent);
            Console.WriteLine("Total Rent: "+total);
         }

         Console.WriteLine("                      ");
      }

      // waitng for user to press somethng before exitng
      Console.WriteLine("Press any key to close rental app...");
      Console.ReadKey();
   }
}
