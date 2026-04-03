using System;
using System.Collections.Generic;

//  interface for department stuff
public interface idep
{
   void asgn(string d);
   string getd();
}

//  abstract base class for all employees
public abstract class emp
{
   private int id;      
   private string nm;   
   private double bas;  

   //  properties to encapsulate fields , make it secure
   public int idi 
   { 
      get { return id; } 
      set { id = value; } 
   }

   public string nme
   { 
      get { return nm;} 
      set { nm = value;} 
   }

   public double basee
   { 
      get { return bas;} 
      set { bas = value;} 
   }

   //  abstract method that subclasses must implement
   public abstract double cals();

   //  concrete method to show details , used by all
   public void disp()
   {
      Console.WriteLine("ID: " + id);
      Console.WriteLine("Name: "+nm);
      Console.WriteLine("Base Salary: "+bas);
      Console.WriteLine("Final Salary: "+cals());
   }
}

//  full time employee , fixed salary usually
public class ft : emp , idep
{
   private string dept;

   public double cals()
   {
      //  full time just gets the base salary , no extra calc here
      return basee;
   }

   public void asgn(string d)
   {
      dept = d;   //  assigning department
   }

   public string getd()
   {
      return dept;
   }
}

//  part time employee , salary based on hours worked
public class pt : emp , idep
{
   private int hrs;     
   private double rate; 

   public int hrss
   { 
      get { return hrs;} 
      set { hrs = value;} 
   }

   public double rat
   { 
      get { return rate;} 
      set { rate = value;} 
   }

   public double cals()
   {
      //  part time salary = hours * rate , simple calc
      return hrs * rate;
   }

   private string dept = "";

   public void asgn(string d)
   {
      dept = d;
   }

   public string getd()
   {
      return dept;
   }
}

public class prog
{
   public static void Main(string[] args)
   {
      /*
      The current question is:

      1. Employee Management System
      Description: Build an employee management system with the following requirements:

      * Use an abstract class Employee with fields like employeeId, name, and baseSalary.

      * Provide an abstract method CalculateSalary() and a concrete method DisplayDetails().

      * Create two subclasses: FullTimeEmployee and PartTimeEmployee, implementing CalculateSalary() based on work hours or fixed salary.

      * Use encapsulation to restrict direct access to fields and provide properties for access.

      * Create an interface IDepartment with methods like AssignDepartment() and GetDepartmentDetails().

      * Ensure polymorphism by processing a list of employees and displaying their details using the Employee reference.

      No additional hints were given.
      */

      List<emp> elst = new List<emp>();   //  list to hold employees , for polymorphism

      //  creating a full time employee
      ft f1 = new ft();
      f1.idi = 101;
      f1.nme = "Amit";
      f1.basee = 50000;
      f1.asgn("IT");

      //  creating part time employees
      pt p1 = new pt();
      p1.idi = 201;
      p1.nme = "Ravi";
      p1.basee = 0;       //  base not used really
      p1.hrss = 120;
      p1.rat = 400;
      p1.asgn("HR");

      pt p2 = new pt();
      p2.idi = 202;
      p2.nme = "Neha";
      p2.basee = 0;
      p2.hrss = 80;
      p2.rat = 450;
      p2.asgn("Sales");

      //  adding them to list
      elst.Add(f1);
      elst.Add(p1);
      elst.Add(p2);

      Console.WriteLine("Employee Details using polymorphism:\n");

      //  looping through list with base class reference , polymorphism in action
      foreach (emp e in elst)
      {
         e.disp();      //  calls correct cals() automatically

         //  also printing department using interface ref
         if (e is idep)
         {
            idep idp = (idep)e;
            Console.WriteLine("Department: " + idp.getd());
         }

         Console.WriteLine();   //  empty line for better readng
      }

      //  waitng for user to press somethng before closng
      Console.WriteLine("Press any key to exit the program...");
      Console.ReadKey();
   }
}
