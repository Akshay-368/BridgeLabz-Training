using System ;
class Intoperations
{
    public static void Main()
    {
        /*2. Write an IntOperation program by taking a, b, and c as input values and
        print the following integer operations: a + b * c, a * b + c, c + a / b, and a % b + c. 
        Please also understand the precedence of the operators.
Hint:
Create variables a, b, and c of int data type.
Take user input for a, b, and c.
Compute the 3 integer operations and assign results to variables.
Finally, print the results and understand operator precedence.
I/P => a, b, c
O/P => The results of Int Operations are ___, ___, and ___
        */

        Console.WriteLine (" Enter the first int number a : ");
        int a = int.Parse (Console.ReadLine());
        // Using different way to take the input just for practice purpose
        Console.WriteLine( " Enter the second int number b  and c (seperated by space in a single Line ) : ");
        string i = Console.ReadLine();
        string[] s = i.Split();
        int b = Convert.ToInt32 ( s[0] );
        int c = int.Parse  ( s[1] ) ; // trying parse function  as it takes string input and convert it to target type mentioned using . operater

        // Now doing the operations : as per the question
        int o1 = a + b * c ; // operation 1
        int o2 = a * b + c ; // operation 2
        int o3 = c + a / b ; // operation 3
        int o4 = a % b + c ; // operation 4

        // Now printing

        Console.WriteLine ($"The results of Int Operations are {o1} , {o2} , {o3} and {o4}");


    }
}