using System;
using System.Collections.Generic;

public class bankSys 
{
    // dictionary for account number -> balance
    public static Dictionary<int,double> accounts = new Dictionary<int,double>();

    // sorted dictionary - sorted by balance
    public static SortedDictionary<double,int> sortedByBalance = new SortedDictionary<double,int>(new BalanceComparer());

    // queue for withdrawal requests
    public static Queue<int> withdrawalQueue = new Queue<int>();

    public static void addAccount(int accNum,double initialBal)
    {
        if(accounts.ContainsKey(accNum))
        {
            Console.WriteLine("account already exists");
        }
        else
        {
            accounts[accNum] = initialBal;
            sortedByBalance[initialBal] = accNum;
            Console.WriteLine("account " + accNum + " created with Rs." + initialBal);
        }
    }

    public static void requestWithdrawal(int accNum)
    {
        if(!accounts.ContainsKey(accNum))
        {
            Console.WriteLine("account not found");
            return;
        }

        withdrawalQueue.Enqueue(accNum);
        Console.WriteLine("withdrawal request added for account " + accNum);
    }

    public static void processWithdrawals()
    {
        while(withdrawalQueue.Count > 0)
        {
            int acc = withdrawalQueue.Dequeue();
            Console.WriteLine("processing withdrawal for account " + acc);
            // simple print (no actual deduction)
        }
    }

    public static void showAccounts()
    {
        Console.WriteLine("Accounts (normal):");
        foreach(KeyValuePair<int,double> a in accounts)
        {
            Console.WriteLine("Acc " + a.Key + " - Rs." + a.Value);
        }

        Console.WriteLine("\nSorted by balance:");
        foreach(KeyValuePair<double,int> a in sortedByBalance)
        {
            Console.WriteLine("Acc " + a.Value + " - Rs." + a.Key);
        }
    }

    // reverse comparer for sorted dictionary (highest balance first)
    public class BalanceComparer : IComparer<double>
    {
        public int Compare(double a,double b)
        {
            return b.CompareTo(a);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        Implement a Banking System
        * Dictionary<int, double> to store account balances.
        * SortedDictionary to sort customers by balance.
        * Queue to process withdrawal requests.
        */

        Console.WriteLine("Simple Banking System\n");

        int ch = 0;
        while(ch != 5)
        {
            Console.WriteLine("1 Add account");
            Console.WriteLine("2 Request withdrawal");
            Console.WriteLine("3 Process withdrawals");
            Console.WriteLine("4 Show accounts");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("enter account number : ");
                int acc = Convert.ToInt32(Console.ReadLine());
                Console.Write("enter initial balance : ");
                double bal = Convert.ToDouble(Console.ReadLine());

                addAccount(acc, bal);
            }
            else if(ch == 2)
            {
                Console.Write("enter account number for withdrawal : ");
                int acc = Convert.ToInt32(Console.ReadLine());
                requestWithdrawal(acc);
            }
            else if(ch == 3)
            {
                processWithdrawals();
            }
            else if(ch == 4)
            {
                showAccounts();
            }
        }
    }
}
