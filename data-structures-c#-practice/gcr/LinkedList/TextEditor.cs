using System;

public class txt 
{
    // node for text state
    public struct st 
    {
        public string con; // content of text at this state

        public st prv;
        public st nxt;
    }

    public static st cur = null; // current state pointer
    public static st hed = null; // head for limiting history
    public static int maxh = 10; // max history size
    public static int cnt = 0; // current count of states

    public static void adState(string nwtxt) 
    {
        st nw = new st();
        nw.con = nwtxt;
        nw.nxt = null;

        if(cur == null)
        {
            nw.prv = null;
            cur = nw;
            hed = nw;
            cnt = 1;
            return;
        }

        // if we are not at the end (after undo), cut off redo history
        if(cur.nxt != null)
        {
            cur.nxt = null; // remove future states
        }

        nw.prv = cur;
        cur.nxt = nw;
        cur = nw;

        cnt++;

        // if too many states , remove oldest from front
        if(cnt > maxh)
        {
            hed = hed.nxt;
            hed.prv = null;
            cnt--;
            // old head removed to keep only last 10
        }
    }

    public static void undo() 
    {
        if(cur == null || cur.prv == null)
        {
            Console.WriteLine("cant undo more , at oldest state");
            return;
        }

        cur = cur.prv;
        Console.WriteLine("Undo done");
    }

    public static void redo() 
    {
        if(cur == null || cur.nxt == null)
        {
            Console.WriteLine("nothing to redo");
            return;
        }

        cur = cur.nxt;
        Console.WriteLine("Redo done");
    }

    public static void disCur() 
    {
        if(cur == null)
        {
            Console.WriteLine("Text is empty right now");
            return;
        }

        Console.WriteLine("Current text:");
        Console.WriteLine(">>> " + cur.con + " <<<");
    }

    public static void Main(string[] args) 
    {
        /*
        8. Doubly Linked List: Undo/Redo Functionality for Text Editor
        Problem Statement: Design an undo/redo functionality for a text editor using a doubly linked list. Each node represents a state of the text content (e.g., after typing a word or performing a command). Implement the following:

        * Add a new text state at the end of the list every time the user types or performs an action.

        * Implement the undo functionality (revert to the previous state).

        * Implement the redo functionality (revert back to the next state after undo).

        * Display the current state of the text.

        * Limit the undo/redo history to a fixed size (e.g., last 10 states).
        */

        string init = "";
        adState(init); // start with empty

        int ch = 0;
        while(ch != 6)
        {
            Console.WriteLine("\nText Editor Undo/Redo");
            Console.WriteLine("1 Type new text (add state)");
            Console.WriteLine("2 Undo");
            Console.WriteLine("3 Redo");
            Console.WriteLine("4 Print current text");
            Console.WriteLine("5 Clear all and start fresh");
            Console.WriteLine("6 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            ch = Convert.ToInt32(Console.ReadLine());

            if(ch == 1)
            {
                disCur(); // show current first
                Console.Write("Enter new text to add (or append) : ");
                string nwt = Console.ReadLine();

                string full = "";
                if(cur != null)
                    full = cur.con + nwt; // simple append , like typing
                else
                    full = nwt;

                adState(full);
                Console.WriteLine("New state added");
            }
            else if(ch == 2)
            {
                undo();
            }
            else if(ch == 3)
            {
                redo();
            }
            else if(ch == 4)
            {
                disCur();
            }
            else if(ch == 5)
            {
                cur = null;
                hed = null;
                cnt = 0;
                adState(""); // fresh empty
                Console.WriteLine("All cleared , new start");
            }

            // always show current after action
            if(ch >=1 && ch <=4) disCur();
        }
    }
}
