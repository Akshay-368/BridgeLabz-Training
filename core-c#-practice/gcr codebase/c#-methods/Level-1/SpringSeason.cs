using System;

public static class SpringSeason
{
    public static void Main (string[] args )
    {
        // here args is an array of strings and it contains command line inputs and usually we can just avoid writing string[] args but since question explicityly asks for it
        // so we can't avoid it, in this case.
        // basically Each value we pass when running the program goes into this array
        // and thus later on we can use args[0] , args[1] etc

        // and a basic difference between giving input through args and console is that with console program runs and then pause and wait for user to give input
        // while in args program doesn't wait as it only starts running after we give input at the laucnh time and thus it is faster and not interactive.
        // Thus it would be pointles to write console.writeline( "enter input " ) as this message itself will be printed later on the console window.
        
        /*
        6. Write a program SpringSeason that takes two int values month and day
        from the command line and prints whether it is Spring Season or not.
        Hint =>
        Spring Season is from March 20 to June 20
        Write a Method to check for Spring season and return true or false
        */

        //  input from command line arguments , and then parsing them to int types and storing . 
        int month = int.Parse ( args[0] );
        int day = int.Parse ( args[1] );
        // args[0] is for month , args[1] is for day

        bool isSpring = Fun ( month , day );
        // Calling the helper method to check if the given date is in Spring season or not. and the method should return a boolean value only. since we just want to know as in yes or no

        if ( isSpring == true )
        {
            Console.WriteLine ( " Its a Spring Season " );
        }
        else
        {
            Console.WriteLine ( " Not a Spring Season " );
        }
    }

    private static bool Fun ( int m , int d )
    {
        // This method checks whether the given month and day
        // lies between March 20 and June 20
        // Making this method private so that only this class can call it , just one of the best practices
        // And making it static so that it can be called directly otherwise we would have to create it an object of the class. ( that's what happened with non-static)
        // ANy static method means it belongs to class itself and is not just any instance of the class

        if ( ( m == 3 && d >= 20 ) || ( m == 4 ) || ( m == 5 ) || ( m == 6 && d <= 20 ) )
        {
            return true;
            //  date lies in Spring season
        }
        else
        {
            return false;
            //  date does not lie in Spring season
        }
    }
}
