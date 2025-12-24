using System;

public static class SmallestLargest
{
    public static void Main ()
    {
        /*
        8. Write a program to find the smallest and the largest of the 3 numbers.
        Hint =>
        Take user input for 3 numbers
        Write a single method to find the smallest and largest of the three numbers
        */

        Console.WriteLine ( " Enter the first number : " );
        int n1 = int.Parse ( Console.ReadLine() );
        // Taking the first integer input from the user

        Console.WriteLine ( " Enter the second number : " );
        int n2 = int.Parse ( Console.ReadLine() );
        // Taking the second integer input from the user

        Console.WriteLine ( " Enter the third number : " );
        int n3 = int.Parse ( Console.ReadLine() );
        // Taking the third integer input from the user

        int[] result = Find ( n1 , n2 , n3 );
        // Calling the method which returns an integer array and takes the three numbers as arguments of type int
        // result[0] will contain the smallest number
        // result[1] will contain the largest number
        // Since we want to return more than one value, we are using an integer array

        Console.WriteLine ( " Smallest number is : " + result[0] );
        Console.WriteLine ( " Largest number is : " + result[1] );
    }

    private static int[] Find ( int n1 , int n2 , int n3 )
    {
        // This method finds the smallest and the largest among three numbers
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int smallest = n1 ;
        int largest = n1;
        //  assuming the first number to be both smallest and largest as of now .

        if ( n2 < smallest )
        {
            smallest = n2 ;
            // we will make the change if second number is smaller, thus updating the smallest variable we created
        }

        if ( n3 < smallest )
        {
            smallest = n3;
            // we will make the change if third number is smaller, thus updating the smallest variable we created
        }

        if ( n2 > largest )
        {
            largest = n2 ;
            // Updating largest if second number is greater
        }

        if ( n3 > largest )
        {
            largest = n3 ;
            // Updating largest if third number is greater
        }

        int[] arr = new int[2];
        // Creating an integer array of size 2
        // arr[0] will store the smallest number
        // arr[1] will store the largest number

        arr[0] = smallest ;
        arr[1] = largest;

        return arr;
        // Returning the array containing smallest and largest values
    }
}
