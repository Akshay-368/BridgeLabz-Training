
// part time employee class
public class part : emp
{
   public part()
   {
      hrs = 4 ;   // assume part time 4 hours , even if said 8 , standard is less
   }

   public override double calw()
   {
      // part time wage
      return hrs * rat;
   }
}
