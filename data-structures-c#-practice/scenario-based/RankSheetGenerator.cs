using System;

// simple node for linked list (we will use this instead of any collection)
public class Node 
{
    public int marks;       // student marks
    public string name;     // student name
    public Node next;       // next student in list

    public Node(int m,string n)
    {
        marks = m;
        name = n;
        next = null;
    }
}

public class rankGen 
{
    // this function merges two sorted linked lists
    // we compare marks , if equal we keep original order (stable)
    public static Node mergeTwoLists(Node list1,Node list2)
    {
        // dummy head to make merging easy
        Node dummy = new Node(0,"");
        Node current = dummy;

        while(list1 != null && list2 != null)
        {
            if(list1.marks >= list2.marks) // higher marks first
            {
                current.next = list1;
                list1 = list1.next;
            }
            else
            {
                current.next = list2;
                list2 = list2.next;
            }
            current = current.next;
        }

        // add remaining nodes
        if(list1 != null)
        {
            current.next = list1;
        }
        if(list2 != null)
        {
            current.next = list2;
        }

        return dummy.next;
    }

    // merge sort on linked list
    // we divide list into two halves , sort each , then merge
    public static Node mergeSortLinked(Node head)
    {
        // base case - empty or single node
        if(head == null || head.next == null)
        {
            return head;
        }

        // find middle using slow-fast pointer
        Node slow = head;
        Node fast = head;
        Node prev = null;

        while(fast != null && fast.next != null)
        {
            prev = slow;
            slow = slow.next;
            fast = fast.next.next;
        }

        // split list into two
        prev.next = null;

        // sort both halves
        Node leftSorted = mergeSortLinked(head);
        Node rightSorted = mergeSortLinked(slow);

        // merge them
        return mergeTwoLists(leftSorted , rightSorted);
    }

    // helper to print linked list
    public static void printRankList(Node head)
    {
        Console.WriteLine("Final State-wise Rank List (Highest marks first):");
        Node temp = head;
        int rank = 1;

        while(temp != null)
        {
            Console.WriteLine("Rank " + rank + " : " + temp.name + " - " + temp.marks);
            temp = temp.next;
            rank++;
        }
    }

    public static void Main(string[] args) 
    {
        /*
        EduResults – Rank Sheet Generator (Merge Sort)
        Story: An educational board compiles marks of thousands of students from different districts.
        Each district submits a sorted list of students by score. The main server needs to merge and
        sort all these lists into a final state-wise rank list. Merge Sort ensures efficiency and maintains
        stability for duplicate scores.
        Concepts Involved:
        ● Merge Sort
        ● Merging sorted sublists
        ● Large datasets with stable sorting
        */

        Console.WriteLine("EduResults - Rank Sheet Generator (Merge Sort)\n");

        Console.Write("Waiting , for user to enter how many districts : ");
        int districtCount = Convert.ToInt32(Console.ReadLine());

        Node finalHead = null; // final merged list

        for(int d=1; d<=districtCount ; d++)
        {
            Console.WriteLine("\nDistrict " + d + ":");

            Console.Write("Waiting , for user to enter how many students in this district : ");
            int studentCount = Convert.ToInt32(Console.ReadLine());

            Node districtHead = null;
            Node current = null;

            Console.WriteLine("enter students (name marks) - higher marks better:");
            for(int s=0; s<studentCount ; s++)
            {
                Console.Write("student " + (s+1) + " name : ");
                string name = Console.ReadLine();

                Console.Write("marks : ");
                int marks = Convert.ToInt32(Console.ReadLine());

                Node newNode = new Node(marks, name);

                // add to district list (we assume districts give sorted but we will merge anyway)
                if(districtHead == null)
                {
                    districtHead = newNode;
                    current = newNode;
                }
                else
                {
                    current.next = newNode;
                    current = newNode;
                }
            }

            // merge this district to final list
            finalHead = mergeTwoLists(finalHead , districtHead);
        }

        // final sort (though merge already sorted , but for safety)
        finalHead = mergeSortLinked(finalHead);

        Console.WriteLine("\nAll districts merged and sorted!\n");

        printRankList(finalHead);

        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
