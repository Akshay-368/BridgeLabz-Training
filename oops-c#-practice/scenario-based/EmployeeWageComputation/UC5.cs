
// UC5: month wages , 20 days
public class uc5
{
   public static void run()
   {
      Console.WriteLine(" UC5m: Wages for a Month " );

      List<emp> emps = new List<emp>();   // collection library

      // simulate 20 days , random type each day for one emp kinda
      double totw = 0;
      for(int d=1; d<=20; d++)
      {
         Random rnd = new Random();
         int typ = rnd.Next(3);

         emp e = null;
         if(typ == 1)
            e = new full();
         else if(typ == 2)
            e = new part();

         if(e != null)
         {
            double dw = e.calw();
            totw += dw;
            emps.Add(e);   // add to list
         }
      }

      Console.WriteLine (" Total Monthly Wage : " + totw);
      Console.WriteLine ( " Number of Working Days : " + emps.Count ) ;
   }
}

