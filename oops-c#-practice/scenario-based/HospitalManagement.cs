using System;
using System.Collections.Generic;



// interface for anything that can be paid
public interface ipay
{
   double calb();
   string getbd();
}

// abstract base class wait no , Patient is base
public abstract class pat
{
   private int id;      
   private string nm ;   
   private int age;     

   public int idi 
   { 
      get { return id ;} 
      set { id = value ; } 
   }

   public string nme
   { 
      get { return nm ;}
      set { nm = value ;}
   }

   public int ag
   { 
      get { return age ;} 
      set { age = value ;} 
   }

   // this will be overridden for polymorphism
   public abstract void disp() ;
}

// in patient stays in hospital
public class inp : pat , ipay
{
   private int days;    
   private double rpd = 2000 ;  // rate per day

   public int dys
   { 
      get { return days ;} 
      set { days = value; } 
   }

   public override void disp()
   {
      Console.WriteLine("Patient Type : In-Patient") ;
      Console.WriteLine("ID: " + idi);
      Console.WriteLine("Name : "+nme );
      Console.WriteLine("Age : "+ag);
      Console.WriteLine("Days Admitted:  "+ days);
   }

   public double calb()
   {
      return days * rpd;
   }

   public string getbd()
   {
      return "Room charges + treatment " ;
   }
}

// out patient just visits
public class outp : pat , ipay
{
   private double consf = 800;  // consultation fee fixed

   public override void disp()
   {
      Console.WriteLine("Patient Type: Out-Patient");
      Console.WriteLine("ID: "+idi);
      Console.WriteLine("Name : "+ nme);
      Console.WriteLine("Age: "+ ag);
   }

   public double calb()
   {
      return consf;
   }

   public string getbd()
   {
      return "Consultation fee only " ;
   }
}

public class hosp
{
   public static void Main(string[] args)
   {
      /*
      Hospital Patient Management System
      ● Concepts: Patient, Doctor, Bill classes.
      ● OOP: Encapsulation (Properties), Abstraction (Interface IPayable), Inheritance
      (InPatient, OutPatient : Patient), Polymorphism (DisplayInfo).

      Note: Doctor class not fully needed for demo, so focused on Patient and billing.
      No hints given.
      */

      List<pat> plist = new List<pat>();

      inp i1 = new inp();
      i1.idi = 501;
      i1.nme = "Rajesh";
      i1.ag = 45;
      i1.dys = 5;

      outp o1 = new outp();
      o1.idi = 602;
      o1.nme = "Priya";
      o1.ag = 28;

      inp i2 = new inp();
      i2.idi = 503;
      i2.nme = "Anil";
      i2.ag = 60;
      i2.dys = 10;

      plist.Add(i1);
      plist.Add(o1);
      plist.Add(i2);

      Console.WriteLine( " Hospital Patients Info and Bills : \n ");

      foreach (pat p in plist)
      {
         p.disp();         // polymorphism here , correct disp called

         if (p is ipay)
         {
            ipay py = (ipay)p;
            Console.WriteLine("Bill Details: "+py.getbd());
            Console.WriteLine("Total Bill: "+py.calb());
         }

         Console.WriteLine("                              ");
      }

      // waitng for user to hit key before closng
      Console.WriteLine("Press any key to exit hospital system...");
      Console.ReadKey();
   }
}

