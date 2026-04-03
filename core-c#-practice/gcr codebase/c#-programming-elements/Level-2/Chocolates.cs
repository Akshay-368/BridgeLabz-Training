using System;
class Chocolates
{
    public static void Main()
    {
        /*10. Create a program to divide N number of chocolates among M children.
        Hint:
        Get an integer value from the user for numberOfChocolates and numberOfChildren.
        Find the number of chocolates each child gets and the number of remaining chocolates.
        Display the results.
        I/P => numberOfChocolates, numberOfChildren
        O/P => The number of chocolates each child gets is ___ and the number of remaining chocolates is ___
        */

        Console.WriteLine(" Enter the total number of chocolates and number of children ( separated by space ) : " ) ;
        string s = Console.ReadLine();
        string [] i = s.Split();

        int numberOfChocolates = int.Parse( i [0] );
        int numberOfChildren = Convert.ToInt32( i[1]);


        int chocolates = numberOfChocolates / numberOfChildren; // integer division
        int remaining = numberOfChocolates % numberOfChildren; // remainder
        // Keeping them both as integer as number of chocolates and number of children can't be in decimals ever.

        Console.WriteLine("The number of chocolates each child gets is {0} and the number of remaining chocolates is {1}.", chocolates, remaining);



    }
}