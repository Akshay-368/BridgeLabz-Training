using System;

public class bankTrans 
{
    // custom exception for insufficient balance
    public class InsufficientFundsException : Exception
    {
        public InsufficientFundsException(string msg) : base(msg) { }
    }

    public static double balance = 5000.0;

    // withdraw method
    public static void withdraw(double amount)
    {
        if(amount < 0)
        {
            throw new ArgumentException("Invalid amount - cannot be negative");
        }

        if(amount > balance)
        {
            throw new InsufficientFundsException("Insufficient balance!");
        }

        balance -= amount;
        Console.WriteLine("Withdrawal successful , new balance: " + balance);
    }

    public static void Main(string[] args) 
    {
        /*
        10. Implementing a Bank Transaction System
        💡 Problem Statement:
        Develop a Bank Account System where:
        * Withdraw(double amount) method:
          * Throws InsufficientFundsException if withdrawal amount exceeds balance.
          * Throws ArgumentException if the amount is negative.
        * Handle exceptions in Main().
        Expected Behavior:
        * If valid, print "Withdrawal successful, new balance: X".
        * If balance is insufficient, throw and handle "Insufficient balance!".
        * If the amount is negative, throw and handle "Invalid amount!".
        */

        Console.WriteLine("Bank Withdrawal System\n");
        Console.WriteLine("Current balance: " + balance + "\n");

        while(true)
        {
            Console.Write("Waiting , for user to enter amount to withdraw (0 to exit) : ");
            double amt = Convert.ToDouble(Console.ReadLine());

            if(amt == 0) break;

            try
            {
                withdraw(amt);
            }
            catch(InsufficientFundsException ifEx)
            {
                Console.WriteLine("Insufficient balance!");
                Console.WriteLine("(details: " + ifEx.Message + ")");
            }
            catch(ArgumentException argEx)
            {
                Console.WriteLine("Invalid amount!");
                Console.WriteLine("(details: " + argEx.Message + ")");
            }
            catch(Exception e)
            {
                Console.WriteLine("some error : " + e.Message);
            }
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
