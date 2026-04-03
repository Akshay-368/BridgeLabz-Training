using System;
using System.Collections.Generic;



// interface for medical records
public interface imed
{
   void addr(string rec);
   string viewr();
}

// abstract class Patient
public abstract class pat
{
   private int id;         
   private string nm;      
   private int ag;         
   private string diag = "";      // sensitive , private
   private List<string> hist = new List<string>();  // medical history , protected access

   // encapsulation properties
   public int idi
   { 
      get { return id;}
      set { id = value;}
   }

   public string nme
   { 
      get { return nm;}
      set { nm = value;}
   }

   public int agee
   { 
      get { return ag;}
      set { ag = value;}
   }

   protected string dgn
   {
      get { return diag;}
      set { diag = value;}
   }

   protected List<string> hlist
   {
      get { return hist;}
   }

   // abstract bill calc
   public abstract double calb();

   // concrete details method
   public void getdet()
   {
      Console.WriteLine("Patient ID: "+id);
      Console.WriteLine("Name : "+nm);
      Console.WriteLine("Age: "+ag);
      if(diag != "")
         Console.WriteLine("Diagnosis: "+diag);   // only show if set
   }
}

// InPatient subclass
public class inp : pat , imed
{
   private int days;     
   private double rpd = 2500;   // room charge per day

   public int dys
   { 
      get { return days;}
      set { days = value;}
   }

   public override double calb()
   {
      // bill = room charge + some treatment
      return days * rpd + 5000;   // flat treatment fee
   }

   public void addr(string rec)
   {
      hlist.Add(rec);
      dgn = rec;    // last record as diagnosis kinda
   }

   public string viewr()
   {
      string all = "";
      foreach(string r in hlist)
         all += r + "\n";
      return all;
   }
}

// OutPatient subclass
public class outp : pat , imed
{
   private double consf = 1200;   // consultation

   public override double calb()
   {
      return consf + 800;   // meds extra
   }

   public void addr(string rec)
   {
      hlist.Add(rec);
      dgn = rec;
   }

   public string viewr()
   {
      string all = "";
      foreach(string r in hlist)
         all += r + "\n";
      return all;
   }
}

public class hospman
{
   public static void Main(string[] args)
   {
      /*
      7. Hospital Patient Management
      Description: Design a system to manage patients in a hospital.
      Abstract Class:
      Create an abstract class Patient with fields: patientId, name, and age.
      Add an abstract method CalculateBill().
      Implement a concrete method GetPatientDetails().
      Subclasses:
      Extend Patient into InPatient and OutPatient.
      Implement CalculateBill() differently for each subclass.
      Interface:
      Implement an interface IMedicalRecord.
      Define methods AddRecord() and ViewRecords().
      Encapsulation:
      Protect sensitive patient data like diagnosis and medical history.
      Polymorphism:
      Use a Patient reference to handle different patient types dynamically.
      Display billing details based on polymorphic behavior.
    */

      List<pat> plist = new List<pat>();

      inp i1 = new inp();
      i1.idi = 701;
      i1.nme = "Sunita";
      i1.agee = 38;
      i1.dys = 4;
      i1.addr("Fever and cough - admitted");

      outp o1 = new outp();
      o1.idi = 802;
      o1.nme = "Arjun";
      o1.agee = 25;
      o1.addr("Sprained ankle checkup");

      inp i2 = new inp();
      i2.idi = 703;
      i2.nme = "Vijay";
      i2.agee = 55;
      i2.dys = 7;
      i2.addr("Heart issue - ICU");

      plist.Add(i1);
      plist.Add(o1);
      plist.Add(i2);

      Console.WriteLine("Hospital Patients and Bills :\n");

      // polymorphism using base ref
      foreach(pat p in plist)
      {
         p.getdet();

         double bill = p.calb();     // correct bill calculated
         Console.WriteLine("Total Bill: "+bill);

         if(p is imed)
         {
            imed mr = (imed)p;
            Console.WriteLine("Medical Records:\n"+mr.viewr());
         }

      }

      // waitng , for user to enter the inupt key
      Console.WriteLine(" Press any key to exit hospital managemnt...");
      Console.ReadKey();
   }
}

