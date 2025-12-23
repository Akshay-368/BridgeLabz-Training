public class FizzBuzz
{
    public static void Main()
    {
        /*Write a program FizzBuzz, take a number as user input and if it is a positive integer
        loop from 0 to the number and save the number, but for multiples of 3 save "Fizz" instead of the number,
        for multiples of 5 save "Buzz", and for multiples of both save "FizzBuzz". 
        Finally, print the array results for each index position in the format Position 1 = 1, …, Position 3 = Fizz,...
        Hint => 
        Create a String Array to save the results and 
        Finally, loop again to show the results of the array based on the index position
        */

        Console.WriteLine (" Enter the positive integer : ");
        int n = Convert.ToInt32 ( Console.ReadLine() ) ;

        // creating a string array to store the results
        string[] r = new string[n + 1];

        // Now using loop and if else as per the given conditions
        for ( int i = 0 ; i <= n ; i ++)
        {
            if ( i % 3 == 0  && i % 5 != 0 )
            {
                Console.WriteLine ($"Number is {i} and that's why Fizz"); //only divisible by 3
                r[i] = "Fizz";
            }else if ( i % 5 == 0  && i%3 != 0)
            {
                Console.WriteLine ( $"Number is {i} and that's why Buzz"); // only divisible by 5
            }else if (i % 3 == 0 && i % 5 == 0) {
                Console.WriteLine ( $"Number is {i} and that's why FizzBuzz"); // divisible by 5 and 3 both
                r[i] = "Buzz" ;
            }
            else
            {
                Console.WriteLine ($" Number is : {i}"); // Divisible by neither 3 nor 5
                r[i] = i.ToString() ;
            }
        }

        for ( int i = 0 ; i <= n ; i ++ )
        {
            Console.WriteLine ( " Position {0} = {1} " , i , results[i]  );
        }
    }
}

