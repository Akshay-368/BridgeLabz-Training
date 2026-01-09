using System;

public class prog 
{
    // node structur for task
    public struct nd 
    {
     public int id;
      public string nam;
     public int pri;
      public string due;

     public nd nxt;
    }

    public static nd hed = null;

    public static void adBeg( int i, string n, int p, string d ) 
    {
        nd nw = new nd();
        nw.id = i;
        nw.nam = n;
         nw.pri = p;
        nw.due = d;

      if (hed == null) 
      {
          nw.nxt = nw; // point to itsef cuz only one
          hed = nw;
      }
      else 
      {
          nd tmp = hed;
          while (tmp.nxt != hed) 
          {
              tmp = tmp.nxt;
          }
          tmp.nxt = nw;
          nw.nxt = hed;
          hed = nw; // new head is nw
      }

      // why we do this: to keep it circluar and add at start
    }

    public static void adEnd( int i,string n,int p,string d )
    {
        nd nw = new nd();
        nw.id = i;
        nw.nam = n;
        nw.pri = p;
        nw.due = d;

        if(hed == null)
        {
            nw.nxt = nw;
            hed = nw;
            return;
        }

        nd tmp = hed;
        while(tmp.nxt != hed)
        {
            tmp = tmp.nxt;
        }
        tmp.nxt = nw;
        nw.nxt = hed;
        // added at the last position, circle stays intact
    }

    public static void adPos(int pos,int i,string n,int p,string d)
    {
        if(pos == 0)
        {
            adBeg(i,n,p,d);
            return;
        }

        nd nw = new nd();
        nw.id = i;
        nw.nam = n;
        nw.pri = p;
        nw.due = d;

        nd tmp = hed;
        for(int k=0; k<pos-1; k++)
        {
            if(tmp.nxt == hed) break; // safety
            tmp = tmp.nxt;
        }

        nw.nxt = tmp.nxt;
        tmp.nxt = nw;
        // inserted after given pos, circle still good
    }

    public static void remId(int iid)
    {
        if(hed == null)
        {
            Console.WriteLine("list empty cant remove");
            return;
        }

        if(hed.id == iid)
        {
            if(hed.nxt == hed)
            {
                hed = null; // only one node
            }
            else
            {
                nd tmp = hed;
                while(tmp.nxt != hed)
                {
                    tmp = tmp.nxt;
                }
                tmp.nxt = hed.nxt;
                hed = hed.nxt;
            }
            return;
        }

        nd cur = hed;
        nd prv = null;
        do
        {
            prv = cur;
            cur = cur.nxt;
            if(cur.id == iid)
            {
                prv.nxt = cur.nxt;
                return;
            }
        }while(cur != hed);

        Console.WriteLine("task with that id not found");
    }

    public static nd cur = null; // for viewing current task

    public static void viewCur()
    {
        if(cur == null)
        {
            if(hed == null)
            {
                Console.WriteLine("no tasks at all");
                return;
            }
            cur = hed; // start from head first time
        }

        Console.WriteLine("Current task -> ID: "+cur.id+" Name: "+cur.nam+" Pri: "+cur.pri+" Due: "+cur.due);
    }

    public static void nxtTask()
    {
        if(cur == null || hed == null)
        {
            Console.WriteLine("no task to move next");
            return;
        }
        cur = cur.nxt;
        // moved to next cuz its circular
    }

    public static void disAll()
    {
        if(hed == null)
        {
            Console.WriteLine("nothing to print, list empty");
            return;
        }

        nd tmp = hed;
        Console.WriteLine("All tasks in the list:");
        do
        {
            Console.WriteLine("ID: "+tmp.id+" , Name: "+tmp.nam+" , Priority: "+tmp.pri+" , Due Date: "+tmp.due);
            tmp = tmp.nxt;
        }while(tmp != hed);
    }

    public static void srchPri(int pp)
    {
        if(hed == null)
        {
            Console.WriteLine("list empty no search");
            return;
        }

        nd tmp = hed;
        bool fnd = false;
        Console.WriteLine("Tasks with priority "+pp+" :");
        do
        {
            if(tmp.pri == pp)
            {
                Console.WriteLine("ID: "+tmp.id+" Name: "+tmp.nam+" Due: "+tmp.due);
                fnd = true;
            }
            tmp = tmp.nxt;
        }while(tmp != hed);

        if(!fnd)
        {
            Console.WriteLine("no task with that priority found");
        }
    }

    public static void Main(string[] args) 
    {
        /*
        3. Circular Linked List: Task Scheduler
        Problem Statement: Create a task scheduler using a circular linked list. Each node in the list represents a task with Task ID, Task Name, Priority, and Due Date. Implement the following functionalities:

        * Add a task at the beginning, end, or at a specific position in the circular list.

        * Remove a task by Task ID.

        * View the current task and move to the next task in the circular list.

        * Display all tasks in the list starting from the head node.

        * Search for a task by Priority.
        */

        int ch = 0;
        while(ch != 9)
        {
            Console.WriteLine("\nWhat you wanna do?");
            Console.WriteLine("1 Add at beginning");
            Console.WriteLine("2 Add at end");
            Console.WriteLine("3 Add at position");
            Console.WriteLine("4 Remove by ID");
            Console.WriteLine("5 View current task");
            Console.WriteLine("6 Move to next task");
            Console.WriteLine("7 Print all tasks");
            Console.WriteLine("8 Search by priority");
            Console.WriteLine("9 Exit");
            
            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("Enter task id : ");
                int ii = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter task name : ");
                string nn = Console.ReadLine();
                Console.Write("Enter priority : ");
                int pp = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter due date : ");
                string dd = Console.ReadLine();

                adBeg(ii,nn,pp,dd);
            }
            else if(ch == 2)
            {
                Console.Write("Enter task id : ");
                int ii = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter task name : ");
                string nn = Console.ReadLine();
                Console.Write("Enter priority : ");
                int pp = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter due date : ");
                string dd = Console.ReadLine();

                adEnd(ii,nn,pp,dd);
            }
            else if(ch == 3)
            {
                Console.Write("Enter position (0 for begin) : ");
                int ps = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter task id : ");
                int ii = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter task name : ");
                string nn = Console.ReadLine();
                Console.Write("Enter priority : ");
                int pp = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter due date : ");
                string dd = Console.ReadLine();

                adPos(ps,ii,nn,pp,dd);
            }
            else if(ch == 4)
            {
                Console.Write("Enter id to remove : ");
                int ri = Convert.ToInt32(Console.ReadLine());
                remId(ri);
            }
            else if(ch == 5)
            {
                viewCur();
            }
            else if(ch == 6)
            {
                nxtTask();
            }
            else if(ch == 7)
            {
                disAll();
            }
            else if(ch == 8)
            {
                Console.Write("Enter priority to search : ");
                int sp = Convert.ToInt32(Console.ReadLine());
                srchPri(sp);
            }
        }
    }
}
