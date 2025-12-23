using System ;

public static class PositiveOrNegative
{
    public static void Main()
    {
        /*Write a program to take user input for 5 numbers and check whether a number is positive,  negative, or zero.
        Further for positive numbers check if the number is even or odd.
        Finally compare the first and last elements of the array and display if they equal, greater or less
        Hint =>
        Define an integer array of 5 elements and get user input to store in the array.
        Loop through the array using the length If the number is positive, check for even or odd numbers and print accordingly
        If the number is negative, print negative. Else if the number is zero, print zero.
        Finally compare the first and last element of the array and display if they equal, greater or less
        */

        const int size = 5; // Fixing the size of the array
        int[] numbers = new int[size]; // Creating an array of size
        for (int i = 0; i < size; i++)
        {
            Console.WriteLine ($"Enter number : for the {i+1}th position : ");
            numbers[i] = Convert.ToInt32(Console.ReadLine()); // Reading user input and storing in the array
        }
        // Now checking if the numbers are positive or negative or zero
        for (int i = 0; i < size; i++)
        {
            if (numbers[i] > 0)
            {
                if (numbers[i] % 2 == 0)
                {
                    Console.WriteLine( $"The {i+1}th number is positive and even. " ) ;
                }
                else
                {
                    Console.WriteLine( $"The {i+1}th number is positive and odd. " ) ;
                }
            }
            else if (numbers[i] < 0)
            {
                Console.WriteLine( $"The {i+1}th number is negative." ) ;
            }
            else
            {
                Console.WriteLine( $"The {i+1}th number is zero. " ) ;
            }
        }

        // Comparing the  first and last element as per the question's instruction
        int first = numbers[0] ;
        int last = numbers[size - 1] ;

        if (first == last)
        {
            Console.WriteLine( $"First element {first} is equal to last element {last}." ) ;
        }
        else if (first > last)
        {
            Console.WriteLine( $"First element {first} is greater than last element {last}.") ;
        }
        else
        {
            Console.WriteLine( $"First element {first} is less than last element {last} .") ;
        }

    }
}
