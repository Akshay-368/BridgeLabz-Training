using System;
using System.Collections.Generic;

public class listMan 
{
    public static void addElement(List<int> lst,int val)
    {
        lst.Add(val);
        Console.WriteLine (" added " + val );
    }

    public static void removeElement(List<int> lst,int val)
    {
        if(lst.Contains(val))
        {
            lst.Remove(val);
            Console.WriteLine ( "removed " + val);
        }
        else
        {
            Console.WriteLine(val + " not found " );
        }
    }

    public static int getSize(List<int> lst)
    {
        return lst.Count;
    }

    public static void testList ()
    {
        List<int> testList = new List<int>();

        Console.WriteLine ( "initial size: " + getSize(testList));

        addElement(testList, 10);
        addElement(testList, 20);
        addElement(testList, 30);

        Console.WriteLine("size after adds: " + getSize(testList));

        removeElement(testList, 20);
        Console.WriteLine("size after remove: " + getSize(testList));

        Console.WriteLine("list now:");
        foreach(int x in testList)
        {
            Console.Write(x + " ");
        }
        Console.WriteLine();
    }

    public static void Main(string[] args) 
    {
        /*
        3. Testing List Operations
        Problem:
        Create a ListManager class that has the following methods:
        * AddElement(List<int> list, int element): Adds an element to a list.
        * RemoveElement(List<int> list, int element): Removes an element from a list.
        * GetSize(List<int> list): Returns the size of the list.
        Write NUnit or MSTest tests to verify that:
        ✅ Elements are correctly added.
        ✅ Elements are correctly removed.
        ✅ The size of the list is updated correctly.
        */

        Console.WriteLine("List Operations Tests ");

        testList();

        Console.WriteLine("Press any key...");
        Console.ReadKey();
    }
}
