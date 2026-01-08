using System;

// node for each inventory item
public class node
{
   public int idi;           
   public string nam;        
   public int qty;           
   public double prc;        
   public node nxt;          

   public node(int id, string n, int q, double p)
   {
      idi = id;
      nam = n;
      qty = q;
      prc = p;
      nxt = null;
   }

   // override ToString for easy printng
   public override string ToString()
   {
      return "ID: " + idi + " , Name: " + nam + " , Qty: " + qty + " , Price: " + prc + " , Value: " + (qty * prc);
   }
}

public class inv
{
   private node hed = null;   

   // add at beginning
   public void addbeg(int id, string n, int q, double p)
   {
      node nw = new node(id, n, q, p);
      nw.nxt = hed;
      hed = nw;
      Console.WriteLine("Added at start: " + nw);
   }

   // add at end
   public void addend(int id, string n, int q, double p)
   {
      node nw = new node(id, n, q, p);

      if(hed == null)
      {
         hed = nw;
      }
      else
      {
         node cur = hed;
         while(cur.nxt != null)
            cur = cur.nxt;
         cur.nxt = nw;
      }
      Console.WriteLine("Added at end: " + nw);
   }

   // add at position (1-based)
   public void addpos(int pos, int id, string n, int q, double p)
   {
      if(pos < 1)
      {
         Console.WriteLine("Invalid pos");
         return;
      }

      node nw = new node(id, n, q, p);

      if(pos == 1)
      {
         nw.nxt = hed;
         hed = nw;
         Console.WriteLine("Added at pos 1: " + nw);
         return;
      }

      node cur = hed;
      for(int i = 1; i < pos-1 && cur != null; i++)
         cur = cur.nxt;

      if(cur == null)
      {
         Console.WriteLine("Position too large");
         return;
      }

      nw.nxt = cur.nxt;
      cur.nxt = nw;
      Console.WriteLine("Added at pos " + pos + ": " + nw);
   }

   // remove by item id
   public void rem(int id)
   {
      if(hed == null)
      {
         Console.WriteLine("Inventory empty , nothing to remove");
         return;
      }

      if(hed.idi == id)
      {
         Console.WriteLine("Removing: " + hed);
         hed = hed.nxt;
         return;
      }

      node cur = hed;
      while(cur.nxt != null && cur.nxt.idi != id)
         cur = cur.nxt;

      if(cur.nxt == null)
      {
         Console.WriteLine("Item ID " + id + " not found");
         return;
      }

      Console.WriteLine("Removing: " + cur.nxt);
      cur.nxt = cur.nxt.nxt;
   }

   // update quantity by id
   public void updqty(int id, int newq)
   {
      node cur = hed;
      while(cur != null)
      {
         if(cur.idi == id)
         {
            Console.WriteLine("Updating qty for " + cur.nam + " from " + cur.qty + " to " + newq);
            cur.qty = newq;
            return;
         }
         cur = cur.nxt;
      }
      Console.WriteLine("Item ID " + id + " not found , cant update qty");
   }

   // search by id
   public void srchid(int id)
   {
      node cur = hed;
      int pos = 1;
      while(cur != null)
      {
         if(cur.idi == id)
         {
            Console.WriteLine("Found at position " + pos + ": " + cur);
            return;
         }
         cur = cur.nxt;
         pos++;
      }
      Console.WriteLine("Item ID " + id + " not found");
   }

   // search by name (partial match ok)
   public void srchnam(string n)
   {
      node cur = hed;
      bool fnd = false;
      int pos = 1;
      while(cur != null)
      {
         if(cur.nam.IndexOf(n, StringComparison.OrdinalIgnoreCase) >= 0)
         {
            Console.WriteLine("Found at position " + pos + ": " + cur);
            fnd = true;
         }
         cur = cur.nxt;
         pos++;
      }
      if(!fnd)
         Console.WriteLine("No item with name containing \"" + n + "\"");
   }

   // calculate total inventory value
   public void totval()
   {
      if(hed == null)
      {
         Console.WriteLine("Inventory empty , total value = 0");
         return;
      }

      double tot = 0;
      node cur = hed;
      while(cur != null)
      {
         tot += cur.qty * cur.prc;
         cur = cur.nxt;
      }
      Console.WriteLine("Total Inventory Value: " + tot);
   }

   // helper to get list count
   private int cnt()
   {
      int c = 0;
      node cur = hed;
      while(cur != null)
      {
         c++;
         cur = cur.nxt;
      }
      return c;
   }

   // simple bubble sort by name asc
   public void sortnamasc()
   {
      if(hed == null || hed.nxt == null) return;

      bool swp;
      do
      {
         swp = false;
         node cur = hed;
         while(cur.nxt != null)
         {
            if(string.Compare(cur.nam, cur.nxt.nam, StringComparison.OrdinalIgnoreCase) > 0)
            {
               // swap data
               int tmpid = cur.idi; string tmpn = cur.nam; int tmpq = cur.qty; double tmpp = cur.prc;
               cur.idi = cur.nxt.idi; cur.nam = cur.nxt.nam; cur.qty = cur.nxt.qty; cur.prc = cur.nxt.prc;
               cur.nxt.idi = tmpid; cur.nxt.nam = tmpn; cur.nxt.qty = tmpq; cur.nxt.prc = tmpp;
               swp = true;
            }
            cur = cur.nxt;
         }
      } while(swp);
      Console.WriteLine("Sorted by Name Ascending");
   }

   // sort by price desc
   public void sortprcdesc()
   {
      if(hed == null || hed.nxt == null) return;

      bool swp;
      do
      {
         swp = false;
         node cur = hed;
         while(cur.nxt != null)
         {
            if(cur.prc < cur.nxt.prc)
            {
               // swap data
               int tmpid = cur.idi; string tmpn = cur.nam; int tmpq = cur.qty; double tmpp = cur.prc;
               cur.idi = cur.nxt.idi; cur.nam = cur.nxt.nam; cur.qty = cur.nxt.qty; cur.prc = cur.nxt.prc;
               cur.nxt.idi = tmpid; cur.nxt.nam = tmpn; cur.nxt.qty = tmpq; cur.nxt.prc = tmpp;
               swp = true;
            }
            cur = cur.nxt;
         }
      } while(swp);
      Console.WriteLine("Sorted by Price Descending");
   }

   // display all items
   public void disp()
   {
      if(hed == null)
      {
         Console.WriteLine("Inventory is empty right now");
         return;
      }

      Console.WriteLine("Current Inventory:\n");
      node cur = hed;
      int num = 1;
      while(cur != null)
      {
         Console.WriteLine(num + ". " + cur);
         cur = cur.nxt;
         num++;
      }
   }
}

public class prog
{
   public static void Main(string[] args)
   {
      /*
      4. Singly Linked List: Inventory Management System
      Problem Statement: Design an inventory management system using a singly linked list where each node stores information about an item such as Item Name, Item ID, Quantity, and Price. Implement the following functionalities:

      * Add an item at the beginning, end, or at a specific position.

      * Remove an item based on Item ID.

      * Update the quantity of an item by Item ID.

      * Search for an item based on Item ID or Item Name.

      * Calculate and display the total value of inventory (Sum of Price * Quantity for each item).

      * Sort the inventory based on Item Name or Price in ascending or descending order.

      */

      inv stock = new inv();

      // adding demo items
      stock.addbeg(1001, "Laptop", 5, 55000);
      stock.addend(1002, "Mouse", 50, 500);
      stock.addpos(2, 1003, "Keyboard", 30, 1500);
      stock.addend(1004, "Monitor", 10, 12000);
      stock.addpos(4, 1005, "Webcam", 20, 2500);

      stock.disp();

      Console.WriteLine("     ");

      // search demos
      stock.srchid(1003);
      stock.srchnam("cam");
      stock.srchnam("phone");   // not exist

      // update qty
      stock.updqty(1002, 75);
      stock.updqty(9999, 10);

      // total value
      stock.totval();

      // sort demos
      Console.WriteLine("Sorting by Name Asc...");
      stock.sortnamasc();
      stock.disp();

      Console.WriteLine("Sorting by Price Desc...");
      stock.sortprcdesc();
      stock.disp();

      // remove demo
      Console.WriteLine("         ");
      stock.rem(1001);   // first
      stock.rem(1004);   // last
      stock.rem(1003);   // middle
      stock.rem(9999);   // not exist

      Console.WriteLine("After removals:");
      stock.disp();

      stock.totval();

      // waitng , for user to press somethng before exitng
      Console.WriteLine("Press any key to exit inventory system...");
      Console.ReadKey();
   }
}
