using System;

public class DigitCount
{
    public static void Main()
    {
        /*Create a program to take a number as input find the frequency of each digit in the number using an array and display the frequency of each digit
        Hint => 
        Take the input for a number
        Find the count of digits in the number
        Find the digits in the number and save them in an array
        Find the frequency of each digit in the number. For this define a frequency array of size 10, Loop through the digits array, and increase the frequency of each digit
        Display the frequency of each digit in the number
        */

        Console.Write(" Enter a number: ");
        int num = int.Parse(Console.ReadLine().ToString());

        int temp = num ;
        int cnt = 0 ;

        // count
        while (temp != 0)
        {
            cnt++;
            temp = temp / 10 ;
        }

        int[] digits = new int[cnt];

        temp = num ;
        int i = cnt - 1 ;

        // storing digits in the array
        while (temp != 0)
        {
            int d = temp % 10 ;
            digits[i] = d ;
            i-- ;
            temp = temp / 10 ;
        }

        // frequency array
        int[] freq = new int[10];

        // calculating frequency
        for (int j = 0 ; j < digits.Length ; j++ )
        {
            int val = digits[j] ;
            freq[val] = freq[val] + 1 ;
        }

        Console.WriteLine ("Frequency of digits in the number : ") ;

        // printing frequency
        for (int k = 0; k < 10; k++)
        {
            if ( freq[k] > 0 )
            {
                Console.WriteLine ("Digit " + k + " occurs " + freq[k] + " times ") ;
            }
        }
    }
}
