using System ;
class Swap
{
    public static void Main()
    {
        /* 7. Create a program to swap two numbers
Hint:
Create a variable number1 and take user input.
Create a variable number2 and take user input.
Swap number1 and number2 and print the swapped output.
I/P => number1, number2
O/P => The swapped numbers are ___ and ___

        */

        Console.WriteLine( " Enter the numbers that you want to swap (both at once , spearted by space ) : " ) ;
        string s = Console.ReadLine();
        string[] a = s.Split();
        double var1 = double.Parse ( a [0]);
        double var2 = Convert.ToDouble (a [1]);

        (var1, var2) = (var2, var1); // Swapping using tuple assignment , closest to my native and primary python language where tuple unpacking is directly supported
        Console.WriteLine (" The swapped no.s are : {0} and {1} " , var1 , var2);
        

    }
}