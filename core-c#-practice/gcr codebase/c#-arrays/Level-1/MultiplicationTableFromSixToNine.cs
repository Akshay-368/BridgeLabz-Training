using System ;
public static class MultiplicationTableFromSixToNine
{
    public static void Main()
    {
        /* Create a program to find the multiplication table of a number entered by the user from 6 to 9 and display the result
        Hint =>
        Take integer input and store it in the variable number as well as define an integer array to store the multiplication result in the variable multiplicationResult
        Using a for loop, find the multiplication table of numbers from 6 to 9 and save the result in the array
        Finally, display the result from the array in the format number * i = ___
        */

        int number ; // Variable to store the number entered by the user
        int[] multiplicationResult = new int[4] ; // Array to store multiplication results from 6 to 9 ( total 4 values )

        Console.WriteLine ( " Enter a number to generate its multiplication table from 6 to 9 : " );
        var input = Console.ReadLine() ;

        if ( !int.TryParse ( input , out number ) )
        {
            Console.WriteLine ( " Invalid input " );
            return ; // Exiting the program if the input is invalid
        }

        // Using for loop to calculate multiplication table from 6 to 9
        int index = 0 ; // Index variable initialized to zero for storing values in the array
        for ( int i = 6 ; i <= 9 ; i++ )
        {
            multiplicationResult[index] = number * i ; // Storing the multiplication result in the array
            index++ ; // Incrementing the index to move to the next position in the array
        }

        // Displaying the multiplication table stored in the array
        Console.WriteLine ( " The multiplication table of the given number from 6 to 9 is : " );
        index = 0 ; // Resetting index to zero for reading the array values
        for ( int i = 6 ; i <= 9 ; i++ )
        {
            Console.WriteLine ( "{0} * {1} = {2}" , number , i , multiplicationResult[index] );
            index++ ; // Moving to the next value in the array
        }
    }
}
