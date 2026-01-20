using System;
using System.Collections.Generic;

public class rotList 
{
    // rotate list by k positions to the left
    // we do it simple way - create new list
    public static void rotateList(List<int> numList,int rotateBy)
    {
        if(rotateBy <= 0 || numList.Count == 0)
        {
            Console.WriteLine("nothing to rotate");
            return;
        }

        // make rotateBy in range of list size
        rotateBy = rotateBy % numList.Count;

        // create new list for rotated result
        List<int> rotated = new List<int>();

        // first add from rotateBy to end
        for(int i=rotateBy; i<numList.Count ; i++)
        {
            rotated.Add(numList[i]);
        }

        // then add from start to rotateBy-1
        for(int i=0; i<rotateBy ; i++)
        {
            rotated.Add(numList[i]);
        }

        // now copy back to original list
        numList.Clear();
        for(int i=0; i<rotated.Count ; i++)
        {
            numList.Add(rotated[i]);
        }

        Console.WriteLine("list rotated by " + rotateBy);
    }

    public static void Main(string[] args) 
    {
        /*
        3. Rotate Elements in a List
        Rotate the elements of a list by a given number of positions.
        Example:
        Input: [10, 20, 30, 40, 50], rotate by 2
        Output: [30, 40, 50, 10, 20]
        */

        Console.WriteLine("Rotate List by k positions\n");

        Console.Write("Waiting , for user to enter how many numbers : ");
        int n = Convert.ToInt32(Console.ReadLine());

        List<int> numbers = new List<int>();

        Console.WriteLine("enter numbers:");
        for(int i=0; i<n ; i++)
        {
            Console.Write("number " + (i+1) + " : ");
            numbers.Add(Convert.ToInt32(Console.ReadLine()));
        }

        Console.Write("Waiting , for user to enter rotate positions (left) : ");
        int k = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine(" Before rotate:");
        foreach(int x in numbers) Console.Write(x + " ");
        Console.WriteLine();

        rotateList(numbers , k);

        Console.WriteLine("After rotate:");
        foreach(int x in numbers) Console.Write(x + " ");
        Console.WriteLine();

        Console.WriteLine(" Press any key...");
        Console.ReadKey();
    }
}
