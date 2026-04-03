using System;
public static class Reverse
{
    public static void Main()
    {
        /*Create a program to take a number as input and reverse the number. To do this, store the digits of the number in an array and display the array in reverse order
        Hint => 
        Take user input for a number. 
        Find the count of digits in the number. 
        Find the digits in the number and save them in an array
        Create an array to store the elements of the digits array in reverse order
        Finally, display the elements of the array in reverse order  
        */

        Console.WriteLine("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());
        var og = number;
        int size = number.ToString().Length; // count of the digits
        int[] n = new int[size];
        for (int i = 0 ; i < size ; i++)
        {
            n[i] = number % 10;
            number = number / 10 ;
        }

        // reversed array
        int[] r = new int[size];
        for (int i = 0; i < size; i++)
        {
            r[i] = digits[size - 1 - i];
        }

        // Printing reversed array
        Console.WriteLine("Digits in reverse order is as follows:");
        for (int i = 0; i < size; i++)
        {
            Console.Write(r[i]);
        }



    }
}
