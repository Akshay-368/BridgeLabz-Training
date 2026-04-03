
// UC2: daily wage
public class uc2
{
   public static void run()
   {
      Console.WriteLine("UC2: Calculate Daily Employee Wage");

      // create full time emp instance
      full f = new full();
      f.idi = 1;
      f.nme = "Amit";

      // check attendance
      Random rnd = new Random();
      int att = rnd.Next(2);

      double wage = 0;
      if(att == 1)
         wage = f.calw();   // polymorphism if more types

      Console.WriteLine(f.ToString());   // overriden ToString
      Console.WriteLine("Daily Wage: " + wage);
   }
}

