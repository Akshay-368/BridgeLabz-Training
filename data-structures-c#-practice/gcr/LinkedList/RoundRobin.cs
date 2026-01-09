using System;

public class rr 
{
    // node for proces
    public struct pr 
    {
        public int pid;
        public int bur; // burst time
        public int pri;
        public int rem; // remaining time , same as bur at start
        public int wat; // waiting time
        public int tat; // turnaround time

        public pr nxt;
    }

    public static pr hed = null;

    public static void adEnd(int id,int bt,int prty) 
    {
        pr nw = new pr();
        nw.pid = id;
        nw.bur = bt;
        nw.pri = prty;
        nw.rem = bt; // remaining starts same
        nw.wat = 0;
        nw.tat = 0;

        if(hed == null)
        {
            nw.nxt = nw; // circle to self
            hed = nw;
            return;
        }

        pr tmp = hed;
        while(tmp.nxt != hed)
        {
            tmp = tmp.nxt;
        }
        tmp.nxt = nw;
        nw.nxt = hed;
        // added at end , circle ok
    }

    public static void remId(int rid)
    {
        if(hed == null)
        {
            Console.WriteLine("no process to remove");
            return;
        }

        if(hed.pid == rid && hed.nxt == hed)
        {
            hed = null; // only one
            return;
        }

        pr tmp = hed;
        pr prv = null;

        do
        {
            if(tmp.pid == rid)
            {
                if(prv == null) // head to remove
                {
                    pr last = hed;
                    while(last.nxt != hed) last = last.nxt;
                    last.nxt = hed.nxt;
                    hed = hed.nxt;
                }
                else
                {
                    prv.nxt = tmp.nxt;
                }
                return;
            }
            prv = tmp;
            tmp = tmp.nxt;
        }while(tmp != hed);

        Console.WriteLine("process id not found");
    }

    public static void disAll()
    {
        if(hed == null)
        {
            Console.WriteLine("queue empty nothing to print");
            return;
        }

        Console.WriteLine("Current processes in queue:");
        pr tmp = hed;
        do
        {
            Console.WriteLine("PID: "+tmp.pid+" Burst: "+tmp.bur+" Remaining: "+tmp.rem+" Priority: "+tmp.pri);
            tmp = tmp.nxt;
        }while(tmp != hed);
    }

    public static void simRR(int qtm)
    {
        if(hed == null)
        {
            Console.WriteLine("no processes to schedule");
            return;
        }

        pr cur = hed;
        int tot = 0; // total processes initially
        pr cnt = hed;
        do
        {
            tot++;
            cnt = cnt.nxt;
        }while(cnt != hed);

        int[] wt = new int[tot];
        int[] tt = new int[tot];
        int idx = 0;

        Console.WriteLine("Starting round robin with quantum "+qtm);

        bool done = false;
        while(!done)
        {
            done = true;

            cur = hed; // start from head each full round kinda
            do
            {
                if(cur.rem > 0)
                {
                    done = false; // still work left

                    int exe = (cur.rem > qtm) ? qtm : cur.rem;
                    Console.WriteLine("Executing PID "+cur.pid+" for "+exe+" units");
                    cur.rem -= exe;

                    // update waiting for others
                    pr oth = hed;
                    do
                    {
                        if(oth.pid != cur.pid && oth.rem > 0)
                        {
                            oth.wat += exe;
                        }
                        oth = oth.nxt;
                    }while(oth != hed);

                    if(cur.rem == 0)
                    {
                        cur.tat = cur.wat + cur.bur; // turnaround = wait + burst
                        Console.WriteLine("Process "+cur.pid+" finished");
                    }
                }

                cur = cur.nxt;
            }while(cur != hed && !done);

            disAll();
            Console.WriteLine("");
        }

        // calculate avg
        double sumWt = 0, sumTat = 0;
        pr tmp = hed;
        int c = 0;
        do
        {
            if(tmp.rem == 0)
            {
                sumWt += tmp.wat;
                sumTat += tmp.tat;
                c++;
            }
            tmp = tmp.nxt;
        }while(tmp != hed);

        if(c > 0)
        {
            Console.WriteLine("Average waiting time: "+ (sumWt / c));
            Console.WriteLine("Average turnaround time: "+ (sumTat / c));
        }
    }

    public static void Main(string[] args) 
    {
        /*
        6. Circular Linked List: Round Robin Scheduling Algorithm
        Problem Statement: Implement a round-robin CPU scheduling algorithm using a circular linked list. Each node will represent a process and contain Process ID, Burst Time, and Priority. Implement the following functionalities:

        * Add a new process at the end of the circular list.

        * Remove a process by Process ID after its execution.

        * Simulate the scheduling of processes in a round-robin manner with a fixed time quantum.

        * Display the list of processes in the circular queue after each round.

        * Calculate and display the average waiting time and turn-around time for all processes.
        */

        int ch = 0;
        int quan = 2; // default quantum

        while(ch != 5)
        {
            Console.WriteLine("\nRound Robin Menu:");
            Console.WriteLine("1 Add process");
            Console.WriteLine("2 Set time quantum");
            Console.WriteLine("3 Print current queue");
            Console.WriteLine("4 Start simulation");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("Enter process id : ");
                int pi = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter burst time : ");
                int bt = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter priority : ");
                int pr = Convert.ToInt32(Console.ReadLine());

                adEnd(pi,bt,pr);
            }
            else if(ch == 2)
            {
                Console.Write("Enter new time quantum : ");
                quan = Convert.ToInt32(Console.ReadLine());
                Console.WriteLine("Quantum set to "+quan);
            }
            else if(ch == 3)
            {
                disAll();
            }
            else if(ch == 4)
            {
                simRR(quan);
            }
        }
    }
}
