using System;

public class acc
{
    public string accnum;         // public
    protected string holder;      // protected
    private double bal;           // private
    
    public acc(string num, string h, double b)
    {
        accnum = num;
        holder = h;
        bal = b;
    }
    
    public double getbal()
    {
        return bal;
    }
    
    public void dep(double amt)
    {
        if (amt > 0)
        {
            bal += amt;
            Console.WriteLine("deposited " + amt);
        }
    }
    
    public void wit(double amt)
    {
        if (amt > 0 && amt <= bal)
        {
            bal -= amt;
            Console.WriteLine("withdrew " + amt);
        }
        else
        {
            Console.WriteLine("invalid withdraw amount");
        }
    }
    
    public void disp()
    {
        Console.WriteLine("Account Number: " + accnum);
        Console.WriteLine("Holder Name   : " + holder);
        Console.WriteLine("Balance       : " + bal);
    }
}

public class savacc : acc
{
    public savacc(string num, string h, double b) : base(num, h, b)
    {
    }
    
    public void showprot()
    {
        Console.WriteLine("from savings account:");
        Console.WriteLine("Public acc num: " + accnum);
        Console.WriteLine("Protected holder: " + holder);
    }
}

public class bank
{
    public static void Main()
    {
        /*
        Problem 3: Bank Account Management

        * Create a BankAccount class with:

          * accountNumber (public)

          * accountHolder (protected)

          * balance (private)

        * Implement methods to:

          * Access and modify balance using public methods.

          * Create a subclass SavingsAccount to demonstrate access to accountNumber and accountHolder.
        */
        
        acc a = new acc ( "  ACC12345", "Vikram Singh", 5000);
        a.disp();
        
        Console.WriteLine () ;
        a.dep(2000);
        a.wit (1000) ;
        a.disp() ;
        
        Console.WriteLine();
        savacc sa = new savacc ( "SAV9876", "Neha Patel", 10000);
        sa.showprot();
        sa.disp();
        
        Console.WriteLine( " press enter to quit.." ) ;
        Console.ReadLine () ;
    }
}
