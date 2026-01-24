using System;

public class bankAcc 
{
    // simple bank account class for testing
    public class BankAccount
    {
        private double balance;

        public BankAccount(double initial = 0)
        {
            balance = initial >= 0 ? initial : 0;
        }

        public void Deposit(double amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("cannot deposit zero or negative");
                return;
            }
            balance += amount;
            Console.WriteLine("deposited " + amount + " , new balance: " + balance);
        }

        public void Withdraw(double amount)
        {
            if(amount <= 0)
            {
                Console.WriteLine("cannot withdraw zero or negative");
                return;
            }

            if(amount > balance)
            {
                Console.WriteLine("insufficient funds");
                return;
            }

            balance -= amount;
            Console.WriteLine("withdrew " + amount + " , new balance: " + balance);
        }

        public double GetBalance()
        {
            return balance;
        }
    }

    // manual student-style tests
    public static void testBankAccount()
    {
        Console.WriteLine("=== BankAccount Tests (manual student style) ===\n");

        // test 1: initial balance
        BankAccount acc = new BankAccount(1000);
        double bal = acc.GetBalance();
        if(bal == 1000)
        {
            Console.WriteLine("Initial balance test: PASS");
        }
        else
        {
            Console.WriteLine("Initial balance FAIL");
        }

        // test 2: deposit positive
        acc.Deposit(500);
        if(acc.GetBalance() == 1500)
        {
            Console.WriteLine("Deposit positive PASS");
        }

        // test 3: deposit negative (should not change)
        double before = acc.GetBalance();
        acc.Deposit(-100);
        if(acc.GetBalance() == before)
        {
            Console.WriteLine("Deposit negative blocked: PASS");
        }

        // test 4: withdraw valid
        acc.Withdraw(300);
        if(acc.GetBalance() == 1200)
        {
            Console.WriteLine("Withdraw valid PASS");
        }

        // test 5: withdraw too much
        before = acc.GetBalance();
        acc.Withdraw(2000);
        if(acc.GetBalance() == before)
        {
            Console.WriteLine("Withdraw insufficient blocked: PASS");
        }

        // test 6: withdraw zero/negative
        before = acc.GetBalance();
        acc.Withdraw(0);
        if(acc.GetBalance() == before)
        {
            Console.WriteLine("Withdraw zero blocked: PASS");
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

        Console.WriteLine("Bank Account Testing ");

        testBankAccount();

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
