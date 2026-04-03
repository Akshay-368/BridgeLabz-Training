using System;

public class hmp 
{
    // node for chaining collisions
    public struct nd 
    {
        public int key;
        public string val;
        public nd nxt;
    }

    public static nd[] tab; // array of buckets
    public static int sz = 11; // num of buckets , prime number good
    public static int cnt = 0; // how many entries

    public static void init() 
    {
        tab = new nd[sz];
        for(int i=0; i<sz; i++) 
        {
            tab[i].key = 0;
            tab[i].val = "";
            tab[i].nxt = new nd(); // empty next
        }
      // table initialized with empty slots
    }

    public static int hsh(int k) 
    {
        return (k % sz + sz) % sz; // simple hash , handle negative
    }

    public static void put(int ky,string vl) 
    {
        if(tab == null) init();

        int idx = hsh(ky);

        nd cur = tab[idx];
        nd prv = new nd();

        // find if key exists , update
        while(cur.key != 0 || cur.val != "")
        {
            if(cur.key == ky)
            {
                cur.val = vl; // just update value
                return;
            }
            prv = cur;
            cur = cur.nxt;
        }

        // new entry , add to chain
        nd nw = new nd();
        nw.key = ky;
        nw.val = vl;
        nw.nxt = new nd(); // empty

        if(tab[idx].key == 0 && tab[idx].val == "")
        {
            tab[idx] = nw; // first in bucket
        }
        else
        {
            prv.nxt = nw; // add to end of chain
        }

        cnt++;
        Console.WriteLine("Put key "+ky+" with val "+vl);
      // handles collision by chaining in list
    }

    public static string get(int ky) 
    {
        if(tab == null)
        {
            Console.WriteLine("hashmap empty");
            return "";
        }

        int idx = hsh(ky);

        nd cur = tab[idx];

        while(cur.key != 0 || cur.val != "")
        {
            if(cur.key == ky)
            {
                Console.WriteLine("Found key "+ky+" value "+cur.val);
                return cur.val;
            }
            cur = cur.nxt;
        }

        Console.WriteLine("Key "+ky+" not found");
        return "";
      // search in chain at that bucket
    }

    public static void del(int ky) 
    {
        if(tab == null)
        {
            Console.WriteLine("nothing to delete");
            return;
        }

        int idx = hsh(ky);

        nd cur = tab[idx];
        nd prv = new nd();

        while(cur.key != 0 || cur.val != "")
        {
            if(cur.key == ky)
            {
                if(prv.key == 0 && prv.val == "") // first in bucket
                {
                    tab[idx] = cur.nxt;
                }
                else
                {
                    prv.nxt = cur.nxt;
                }
                cnt--;
                Console.WriteLine("Deleted key "+ky);
                return;
            }
            prv = cur;
            cur = cur.nxt;
        }

        Console.WriteLine("Key "+ky+" not there to delete");
      // remove from chain properly
    }

    public static void prntAll() 
    {
        if(tab == null || cnt == 0)
        {
            Console.WriteLine("hashmap empty nothing to print");
            return;
        }

        Console.WriteLine("HashMap contents:");
        for(int i=0; i<sz; i++)
        {
            if(tab[i].key != 0 || tab[i].val != "")
            {
                Console.WriteLine("Bucket "+i+":");
                nd cur = tab[i];
                while(cur.key != 0 || cur.val != "")
                {
                    Console.WriteLine("  Key: "+cur.key+" Val: "+cur.val);
                    cur = cur.nxt;
                }
            }
        }
      // prints all non-empty buckets and chains
    }

    public static void Main(string[] args) 
    {
        /*
        Implement a Custom Hash Map

        * Problem: Design and implement a basic hash map class with operations for insertion, deletion, and retrieval.

        * Hint: Use an array of linked lists to handle collisions using separate chaining.
        */

        init(); // start fresh

        int ch = 0;
        while(ch != 5)
        {
            Console.WriteLine("\nCustom Hash Map Menu:");
            Console.WriteLine("1 Put (insert/update)");
            Console.WriteLine("2 Get value");
            Console.WriteLine("3 Delete key");
            Console.WriteLine("4 Print all entries");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("Enter key : ");
                int ky = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter value : ");
                string vl = Console.ReadLine();
                put(ky,vl);
            }
            else if(ch == 2)
            {
                Console.Write("Enter key to get : ");
                int ky = Convert.ToInt32(Console.ReadLine());
                get(ky);
            }
            else if(ch == 3)
            {
                Console.Write("Enter key to delete : ");
                int ky = Convert.ToInt32(Console.ReadLine());
                del(ky);
            }
            else if(ch == 4)
            {
                prntAll();
            }
        }
    }
}
