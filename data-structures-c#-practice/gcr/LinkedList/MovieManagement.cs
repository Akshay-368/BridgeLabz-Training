using System;

/*
The current date is January 08, 2026.

2. Doubly Linked List: Movie Management System
Problem Statement: Implement a movie management system using a doubly linked list. Each node will represent a movie and contain Movie Title, Director, Year of Release, and Rating. Implement the following functionalities:

* Add a movie record at the beginning, end, or at a specific position.

* Remove a movie record by Movie Title.

* Search for a movie record by Director or Rating.

* Display all movie records in both forward and reverse order.

* Update a movie's Rating based on the Movie Title.
*/

public abstract class AbsMov  
{
    // this is base for movie data , we keep it abstract so no one makes direct obj
    public string Titl { get;  set; }
    public string Dir { get; set; }
    public int Yr { get; set; }
    public double Rat { get; set; }

    protected AbsMov(string t, string d, int y, double r)
    {
        Titl = t;
        Dir = d;
        Yr = y;
        Rat = r;
    }
}

public interface IMovOp
{
    // interface to force methods , makes code more secure kinda
    void AddBeg(string t, string d, int y, double r);
    void AddEnd(string t, string d, int y, double r);
    void AddPos(int pos, string t, string d, int y, double r);
    void Rem(string t);
    void SrchDir(string d);
    void SrchRat(double r);
    void UpdRat(string t, double nr);
    void PrFwd();
    void PrRev();
}

public class Mov : AbsMov
{
    // actual node , has next and prev for doubly link
    public Mov Next;
    public Mov Prev;

    public Mov(string t, string d, int y, double r) : base(t, d, y, r)
    {
        Next = null;
        Prev = null;
    }
}

public class MovMgr : IMovOp
{
    private static Mov head;  // head of list , private for encapsulation

    public static void Main(string[] args)
    {
        head = null;
        // simple menu loop , nothing fancy
        while(true) 
        {
            Console.WriteLine("\n=== Movie Managment System ===");
            Console.WriteLine("1. Add at begining");
            Console.WriteLine("2. Add at end ");
            Console.WriteLine("3. Add at position");
            Console.WriteLine("4. Remove by title");
            Console.WriteLine("5. Search by director");
            Console.WriteLine("6. Search by rating ");
            Console.WriteLine("7. Update rating");
            Console.WriteLine("8. Print forward");
            Console.WriteLine("9. Print reverse");
            Console.WriteLine("0. Exit");
            
            Console.Write("Enter your choise : ");
            string ch = Console.ReadLine();
            
            if(ch == "0") break;

            switch(ch)
            {
                case "1":
                    AddBegHelpr();
                    break;
                case "2":
                    AddEndHelpr();
                    break;
                case "3":
                    AddPosHelpr();
                    break;
                case "4":
                    RemHelpr();
                    break;
                case "5":
                    SrchDirHelpr();
                    break;
                case "6":
                    SrchRatHelpr();
                    break;
                case "7":
                    UpdRatHelpr();
                    break;
                case "8":
                    PrFwd();
                    break;
                case "9":
                    PrRev();
                    break;
                default:
                    Console.WriteLine("Wrong choise , try again");
                    break;
            }
        }
    }

    // helper to avoid repeat code when waiting for user to enter the inupt
    private static void GetMovData(out string t, out string d, out int y, out double r)
    {
        Console.Write("Enter movie title : ");
        t = Console.ReadLine();

        Console.Write(" Enter director name : ");
        d = Console.ReadLine();

        Console.Write(" Enter year of release : ");
        while(!int.TryParse(Console.ReadLine(), out y))
        {
            Console.Write(" Bad year , enter again : ");
        }

        Console.Write(" Enter rating (0-10) : ");
        while(!double.TryParse(Console.ReadLine(), out r) || r < 0 || r > 10)
        {
            Console.Write(" Bad rating , enter again : ");
        }
    }

    private static void AddBegHelpr()
    {
        GetMovData(out string t, out string d, out int y, out double r);
        new MovMgr().AddBeg(t, d, y, r);  // using interface ref but actual obj
    }

    private static void AddEndHelpr()
    {
        GetMovData(out string t, out string d, out int y, out double r);
        new MovMgr().AddEnd(t, d, y, r);
    }

    private static void AddPosHelpr()
    {
        Console.Write("Enter position (1 based) : ");
        if(int.TryParse(Console.ReadLine(), out int pos) && pos > 0)
        {
            GetMovData(out string t, out string d, out int y, out double r);
            new MovMgr().AddPos(pos, t, d, y, r);
        }
        else
        {
            Console.WriteLine("Invalid position");
        }
    }

    private static void RemHelpr()
    {
        Console.Write("Enter title to remove : ");
        string t = Console.ReadLine();
        new MovMgr().Rem(t);
    }

    private static void SrchDirHelpr()
    {
        Console.Write("Enter director to search : ");
        string d = Console.ReadLine();
        new MovMgr().SrchDir(d);
    }

    private static void SrchRatHelpr()
    {
        Console.Write("Enter rating to search : ");
        if(double.TryParse(Console.ReadLine(), out double r))
        {
            new MovMgr().SrchRat(r);
        }
    }

    private static void UpdRatHelpr()
    {
        Console.Write("Enter title to update : ");
        string t = Console.ReadLine();

        Console.Write("Enter new rating : ");
        if(double.TryParse(Console.ReadLine(), out double nr))
        {
            new MovMgr().UpdRat(t, nr);
        }
    }

    public void AddBeg(string t, string d, int y, double r)
    {
        // adding new movie at start
        Mov nw = new Mov(t, d, y, r);

        if(head == null)
        {
            head = nw;
        }
        else
        {
            nw.Next = head;
            head.Prev = nw;
            head = nw;
        }

        Console.WriteLine("Added at begining succesfully");
    }

    public void AddEnd(string t, string d, int y, double r)
    {
        Mov nw = new Mov(t, d, y, r);

        if(head == null)
        {
            head = nw;
        }
        else
        {
            Mov tmp = head;
            while(tmp.Next != null)
            {
                tmp = tmp.Next;
            }

            tmp.Next = nw;
            nw.Prev = tmp;
        }

        Console.WriteLine("Added at end ok");
    }

    public void AddPos(int pos, string t, string d, int y, double r)
    {
        if(pos == 1)
        {
            AddBeg(t, d, y, r);
            return;
        }

        Mov nw = new Mov(t, d, y, r);
        Mov tmp = head;
        int cnt = 1;

        while(tmp != null && cnt < pos-1)
        {
            tmp = tmp.Next;
            cnt++;
        }

        if(tmp == null)
        {
            Console.WriteLine("Position too big , adding at end instead");
            AddEnd(t, d, y, r);
            return;
        }

        nw.Next = tmp.Next;
        nw.Prev = tmp;

        if(tmp.Next != null)
        {
            tmp.Next.Prev = nw;
        }

        tmp.Next = nw;

        Console.WriteLine("Inserted at position " + pos);
    }

    public void Rem(string t)
    {
        if(head == null)
        {
            Console.WriteLine("List empty , nothing to remove");
            return;
        }

        Mov tmp = head;

        while(tmp != null && tmp.Titl != t)
        {
            tmp = tmp.Next;
        }

        if(tmp == null)
        {
            Console.WriteLine("Movie with title " + t + " not found");
            return;
        }

        // found it , now remove
        if(tmp.Prev != null)
        {
            tmp.Prev.Next = tmp.Next;
        }
        else
        {
            head = tmp.Next;
        }

        if(tmp.Next != null)
        {
            tmp.Next.Prev = tmp.Prev;
        }

        Console.WriteLine("Removed " + t + " successfully");
    }

    public void SrchDir(string d)
    {
        if(head == null)
        {
            Console.WriteLine("No movies yet");
            return;
        }

        Mov tmp = head;
        bool fnd = false;

        Console.WriteLine("\nMovies by director " + d + " :");

        while(tmp != null)
        {
            if(tmp.Dir == d)
            {
                PrOne(tmp);
                fnd = true;
            }

            tmp = tmp.Next;
        }

        if(!fnd)
        {
            Console.WriteLine("No movie found with that director");
        }
    }

    public void SrchRat(double r)
    {
        if(head == null)
        {
            Console.WriteLine("List is empty");
            return;
        }

        Mov tmp = head;
        bool fnd = false;

        Console.WriteLine("\nMovies with rating " + r + " :");

        while(tmp != null)
        {
            if(tmp.Rat == r)
            {
                PrOne(tmp);
                fnd = true;
            }

            tmp = tmp.Next;
        }

        if(!fnd)
        {
            Console.WriteLine("No movie with that rating");
        }
    }

    public void UpdRat(string t, double nr)
    {
        if(head == null)
        {
            Console.WriteLine("Empty list");
            return;
        }

        Mov tmp = head;

        while(tmp != null && tmp.Titl != t)
        {
            tmp = tmp.Next;
        }

        if(tmp == null)
        {
            Console.WriteLine("Title not found");
            return;
        }

        tmp.Rat = nr;
        Console.WriteLine("Rating updated for " + t);
    }

    public void PrFwd()
    {
        if(head == null)
        {
            Console.WriteLine("No movies to print");
            return;
        }

        Console.WriteLine("\nPrinting all movies forward :");

        Mov tmp = head;
        while(tmp != null)
        {
            PrOne(tmp);
            tmp = tmp.Next;
        }
    }

    public void PrRev()
    {
        if(head == null)
        {
            Console.WriteLine("No movies to print");
            return;
        }

        // first go to last node
        Mov tmp = head;
        while(tmp.Next != null)
        {
            tmp = tmp.Next;
        }

        Console.WriteLine("\nPrinting all movies reverse :");

        while(tmp != null)
        {
            PrOne(tmp);
            tmp = tmp.Prev;
        }
    }

    // small helper to print one movie , avoids repeat code
    private static void PrOne(Mov m)
    {
        Console.WriteLine("Title: " + m.Titl + " | Director: " + m.Dir + " | Year: " + m.Yr + " | Rating: " + m.Rat);
    }
}
