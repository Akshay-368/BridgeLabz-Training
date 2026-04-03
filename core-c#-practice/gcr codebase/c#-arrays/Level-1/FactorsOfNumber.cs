using System ;
public static class FactorsOfNumber
{
    public static void Main()
    {
        /* Create a program to find the factors of a number taken as user input, store the factors in an array, and display the factors
        Hint =>
        Take the input for a number
        Find the factors of the number and save them in an array. For this create integer variable maxFactor and initialize to 10,
        factors array of size maxFactor and index variable to reflect the index of the array.
        To find factors loop through the numbers from 1 to the number, find the factors, and add them to the array element by incrementing the index.
        If the index is equal to maxIndex, then need factors array to store more elements
        To store more elements, reset the maxIndex to twice its size, use the temp array to store the elements from the factors array,
        and eventually assign the factors array to the temp array
        Finally, Display the factors of the number
        */

        Console.WriteLine("Enter a positive integer to find its factors: ");
        var input = Console.ReadLine();

        if (!int.TryParse (input , out int number ) || number <= 0)
        {
            Console.WriteLine("Invalid input. " ) ;
            return;
        }

        int maxFactor = 10 ; // Initial size of the array
        int[] factors = new int[maxFactor] ; // Array to store factors
        int index = 0 ; // Current position in the array


        for (int i = 1 ; i <= number ; i++)
        {
            if (number % i == 0) // If i is a factor
            {
                // Checking if array is full
                if (index == maxFactor)
                {
                    // Doubling the size of the array
                    maxFactor *= 2 ;
                    int[] temp = new int[maxFactor] ;

                    // let's copy old factors into temp
                    for (int j = 0 ; j < index ; j++)
                    {
                        temp[j] = factors[j] ;
                    }

                    // temp back to factors
                    factors = temp ;
                }

                factors[index] = i ;
                index++ ;
            }
        }

        // Printing the factors
        Console.WriteLine("The factors of the number are: ");
        for (int i = 0 ; i < index ; i++)
        {
            Console.WriteLine(factors[i]) ;
        }
    }
}
