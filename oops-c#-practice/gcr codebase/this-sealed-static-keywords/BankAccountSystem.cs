using System;

public class BankAccount
{
    public static string bankName = "Global National Bank";  // static shared by all
    public static int totalAccounts = 0;                     // counting accounts
    
    public readonly string AccountNumber;   // readonly - set only once
    public string AccountHolderName;
    public double Balance;
    
    public BankAccount(string AccountNumber, string AccountHolderName, double initialBal)
    {
        // using this to resolve ambiguity (parameter vs field names same)
        this.AccountNumber = AccountNumber;
        this.AccountHolderName = AccountHolderName;
        this.Balance = initialBal;
        
        totalAccounts++;  // one more account created
    }
    
    public void ShowDetails()
    {
        Console.WriteLine("Bank : " + bankName);
        Console.WriteLine("Account No : " + AccountNumber);
        Console.WriteLine("Holder : " + AccountHolderName);
        Console.WriteLine("Balance : " + Balance);
    }
    
    public static void GetTotalAccounts()
    {
        // static method to show total count
        Console.WriteLine("Total Accounts in " + bankName + ": " + totalAccounts);
    }
    
    public static void Main(string[] args)
    {
        /*
        Sample Program 1: Bank Account System
        Create a BankAccount class with the following features:

        * static: 
          * A static variable bankName shared across all accounts.
          * A static method GetTotalAccounts() to display the total number of accounts.

        * this: 
          * Use this to resolve ambiguity in the constructor when initializing AccountHolderName and AccountNumber.

        * readonly: 
          * Use a readonly variable AccountNumber to ensure it cannot be changed once assigned.

        * is operator: 
          * Check if an account object is an instance of the BankAccount class before displaying its details.
        */
        
        Console.WriteLine("Welcome to " + bankName);
        Console.WriteLine();
        
        BankAccount acc1 = new BankAccount("ACC001234", "Rohan Mehta", 5000.50);
        BankAccount acc2 = new BankAccount("ACC009876", "Sonia Kapoor", 12000);
        
        object obj1 = acc1;
        object obj2 = "just a string";
        
        Console.WriteLine("checking objects with 'is' operator");
        Console.WriteLine();
        
        if (obj1 is BankAccount ba1)
        {
            Console.WriteLine("obj1 is a BankAccount, showing details:");
            ba1.ShowDetails();
        }
        
        Console.WriteLine();
        
        if (obj2 is BankAccount)
        {
            Console.WriteLine("obj2 is BankAccount - this wont print");
        }
        else
        {
            Console.WriteLine("obj2 is not a BankAccount");
        }
        
        Console.WriteLine();
        acc2.ShowDetails();
        
        Console.WriteLine();
        BankAccount.GetTotalAccounts();
        
        Console.WriteLine("press enter to exit...");
        Console.ReadLine();
    }
}
