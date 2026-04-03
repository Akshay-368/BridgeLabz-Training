using System;
using System.Collections.Generic;

public class insPol 
{
    // simple class for insurance policy
    public class Policy
    {
        public string polNum;
        public string coverageType;
        public string expiryDate; // simple string format dd-mm-yyyy

        public Policy(string num,string type,string date)
        {
            polNum = num;
            coverageType = type;
            expiryDate = date;
        }

        public override string ToString()
        {
            return polNum + " - " + coverageType + " - " + expiryDate;
        }
    }

    public static void manageInsurance()
    {
        // HashSet for unique policies (no duplicates)
        HashSet<string> uniquePolicies = new HashSet<string>();

        // LinkedHashSet like - we use List to keep insertion order
        List<Policy> orderedPolicies = new List<Policy>();

        // SortedSet for expiry date sorting
        SortedSet<Policy> sortedByExpiry = new SortedSet<Policy>(new ExpiryComparer());

        int ch = 0;
        while(ch != 5)
        {
            Console.WriteLine("Insurance Menu:");
            Console.WriteLine("1 Add policy");
            Console.WriteLine("2 Show unique policies (HashSet)");
            Console.WriteLine("3 Show in insertion order (LinkedHashSet like)");
            Console.WriteLine("4 Show sorted by expiry (TreeSet like)");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("enter policy number : ");
                string num = Console.ReadLine();
                Console.Write("enter coverage type : ");
                string typ = Console.ReadLine();
                Console.Write("enter expiry date (dd-mm-yyyy) : ");
                string dt = Console.ReadLine();

                Policy p = new Policy(num, typ, dt);

                // add to all structures
                if(uniquePolicies.Add(num))
                {
                    orderedPolicies.Add(p);
                    sortedByExpiry.Add(p);
                    Console.WriteLine("policy added successfully");
                }
                else
                {
                    Console.WriteLine("duplicate policy number , not added");
                }
            }
            else if(ch == 2)
            {
                Console.WriteLine("Unique policies (HashSet):");
                foreach(string p in uniquePolicies)
                {
                    Console.WriteLine(p);
                }
            }
            else if(ch == 3)
            {
                Console.WriteLine("Insertion order (LinkedHashSet like):");
                foreach(Policy p in orderedPolicies)
                {
                    Console.WriteLine(p);
                }
            }
            else if(ch == 4)
            {
                Console.WriteLine("Sorted by expiry (TreeSet like):");
                foreach(Policy p in sortedByExpiry)
                {
                    Console.WriteLine(p);
                }
            }
        }
    }

    // custom comparer for expiry date (simple string compare for now)
    public class ExpiryComparer : IComparer<Policy>
    {
        public int Compare(Policy a,Policy b)
        {
            return string.Compare(a.expiryDate, b.expiryDate);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        Insurance Policy Management System
        1. Store Unique Policies using:
           * HashSet for quick lookups.
           * LinkedHashSet to maintain the order of insertion.
           * SortedSet (TreeSet equivalent) to maintain policies sorted by expiry date.
        2. Retrieve Policies:
           * All unique policies.
           * Policies expiring soon (within the next 30 days).
           * Policies with a specific coverage type.
           * Duplicate policies based on policy numbers.
        */

        Console.WriteLine("Insurance Policy Manager\n");

        manageInsurance();

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
