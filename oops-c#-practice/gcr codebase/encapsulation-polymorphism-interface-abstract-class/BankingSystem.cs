
// interface for loan stuff
public interface iloan
{
   bool appl();
   double calel();
}

// abstract bank account base
public abstract class bacc
{
   private string accn;    
   private string hname;   
   private double bal;     

   // secure properties
   public string accno
   { 
      get { return accn;}
      set { accn = value;}
   }

   public string nam
   { 
      get { return hname;}
      set { hname = value;}
   }

   public double bals
   { 
      get { return bal;}
      set { bal = value;}
   }

   // deposit method common
   public void dep(double amt)
   {
      if(amt > 0)
         bal += amt;
      else
         Console.WriteLine( " Invalid deposit amnt " ) ;
   }

   // withdraw method
   public void wdr(double amt)
   {
      if(amt > 0 && amt <= bal)
         bal -= amt;
      else
         Console.WriteLine("Cant withdraw , low bal or invalid");
   }

   // abstract interest
   public abstract double calint();

   // print info
   public void prnt()
   {
      Console.WriteLine("Acc No : " + accn );
      Console.WriteLine("Holder : "+ hname );
      Console.WriteLine("Balance: " +bal );
   }
}

// savings account
public class sav : bacc , iloan
{
   public override double calint()
   {
      // savings 4% interest per year kinda
      return bals * 0.04 ;
   }

   public bool appl()
   {
      // can apply if bal > 10000
      return bals > 10000;
   }

   public double calel()
   {
      return bals * 2;   // loan up to 2x balance
   }
}

// current account
public class cur : bacc , iloan
{
   public override double calint()
   {
      // current low interest 1%
      return bals * 0.01 ;
   }

   public bool appl()
   {
      return bals > 50000 ;   // higher limit
   }

   public double calel()
   {
      return bals * 1.5 ;
   }
}

public class bank
{
   public static void Main(string[] args)
   {
      /*
      4. Banking System
      Description: Create a banking system with different account types:
      Define an abstract class BankAccount with fields like accountNumber, holderName, and balance.
      Add methods like Deposit(double amount), Withdraw(double amount), and an abstract method CalculateInterest().
      Implement subclasses SavingsAccount and CurrentAccount with unique interest calculations.
      Create an interface ILoanable with methods ApplyForLoan() and CalculateLoanEligibility().
      Use encapsulation to secure account details and restrict unauthorized access.
      Demonstrate polymorphism by processing different account types and calculating interest dynamically.

      No additonal hints.
      */

      List<bacc> alst= new List<bacc>();

      sav s1 = new sav();
      s1.accno = "SAV001" ;
      s1.nam = "Asha Devi";
      s1.bals = 25000;
      s1.dep(5000);   // demo deposit

      cur c1 = new cur();
      c1.accno = "CUR101";
      c1.nam = "Vikram Singh";
      c1.bals = 80000;
      c1.wdr(10000);   // demo withdraw

      sav s2 = new sav();
      s2.accno = "SAV002";
      s2.nam = "Laxmi";
      s2.bals = 15000;

      alst.Add(s1); alst.Add(c1); alst.Add(s2);

      Console.WriteLine("Bank Accounts Interest and Loan Info:\n");

      // polymorphism processng
      foreach(bacc a in alst)
      {
         a.prnt();

         double intr = a.calint();
         Console.WriteLine("Interest Earned: "+intr);

         // loan via interface
         if(a is iloan)
         {
            iloan ln = (iloan)a;
            if(ln.appl())
            {
               Console.WriteLine("Loan Applied: Yes");
               Console.WriteLine("Eligible Loan Amt: "+ln.calel());
            }
            else
            {
               Console.WriteLine("Loan Applied: No , low balance");
            }
         }
      }

      // waitng , for user to enter the inupt key to exit
      Console.WriteLine(" Press any key to close bankng systm ...");
      Console.ReadKey();
   }
}
