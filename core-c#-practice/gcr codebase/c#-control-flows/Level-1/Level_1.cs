using System;
namespace Level_1 ;
using System.Diagnostics ;

public class DivisibleByFive
{
    public static void Run()
    {
        /*Write a program to check if a number is divisible by 5
        I/P => number
        O/P => Is the number ___ divisible by 5? ___
        */
        Console.WriteLine("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        bool isDivisible = (number % 5 == 0);

        Console.WriteLine($"Is the number {number} divisible by 5? {isDivisible}");
    }
}

public class SmallestCheck
{
    public static void Run()
    {
        /*Write a program to check if the first is the smallest of the 3 numbers.
        I/P => number1, number2, number3
        O/P => Is the first number the smallest? ____
        */
        Console.WriteLine("Enter three numbers (space separated): ");
        string[] input = Console.ReadLine().Split();
        int number1 = Convert.ToInt32(input[0]);
        int number2 = Convert.ToInt32(input[1]);
        int number3 = Convert.ToInt32(input[2]);

        bool isSmallest = (number1 < number2 && number1 < number3);

        Console.WriteLine($"Is the first number the smallest? {isSmallest}");
    }
}

public class LargestCheck
{
    public static void Run()
    {
        /*Write a program to check if the first, second, or third number is the largest of the three.
        I/P => number1, number2, number3
        O/P =>
        Is the first number the largest? ____
        Is the second number the largest? ___
        Is the third number the largest? ___
        */
        Console.WriteLine("Enter three numbers (space separated): ");
        string[] input = Console.ReadLine().Split();
        int number1 = Convert.ToInt32(input[0]);
        int number2 = Convert.ToInt32(input[1]);
        int number3 = Convert.ToInt32(input[2]);

        if (number1 >= number2 && number1 >= number3)
            Console.WriteLine("The first number is the largest.");
        else if (number2 >= number1 && number2 >= number3)
            Console.WriteLine("The second number is the largest.");
        else
            Console.WriteLine("The third number is the largest.");
    }
}

public class NaturalNumberSum
{
    public static void Run()
    {
        /*Write a program to check for the natural number and write the sum of n natural numbers 
        Hint =>
        A Natural Number is a positive integer (1,2,3, etc) sometimes with the inclusion of 0
        A sum of n natural numbers is n * (n+1) / 2
        I/P => number
        O/P => If the number is a positive integer then the output is
        The sum of ___ natural numbers is ___
        Otherwise
        The number ___ is not a natural number
        */
        Console.WriteLine("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number >= 0) // natural numbers include 0
        {
            int sum = number * (number + 1) / 2;
            Console.WriteLine($"The sum of {number} natural numbers is {sum}");
        }
        else
        {
            Console.WriteLine($"The number {number} is not a natural number");
        }
    }
}

public class VotingEligibility
{
    public static void Run()
    {
        /*Write a program to check whether a person can vote, depending on whether his/her age is greater than or equal to 18.
        Hint =>
        Get integer input from the user and store it in the age variable.
        If the person is 18 or older, print "The person can vote." Otherwise, print "The person cannot vote." 
        I/P => age
        O/P => If the person's age is greater or equal to 18 then the output is 
        The person's age is ___ and can vote.
        Otherwise
        The person's age is ___ and cannot vote.
        */
        Console.WriteLine("Enter the person's age: ");
        int age = Convert.ToInt32(Console.ReadLine());

        if (age >= 18)
            Console.WriteLine($"The person's age is {age} and can vote.");
        else
            Console.WriteLine($"The person's age is {age} and cannot vote.");
    }
}

public class NumberCheck
{
    public static void Run()
    {
        /*Write a program to check whether a number is positive, negative, or zero.
        Hint =>
        Get integer input from the user and store it in the number variable.
        If the number is positive, print positive.
        If the number is negative, print negative.
        If the number is zero, print zero.
        */
        Console.WriteLine("Enter a number: ");
        int number = Convert.ToInt32(Console.ReadLine());

        if (number > 0)
            Console.WriteLine("Positive");
        else if (number < 0)
            Console.WriteLine("Negative");
        else
            Console.WriteLine("Zero");
    }
}

public class SpringSeason
{
    public static void Run()
    {
        /*Write a program SpringSeason that takes two int values month and
        day from the command line and prints “Its a Spring Season” otherwise prints “Not a Spring Season”.
        Hint =>
        Spring Season is from March 20 to June 20
        */
        Console.WriteLine("Enter month (1-12): ");
        int month = Convert.ToInt32(Console.ReadLine());

        Console.WriteLine("Enter day: ");
        int day = Convert.ToInt32(Console.ReadLine());

        // Spring Season: March 20 (month=3, day>=20) to June 20 (month=6, day<=20)
        bool isSpring = (month == 3 && day >= 20) ||
                        (month == 4) ||
                        (month == 5) ||
                        (month == 6 && day <= 20);

        if (isSpring)
            Console.WriteLine("It's a Spring Season");
        else
            Console.WriteLine("Not a Spring Season");
    }
}

public class RocketLaunchWhile
{
    public static void Run()
    {
        /*Write a program to count down the number from the user input value to 1 using a while loop for a rocket launch
        Hint =>
        Create a variable counter to take user inputted value for the countdown.
        Use the while loop to check if the counter is 1
        Inside a while loop, print the value of the counter and decrement the counter.
        */
        Console.WriteLine("Enter countdown start number: ");
        int counter = Convert.ToInt32(Console.ReadLine());

        while (counter >= 1)
        {
            Console.WriteLine(counter);
            counter--;
        }

        Console.WriteLine("Blast Off!");
    }
}

public class RocketLaunchFor
{
    public static void Run()
    {
        /* Rewrite program 8 to do the countdown using the for-loop */
        Console.WriteLine("Enter countdown start number: ");
        int counter = Convert.ToInt32(Console.ReadLine());

        for (int i = counter; i >= 1; i--)
        {
            Console.WriteLine(i);
        }

        Console.WriteLine("Blast Off!");
    }
}


public class SumUntilZero
{
    public static void Run()
    {
        /*
        Program to find the sum of numbers until the user enters 0.
        Hint =>
        Create a variable total of type double initialize to 0.0.
        Use while loop to keep asking for input until user enters 0.
        */

        double total = 0.0;

        Console.WriteLine("Enter numbers to add (enter 0 to stop): ");
        double number = Convert.ToDouble(Console.ReadLine());

        while (number != 0)
        {
            total += number;
            Console.WriteLine("Enter another number (0 to stop): ");
            number = Convert.ToDouble(Console.ReadLine());
        }

        Console.WriteLine($"The total sum is: {total}");
    }
}

public class SumUntilZeroOrNegative
{
    public static void Run()
    {
        /*
        Rewrite the program 10 to find the sum until the user enters 0 or a negative number.
        Hint =>
        Use infinite while loop (while(true)).
        Break the loop if user enters 0 or a negative number.
        */

        double total = 0.0;

        Console.WriteLine("Enter numbers to add ( enter 0 or negative number to stop ) : " ) ;

        while ( true )
        {
            double number = Convert.ToDouble ( Console.ReadLine() ) ;

            if (number <= 0) {  // stop if 0 or negative , as asked in the question itself
                break ;
        }

            total += number ;
        }

        Console.WriteLine ( $"The total sum is: {total} " ) ;
    }
}

public static class SumOfNaturalNumber
{
    public static void Run()
    {
        /*Write a program to find the sum of n natural numbers using while loop compare the result
        with the formulae n*(n+1)/2 and show the result from both computations was correct.
        Hint =>
        Take the user input number and check whether it's a Natural number
        If it's a natural number Compute using formulae as well as compute using while loop
        Compare the two results and print the result
        */
        Console.WriteLine (" Enter the int number for which you want the sum : ");
        int n = Convert.ToInt32 (Console.ReadLine () );
        // Checking if it's a natural number or not
        if (n <= 0) {
            Console.WriteLine( "Please enter a positive natural number." );
            return ;
            }

        // Using the formula finidng the sum
        // Going to measure the time as well with help of Stopwatch from System.Diagnostics .
        Stopwatch tf = Stopwatch.StartNew () ; // starting the clock-timer for watching time
        int s =  n * (n + 1) / 2 ;
        Console.WriteLine ($" The sum of N {n} natural numbers using the formula is : {s}");
        tf.Stop(); // Stopping the timer

        Console.WriteLine ( $" The time it takes for the formula to execute the code is : {tf.Elapsed.TotalMilliseconds} ms and the cpu cycles or ticks are : {tf.ElapsedTicks}") ;
        Console.WriteLine ($"Seconds : {tf.Elapsed.TotalSeconds}");


        // Now using while loop finiding the sum :
        int sWhile = 0 ; // Initializing the sum variable to store the result for while loop
        int N = n ; //  Having a backup for the original number entered
        Stopwatch tw = Stopwatch.StartNew();
        while (n > 0)
        {
            sWhile += n ;
            n -- ;
        }
        tw.Stop();
        Console.WriteLine ( $" The sum of N {N} natural numbers using the while loop is {sWhile }");
        Console.WriteLine ($" Seconds consumed : {tw.Elapsed.TotalSeconds}");
        Console.WriteLine ($" Milliseconds : {tw.Elapsed.TotalMilliseconds}" );;
        Console.WriteLine ($" The raw cpu cycles : {tw.ElapsedTicks}");

        // Comparing the results
        if (s == sWhile) {
            Console.WriteLine (" Both results match !" ) ;
        }else {
            Console.WriteLine( "Results do not match!" ) ;
        }
    }
}



public static class SumOfNaturalNumberUsingFor
{
    public static void Run()
    {
        /*Rewrite the program number 12 with the for loop instead of a while loop to find the sum of n Natural Numbers. 
        Hint =>
        Take the user input number and check whether it's a Natural number
        If it's a natural number Compute using formulae as well as compute using for loop
        Compare the two results and print the result , the previous question was :

        Write a program to find the sum of n natural numbers using while loop compare the result
        with the formulae n*(n+1)/2 and show the result from both computations was correct.
        Hint =>
        Take the user input number and check whether it's a Natural number
        If it's a natural number Compute using formulae as well as compute using while loop
        Compare the two results and print the result
        */
        Console.WriteLine (" Enter the int number for which you want the sum : ");
        int n = Convert.ToInt32 (Console.ReadLine () );
        // Checking if it's a natural number or not
        if (n <= 0) {
            Console.WriteLine( "Please enter a positive natural number." );
            return ;
            }

        // Using the formula finidng the sum
        // Going to measure the time as well with help of Stopwatch from System.Diagnostics .
        Stopwatch tf = Stopwatch.StartNew () ; // starting the clock-timer for watching time
        int s =  n * (n + 1) / 2 ;
        Console.WriteLine ($" The sum of N {n} natural numbers using the formula is : {s}");
        tf.Stop(); // Stopping the timer

        Console.WriteLine ( $" The time it takes for the formula to execute the code is : {tf.Elapsed.TotalMilliseconds} ms and the cpu cycles or ticks are : {tf.ElapsedTicks}") ;
        Console.WriteLine ($"Seconds : {tf.Elapsed.TotalSeconds}");


        // Now using for  loop finiding the sum :
        int sFor = 0 ; // Initializing the sum variable to store the result for while loop
        int N = n ; //  Having a backup for the original number entered
        Stopwatch tw = Stopwatch.StartNew();
        for (int i = 1; i <= N; i++)
        {
            sFor += i;
        }

        tw.Stop();
        Console.WriteLine ( $" The sum of N {N} natural numbers using the for loop is {sFor }");
        Console.WriteLine ($" Seconds consumed : {tw.Elapsed.TotalSeconds}");
        Console.WriteLine ($" Milliseconds : {tw.Elapsed.TotalMilliseconds}" );;
        Console.WriteLine ($" The raw cpu cycles : {tw.ElapsedTicks}");

        // Comparing the results
        if (s == sFor) {
            Console.WriteLine (" Both results match !" ) ;
        }else {
            Console.WriteLine( "Results do not match!" ) ;
        }
    }
}



public static class FactorialUsingWhile
{
    public static void Run()
    {
        /*Write a Program to find the factorial of an integer entered by the user.
        Hint =>
        For example, the factorial of 4 is 1 * 2 * 3 * 4 which is 24.
        Take an integer input from the user and assign it to the variable.
        Check the user has entered a positive integer.
        Using a while loop, compute the factorial.
        Print the factorial at the end.
        */

        Console.WriteLine(" Enter the integer number for which you want the factorial : ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Checking for the condition if it's a positive integer
        if (n < 0)
        {
            Console.WriteLine(" Please enter a positive integer.");
            return;
        }

        // Special case for 0! = 1
        if (n == 0 || n == 1)
        {
            Console.WriteLine( $" The factorial of {n} is : 1");
            return ;
        }

        // Using while loop
        int factorial = 1;
        int N = n; // backing-up the original number
        Stopwatch tw = Stopwatch.StartNew(); // start timing of the clock
        while (n > 1)
        {
            factorial *= n;
            n--;
        }
        tw.Stop(); // stop timing

        // Printing the result
        Console.WriteLine($" The factorial of {N} is : {factorial}");
        Console.WriteLine($" Seconds consumed : {tw.Elapsed.TotalSeconds}");
        Console.WriteLine($" Milliseconds : {tw.Elapsed.TotalMilliseconds}");
        Console.WriteLine($" The raw cpu cycles : {tw.ElapsedTicks}");
    }
}



public static class FactorialUsingFor
{
    public static void Run()
    {
        /*Rewrite program 14 using for loop
        Hint =>
        Take the integer input, check for natural number and determine the factorial using for loop
        and finally print the result.
        */

        Console.WriteLine(" Enter the integer number for which you want the factorial : ");
        int n = Convert.ToInt32(Console.ReadLine());

        // Checking if it's a +ve integer
        if (n < 0)
        {
            Console.WriteLine("Please enter a non-negative integer.");
            return;
        }

        // Special case for 0! = 1
        if (n == 0)
        {
            Console.WriteLine(" The factorial of 0 is : 1");
            return;
        }

        // Using for loop to find the factorial
        int factorial = 1;
        int N = n; // backup of original number
        Stopwatch tf = Stopwatch.StartNew(); // start timing
        for (int i = 1; i <= N; i++)
        {
            factorial *= i;
        }
        tf.Stop(); // stop timing

        // Printing the result
        Console.WriteLine($" The factorial of {N} is : {factorial}");
        Console.WriteLine($" Seconds consumed : {tf.Elapsed.TotalSeconds}");
        Console.WriteLine($" Milliseconds : {tf.Elapsed.TotalMilliseconds}");
        Console.WriteLine($" The raw cpu cycles : {tf.ElapsedTicks}");
    }
}



public static class OddEvenNumbers
{
    public static void Run()
    {
        /*Create a program to print odd and even numbers between 1 to the number entered by the user.
        Hint =>
        Get an integer input from the user, assign to a variable number and check for Natural Number.
        Using a for loop, iterate from 1 to the number.
        In each iteration of the loop, print the number is odd or even number.
        */

        Console.WriteLine(" Enter the integer number up to which you want odd/even check : ");
        int number = Convert.ToInt32(Console.ReadLine());

        // Checking if it's a natural number
        if (number <= 0)
        {
            Console.WriteLine("Please enter a positive natural number.");
            return;
        }

        // Using for loop
        for (int i = 1; i <= number; i++)
        {
            if (i % 2 == 0)
            {
                Console.WriteLine($" {i} is an Even number");
            }
            else
            {
                Console.WriteLine($" {i} is an Odd number");
            }
        }
    }
}



public static class EmployeeBonus
{
    public static void Run()
    {
        /*Create a program to find the bonus of employees based on their years of service.
        Hint =>
        Zara decided to give a bonus of 5% to employees whose year of service is more than 5 years.
        Take salary and year of service in the year as input.
        Print the bonus amount.
        */

        Console.WriteLine(" Enter the employee salary : ");
        double salary = Convert.ToDouble ( Console.ReadLine() ) ;

        Console.WriteLine ( " Enter the employee years of service : " );
        int years = Convert.ToInt32 (Console.ReadLine() ); // yearsOfService

        // Checking if salary and years of service are valid
        if (salary < 0 || years < 0)
        {
            Console.WriteLine(" Please enter valid positive values for salary and years .");
            return ;
        }

        // Bonus solution
        double bonus = 0 ; // using double for value can be in decimals as well
        if (years > 5)
        {
            bonus = salary * 0.05; // since it was mentioned as 5% bonus
            Console.WriteLine ( $" Employee is eligible for bonus. Bonus amount is : {bonus} " ) ;
        }
        else
        {
            Console.WriteLine ( " Employee is not eligible for bonus as they have less than or equal to 5 years of service .") ;
        }
    }
}



public static class MultiplicationTable
{
    public static void Run()
    {
        /*Create a program to find the multiplication table of a number entered by the user from 6 to 9.
        Hint =>
        Take integer input and store it in the variable number.
        Using a for loop, find the multiplication table of number from 6 to 9
        and print it in the format number * i = ___
        */

        Console.WriteLine(" Enter the integer number for which you want to get the multiplication table : ");
        int n = Convert.ToInt32 (Console.ReadLine()); // initializing the number

        // Checking if the number is valid or not as only natural numbers are allowed
        if (n <= 0)
        {
            Console.WriteLine(" Please enter a +ve natural number.");
            return ;
        }

        // Multiplication table from 6 to 9
        Console.WriteLine($" Multiplication table of {n} from 6 to 9 :") ;
        for (int i = 6; i <= 9; i++)
        {
            Console.WriteLine($" {n} * {i} = {n * i}" ) ;
        }
    }
}