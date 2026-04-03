
// UC3: add part time

public class uc3
{
   public static void run()
   {
      Console.WriteLine ( " UC3: Add Part Time Employee & Wage " ) ;

      Random rnd = new Random();
      int typ = rnd.Next(3);   // 0 absent, 1 full, 2 part

      emp e = null;
      if(typ == 1)
      {
         e = new full();
         e.idi = 2;
         e.nme = "Ravi";
      }
      else if(typ == 2)
      {
         e = new part();
         e.idi = 3;
         e.nme = "Sita";
      }

      double wage = 0;
      if(e != null)
         wage = e.calw();   // polymorphism

      if(e != null)
      {
         Console.WriteLine(e.ToString());
         Console.WriteLine(" Wage: " + wage);
      }
      else
         Console.WriteLine("Employee Absent , No Wage");
   }
}

