using System;
using System.Collections.Generic;

public class nthEnd 
{
    // find nth from end without knowing size
    // we use two pointers
    public static int findNthFromEnd(LinkedList<int> linkList,int nFromEnd)
    {
        if(linkList.Count == 0)
        {
            Console.WriteLine("list empty");
            return -1;
        }

        if(nFromEnd <= 0 || nFromEnd > linkList.Count)
        {
            Console.WriteLine("invalid n , must be 1 to " + linkList.Count);
            return -1;
        }

        // first pointer moves n steps ahead
        LinkedListNode<int> fast = linkList.First;
        for(int i=1; i<nFromEnd ; i++)
        {
            fast = fast.Next;
        }

        // second pointer starts from beginning
        LinkedListNode<int> slow = linkList.First;

        // move both till fast reaches end
        while(fast.Next != null)
        {
            fast = fast.Next;
            slow = slow.Next;
        }

        Console.WriteLine("nth from end found: " + slow.Value);
        return slow.Value;
    }

    public static void Main(string[] args) 
    {
        /*
        5. Find the Nth Element from the End
        Given a singly linked list (LinkedList), find the Nth element from the end without calculating its size.
        Example:
        Input: [A, B, C, D, E], N=2
        Output: D
        */

        Console.WriteLine("Find Nth from End in LinkedList\n");

        Console.Write("Waiting , for user to enter how many numbers : ");
        int n = Convert.ToInt32(Console.ReadLine());

        LinkedList<int> link = new LinkedList<int>();

        Console.WriteLine("enter numbers:");
        for(int i=0; i<n ; i++)
        {
            Console.Write("number " + (i+1) + " : ");
            link.AddLast(Convert.ToInt32(Console.ReadLine()));
        }

        Console.Write("Waiting , for user to enter n from end (1 = last) : ");
        int k = Convert.ToInt32(Console.ReadLine());

        findNthFromEnd(link , k);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
