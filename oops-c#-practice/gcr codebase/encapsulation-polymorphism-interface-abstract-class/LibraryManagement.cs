using System;
using System.Collections.Generic;

// interface for reservation stuff
public interface ires
{
   bool resv(string pers);
   bool chka();
}

// abstract base class for all library items
public abstract class libit
{
   private int id;        
   private string tit;    
   private string aut;    
   private bool avail = true ;   
   private string borr = "" ;    // borrower name , sensitive so private

   // encapsulation with properties
   public int idi
   { 
      get { return id ;}
      set { id = value ;}
   }

   public string title
   { 
      get { return tit ;}
      set { tit = value ;}
   }

   public string auth
   { 
      get { return aut ;}
      set { aut = value ;}
   }

   // internal access for subclasses and interface
   protected bool av
   {
      get { return avail;}
      set { avail = value;}
   }

   protected string bor
   {
      get { return borr;}
      set { borr = value;}
   }

   // abstract loan duration
   public abstract int getld() ;

   // concrete method for details
   public void getdet()
   {
      Console.WriteLine("Item ID : "+id);
      Console.WriteLine("Title : "+tit);
      Console.WriteLine("Author: "+aut);
      Console.WriteLine("Available : "+avail);
      if(!avail)
         Console.WriteLine("Borrowed by : " +borr);   // only show if borrowed , secure
   }
}

// book subclass
public class book : libit , ires
{
   public override int getld()
   {
      // books can be loaned for 14 days
      return 14 ;
   }

   public bool resv(string pers)
   {
      if(av)
      {
         av = false ;
         bor = pers ;
         return true ;
      }
      return false ;
   }

   public bool chka ()
   {
      return av;
   }
}

// magazine subclass
public class mag : libit , ires
{
   public override int getld ()
   {
      // magazines only 7 days
      return 7;
   }

   public bool resv(string pers)
   {
      if(av)
      {
         av = false ;
         bor = pers ;
         return true;
      }
      return false;
   }

   public bool chka ()
   {
      return av;
   }
}

// dvd subclass
public class dvd : libit , ires
{
   public override int getld ()
   {
      // dvds for 3 days only
      return 3;
   }

   public bool resv(string pers )
   {
      if(av)
      {
         av = false ;
         bor = pers ;
         return true ;
      }
      return false;
   }

   public bool chka()
   {
      return av ;
   }
}

public class libsys
{
   public static void Main(string[] args)
   {
      /*
      5. Library Management System
      Description: Develop a library management system:
      Use an abstract class LibraryItem with fields like itemId, title, and author.
      Add an abstract method GetLoanDuration() and a concrete method GetItemDetails().
      Create subclasses Book, Magazine, and DVD, overriding GetLoanDuration() with specific logic.
      Implement an interface IReservable with methods ReserveItem() and CheckAvailability().
      Apply encapsulation to secure details like the borrower’s personal data.
      Use polymorphism to allow a general LibraryItem reference to manage all items.

      */

      List<libit> items = new List<libit>() ;   // polymorphism list

      // creating some items
      book b1 = new book();
      b1.idi = 1001 ;
      b1.title = "C# Programming";
      b1.auth = "John Sharp" ;

      mag m1 = new mag();
      m1.idi = 2001;
      m1.title = "Tech Today";
      m1.auth = "Various";

      dvd d1 = new dvd();
      d1.idi = 3001;
      d1.title = "Inception";
      d1.auth = "Christopher Nolan";

      book b2 = new book();
      b2.idi = 1002;
      b2.title = "Data Structures";
      b2.auth = "Mark Allen";

      // add to list
      items.Add(b1);
      items.Add(m1);
      items.Add(d1);
      items.Add(b2);

      // demo reservation on some
      if(b1 is ires)
      {
         ires r1 = (ires)b1;
         r1.resv("Ramesh Kumar");
      }

      if(d1 is ires)
      {
         ires r3 = (ires)d1;
         r3.resv("Sita Devi");
      }

      Console.WriteLine("Library Items Details and Loan Info : \n");

      // polymorphism in action
      foreach(libit it in items)
      {
         it.getdet();      // common details

         Console.WriteLine("Loan Duration ( days ) : "+it.getld());   // correct duration called

         // availability via interface
         if(it is ires)
         {
            ires rs = (ires)it;
            if(rs.chka())
               Console.WriteLine("Status: Available for reservation");
            else
               Console.WriteLine("Status: Reserved / Borrowed");
         }


      }

      // waitng , for user to enter the inupt key before closng
      Console.WriteLine("Press any key to exit library managemnt systm..." ) ;
      Console.ReadKey();
   }
}
