
// menu class to show options
public class menu
{
   public static void show()
   {
      Console.WriteLine("Choose UC to Run:");
      Console.WriteLine("1 - UC1");
      Console.WriteLine("2 - UC2");
      Console.WriteLine("3 - UC3");
      Console.WriteLine("4 - UC4");
      Console.WriteLine("5 - UC5");
      Console.WriteLine("6 - UC6");
      Console.WriteLine("0 - Exit");

      int ch = Convert.ToInt32(Console.ReadLine());

      switch(ch)
      {
         case 1: uc1.run(); break;
         case 2: uc2.run(); break;
         case 3: uc3.run(); break;
         case 4: uc4.run(); break;
         case 5: uc5.run(); break;
         case 6: uc6.run(); break;
         default: return;
      }
   }
}
