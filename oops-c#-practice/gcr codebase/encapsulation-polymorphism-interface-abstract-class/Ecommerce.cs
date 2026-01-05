using System;
using System.Collections.Generic;

// interface for products that have tax
public interface itax
{
   double calt();
   string gettd();
}

// abstract class for all products
public abstract class prod
{
   private int id;     
   private string nm;  
   private double pr;  

   // properties for encapsulation , secure access
   public int idi
   {
      get { return id;}
      set { id = value;}
   }

   public string nme
   { 
      get { return nm; }
      set { nm = value; }
   }

   public double pri
   { 
      get { return pr;}
      set { pr = value; }
   }

   // abstract discount method
   public abstract double cald();

   // common method to print basic info
   public void prntb()
   {
      Console.WriteLine("Product ID: " + id);
      Console.WriteLine("Name : "+nm);
      Console.WriteLine("Price: "+pr);
   }
}

// electronics class
public class elec : prod , itax
{
   public double cald()
   {
      // electronics get 10% discount
      return pri * 0.10;
   }

   public double calt()
   {
      // 18% tax for electronics
      return pri * 0.18;
   }

   public string gettd()
   {
      return "Tax: 18% GST";
   }
}

// clothing class
public class cloth : prod , itax
{
   public double cald()
   {
      // clothing 5% discount
      return pri * 0.05;
   }

   public double calt()
   {
      // 5% tax on clothing
      return pri * 0.05;
   }

   public string gettd()
   {
      return "Tax: 5% GST";
   }
}

// groceries no tax
public class groc : prod
{
   public double cald()
   {
      // groceries get 20% discount sometimes
      return pri * 0.20;
   }

   // no need to implement itax , only elec and cloth have tax
}

public class shop
{
   public static void Main(string[] args)
   {
      /*


      2. E-Commerce Platform
      Description: Develop a simplified e-commerce platform:

      * Create an abstract class Product with fields like productId, name, and price, and an abstract method CalculateDiscount().

      * Extend it into concrete classes: Electronics, Clothing, and Groceries.

      * Implement an interface ITaxable with methods CalculateTax() and GetTaxDetails() for applicable product categories.

      * Use encapsulation to protect product details, allowing updates only through setter methods.

      Showcase polymorphism by creating a method that calculates and prints the final price (price + tax - discount) for a list of products.

      No extra hints given.
      */

      List<prod> cart = new List<prod>();   // list for polymorphism

      // creating some products manually

      elec e1 = new elec();
      e1.idi = 1001;
      e1.nme = "Laptop";
      e1.pri = 80000;

      cloth c1 = new cloth();
      c1.idi = 2001;
      c1.nme = "T-Shirt";
      c1.pri = 1200;

      groc g1 = new groc();
      g1.idi = 3001;
      g1.nme = "Rice Bag";
      g1.pri = 2500;

      elec e2 = new elec();
      e2.idi = 1002;
      e2.nme = "Phone";
      e2.pri = 35000;

      // adding to cart list
      cart.Add(e1);
      cart.Add(c1);
      cart.Add(g1);
      cart.Add(e2);

      Console.WriteLine("E-Commerce Cart Final Prices:\n");

      // polymorphism here , using base class ref
      foreach (prod p in cart)
      {
         p.prntb();

         double disc = p.cald();     // correct discount called
         Console.WriteLine("Discount: "+disc);

         double taxx = 0;
         string taxinfo = "No Tax";

         // check if product has tax using interface
         if (p is itax)
         {
            itax tx = (itax)p;
            taxx = tx.calt();
            taxinfo = tx.gettd();
         }

         Console.WriteLine(taxinfo);
         Console.WriteLine("Tax Amount: "+taxx);

         // final price calc
         double finalp = p.pri - disc + taxx;

         Console.WriteLine("Final Price: "+finalp);
         Console.WriteLine("                        ");   // separator for readng
      }

      // waitng for user to press key before exitng
      Console.WriteLine("Press any key to close the shop...");
      Console.ReadKey();
   }
}
