using System;

public class multiEx 
{
    // this function tries to get value at given index from array
    // handle two possible exceptions
    public static void getValueAtIndex(int[] arr,int index)
    {
        if(arr == null)
        {
            Console.WriteLine("Array is not initialized!");
            return;
        }

        try
        {
            int value = arr[index];
            Console.WriteLine("Value at index " + index + " : " + value);
        }
        catch(IndexOutOfRangeException ioor)
        {
            Console.WriteLine("Invalid index!");
            Console.WriteLine("(details: " + ioor.Message + ")");
        }
        catch(Exception anyEx)
        {
            Console.WriteLine("some other error : " + anyEx.Message);
        }
    }

    public static void Main(string[] args) 
    {
        /*
        4. Handling Multiple Exceptions
        💡 Problem Statement:
        Create a C# program that performs array operations.
        * Accept an integer array and an index number.
        * Retrieve and print the value at that index.
        * Handle the following exceptions:
          * IndexOutOfRangeException if the index is out of range.
          * NullReferenceException if the array is null.
        Expected Behavior:
        * If valid, print "Value at index X: Y".
        * If the index is out of bounds, display "Invalid index!".
        * If the array is null, display "Array is not initialized!".
        */

        Console.WriteLine("Array Value Finder with Exceptions\n");

        Console.Write("Waiting , for user to enter array size : ");
        int size = Convert.ToInt32(Console.ReadLine());

        int[] numbers = new int[size];

        Console.WriteLine("enter array elements:");
        for(int i=0; i<size ; i++)
        {
            Console.Write("element " + (i+1) + " : ");
            numbers[i] = Convert.ToInt32(Console.ReadLine());
        }

        Console.Write("Waiting , for user to enter index to check : ");
        int idx = Convert.ToInt32(Console.ReadLine());

        getValueAtIndex(numbers , idx);

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
