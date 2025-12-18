using System;
class Sum_of_two
{
    public static void Main ()
    {
        Console.WriteLine ("Enter the num1 : "); // Asking the user for first no.
        int a = int.Parse ( Console.ReadLine () ) ; // Taking the value and converting it to integer using Parse method
        // Used Parse method ( static ) to convert string input to target type which is int here
        // Using int here because we are only dealing with whole numbers

        Console.WriteLine ("Enter the num2 : "); // Asking the user for second no.
        int b = int.Parse ( Console.ReadLine () ) ; // Taking the value and converting it to integer using Parse method
        // Used Parse method ( static ) to convert string input to target type which is int here
        // Using int here because we are only dealing with whole numbers

        int sum = a + b ; // Adding the two numbers
        Console.WriteLine ( " The sum of " + a + " and " + b + " is : " + sum ) ; // Showing the sum of two numbers
    }
}
