using System;
// using System.Linq.Expressions;
namespace Level_3;

public static class Armstrong
{
    public static void Run()
    {
        /*Create a program to check if a number is Armstrong or not. Use the hints to show the steps clearly in the code
        Hint =>
        Armstrong Number is a number whose Sum of cubes of each digit results in the original number e.g. 153 = 1^3 + 5^3 + 3^
        3
        Get an integer input and store it in the number variable define sum variable, initialize it to zero and originalNumber variable,
        and assign it to the input number variable

        Use the while loop till the originalNumber is not equal to zero
        In the while loop find the reminder number by using the modulus operator as in  number % 10. Find the cube of the number
        and add it to the sum variable

        Again in while loop find the quotient of the number and assign it to the original number using number / 10 expression.
        This removes the last digit of the original number.

        Finally check if the number and the sum are the same, if same its an Armstrong number else not. So display accordingly
        */

        Console.WriteLine ( " Enter an int number for which you want to check if it is Armstrong : " );
        int arm = int.Parse(Console.ReadLine());

        int sum = 0 ;
        int originalNumber = arm ;
        
        while (arm != 0)
        {
            sum = sum + (int)Math.Pow(arm % 10, 3);
            arm = arm / 10;
        }

        if ( sum == originalNumber)
        {
            Console.WriteLine (" Yes the given number ; {0} is an Armstrong Number ." , originalNumber);

        }else
        {
            Console.WriteLine ($"No the given the number : {originalNumber} is not an Armstrong Number as its each digit's cube is : {sum}") ;
        }

    }
}

public static class NumberOfDigits
{
    public static void Run ()
    {
        /*Create a program to count the number of digits in an integer.
        Hint =>
        Get an integer input for the number variable.
        Create an integer variable count with value 0.
        Use a loop to iterate until number is not equal to 0.
        Remove the last digit from number in each iteration
        Increase count by 1 in each iteration.
        Finally display the count to show the number of digits
        */

        Console.WriteLine (" Enter an integer number for counting it's no.of digits : ");
        int var = Convert.ToInt32 (Console.ReadLine ());
        int originalNumber = var ;
        int digit; // for getting digits from the var
        int count = 0 ; // initializing count and it's value as well to zero
        while (var != 0)
        {
            digit = var % 10 ;
            count = count + 1 ;
            var = var / 10 ;
        }
        Console.WriteLine ( "The number of digits in the entered number : {0} is {1} " , originalNumber , count ) ;

    }
}

public static class HarshadNumber
{
    public static void Run()
    {
        /*Create a program to check if a number taken from the user is a Harshad Number.
        Hint =>
        A Harshad number is an integer which is divisible by the sum of its digits. 
        For example, 21 which is perfectly divided by 3 (sum of digits: 2 + 1).
        Get an integer input for the number variable.
        Create an integer variable sum with initial value 0.
        Create a while loop to access each digit of the number.
        Inside the loop, add each digit of the number to sum.
        Check if the number is perfectly divisible by the sum.
        If the number is divisible by the sum, print Harshad Number. Otherwise, print Not a Harshad Number.
        */
        
        Console.WriteLine (" Enter an integer for which you want to check if it is a Harshad No. : ");
        int n = Convert.ToInt32 (Console.ReadLine());
        int s = 0 ; // sum of the digits
        int originalNumber = n ;
        while (n != 0)
        {
            s = s + n % 10 ;
            n = n / 10 ;
        }
        if ( originalNumber % s  == 0)
        {
            Console.WriteLine (" Yes the entered number is Harshad number ");
        }else
        {
            Console.WriteLine (" No the given number is not a Harshad number ");
        }
    }
}

public static class AbundantNumber
{
    public static void Run()
    {
        /*Create a program to check if a number is an Abundant Number.
        Hint =>
        An abundant number is an integer in which the sum of all the divisors of the number is greater than the number itself. For example,
        Divisor of 12: 1, 2, 3, 4, 6
        Sum of divisor: 1 + 2 + 3 + 4 + 6 = 16 > 12
        Get an integer input for the number variable.
        Create an integer variable sum with initial value 0.
        Run a for loop from i = 1 to i < number.
        Inside the loop, check if number is divisible by i.
        If true, add i to sum.
        Outside the loop Check if sum is greater than number.
        If the sum is greater than the number, print Abundant Number. Otherwise, print Not an Abundant Number.
        */
        Console.WriteLine (" Enter an integer for which you want to check if it is a Abundant No. : ");
        int n = Convert.ToInt32 (Console.ReadLine()); // taking the number
        int s = 0 ; // sum of the digits
        int originalNumber = n ; // storing the original
        for (int i = 1 ; i < n ; i ++)
        {
            if ( n % i == 0)
            {
                s = s + i ;
            }
        }
        // checking if sum is greater than n
        if ( s > originalNumber)
        {
            Console.WriteLine (" Yes the given number : {0} is an abundant number as it's divisors sum is {1}" , originalNumber , s );
        }else
        {
            Console.WriteLine (" No the given number : {0} is not an abundant number as it's divisors sum is {1}" , originalNumber , s );
        }
    }
}

public static class Day_Week
{
    public static void Run()
    {
        /*
        Write a program DayOfWeek that takes a date as input and prints the day of the week that the date falls on.
        Your program should take three command-line arguments: m (month), d (day), and y (year). For m use 1 for January, 2 for February,
        and so forth. For output print 0 for Sunday, 1 for Monday, 2 for Tuesday, and so forth.
        Use the following formulas, for the Gregorian calendar (where / denotes integer division):
        y0 = y − (14 − m) / 12
        x = y0 + y0/4 − y0/100 + y0/400
        m0 = m + 12 × ((14 − m) / 12) − 2
        d0 = (d + x + 31m0 / 12) mod 7
        */
        Console.WriteLine (" Enter the input date for which you want to find the day of the week as in month ( 1 - 12 ) , day  and year ( seperated by space in a single line ) : ");
        string s = Console.ReadLine () ;
        string[] a = s.Split();
        int m =  Convert.ToInt32 ( a[0]  );
        int d = Convert.ToInt32 ( a[1]  ) ;
        int y = Convert.ToInt32 ( a[2] ) ;

        // Now applying formulas as per question :
        int y0 = y - (14 - m) / 12;
        int x = y0 + y0 / 4 - y0 / 100 + y0 / 400;
        int m0 = m + 12 * ((14 - m) / 12) - 2;
        int d0 = (d + x + (31 * m0) / 12) % 7;

        Console.WriteLine($"Day of week (0=Sunday, 1=Monday, ... , 6=Saturday): {d0}"); // Printing the result as oer the condition
    }
}

public static class Calculator
{
    public static void Run()
    {
        /*
        Write a program to create a calculator using switch...case.
        Hint =>
        Create two double variables named first and second and a String variable named op.
        Get input values for all variables.
        The input for the operator can only be one of the four values: "+", "-", "*" or "/".
        Run a for loop from i = 1 to i < number.
        Based on the input value of the op, perform specific operations using the switch...case statement and print the result.
        If op is +, perform addition between first and second; if it is -, perform subtraction and so on.
        If op is neither of those 4 values, print Invalid Operator.
        */
        double first , second ;
        string op ;
        Console.WriteLine ( " This is a calculator for two numbers only ");
        Console.WriteLine ( " Enter the value for the first number : ");
        first = double.Parse ( Console.ReadLine () ) ;
        Console.WriteLine ( " Enter the value for the second number : ");
        second = Convert.ToDouble ( Console.ReadLine () ) ;
        Console.WriteLine ( " Enter the value for the operator ( * , + , - , / ) : ");
        op = Console.ReadLine () ;
        Console.WriteLine ( "Enter the frequency till when you want to continue to run the calculator : ");
        int n = Convert.ToInt32 (  Console.ReadLine  );

        for ( int i = 0 ; i < n ; i ++)
        {
            switch (op)
            {
                case "+" :
                Console.WriteLine ( $" The answer of sum of of {first} + {second} is {second + first}");
                break ;

                case "-":
                    Console.WriteLine($"Result: {first - second}");
                    break;
                case "*":
                Console.WriteLine($"Result: {first * second}");
                break;

                case "/" :
                if (second != 0) {
                        Console.WriteLine($"Result: {first / second}");
                } else {
                        Console.WriteLine("Error: Division by zero is not allowed.");
                }
                break;
                default :
                Console.WriteLine ( "Invalid Operator " ) ;
                break ;

            }
        }

    }
}

