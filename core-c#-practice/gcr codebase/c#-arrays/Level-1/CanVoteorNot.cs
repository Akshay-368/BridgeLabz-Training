using System ;
public static class CanVoteorNot
{
    public static void Main()
    {
        /*Write a program to take user input for the age of all 10 students in a class
        and check whether the student can vote depending on his/her age is greater or equal to 18.
        Hint =>
        Define an array of 10 integer elements and take user input for the student's age.
        Loop through the array using the length property and for the element of the array check If the age is a
        negative number print an invalid age and if 18 or above, print The student with the age ___ can vote.
        Otherwise, print The student with the age ___ cannot vote.
        */

        const int num_of_students = 10; // Making it const so that it becomes immutable and compiler know about it.
        int [] age = new int [num_of_students]; // Intilainzing the array for storing the ages
        // Looping through the array to get the ages of the students
        for (int i = 0 ; i < num_of_students ; i++)
        {
            Console.WriteLine ( $"Enter the age of student for the {i+1} th number of student : ");
            age [i] = Convert.ToInt32 (Console.ReadLine ()); // Taking the input from the user and storing it in the array at the required position
        }

        // Now checking if for the age of the student whether they are eligible or not
        for (int i = 0 ; i < num_of_students ; i++)
        {
            if (age [i] < 0)
            {
                Console.WriteLine (" Invalid age .") ;
            }else if ( age[i] >= 18)
            {
                Console.WriteLine ( $" The studnet with the age of {age[i] } can vote .") ;
            }
            else
            {
                Console.WriteLine ( $" The studnet with the age of {age[i] } cannot vote .") ;
            }
        }
        

        
    }
}
