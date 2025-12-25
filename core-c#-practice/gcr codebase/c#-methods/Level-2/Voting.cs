using System;

public static class Vote
{
    public static void Main ()
    {
        /*Q7.
        Write a program to take user input for the age of all 10 students
        and check whether the student can vote or not
        Hint =>
        a. Create a class public class StudentVoteChecker and define a method public boolean CanStudentVote(int age) which takes in age as a parameter and returns true or false
        b. Inside the method firstly validate the age for a negative number, if a negative return is false cannot vote.
        For valid age check for age is 18 or above return true; else return false;
        c. In the main function define an array of 10 integer elements, loop through the array by take user input for the student's age, call CanStudentVote() and display the result
        */

        int[] age = new int[10];
        // Array to store ages of 10 students

        for ( int i = 0 ; i < age.Length ; i++ )
        {
            Console.WriteLine ( " Enter age of student " + ( i + 1 ) + " : " );
            age[i] = int.Parse ( Console.ReadLine() );

            bool res = can ( age[i] );
            // Calling helper method to check voting eligibility and storing the result in a boolean type variable as answer can be either yes or no.

            if ( res == true )
            {
                Console.WriteLine ( " Student can vote " );
            }
            else
            {
                Console.WriteLine ( " Student cannot vote " );
            }
        }
    }

    private static bool can ( int a )
    {
        // Method to check whether a student can vote or not
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( a < 0 )
        {
            return false;
            // Negative age is invalid, so can't vote
        }
        else if ( a >= 18 )
        {
            return true;
            // Age is 18 or above, so eligible to vote
        }
        else
        {
            return false;
            // Age is below 18, so can't vote
        }
    }
}
