using System ;
public static class StoreNumberAndSum
{
    public static void Main()
    {
        /*Write a program to store multiple values in an array up to a maximum of 10 or until the user enters a 0 or a negative number.
        Show all the numbers as well as the sum of all numbers 
        Hint =>
        Create a variable to store an array of 10 elements of type double as well as a variable to store the total of type double initializes to 0.0.
        Also, the index variable is initialized to 0 for the array
        Use infinite while loop as in while (true)
        Take the user entry and check if the user entered 0 or a negative number to break the loop
        Also, break from the loop if the index has a value of 10 as the array size is limited to 10.
        If the user entered a number other than 0 or a negative number inside the while loop then assign the number to the array element and increment the index value
        Take another for loop to get the values of each element and add it to the total
        Finally display the total value
        */

        double[] numbers = new double[10]; // Array of 10 elements
        double total = 0.0 ; // Sum intialized to zero
        int index = 0 ; // Index variable initialized to zero which is our current position in the array
        while  ( true)
        {
            Console.WriteLine ( " Enter a number (0 or negative to exit) : ");
            var input = Console.ReadLine();
            if ( !double.TryParse(input , out double number))
            {
                Console.WriteLine ("Invalid input . Please enter again. ");
                continue ; // try the same iteration again ( this works because we are currently in the infinite while loop and hence when the control will go back up and then it will come back to the smae statement)
            }

            if ( number == 0 || number < 0 )
            {
                break; // breaking the loop when 0 or -ve no. is entered as per the question
            }
            else if (index == 10)
            {
                break ; // breaking the loop when the array is filled up
            }
            else
            {
                numbers[index] = number; // adding the new number to the array
                index++; // incrementing the index to move to the next position in the array
            }
        }

        // Now doing the sum of the entered value stored in the array and displaying the elements as well 
        Console.WriteLine ("The numbers entered are : ") ;
        for (int i = 0 ; i < index ; i++)
        {
            total += numbers[i]; // adding each number to the total that we created at the begining
            // Also displaying the numbers as well
            Console.WriteLine ( "{0} " , numbers[i] ) ;
        }

        Console.WriteLine ( " The total sum of all the numbers is : " + total); // printing the total sum of all the numbers entered by the user
    }
}
