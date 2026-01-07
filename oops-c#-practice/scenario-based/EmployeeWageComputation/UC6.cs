
// UC6: till condition

public class uc6
{
   public static void run()
   {
      Console.WriteLine ( " UC 6 : Wages till Condition");

      List<emp> emps = new List<emp>();   // collection

      int maxd = 20;
      int maxh = 100;
      int curd = 0;
      int curh = 0;
      double totw = 0;

      while(curd < maxd && curh < maxh)
      {
         Random rnd = new Random();
         int typ = rnd.Next(3);

         emp e = null;
         int eh = 0;

         if(typ == 1)
         {
            e = new full();
            eh = 8;
         }
         else if(typ == 2)
         {
            e = new part();
            eh = 4;
         }

         if(e != null && curh + eh <= maxh)
         {
            double dw = e.calw();
            totw += dw;
            curh += eh;
            curd++;
            emps.Add(e);
         }
         else if(e != null)
         {
            break;   // cant add more hours
         }
      }

      Console.WriteLine ("Total Wage: " + totw);
      Console.WriteLine( "Total Hours: " + curh);
      Console.WriteLine("  Total Days: " + curd);
   }
}

