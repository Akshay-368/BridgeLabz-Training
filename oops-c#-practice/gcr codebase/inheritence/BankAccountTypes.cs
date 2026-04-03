using System;

public static class prog
{
    public static void Main(  )
    {
        /*
        Sample Problem 1: Bank Account Types

        * Description: Model a banking system with different account types using hierarchical inheritance. BankAccount is the superclass, with SavingsAccount, CheckingAccount, and FixedDepositAccount as subclasses.

        * Tasks:

          * Define a base class BankAccount with attributes like AccountNumber and Balance.

          * Define subclasses SavingsAccount, CheckingAccount, and FixedDepositAccount, each with unique attributes like interestRate for SavingsAccount and WithdrawalLimit for CheckingAccount.

          * Implement a method DisplayAccountType() in each subclass to specify the account type.

        * Goal: Explore hierarchical inheritance, demonstrating how each subclass can have unique attributes while inheriting from a shared superclass.
        */
        
        // hierarchical inheritance for bank accounts
        
        ba b1 = new sa("SA001",5000,4.5);
        ba b2 = new ca("CA001",2000,10);
        ba b3 = new fd("FD001",10000,7.2,12);
        
        // all share account number and balance but different extra stuff
        
        b1.dat();
        Console.WriteLine();
        b2.dat();
        Console.WriteLine();
        b3.dat();
        
        // why hierarchical ? one base , many subclasses
        
        Console.WriteLine("bank account hierarchy done");
    }
}

public class ba
{
    public string an; // account number
    public double bl; // balance
    
    public ba(string a , double b)
    {
        this.an = a;
        this.bl = b;
    }
    
    public virtual void dat()
    {
        Console.WriteLine("Account Number : " + an );
        Console.WriteLine("Balance  : " + bl );
    }
}

public class sa : ba
{
    public double ir; // interest rate
    
    public sa(string a,double b,double i) : base(a , b)
    {
        this.ir = i;
    }
    
    public override void dat()
    {
        base.dat();
        Console.WriteLine("Account Type : Savings Account");
        Console.WriteLine("Interest Rate : " + ir + "%");
    }
}

public class ca : ba
{
    public int wl; // withdrawal limit per month
    
    public ca(string a,double b,int w) : base(a,b)
    {
        this.wl = w;
    }
    
    public override void dat()
    {
        base.dat();
        Console.WriteLine("Account Type : Checking Account");
        Console.WriteLine("Withdrawal Limit : " + wl + " times/month");
    }
}

public class fd : ba
{
    public double ir;
    public int tm; // term in months
    
    public fd(string a,double b,double i,int t) : base(a,b)
    {
        this.ir = i;
        this.tm = t;
    }
    
    public override void dat()
    {
        base.dat();
        Console.WriteLine("Account Type : Fixed Deposit");
        Console.WriteLine("Interest Rate : " + ir + "%");
        Console.WriteLine("Term : " + tm + " months");
    }
}
