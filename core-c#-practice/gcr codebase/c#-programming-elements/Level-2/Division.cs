using System;
class Division
{
    public static void Main()
    {
        /*1. Write a program to take 2 numbers and print their quotient and remainder
Hint: Use division operator (/) for quotient and modulus operator (%) for remainder
I/P => number1, number2
O/P => The Quotient is ___ and Remainder is ___ of two numbers ___ and ___
        */

        Console.WriteLine("Enter the fist number : ");
        double a = double.Parse ( Console.ReadLine() );
        Console.WriteLine ( " Enter the second number : ");
        double b = Convert.ToDouble(Console.ReadLine());
        int q = ( int ) ( a / b ) ; // quotient
        int r = ( int ) ( a % b ) ; // remainder

        Console.WriteLine("The Quotient is {0} and Reaminder is {1} of two numbers {2} and {3} " , q , r , a , b );
    }
}