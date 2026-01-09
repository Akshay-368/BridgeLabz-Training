using System;

public class lib 
{
    // node for book stuff
    public struct bk 
    {
        public string tit;
        public string aut;
        public string gen;
        public int id;
        public bool avl;  // true if available

        public bk prv;
        public bk nxt;
    }

    public static bk hed = null;

    public static void adBeg(string t,string a,string g,int i,bool av) 
    {
        bk nw = new bk();
        nw.tit = t;
        nw.aut = a;
        nw.gen = g;
        nw.id = i;
        nw.avl = av;

        if(hed == null)
        {
            nw.prv = null;
            nw.nxt = null;
            hed = nw;
        }
        else
        {
            nw.nxt = hed;
            nw.prv = null;
            hed.prv = nw;
            hed = nw; // new head now
        }
        // added at start, doubly links updated
    }

    public static void adEnd(string t,string a,string g,int i,bool av)
    {
        bk nw = new bk();
        nw.tit = t;
        nw.aut = a;
        nw.gen = g;
        nw.id = i;
        nw.avl = av;
        nw.nxt = null;

        if(hed == null)
        {
            nw.prv = null;
            hed = nw;
            return;
        }

        bk tmp = hed;
        while(tmp.nxt != null)
        {
            tmp = tmp.nxt;
        }
        tmp.nxt = nw;
        nw.prv = tmp;
        // added at the end , links fixed
    }

    public static void adPos(int pos,string t,string a,string g,int i,bool av)
    {
        if(pos == 0)
        {
            adBeg(t,a,g,i,av);
            return;
        }

        bk nw = new bk();
        nw.tit = t;
        nw.aut = a;
        nw.gen = g;
        nw.id = i;
        nw.avl = av;

        bk tmp = hed;
        for(int k=0; k<pos-1; k++)
        {
            if(tmp == null) break;
            tmp = tmp.nxt;
        }

        if(tmp == null || tmp.nxt == null)
        {
            adEnd(t,a,g,i,av); // if pos too big just add end
            return;
        }

        nw.nxt = tmp.nxt;
        nw.prv = tmp;
        tmp.nxt.prv = nw;
        tmp.nxt = nw;
        // inserted at given pos , both links set
    }

    public static void remId(int rid)
    {
        if(hed == null)
        {
            Console.WriteLine("no books to remove , list empty");
            return;
        }

        bk tmp = hed;
        while(tmp != null)
        {
            if(tmp.id == rid)
            {
                if(tmp.prv != null)
                    tmp.prv.nxt = tmp.nxt;
                else
                    hed = tmp.nxt; // head change

                if(tmp.nxt != null)
                    tmp.nxt.prv = tmp.prv;

                Console.WriteLine("book removed");
                return;
            }
            tmp = tmp.nxt;
        }
        Console.WriteLine("book with that id not found");
    }

    public static void srchTit(string st)
    {
        if(hed == null)
        {
            Console.WriteLine("library empty cant search");
            return;
        }

        bk tmp = hed;
        bool fnd = false;
        Console.WriteLine("Books with title containing \""+st+"\":");
        while(tmp != null)
        {
            if(tmp.tit.ToLower().Contains(st.ToLower()))
            {
                printBk(tmp);
                fnd = true;
            }
            tmp = tmp.nxt;
        }
        if(!fnd) Console.WriteLine("nothing found");
    }

    public static void srchAut(string sa)
    {
        if(hed == null)
        {
            Console.WriteLine("no books here");
            return;
        }

        bk tmp = hed;
        bool fnd = false;
        Console.WriteLine("Books by author containing \""+sa+"\":");
        while(tmp != null)
        {
            if(tmp.aut.ToLower().Contains(sa.ToLower()))
            {
                printBk(tmp);
                fnd = true;
            }
            tmp = tmp.nxt;
        }
        if(!fnd) Console.WriteLine("no match");
    }

    public static void updAvl(int uid,bool nav)
    {
        bk tmp = hed;
        while(tmp != null)
        {
            if(tmp.id == uid)
            {
                tmp.avl = nav;
                Console.WriteLine("availability updated for book id "+uid);
                return;
            }
            tmp = tmp.nxt;
        }
        Console.WriteLine("book id not found cant update");
    }

    public static void disFwd()
    {
        if(hed == null)
        {
            Console.WriteLine("library has no books");
            return;
        }

        Console.WriteLine("All books forward order:");
        bk tmp = hed;
        while(tmp != null)
        {
            printBk(tmp);
            tmp = tmp.nxt;
        }
    }

    public static void disRev()
    {
        if(hed == null)
        {
            Console.WriteLine("no books to print reverse");
            return;
        }

        // first go to last node
        bk tmp = hed;
        while(tmp.nxt != null)
        {
            tmp = tmp.nxt;
        }

        Console.WriteLine("All books reverse order:");
        while(tmp != null)
        {
            printBk(tmp);
            tmp = tmp.prv;
        }
    }

    public static void printBk(bk b)
    {
        string stat = b.avl ? "Available" : "Borrowed";
        Console.WriteLine("ID: "+b.id+" Title: "+b.tit+" Author: "+b.aut+" Genre: "+b.gen+" Status: "+stat);
    }

    public static int cntBk()
    {
        int ct = 0;
        bk tmp = hed;
        while(tmp != null)
        {
            ct++;
            tmp = tmp.nxt;
        }
        return ct;
    }

    public static void Main(string[] args) 
    {
        /*
        5. Doubly Linked List: Library Management System
        Problem Statement: Design a library management system using a doubly linked list. Each node represents a book and contains the following attributes: Book Title, Author, Genre, Book ID, and Availability Status. Implement the following functionalities:

        * Add a new book at the beginning, end, or at a specific position.

        * Remove a book by Book ID.

        * Search for a book by Book Title or Author.

        * Update a book’s Availability Status.

        * Display all books in forward and reverse order.

        * Count the total number of books in the library.
        */

        int ch = 0;
        while(ch != 9)
        {
            Console.WriteLine("\nLibrary Menu:");
            Console.WriteLine("1 Add book beginning");
            Console.WriteLine("2 Add book end");
            Console.WriteLine("3 Add book at position");
            Console.WriteLine("4 Remove book by ID");
            Console.WriteLine("5 Search by Title");
            Console.WriteLine("6 Search by Author");
            Console.WriteLine("7 Update availability");
            Console.WriteLine("8 Print forward , reverse and count");
            Console.WriteLine("9 Exit");

            Console.Write("Waiting , for user to enter the choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1 || ch == 2 || ch == 3)
            {
                Console.Write("Enter book title : ");
                string tt = Console.ReadLine();
                Console.Write("Enter author name : ");
                string aa = Console.ReadLine();
                Console.Write("Enter genre : ");
                string gg = Console.ReadLine();
                Console.Write("Enter book id : ");
                int ii = Convert.ToInt32(Console.ReadLine());
                Console.Write("Is it available (1 yes 0 no) : ");
                int avin = Convert.ToInt32(Console.ReadLine());
                bool avv = (avin == 1);

                if(ch == 1) adBeg(tt,aa,gg,ii,avv);
                else if(ch == 2) adEnd(tt,aa,gg,ii,avv);
                else 
                {
                    Console.Write("Enter position : ");
                    int ps = Convert.ToInt32(Console.ReadLine());
                    adPos(ps,tt,aa,gg,ii,avv);
                }
            }
            else if(ch == 4)
            {
                Console.Write("Enter book id to remove : ");
                int ri = Convert.ToInt32(Console.ReadLine());
                remId(ri);
            }
            else if(ch == 5)
            {
                Console.Write("Enter title to search : ");
                string st = Console.ReadLine();
                srchTit(st);
            }
            else if(ch == 6)
            {
                Console.Write("Enter author to search : ");
                string sa = Console.ReadLine();
                srchAut(sa);
            }
            else if(ch == 7)
            {
                Console.Write("Enter book id : ");
                int ui = Convert.ToInt32(Console.ReadLine());
                Console.Write("New status (1 available 0 borrowed) : ");
                int navin = Convert.ToInt32(Console.ReadLine());
                bool nav = (navin == 1);
                updAvl(ui,nav);
            }
            else if(ch == 8)
            {
                disFwd();
                Console.WriteLine("\n");
                disRev();
                Console.WriteLine("\nTotal books in library: "+cntBk());
            }
        }
    }
}
