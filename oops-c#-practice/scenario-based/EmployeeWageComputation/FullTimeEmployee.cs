
// full time employee class
public class full : emp
{
   public full()
   {
      hrs = 8;   // full day hours
   }

   public override double calw()
   {
      // full day wage
      return hrs * rat;
   }
}

