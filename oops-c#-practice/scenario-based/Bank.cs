using System;
namespace Bank ;

public class bank
{

  public static double bal = 1000.00;   // starting balance, everyone sees same but ok for simple demo
  public static string accnum = "1234567890";  // fixed account number

public static void dep(double amt)
{
    // add money to account, pretty simple
    // but check if amount is positive first
    
    if (amt <= 0)
    {
    Console.WriteLine("cant deposit zero or negative money dude");
    return;
    }
    
    bal = bal + amt;
    
    Console.WriteLine( " deposited " + amt);
    Console.WriteLine( " new balance : " + bal);
}


public static void wit(double amt)
{
    // withdraw money but dont allow overdraft
    
    if (amt <= 0)
    {
    Console.WriteLine("withdraw amount must be positive");
    return;
    }
    
    if (amt > bal)
    {
    Console.WriteLine("not enough balance! overdraft not allowed");
    Console.WriteLine("you only have " + bal);
    return;
    }
    
    bal = bal - amt;
    
    Console.WriteLine("withdrew " + amt);
    Console.WriteLine("remaining balance: " + bal);
}


public static void chk()
{
    // just print current balance and account info
    
    Console.WriteLine( " Account Details : " ) ;
    Console.WriteLine("Account Number: " + accnum);
    Console.WriteLine("Current Balance: " + bal);

}


public static void Run(string[] args)
{
    /*
    Methods – Bank Account Manager
    1. Scenario: A banking app needs to perform operations like deposit, withdraw, and check balance for a user.
    ● Problem: Design a BankAccount class with:
    ● Fields/Properties: AccountNumber, Balance.
    ● Methods: Deposit(double), Withdraw(double), CheckBalance().
    ● Include logic to prevent overdraft.
    */
    
    Console.WriteLine ( " Welcome to simple bank manager " ) ;
    Console.WriteLine ( " starting balance is 1000 ");
    Console.WriteLine();
    
    bool run = true;
    
    while (run)
    {
    Console.WriteLine();
    Console.WriteLine("choose option:");
    Console.WriteLine("1. Check balance");
    Console.WriteLine("2. Deposit money");
    Console.WriteLine("3. Withdraw money");
    Console.WriteLine("4. Exit");
    Console.WriteLine();
    
    Console.WriteLine("waiting for your choice...");
    string ch = Console.ReadLine();
    
    Console.WriteLine();
    
    if (ch == "1")
    {
    chk();
    }
    else if (ch == "2")
    {
        Console.WriteLine("how much to deposit?");
        string inp = Console.ReadLine();
        
        if (double.TryParse(inp, out double am))
        {
        dep(am);
        }
        else
        {
        Console.WriteLine("invalid amount entered");
        }
    }
    else if (ch == "3")
    {
        Console.WriteLine("how much to withdraw?");
        string inp = Console.ReadLine();
        
        if (double.TryParse(inp, out double am))
        {
        wit(am);
        }
        else
        {
        Console.WriteLine("thats not a valid number");
        }
    }
    else if (ch == "4")
    {
        Console.WriteLine("thanks for using, bye!");
        run = false;
    }
    else
    {
        Console.WriteLine("wrong choice, try again");
    }
    
    Console.WriteLine();
    }
    
    // pause before close
    Console.WriteLine("press enter to finish...");
    Console.ReadLine();
    
}
}
