
// UC4: switch case

public class uc4
{
   public static void run()
   {
      Console.WriteLine ( " UC4 : Using Switch Case" ) ;

      Random rnd = new Random();
      int typ = rnd.Next(3);   // 0 absent, 1 full, 2 part

      emp e = null;
      double wage = 0;

      switch(typ)
      {
         case 1:
            e = new full();
            e.idi = 4;
            e.nme = "Vikram";
            wage = e.calw();
            break;
         case 2:
            e = new part();
            e.idi = 5;
            e.nme = "Lata";
            wage = e.calw();
            break;
         default:
            Console.WriteLine("Absent");
            break;
      }

      if(e != null)
      {
         Console.WriteLine(e);   // ToString implicit
         Console.WriteLine("Wage: " + wage);
      }
   }
}

