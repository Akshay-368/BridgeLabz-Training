using System;
using System.Collections.Generic;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        Problem 2: Bank and Account Holders (Association)
        Description: Model a relationship where a Bank has Customer objects associated with it. A Customer can have multiple bank accounts, and each account is linked to a Bank.
        Tasks:

        * Define a Bank class and a Customer class.

        * Use an association relationship to show that each Customer has an account in a Bank.

        * Implement methods that enable communication, such as OpenAccount() in the Bank class and ViewBalance() in the Customer class.

        Goal: Illustrate association by setting up a relationship between customers and the bank.
        */
        
        // starting with bank and customers , association means they know each other but can live separate
        
        bk b1 = new bk("City Bank");
        
        cus c1 = new cus("ram");
        cus c2 = new cus("sita");
        
        // customer opens account in bank
        b1.oa(c1,5000);
        b1.oa(c2,3000);
        b1.oa(c1,2000); // same customer can have more accounts
        
        // now customers check their balances
        c1.vb();
        c2.vb();
        
        Console.WriteLine("thats it for bank association");
    }
}

public static class bk
{
    public string nm; // bank name
    public List<cus> cl; // list of customers , but association not owning them
    
    public bk(string n)
    {
        this.nm = n;
        cl = new List<cus>();
    }
    
    public void oa(cus c , double am)
    {
        // open account , add money and link
        acc a = new acc(am , this); // account knows its bank
        c.al.Add(a); // customer gets the account
        if(!cl.Contains(c))
        {
            cl.Add(c); // bank knows customer if new
        }
        Console.WriteLine(c.nm + " opened account with " + am );
        // why we do this ? to show communication
    }
}

public static class cus
{
    public string nm;
    public List<acc> al; // customer can have many accounts
    
    public cus(string n)
    {
        this.nm = n;
        al = new List<acc>();
    }
    
    public void vb()
    {
        Console.WriteLine("Balances for " + nm + " :");
        double tot = 0;
        foreach(acc a in al)
        {
            Console.WriteLine("  Account in " + a.b.nm + " : " + a.bl );
            tot = tot + a.bl;
        }
        Console.WriteLine("Total balance : " + tot );
        // printing all so customer sees everything
    }
}

public static class acc
{
    public double bl; // balance
    public bk b; // which bank , association
    
    public acc(double b , bk bank)
    {
        this.bl = b;
        this.b = bank;
    }
}
