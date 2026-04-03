using System ;
public static class OddEvenNumbers
{
    public static void Main()
    {
        /* Create a program to save odd and even numbers into odd and even arrays between 1 to the number entered by the user.
        Finally, print the odd and even numbers array
        Hint =>
        Get an integer input from the user, assign it to a variable number, and check for Natural Number. If not a natural number then print an error and exit the program
        Create an integer array for even and odd numbers with size = number / 2 + 1
        Create index variables for odd and even numbers and initialize them to zero
        Using a for loop, iterate from 1 to the number, and in each iteration of the loop, save the odd or even number into the corresponding array
        Finally, print the odd and even numbers array using the odd and even index
        */

        Console.WriteLine ( " Enter a natural number (positive integer) : ");
        var input = Console.ReadLine();

        if (!int.TryParse(input, out int number) || number <= 0)
        {
            Console.WriteLine("Invalid input.");
            return; 
        }

        int size = number / 2 + 1 ; // Maximum possible size for odd/even arrays
        int[] oddNumbers = new int[size] ; // Array to store odd numbers
        int[] evenNumbers = new int[size] ; // Array to store even numbers

        int oddIndex = 0 ; // Index for odd array
        int evenIndex = 0 ; // Index for even array

        for (int i = 1 ; i <= number ; i++)
        {
            if (i % 2 == 0) // Even number
            {
                evenNumbers[evenIndex] = i ;
                evenIndex++ ;
            }
            else // Odd number
            {
                oddNumbers[oddIndex] = i ;
                oddIndex++ ;
            }
        }

        //Printing odd numbers
        Console.WriteLine("Odd numbers are: ");
        for (int i = 0 ; i < oddIndex ; i++)
        {
            Console.WriteLine(oddNumbers[i]) ;
        }

        // Printing even numbers
        Console.WriteLine("Even numbers are: ");
        for (int i = 0 ; i < evenIndex ; i++)
        {
            Console.WriteLine(evenNumbers[i]) ;
        }
    }
}
