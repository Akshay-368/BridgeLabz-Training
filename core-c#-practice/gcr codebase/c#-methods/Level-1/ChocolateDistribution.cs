using System;

public static class ChocolateDistribution
{
    public static void Main ()
    {
        /*
        10. Create a program to divide N number of chocolates among M children.
        Print the number of chocolates each child will get and also the remaining chocolates.

        Hint =>
        Get an integer value from the user for numberOfChocolates and numberOfChildren.
        Write a method to find the number of chocolates each child gets
        and number of remaining chocolates.
        */

        // Here i have tried to follow the naming convention of the question itself and thus created such long names for the variables.
        Console.WriteLine ( " Enter the total number of chocolates : " );
        int numberOfChocolates = int.Parse ( Console.ReadLine() );
        // Taking total number of chocolates from the user
        // Using int because chocolates cannot be in decimal values

        Console.WriteLine ( " Enter the total number of children : " );
        int numberOfChildren = int.Parse ( Console.ReadLine() );
        // Taking total number of children from the user

        int[] result = Find ( numberOfChocolates , numberOfChildren );
        // Calling the method which returns an integer array
        // result[0] will store quotient
        // result[1] will store remainder
        // since the array that we have intialised is what calls the function and thus the function should return an int array ([]) and not just an int .
        // Also the function should take two int values as its parameters

        Console.WriteLine ( " Each child will get : " + result[0] + " chocolates " );
        Console.WriteLine ( " Remaining chocolates are : " + result[1] );
    }

    public static int[] Find ( int number , int divisor )
    {
        // This method calculates quotient and remainder
        // number  -> total chocolates
        // divisor -> total children

        // We could have make this method as private as well as that would have make the method only accessible by the class itself where it is requried .
        // But since in the question we were asked to do it without the private and make it public and hence that's why i am making it public
        // for it being static , it makes it directly callable and otherwise we would have to make it an object first as that's what happens with non-static.

        int quotient = number / divisor;
        //  how many chocolates each child gets

        int remainder = number % divisor;
        //  how many chocolates are left after equal distribution

        int[] arr = new int[2];
        // an integer array of size 2
        // arr[0] will store quotient
        // arr[1] will store remainder

        arr[0] = quotient;
        arr[1] = remainder;

        return arr;
        // Returning the array which contains quotient and remainder
    }
}
