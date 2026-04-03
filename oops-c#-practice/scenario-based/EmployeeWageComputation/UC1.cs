
// class for UC1 - check present or absent
public class uc1
{
   public static void run()
   {
      Console.WriteLine(" UC1 : Check Employee Present or Absent " ) ;

      Random rnd = new Random ()  ;
      int att = rnd.Next (2) ;   // 0 absent , 1 present

      if(att == 1)
         Console.WriteLine ( " Employee is Present" ) ;
      else
         Console.WriteLine("Employee is Absent " ) ;
   }
}

