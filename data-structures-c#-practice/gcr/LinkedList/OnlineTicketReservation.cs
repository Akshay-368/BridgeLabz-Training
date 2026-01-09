using System;

public class tik 
{
    // node for ticket booking
    public struct tk 
    {
        public int tid;
        public string cnam;
        public string mnam;
        public string seat;
        public string btime;

        public tk nxt;
    }

    public static tk hed = null;

    public static void adEnd(int id,string cn,string mn,string st,string bt) 
    {
        tk nw = new tk();
        nw.tid = id;
        nw.cnam = cn;
        nw.mnam = mn;
        nw.seat = st;
        nw.btime = bt;

        if(hed == null)
        {
            nw.nxt = nw; // circle to self cuz first
            hed = nw;
            return;
        }

        tk tmp = hed;
        while(tmp.nxt != hed)
        {
            tmp = tmp.nxt;
        }
        tmp.nxt = nw;
        nw.nxt = hed;
        // added at end , circular link maintained
    }

    public static void remId(int rid)
    {
        if(hed == null)
        {
            Console.WriteLine("no tickets booked yet cant remove");
            return;
        }

        if(hed.tid == rid && hed.nxt == hed)
        {
            hed = null; // only one ticket
            Console.WriteLine("ticket cancelled");
            return;
        }

        tk tmp = hed;
        tk prv = null;

        do
        {
            if(tmp.tid == rid)
            {
                if(prv == null) // removing head
                {
                    tk last = hed;
                    while(last.nxt != hed) last = last.nxt;
                    last.nxt = hed.nxt;
                    hed = hed.nxt;
                }
                else
                {
                    prv.nxt = tmp.nxt;
                }
                Console.WriteLine("ticket with id "+rid+" cancelled");
                return;
            }
            prv = tmp;
            tmp = tmp.nxt;
        }while(tmp != hed);

        Console.WriteLine("ticket id not found");
    }

    public static void disAll()
    {
        if(hed == null)
        {
            Console.WriteLine("no bookings right now , list empty");
            return;
        }

        Console.WriteLine("All booked tickets:");
        tk tmp = hed;
        do
        {
            Console.WriteLine("Ticket ID: "+tmp.tid+" Customer: "+tmp.cnam+" Movie: "+tmp.mnam+" Seat: "+tmp.seat+" Time: "+tmp.btime);
            tmp = tmp.nxt;
        }while(tmp != hed);
    }

    public static void srchCnam(string scn)
    {
        if(hed == null)
        {
            Console.WriteLine("no tickets to search");
            return;
        }

        tk tmp = hed;
        bool fnd = false;
        Console.WriteLine("Tickets for customer containing \""+scn+"\":");
        do
        {
            if(tmp.cnam.ToLower().Contains(scn.ToLower()))
            {
                Console.WriteLine("ID: "+tmp.tid+" Movie: "+tmp.mnam+" Seat: "+tmp.seat+" Time: "+tmp.btime);
                fnd = true;
            }
            tmp = tmp.nxt;
        }while(tmp != hed);

        if(!fnd) Console.WriteLine("no ticket found for that customer");
    }

    public static void srchMnam(string smn)
    {
        if(hed == null)
        {
            Console.WriteLine("empty list cant search");
            return;
        }

        tk tmp = hed;
        bool fnd = false;
        Console.WriteLine("Tickets for movie containing \""+smn+"\":");
        do
        {
            if(tmp.mnam.ToLower().Contains(smn.ToLower()))
            {
                Console.WriteLine("ID: "+tmp.tid+" Customer: "+tmp.cnam+" Seat: "+tmp.seat+" Time: "+tmp.btime);
                fnd = true;
            }
            tmp = tmp.nxt;
        }while(tmp != hed);

        if(!fnd) Console.WriteLine("no bookings for that movie");
    }

    public static int totTik()
    {
        if(hed == null) return 0;

        int ct = 0;
        tk tmp = hed;
        do
        {
            ct++;
            tmp = tmp.nxt;
        }while(tmp != hed);

        return ct;
    }

    public static void Main(string[] args) 
    {
        /*
        9. Circular Linked List: Online Ticket Reservation System
        Problem Statement: Design an online ticket reservation system using a circular linked list, where each node represents a booked ticket. Each node will store the following information: Ticket ID, Customer Name, Movie Name, Seat Number, and Booking Time. Implement the following functionalities:

        * Add a new ticket reservation at the end of the circular list.

        * Remove a ticket by Ticket ID.

        * Display the current tickets in the list.

        * Search for a ticket by Customer Name or Movie Name.

        * Calculate the total number of booked tickets.
        */

        int ch = 0;
        while(ch != 7)
        {
            Console.WriteLine("\nOnline Ticket Reservation System");
            Console.WriteLine("1 Book new ticket");
            Console.WriteLine("2 Cancel ticket by ID");
            Console.WriteLine("3 Print all bookings");
            Console.WriteLine("4 Search by customer name");
            Console.WriteLine("5 Search by movie name");
            Console.WriteLine("6 Show total booked tickets");
            Console.WriteLine("7 Exit");

            Console.Write("Waiting , for user to enter the choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                Console.Write("Enter ticket id : ");
                int ti = Convert.ToInt32(Console.ReadLine());
                Console.Write("Enter customer name : ");
                string cn = Console.ReadLine();
                Console.Write("Enter movie name : ");
                string mn = Console.ReadLine();
                Console.Write("Enter seat number : ");
                string st = Console.ReadLine();
                Console.Write("Enter booking time (like 7:30 PM) : ");
                string bt = Console.ReadLine();

                adEnd(ti,cn,mn,st,bt);
                Console.WriteLine("Ticket booked succesfully");
            }
            else if(ch == 2)
            {
                Console.Write("Enter ticket id to cancel : ");
                int ri = Convert.ToInt32(Console.ReadLine());
                remId(ri);
            }
            else if(ch == 3)
            {
                disAll();
            }
            else if(ch == 4)
            {
                Console.Write("Enter customer name to search : ");
                string sc = Console.ReadLine();
                srchCnam(sc);
            }
            else if(ch == 5)
            {
                Console.Write("Enter movie name to search : ");
                string sm = Console.ReadLine();
                srchMnam(sm);
            }
            else if(ch == 6)
            {
                Console.WriteLine("Total booked tickets: "+totTik());
            }
        }
    }
}
