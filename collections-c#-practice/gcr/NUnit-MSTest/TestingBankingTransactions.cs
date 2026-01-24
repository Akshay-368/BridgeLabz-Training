using System;

public class bankAcc 
{
    // simple bank account class
    public class BankAccount
    {
        private double balance;

        public BankAccount(double initial)
        {
            balance = initial >= 0 ? initial : 0;
        }

        public void deposit(double amt)
        {
            if(amt > 0)
            {
                balance += amt;
                Console.WriteLine("deposited " + amt + " , new balance: " + balance);
            }
            else
            {
                Console.WriteLine("cannot deposit negative or zero");
            }
        }

        public void withdraw(double amt)
        {
            if(amt <= 0)
            {
                Console.WriteLine("cannot withdraw negative or zero");
                return;
            }

            if(amt > balance)
            {
                Console.WriteLine("insufficient funds");
                return;
            }

            balance -= amt;
            Console.WriteLine("withdrew " + amt + " , new balance: " + balance);
        }

        public double getBalance()
        {
            return balance;
        }
    }

    // manual test function (student style)
    public static void testBankAccount()
    {
        Console.WriteLine("Testing BankAccount...");

        BankAccount acc = new BankAccount(1000);

        // test deposit
        acc.deposit(500);
        if(acc.getBalance() == 1500)
        {
            Console.WriteLine("Deposit test PASS");
        }
        else
        {
            Console.WriteLine("Deposit test FAIL");
        }

        // test withdraw valid
        acc.withdraw(200);
        if(acc.getBalance() == 1300)
        {
            Console.WriteLine("Withdraw valid PASS");
        }

        // test withdraw insufficient
        double oldBal = acc.getBalance();
        acc.withdraw(2000);
        if(acc.getBalance() == oldBal)
        {
            Console.WriteLine("Withdraw insufficient PASS (no change)");
        }

        // test negative deposit
        acc.deposit(-100);
        if(acc.getBalance() == oldBal)
        {
            Console.WriteLine("Negative deposit blocked PASS");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        1. Testing Banking Transactions
        Problem:
        Create a BankAccount class with:
        * Deposit(double amount): Adds money to the balance.
        * Withdraw(double amount): Reduces balance.
        * GetBalance(): Returns the current balance.
          ✅ Write unit tests to check correct balance updates.
          ✅ Ensure withdrawals fail if funds are insufficient.
        */

        Console.WriteLine("Bank Account Tests ");

        testBankAccount();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
