using System;
using System.Collections.Generic;

// interface for discount stuff
public interface idisc
{
   double appd(double tot);
   string getdd();
}

// abstract base class for food items
public abstract class food
{
   private string nam;     
   private double pr;      
   private int qty;        

   // encapsulation , properties only
   public string itnm
   { 
      get { return nam;}
      set { nam = value;}
   }

   public double price
   { 
      get { return pr;}
      set { pr = value;}
   }

   public int qnt
   { 
      get { return qty;}
      set { qty = value;}
   }

   // abstract total price calc
   public abstract double caltp();

   // concrete method to print details
   public void getdet()
   {
      Console.WriteLine("Item Name: "+nam);
      Console.WriteLine("Price per unit : "+pr);
      Console.WriteLine("Quantity: "+qty);
   }
}

// veg item subclass
public class veg : food , idisc
{
   public override double caltp()
   {
      // veg items have 5% service charge extra
      double basee = price * qnt;
      return basee + (basee * 0.05);
   }

   public double appd(double tot)
   {
      // veg gets 10% discount on total
      return tot * 0.10;
   }

   public string getdd()
   {
      return "10% Discount on Veg Items";
   }
}

// non veg item subclass
public class nveg : food , idisc
{
   public override double caltp()
   {
      // non veg has higher 12% extra charge
      double basee = price * qnt;
      return basee + (basee * 0.12);
   }

   public double appd(double tot)
   {
      // non veg gets 5% discount only
      return tot * 0.05;
   }

   public string getdd()
   {
      return "5% Discount on Non-Veg Items";
   }
}

public class foodapp
{
   public static void Main(string[] args)
   {
      /*
      6. Online Food Delivery System
      Description: Create an online food delivery system:
      Define an abstract class FoodItem with fields like itemName, price, and quantity.
      Add abstract methods CalculateTotalPrice() and concrete methods like GetItemDetails().
      Extend it into classes VegItem and NonVegItem, overriding CalculateTotalPrice() to include additional charges.
      Use an interface IDiscountable with methods ApplyDiscount() and GetDiscountDetails().
      Use polymorphism to handle different types of food items dynamically.

      */

      List<food> order = new List<food>();   // polymorphism list

      // creating some food items
      veg v1 = new veg();
      v1.itnm = "Paneer Butter Masala " ;
      v1.price = 250;
      v1.qnt = 2;

      nveg nv1 = new nveg();
      nv1.itnm = "Chicken Tikka";
      nv1.price = 350;
      nv1.qnt = 1;

      veg v2 = new veg();
      v2.itnm = "Veg Biryani";
      v2.price = 180;
      v2.qnt = 3;

      nveg nv2 = new nveg();
      nv2.itnm = "Mutton Curry";
      nv2.price = 450;
      nv2.qnt = 1;

      // adding to order
      order.Add(v1 );
      order.Add(nv1 );
      order.Add(v2 );
      order.Add(nv2) ;

      Console.WriteLine("Your Food Order Details : \n");

      double grandtot = 0;

      // processing with base class reference , polymorphism
      foreach(food f in order)
      {
         f.getdet() ;

         double subtot = f.caltp() ;    // correct total with charges
         Console.WriteLine("Sub Total (with charges): " + subtot) ;

         // discount via interface
         if(f is idisc)
         {
            idisc ds = (idisc)f;
            double discamt = ds.appd(subtot);
            Console.WriteLine(ds.getdd());
            Console.WriteLine("Discount Amount : " + discamt);

            subtot -= discamt;
         }

         Console.WriteLine(" Final for this item : " + subtot ) ;
         grandtot += subtot ;


      }

      Console.WriteLine("Grand Total Payable: "+grandtot);

      // waitng , for user to enter the inupt before closng app
      Console.WriteLine("Press any key to exit food delivery app...");
      Console.ReadKey();
   }
}
