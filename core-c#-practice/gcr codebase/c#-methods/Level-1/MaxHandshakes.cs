using System;

public static class MaximumHandshakes
{
    public static void Main ()
    {
        /*
        3. Create a program to find the maximum number of handshakes among N number of students.
        Hint =>
        Get integer input for variable numberOfStudents
        Use the combination formula = ( n * ( n - 1 ) ) / 2
        Write a method to use the combination formula to calculate the number of handshakes
        */

        Console.WriteLine ( " Enter the number of students : " ) ;
        int numberOfStudents = int.Parse ( Console.ReadLine() ) ;
        // Asking for input from the user for the total number of students

        int r = fun ( numberOfStudents );
        // Calling the helping method to find the maximum number of handshakes
        // and store the returned value in r which is result variable and the method should return the answer in int value and take the int value as an argument

        Console.WriteLine ( " The maximum number of possible handshakes among " + numberOfStudents + $" students is : {r} " );
    }

    private static int fun ( int n )
    {
        // This method calculates the maximum number of handshakes
        // using the combination formula
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        int h = ( n * ( n - 1 ) ) / 2; // handshakes among n students
        // Applying the given formula
        // Each student shakes hands with every other student exactly once as the question says

        return h ;
        // Returning the  number of handshakes
    }
}
