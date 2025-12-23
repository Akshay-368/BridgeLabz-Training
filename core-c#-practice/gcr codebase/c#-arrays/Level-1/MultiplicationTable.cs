using System;

public static class MultiplicationTable
{
    public static void Main()
    {
        /* Create a program to print a multiplication table of a number.
        Hint =>
        Get an integer input and store it in the number variable. Also, define a integer array to store the results of multiplication from 1 to 10
        Run a loop from 1 to 10 and store the results in the multiplication table array
        Finally, display the result from the array in the format number * i = ___
        */

        // Asking user for input
        Console.Write( " Enter a number for printing its multiplication table : " ) ;
        int number;
        while (!int.TryParse(Console.ReadLine(), out number))
        {
            Console.Write("Invalid input.");
        }

        // Defining the array to store the results
        const int size = 10;
        int[] table = new int[size];

        // Now we need to fill the array with the multiplication results
        for (int i = 1; i <= size; i++)
        {
            table[i - 1] = number * i ;
        }

        // Printing the results
        Console.WriteLine( $" Multiplication Table of {number} ( as per the question ) is as follows :" );
        for (int i = 1 ; i <= size ; i++)
        {
            Console.WriteLine($"{number} * {i} = {table[i - 1]}" );
        }
    }
}
