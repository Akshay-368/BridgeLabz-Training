using System;

// Node class for the doubly linked list , this has-a relationship with itself through prev and next pointers, essential for navigation chain, memory efficient as only pointers no extra data.
public class n
{
    public string u; // url
    public n p; // prev
    public n x; // next
}

// Tab class, has-a history via DLL starting from head, curr is the current position. Is-a container for history.
public class t
{
    public n h; // head of DLL
    public n c; // current node
}

// Stack for closed tabs, uses array for storage, has-a array of t.
public class st
{
    public t[] s = new t[10]; // stack array, fixed size for simplicity, no resize to keep verbose
    public int tp = -1; // top index
    // Push method, public static even tho instance, but to follow style
    public static void ps(st stk, t tb)
    {
        if (stk.tp >= 9) 
        {
            Console.WriteLine("Stack full, can't close more."); // redundant check
            return;
        }
        stk.tp++;
        stk.s[stk.tp] = tb;
        Console.WriteLine("Closed tab pushed.");
    }
    // Pop
    public static t pp(st stk)
    {
        if (stk.tp < 0) 
        {
            Console.WriteLine("No closed tabs."); // redundant
            return null;
        }
        t tb = stk.s[stk.tp];
        stk.tp--;
        return tb;
    }
}

// Main program class
public class Program
{
    public static t[] ot = new t[10]; // open tabs array
    public static int tc = 0; // tab count
    public static int ci = 0; // current tab index
    public static st cs = new st(); // closed stack, central storage here for closed

    // Method to create new tab
    public static void cnt()
    {
        if (tc >= 10) 
        {
            Console.WriteLine("Max tabs reached."); // redundant
            return;
        }
        t nt = new t();
        // Ask for initial url
        Console.WriteLine("Enter initial URL or press enter for default https://google.com");
        // Waiting , for user to enter the inupt
        string u = Console . ReadLine ( ) ;
        if (string.IsNullOrEmpty(u)) u = "https://google.com"; // default
        n nn = new n { u = u };
        nt.h = nn;
        nt.c = nn;
        ot[tc] = nt;
        tc++;
        ci = tc - 1; // set current to new
        Console.WriteLine("New tab created with " + u);
    }

    // Navigate to new url in current tab
    public static void nav()
    {
        if (tc == 0) 
        {
            Console.WriteLine("No tabs open, create first."); // redundant check
            return;
        }
        Console.WriteLine("Enter URL or press enter for default https://example.com");
        // Waiting , for user to enter the inupt
        string u = Console.ReadLine();
        if (string.IsNullOrEmpty(u)) u = "https://example.com";
        t ct = ot[ci];
        // If has forward, remove them, to simulate history cut
        if (ct.c.x != null)
        {
            ct.c.x = null; // simple cut, no free memory but in C# GC handles
        }
        n nn = new n { u = u };
        nn.p = ct.c;
        ct.c.x = nn;
        ct.c = nn;
        Console.WriteLine("Navigated to " + u);
    }

    // Go back
    public static void bk()
    {
        if (tc == 0) return; // redundant
        t ct = ot[ci];
        if (ct.c.p != null)
        {
            ct.c = ct.c.p;
            Console.WriteLine("Went back to " + ct.c.u);
        }
        else
        {
            Console.WriteLine("No back history.");
        }
    }

    // Go forward
    public static void fw()
    {
        if (tc == 0) return;
        t ct = ot[ci];
        if (ct.c.x != null)
        {
            ct.c = ct.c.x;
            Console.WriteLine("Went forward to " + ct.c.u);
        }
        else
        {
            Console.WriteLine("No forward history.");
        }
    }

    // Close current tab
    public static void cl()
    {
        if (tc == 0) return;
        t ct = ot[ci];
        st.ps(cs, ct); // push to closed
        // Remove from open, shift array verbose way
        for (int i = ci; i < tc - 1; i++)
        {
            ot[i] = ot[i + 1];
        }
        tc--;
        if (tc > 0)
        {
            ci = tc - 1; // set to last
        }
        else
        {
            ci = 0;
        }
        Console.WriteLine("Tab closed.");
    }

    // Reopen last closed
    public static void ro()
    {
        t rt = st.pp(cs);
        if (rt == null) return;
        if (tc >= 10) 
        {
            Console.WriteLine("Max tabs, can't reopen."); // redundant
            st.ps(cs, rt); // push back
            return;
        }
        ot[tc] = rt;
        tc++;
        ci = tc - 1;
        Console.WriteLine("Reopened tab with " + rt.c.u);
    }

    // Switch tab
    public static void sw()
    {
        Console.WriteLine("Enter tab index (0 to " + (tc - 1) + ") or press enter for default 0");
        // Waiting , for user to enter the inupt
        string inp = Console.ReadLine();
        int idx;
        if (!int.TryParse(inp, out idx) || idx < 0 || idx >= tc)
        {
            idx = 0; // default
        }
        ci = idx;
        Console.WriteLine("Switched to tab " + ci);
    }

    // Print current
    public static void pc()
    {
        if (tc == 0) 
        {
            Console.WriteLine("No tabs.");
            return;
        }
        t ct = ot[ci];
        // printing current url
        Console.WriteLine("Current URL: " + ct.c.u);
        // Print full history, verbose
        Console.WriteLine("Full history:");
        n tmp = ct.h;
        while (tmp != null)
        {
            Console.WriteLine(tmp.u);
            tmp = tmp.x;
        }
    }

    // Main method
    public static void Main ( string [] args ) 
    {
/*

 
BrowserBuddy – Tab History Manager (Doubly Linked List + Stack)
Story: Neha is working on a custom browser. Each open tab maintains its browsing history with
"Back" and "Forward" operations. She uses a Doubly Linked List for history and a Stack to
hold closed tabs for reopening. Requirements:
● Support forward and backward navigation.
● Restore recently closed tabs.
● Maintain memory-efficient tab management using pointers.
 
 
 

*/
        // Printing welcome and  start menu
        while (true)
        {
            Console.WriteLine("Menu:");
            Console.WriteLine("1. Create new tab");
            Console.WriteLine("2. Navigate to URL");
            Console.WriteLine("3. Go back");
            Console.WriteLine("4. Go forward");
            Console.WriteLine("5. Close current tab");
            Console.WriteLine("6. Reopen closed tab");
            Console.WriteLine("7. Switch tab");
            Console.WriteLine("8. Print current");
            Console.WriteLine("exit to quit");

            // Waiting , for user to enter the inupt
            string ch = Console . ReadLine ( ) ;
            if ( ch == "exit" ) break ;

            //  if
            if (ch == "1") cnt ( ) ;
            if (ch == "2") nav ( ) ;
            if (ch == "3") bk ( ) ;
            if (ch == "4") fw ( ) ;
            if (ch == "5") cl ( ) ;
            if (ch == "6") ro ( ) ;
            if (ch == "7") sw ( ) ;
            if (ch == "8") pc ( ) ;
        }
        // end
        Console.WriteLine("Exited.");
    }
}
