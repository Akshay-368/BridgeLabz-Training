using System;

// node class for singly linked list
public class node
{
   public int roll;     
   public string nam;   
   public int ag;       
   public char grd;     
   public node nxt;     

   // constructor to make new node
   public node(int r, string n, int a, char g)
   {
      roll = r;
      nam = n;
      ag = a;
      grd = g;
      nxt = null;
   }

   // override ToString for easy printng
   public override string ToString()
   {
      return "Roll: " + roll + " , Name: " + nam + " , Age: " + ag + " , Grade: " + grd;
   }
}

public class sll
{
   private node hed = null;   // head of list

   // add at beginning
   public void addbeg(int r, string n, int a, char g)
   {
      node nw = new node(r, n, a, g);
      nw.nxt = hed;
      hed = nw;
      Console.WriteLine("Added at beginning: " + nw);
   }

   // add at end
   public void addend(int r, string n, int a, char g)
   {
      node nw = new node(r, n, a, g);

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

   // add at specific position , pos starts from 1
   public void addpos(int pos, int r, string n, int a, char g)
   {
      if(pos < 1)
      {
         Console.WriteLine("Invalid position");
         return;
      }

      node nw = new node(r, n, a, g);

      if(pos == 1)
      {
         nw.nxt = hed;
         hed = nw;
         Console.WriteLine("Added at pos 1: " + nw);
         return;
      }

      node cur = hed;
      for(int i=1; i<pos-1 && cur != null; i++)
         cur = cur.nxt;

      if(cur == null)
      {
         Console.WriteLine("Position too big , list shorter");
         return;
      }

      nw.nxt = cur.nxt;
      cur.nxt = nw;
      Console.WriteLine("Added at position " + pos + ": " + nw);
   }

   // delete by roll number
   public void del(int rl)
   {
      if(hed == null)
      {
         Console.WriteLine("List empty , cant delete");
         return;
      }

      if(hed.roll == rl)
      {
         Console.WriteLine("Deleting: " + hed);
         hed = hed.nxt;
         return;
      }

      node cur = hed;
      while(cur.nxt != null && cur.nxt.roll != rl)
         cur = cur.nxt;

      if(cur.nxt == null)
      {
         Console.WriteLine("Roll " + rl + " not found");
         return;
      }

      Console.WriteLine("Deleting: " + cur.nxt);
      cur.nxt = cur.nxt.nxt;
   }

   // search by roll
   public void srch(int rl)
   {
      node cur = hed;
      int posi = 1;
      while(cur != null)
      {
         if(cur.roll == rl)
         {
            Console.WriteLine("Found at position " + posi + ": " + cur);
            return;
         }
         cur = cur.nxt;
         posi++;
      }
      Console.WriteLine("Roll " + rl + " not found in list");
   }

   // update grade by roll
   public void updgrd(int rl, char newg)
   {
      node cur = hed;
      while(cur != null)
      {
         if(cur.roll == rl)
         {
            Console.WriteLine("Updating grade for " + cur.nam + " from " + cur.grd + " to " + newg);
            cur.grd = newg;
            return;
         }
         cur = cur.nxt;
      }
      Console.WriteLine("Roll " + rl + " not found , cant update");
   }

   // display all records
   public void dispall()
   {
      if(hed == null)
      {
         Console.WriteLine("No student records in list yet");
         return;
      }

      Console.WriteLine("All Student Records:\n");
      node cur = hed;
      int cnt = 1;
      while(cur != null)
      {
         Console.WriteLine(cnt + ". " + cur);
         cur = cur.nxt;
         cnt++;
      }
   }
}

public class prog
{
   public static void Main(string[] args)
   {
      /*
      1. Singly Linked List: Student Record Management
      Problem Statement: Create a program to manage student records using a singly linked list. Each node will store information about a student, including their Roll Number, Name, Age, and Grade. Implement the following operations:

      * Add a new student record at the beginning, end, or at a specific position.

      * Delete a student record by Roll Number.

      * Search for a student record by Roll Number.

      * Display all student records.

      * Update a student's grade based on their Roll Number.

      */

      sll list = new sll();   // singly linked list object

      // demo adding some students
      list.addbeg(101, "Amit Sharma", 20, 'A');
      list.addend(102, "Priya Singh", 19, 'B');
      list.addpos(2, 103, "Rohan Kumar", 21, 'C');
      list.addend(104, "Neha Gupta", 20, 'A');
      list.addpos(3, 105, "Vikas Yadav", 19, 'B');

      // display all
      list.dispall();

      Console.WriteLine("\n");

      // search demo
      list.srch(103);
      list.srch(999);   // not exist

      // update grade
      list.updgrd(102, 'A');
      list.updgrd(999, 'A');

      // display again after update
      Console.WriteLine("\nAfter grade update:");
      list.dispall();

      // delete demo
      Console.WriteLine("\n");
      list.del(101);   // first one
      list.del(103);   // middle
      list.del(104);   // last
      list.del(999);   // not exist

      // final display
      Console.WriteLine("\nAfter deletions:");
      list.dispall();

      // waitng , for user to enter the inupt before closng
      Console.WriteLine("\nPress any key to exit student record manager...");
      Console.ReadKey();
   }
}
