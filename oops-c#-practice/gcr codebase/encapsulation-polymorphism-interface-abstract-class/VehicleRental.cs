using System;
using System.Collections.Generic;



// interface for insurance stuff
public interface iins
{
   double cali();
   string getid();
}

// abstract base class for vehicles
public abstract class veh
{
   private string num;     
   private string typ;     
   private double rate;    

   // encapsulation with properties , cant access direct
   public string vnum
   { 
      get { return num; }
      set { num = value;}
   }

   public string typp
   { 
      get { return typ;}
      set { typ = value;}
   }

   public double rat
   { 
      get { return rate;}
      set { rate = value;}
   }

   // abstract rental calc
   public abstract double calrc(int dys);

   // common print method
   public void prnt()
   {
      Console.WriteLine("Vehicle Num: "+num);
      Console.WriteLine("Type: "+typ);
      Console.WriteLine("Rental Rate per day: "+rate);
   }
}

// car subclass
public class car : veh , iins
{
   private string pol = "CAR123";  // sensitive policy num , private

   public override double calrc(int dys)
   {
      // car rental normal rate
      return rat * dys;
   }

   public double cali()
   {
      // car insurance 5% of rental
      return (rat * 30) * 0.05;  // assuming max 30 days kinda
   }

   public string getid()
   {
      return "Car Insurance - Policy: "+pol;
   }
}

// bike subclass
public class bike : veh , iins
{
   private string pol = "BIKE456";

   public override double calrc(int dys)
   {
      // bike cheaper , 80% rate
      return rat * dys * 0.8;
   }

   public double cali()
   {
      return (rat * 30) * 0.03;   // lower insurance
   }

   public string getid()
   {
      return "Bike Insurance - Policy: "+pol;
   }
}

// truck subclass
public class trk : veh , iins
{
   private string pol = "TRK789";

   public override double calrc(int dys)
   {
      // truck higher , 120% rate
      return rat * dys * 1.2;
   }

   public double cali()
   {
      return (rat * 30) * 0.08;   // high insurance
   }

   public string getid()
   {
      return "Truck Insurance - Policy: "+pol;
   }
}

public class vrent
{
   public static void Main(string[] args)
   {
      /*
      3. Vehicle Rental System
      Description: Design a system to manage vehicle rentals:
      Define an abstract class Vehicle with fields like vehicleNumber, type, and rentalRate.
      Add an abstract method CalculateRentalCost(int days).
      Create subclasses Car, Bike, and Truck with specific implementations of CalculateRentalCost().
      Use an interface IInsurable with methods CalculateInsurance() and GetInsuranceDetails().
      Apply encapsulation to restrict access to sensitive details like insurance policy numbers.
      Demonstrate polymorphism by iterating over a list of vehicles and calculating rental and insurance costs for each.


      */

      List<veh> vlist = new List<veh>();   // for poly

      car c1 = new car();
      c1.vnum = "MH04AB1234";
      c1.typp = "Sedan";
      c1.rat = 2500;

      bike b1 = new bike();
      b1.vnum = "DL8BX9999";
      b1.typp = "Sports Bike";
      b1.rat = 800;

      trk t1 = new trk();
      t1.vnum = "GJ12TR5678";
      t1.typp = "Heavy Truck";
      t1.rat = 5000;

      vlist.Add(c1); vlist.Add(b1); vlist.Add(t1);

      int days = 7;   // rentng for 7 days

      Console.WriteLine(" Vehicle Rental Costs for "+ days + " days:\n");

      // poly loop with base ref
      foreach(veh v in vlist)
      {
         v.prnt();

         double rentc = v.calrc(days);   // correct calc called
         Console.WriteLine(" Rental Cost : "+ rentc ) ;

         // insurance via interface
         if(v is iins)
         {
            iins ii = (iins)v;
            double ins = ii.cali();
            Console.WriteLine(ii.getid());
            Console.WriteLine(" Insurance Cost : "+ins);

            double total = rentc + ins;
            Console.WriteLine("Grand Total: "+total);
         }


      }

      // waiting , for user to enter the inupt to close
      Console.WriteLine("Press any keyy to exit rental systm...");
      Console.ReadKey();
   }
}

