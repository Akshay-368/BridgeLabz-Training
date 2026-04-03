using System ;
class Calculator
{
    public static void Main()
    {
        /*11. Write a program to create a basic calculator that can perform addition, subtraction, multiplication, and division. The program should ask for two numbers (floating point) and perform all the operations
Hint:
Create a variable number1 and number 2 and take user inputs.
Perform Arithmetic Operations of addition, subtraction, multiplication, and division and assign the result to a variable and finally print the result
I/P => number1, number2
O/P => The addition, subtraction, multiplication and division value of 2 numbers ___ and ___ is ___, ____, ____, and ___

        */

        Console.WriteLine( " Enter the number : " );

        float a = float.Parse ( Console.ReadLine() );
        Console.Write( " Enter the second number : " );
        float b = float.Parse ( Console.ReadLine() );
        float add = a + b ;
        float sub = a - b ;
        float mul = a * b ;
        float div = a / b ;
        Console.WriteLine("The addition, subtraction, multiplication and division value of 2 numbers {0} and {1} is {2}, {3}, {4}, and {5}", a, b, add, sub, mul, div);
    }
}