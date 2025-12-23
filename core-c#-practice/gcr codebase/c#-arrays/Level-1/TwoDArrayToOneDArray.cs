using System ;
public static class TwoDArrayToOneDArray
{
    public static void Main()
    {
        /* Working with Multi-Dimensional Arrays.
        Write a C# program to create a 2D Array and Copy the 2D Array into a single dimension array
        Hint =>
        Take user input for rows and columns, create a 2D array (Matrix), and take the user input
        Copy the elements of the matrix to a 1D array.
        For this create a 1D array of size rows*columns
        Define the index variable and loop through the 2D array
        Use nested for loop to access each element
        */

        Console.WriteLine ( " Enter the number of rows : " );
        int row = Convert.ToInt32 ( Console.ReadLine() ) ;

        Console.WriteLine ( " Enter the number of columns : " );
        int col = Convert.ToInt32 ( Console.ReadLine() ) ;

        int[,] m = new int[row , col] ; // Creating 2D array

        // Input from user
        Console.WriteLine ( " Enter the elements of the matrix : " );
        for ( int i = 0 ; i < row ; i++ )
        {
            for ( int j = 0 ; j < col ; j++ )
            {
                Console.WriteLine ( $" Enter element at position [ { i}  ,  { j } ] : " );
                m[i , j] = Convert.ToInt32 ( Console.ReadLine() ) ;
            }
        }

        //  1D array to store  the 2D array
        int[] a = new int [ row * col] ;
        int index = 0 ; // Index variable initialized to zero

        // Putting elements from 2D array to 1D array
        for ( int i = 0 ; i < row ; i++ )
        {
            for ( int j = 0 ; j < col ; j++ )
            {
                a[index] = m[i , j] ; // Copying each element
                index++ ; // making index go to next position
            }
        }

        // Printing the elements of the 1D array
        Console.WriteLine ( " The elements copied into the 1D array are : " );
        for ( int i = 0 ; i < a.Length ; i++ )
        {
            Console.WriteLine ( $" Element at position  {i}  = { a[i] } " );
        }
    }
}
