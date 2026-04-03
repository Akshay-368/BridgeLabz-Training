using System;
using System.Collections.Generic;

// interface for flying birds
public interface ifly
{
   void fly();
}

// interface for swimming birds
public interface iswim
{
   void swim();
}

// base class for all birds
public abstract class bird
{
   private int id;         
   private string nam;     
   private string spec;    

   // encapsulation with properties
   public int idi
   { 
      get { return id;}
      set { id = value;}
   }

   public string nme
   { 
      get { return nam;}
      set { nam = value;}
   }

   public string species
   { 
      get { return spec;}
      set { spec = value;}
   }

   // common method to show details
   public void dets()
   {
      Console.WriteLine("Bird ID:  " + id);
      Console.WriteLine("Name : " + nam);
      Console.WriteLine("Species : "+  spec);
   }
}

// Eagle - only flies
public class eagle : bird , ifly
{
   public void fly()
   {
      Console.WriteLine(nme + " the Eagle is soaring high in the sky!" ) ;
   }
}

// Sparrow - only flies
public class spar : bird , ifly
{
   public void fly()
   {
      Console.WriteLine(nme + " the Sparrow is flying quickly between trees.");
   }
}

// Duck - swims and flies? but here only swim as per requirement
public class duck : bird , iswim
{
   public void swim()
   {
      Console.WriteLine(nme + " the Duck is swimming gracefully on the lake.");
   }
}

// Penguin - swims only
public class peng : bird , iswim
{
   public void swim()
   {
      Console.WriteLine(nme + " the Penguin is swimming fast underwater!");
   }
}

// Seagull - both fly and swim
public class gull : bird , ifly , iswim
{
   public void fly()
   {
      Console.WriteLine(nme + " the Seagull is flying over the ocean waves." ) ;
   }

   public void swim()
   {
      Console.WriteLine(nme + " the Seagull is floating and swimming on water.");
   }
}

public class sanct
{
   public static void Main ()
   {
      /*
      Goal: Design a Bird Sanctuary system using Inheritance and Polymorphism.
      Scenario: EcoWing Wildlife Conservation Center needs to track birds.
      ● Attributes: defined in base class Bird.
      ● Interfaces: IFlyable (method Fly()), ISwimmable (method Swim()).
      ● Derived Classes: Eagle, Sparrow (implement IFlyable), Duck, Penguin (implement ISwimmable), Seagull (implements both).
      ● Use Array Concept
      ● Polymorphism: Iterate through list, check interface type (is IFlyable), and call methods.
      */

      // using List as array concept , better than fixed array
      List<bird> birds = new List<bird>();

      eagle e1 = new eagle();
      e1.idi = 101;
      e1.nme = "Thunder";
      e1.species = "Bald Eagle";

      spar s1 = new spar();
      s1.idi = 201;
      s1.nme = "Chirpy";
      s1.species = "House Sparrow";

      duck d1 = new duck();
      d1.idi = 301;
      d1.nme = "Quacky";
      d1.species = "Mallard";

      peng p1 = new peng();
      p1.idi = 401;
      p1.nme = "Tux";
      p1.species = "Emperor Penguin";

      gull g1 = new gull();
      g1.idi = 501;
      g1.nme = "Skydiver";
      g1.species = "Herring Gull";

      eagle e2 = new eagle();
      e2.idi = 102;
      e2.nme = "Storm";
      e2.species = "Golden Eagle";

      // adding all to list
      birds.Add(e1);
      birds.Add(s1);
      birds.Add(d1);
      birds.Add(p1);
      birds.Add(g1);
      birds.Add(e2);

      Console.WriteLine("EcoWing Bird Sanctuary - All Birds Info and Abilities:\n");

      // polymorphism - using base class reference
      foreach(bird b in birds)
      {
         b.dets();

         // check and call fly if possible
         if(b is ifly)
         {
            ifly fl = (ifly)b;
            fl.fly();
         }

         // check and call swim if possible
         if(b is iswim)
         {
            iswim sw = (iswim)b;
            sw.swim();
         }

      }

      // waitng , for user to enter the inupt before closng
      Console.WriteLine("Press any key to exit bird sanctuary system...");
      Console.ReadKey();
   }
}
