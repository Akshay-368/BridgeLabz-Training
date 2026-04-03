using System;
using System.Collections.Generic;

public class revList 
{
    // reverse arraylist without using built-in reverse
    public static void reverseArrayList(List<int> arrList)
    {
        // we use two pointers approach
        // left starts from 0 , right from last
        int left = 0;
        int right = arrList.Count - 1;

        while(left < right)
        {
            // swap left and right elements
            int temp = arrList[left];
            arrList[left] = arrList[right];
            arrList[right] = temp;

            left++;
            right--;
        }

        Console.WriteLine("ArrayList reversed manually");
    }

    // reverse linkedlist without built-in reverse
    public static void reverseLinkedList(LinkedList<int> linkList)
    {
        // we will use stack like approach but simple loop
        // actually easiest way is to create new list and add from end
        LinkedList<int> tempList = new LinkedList<int>();

        // go from last to first
        LinkedListNode<int> current = linkList.Last;

        while(current != null)
        {
            tempList.AddLast(current.Value);
            current = current.Previous;
        }

        // now clear original and add from temp
        linkList.Clear();

        current = tempList.First;
        while(current != null)
        {
            linkList.AddLast(current.Value);
            current = current.Next;
        }

        Console.WriteLine("LinkedList reversed manually");
    }

    public static void Main(string[] args) 
    {
        /*
        List Interface Problems
        1. Reverse a List
        Write a program to reverse the elements of a given list without using built-in reverse methods. Implement it for both ArrayList and LinkedList.
        Example:
        Input: [1, 2, 3, 4, 5]
        Output: [5, 4, 3, 2, 1]
        */

        Console.WriteLine("Reverse List without built-in reverse\n");

        Console.Write("Waiting , for user to enter how many numbers : ");
        int n = Convert.ToInt32(Console.ReadLine());

        List<int> arrayList = new List<int>();
        LinkedList<int> linkedList = new LinkedList<int>();

        Console.WriteLine("enter numbers:");
        for(int i=0; i<n ; i++)
        {
            Console.Write("number " + (i+1) + " : ");
            int num = Convert.ToInt32(Console.ReadLine());

            arrayList.Add(num);
            linkedList.AddLast(num);
        }

        Console.WriteLine(" Before reverse:");
        Console.Write("ArrayList: ");
        foreach(int x in arrayList) Console.Write(x + " ");
        Console.WriteLine();

        Console.Write("LinkedList: ");
        foreach(int x in linkedList) Console.Write(x + " ");
        Console.WriteLine();

        // reverse both
        reverseArrayList(arrayList);
        reverseLinkedList(linkedList);

        Console.WriteLine(" After reverse:");
        Console.Write("ArrayList: ");
        foreach(int x in arrayList) Console.Write(x + " ");
        Console.WriteLine();

        Console.Write("LinkedList: ");
        foreach(int x in linkedList) Console.Write(x + " ");
        Console.WriteLine();

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
