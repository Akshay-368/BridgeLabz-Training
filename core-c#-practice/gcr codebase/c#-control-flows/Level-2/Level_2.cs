using System ;
using System.Runtime.CompilerServices;
namespace Level_2 ;

public static class LeapYear
{
    public static void Run()
    {
        /*
        Write a LeapYear program that takes a year as input and outputs the Year is a Leap Year or not a Leap Year.
        Hint => The LeapYear program only works for year >= 1582, corresponding to a year in the Gregorian calendar.
        So ensure to check for the same.
        Further, the Leap Year is a Year divisible by 4 and not 100 unless it is divisible by 400. E.g. 1800 is not a Leap Year
        and 2000 is a Leap Year.
        Write code having multiple if else statements based on conditions provided above and
        a second part having only one if statement and multiple logical
        */

        Console.WriteLine( " Enter a year ( >= 1582 ) : " ) ;
        int year = Convert.ToInt32 ( Console.ReadLine() );

        //  multiple if-else statements
        Console.WriteLine ( "Checking with multiple if-else statements as asked in question .");
        if (year < 1582)
        {
            Console.WriteLine("Year must be >= 1582 ( as per Gregorian calendar given in the question ).");
        }
        else
        {
            if ( year % 400 == 0 )
            {
                Console.WriteLine( $"{year} is a Leap Year " ) ;
            }
            else if ( year % 100 == 0)
            {
                Console.WriteLine( $"{year} is NOT a Leap Year." );
            }
            else if ( year % 4 == 0)
            {
                Console.WriteLine( $"{year} is a Leap Year." );
            }
            else
            {
                Console.WriteLine ($"{year} is NOT a Leap Year.");
            }
        }

        // Second approach as given in question : single if statements with logical conditions
        if ( year >= 1582 && ( year % 400 == 0 || ( year % 4 == 0 && year % 100 != 0 ) ) )
        {
            Console.WriteLine($"{year} is a Leap Year " ) ;
        }
        
    }
}

public class AverageMarks
{
    public static void Run()
    {
        /*Write a program to input marks and 3 subjects physics, chemistry and maths.
        Compute the percentage and then calculate the grade as per the following guidelines
        Hint =>
        Ensure the Output clearly shows the Average Mark as well as the Grade and Remarks
        */

        Console.WriteLine (" Input the marks of 3 subjects (physics , chemistry , maths ) , space seperated :  ");
        string s = Console.ReadLine();
        string[] a = s.Split ();
        double physics = Convert.ToDouble (a[0]);
        double chemistry = Convert.ToDouble (a[1]);
        double maths = Convert.ToDouble (a[2]);
        double percentage = (maths + physics + chemistry) / 3 ; // no need to convert explicitly from int to double

        // Calling a  function
        (string grade, string remarks) = fun(percentage); // to get grade and remarks

        Console.WriteLine($"The average marks are: {percentage:F2}"); // F2 is a format specifier in C# and
        //  it stands for Fixed-point format (i.e., a number with a fixed number of decimal places).
        // Basically - The number after F (like 2) tells C# how many decimal places to show.

        Console.WriteLine($"Grade: {grade}");
        Console.WriteLine($"Remarks: {remarks}");
    }
    private static (string , string) fun (double percentage)
    {
        if (percentage <= 39)
        {
            return ("R" , "Remedial Standards ");
        }
        else if ( percentage >= 40 && percentage <= 49)
        {
            return ( "E" , "Level - 1- ,too below agency-normalise standards ");
        }
        else if (percentage >= 50 && percentage <= 59)
        {
            return ( "D" , "Level -1 , well below agency normalised standards ");
        }
        else if (percentage >= 60 && percentage <= 69)
        {
            return ( "C" , "Level - 2 below  but approaching agency normalised standards ");
        }
        else if (percentage >= 70 && percentage <= 79)
        {
            return ( "B" , "Level - 3,  at agency normalised standards ");
        }
        else
        {
            return ( "A" , "Level - 4 above agency normalised standards ");
        }
    }
}

public class PrimeNumber
{
    public static void Run()
    {
        /*Write a Program to check if the given number is a prime number or not
        Hint =>
        A number that can be divided exactly only by itself and 1 are Prime Numbers,
        Prime Numbers checks are done for numbers greater than 1
        Loop through all the numbers from 2 to the user input number and check if the reminder is zero.
        If the reminder is zero break out from the loop as the number is divisible by some other number and is not a prime number.
        Use isPrime boolean variable to store the result
        */

        Console.WriteLine (" Enter the number : ") ;
        int n = Convert.ToInt32 (  Console.ReadLine() ) ;
        bool ans = checkPrime (n);
        if (ans)
        {
            Console.WriteLine("The given number is prime");
        }else
        {
            Console.WriteLine( "The given number :{0} is not prime " , n );
        }
    }
    public static bool checkPrime (int n)
    {
        if ( n <= 1 ) return false ;
        if (n <= 3) return true;   // 2 and 3 are prime
        if (n % 2 == 0 || n % 3 == 0 ) return false ; // to eliminate the multiples of 2 and 3 which will automatically be not prime
        // since they would have more factors than 1 and number itself.
        // Thus we have checked for 2 , 3 and any multiples of them which include 6 and many more ....

        // We will only check until square root of n as any number after that will be just a repition of the previous calculations we already did.
        // For example if we have to find if 16 is prime or not , then sq. root of 16 is 4 and thus if we checked till 4, as in :
        // 16 % 1 = 0 ( 16 / 1 = 16) , 16 % 2 = 0 ( 16 / 2 = 8) , 16 % 3 != 0 ( 16 / 3 = 5) , 16 % 4 = 0 ( 16 / 4 = 4)
        // and as we can see any number after that will be just a repeition
        // Since after handling the prime numbers till 3 and any even numbers , any prime number ahead can only be of the form 6k + 1 or 6k - 1.
        // Here i handles 6k-1 and i + 2 handles cases for 6k + 1

        for ( int i = 5 ; i * i <= n ; i += 6)
        {
            if  ( (n % i == 0 ) || n % ( i + 2) == 0 )
            {
                return false ;
            }
        }
        return true ;

    }
}

public class Multiples
{
    public static void Run()
    {
        /*
        Program to find all multiples of a number below 100.
        Hint =>
        Get input value for a variable named number.
        Run a for loop backward: from i = 100 to i = 1.
        Inside the loop, check if i perfectly divides the number.
        If true, print the number and continue the loop.
        */

        Console.WriteLine("Enter a number to find its multiples below 100: " ) ; // Asking user for input
        int num = Convert.ToInt32( Console.ReadLine() ) ;

        Console.WriteLine( $"Multiples of {num} below 100 are : " ) ;

        for ( int i = 100 ; i >= 1 ; i-- )
        {
            if ( i % num == 0 )
            {
                Console.WriteLine(i);
            }
        }
    }
}

public class FizzBuzz
{
    public static void Run()
    {
        /*Write a program FizzBuzz, take a number as user input, and if it is a positive integer loop from 0 to
        the number and print the number, but for multiples of 3 print "Fizz" instead of the number,
        for multiples of 5 print "Buzz", and for multiples of both print "FizzBuzz".
        Hint =>
        Write the program and use for loop
        */
        Console.WriteLine (" Enter the positive integer : ");
        int n = Convert.ToInt32 ( Console.ReadLine() ) ;

        // Now using loop and if else as per the given conditions
        for ( int i = 0 ; i <= n ; i ++)
        {
            if ( i % 3 == 0  && i % 5 != 0 )
            {
                Console.WriteLine ($"Number is {i} and that's why Fizz"); //only divisible by 3
            }else if ( i % 5 == 0  && i%3 != 0)
            {
                Console.WriteLine ( $"Number is {i} and that's why Buzz"); // only divisible by 5
            }else if (i % 3 == 0 && i % 5 == 0) {
                Console.WriteLine ( $"Number is {i} and that's why FizzBuzz"); // divisible by 5 and 3 both
            }
            else
            {
                Console.WriteLine ($" Number is : {i}"); // Divisible by neither 3 nor 5
            }
        }
    }
}

public class FizzBuzz2
{
    public static void Run()
    {
        /* Rewrite the program 5 FizzBuzz using while loop - as the question was :
        Write a program FizzBuzz, take a number as user input, and if it is a positive integer loop from 0 to
        the number and print the number, but for multiples of 3 print "Fizz" instead of the number,
        for multiples of 5 print "Buzz", and for multiples of both print "FizzBuzz".
        Hint =>
        Write the program and use for loop
        */
        Console.WriteLine (" Enter the positive integer : ");
        int n = Convert.ToInt32 ( Console.ReadLine() ) ;

        // Now using loop and if else as per the given conditions
        int i = 0 ; //  Initializing it to zero as per the question
        while (i <= n )
        {
            if ( i % 3 == 0  && i % 5 != 0 )
            {
                Console.WriteLine ($"Number is {i} and that's why Fizz"); //only divisible by 3
            }else if ( i % 5 == 0  && i%3 != 0)
            {
                Console.WriteLine ( $"Number is {i} and that's why Buzz"); // only divisible by 5
            }else if (i % 3 == 0 && i % 5 == 0) {
                Console.WriteLine ( $"Number is {i} and that's why FizzBuzz"); // divisible by 5 and 3 both
            }
            else
            {
                Console.WriteLine ($" Number is : {i}"); // Divisible by neither 3 nor 5
            }
            i = i + 1 ;
        }
    }
}

public class PowerOfNumber
{
    public static void Run()
    {
        /*
        Program to find the power of a number.
        Hint =>
        Get integer input for two variables named number and power.
        Create a result variable with an initial value of 1.
        Run a for loop from i = 1 to i <= power.
        In each iteration of the loop, multiply the result with the number and assign the value to the result.
        Finally, print the result.
        */

        Console.WriteLine( " Enter the base number: " ) ;
        int number = Convert.ToInt32 ( Console.ReadLine() ) ;

        Console.WriteLine( " Enter the power (exoponent): " ) ;
        int power = Convert.ToInt32 ( Console.ReadLine() ) ;

        int result = 1; // Since we need a storage and a variable with which we can start multiplying the number that does not changes the number itself
        // Now applying the loop as per the question
        for (int i = 1; i <= power; i++)
        {
            result = result * number ; // Now using the formula given in question to basically self multiply number 'power' number of tiemes with itself
        }

        Console.WriteLine ( $"{number} raised to the power {power} is: {result} " ) ;
    }
}

public class GreatestFactor
{
    public static void Run()
    {
        /*
        Program to print the greatest factor of a number beside itself.
        Hint =>
        Get an integer input and assign it to the number variable.
        Define a greatestFactor variable and assign it to 1.
        Create a for loop that runs from i = number - 1 down to 1.
        Inside the loop, check if the number is perfectly divisible by i.
        If true, assign i to greatestFactor and break the loop.
        Display the greatestFactor outside the loop.
        */

        Console.WriteLine( " Enter a number ( int only ) : " ) ;
        int n = Convert.ToInt32 ( Console.ReadLine() ) ;

        int greatestFactor = 1; // initializing the variable as asked in the question

        for (int i = n - 1 ; i >= 1 ; i--)
        // Starting from n and going towards one , thus if we find any factor ,then the very first factor will be the largest here
        // because of the order we chose to go in the loop , n to 1 .
        // we just need to keep on dividing the number with every other value of i and the very moment it get divided completely
        // That is when we have found our solution.
        {
            if (  n % i == 0)
            {
                greatestFactor = i ;
                break ; // stop at the largest factor found
            }
        }

        Console.WriteLine( $" The greatest factor of {n} other than itself is : {greatestFactor}" ) ;
    }
}

public class YoungestFriends
{
    public static void Run()
    {
        /*5.Create a program to find the youngest friends among 3 Amar, Akbar,
        and Anthony based on their ages and the tallest among the friends based on their heights
        Hint =>
        Take user input for the age and height of the 3 friends and store it in a variable
        Find the smallest of the 3 ages to find the youngest friend and display it
        Find the largest of the 3 heights to find the tallest friend and display it
        */

        // Asking user details for Amar
        Console.WriteLine("Enter the age and height of Amar ( with space sperated in a single line )");
        string s = Console.ReadLine ();
        string[] a = s.Split();
        int ageAmar = Convert.ToInt32 ( a[0]  );
        int heightAmar = Convert.ToInt32 ( a[1] ) ;

        // Asking user details for Akbar
        Console.WriteLine(" Enter the age and height of Akbar (space separated in a single line ) ") ;
        s = Console.ReadLine();
        a = s.Split();
        int ageAkbar = Convert.ToInt32(a[0]);
        int heightAkbar = Convert.ToInt32(a[1]);

        // Asking user details for Anthony
        Console.WriteLine(" Enter the age and height of Anthony ( with space sperated in a single line ) ");
        s = Console.ReadLine();
        a = s.Split();
        int ageAnthony = Convert.ToInt32( a[0] );
        int heightAnthony = Convert.ToInt32( a[1] );

        // Finidng the smallest of th 3 ages from 3 of them by using a built-in function
        int youngestAge = Math.Min( ageAmar, Math.Min(ageAkbar, ageAnthony) ) ;
        string youngestFriend;
        if (youngestAge == ageAmar) {
            youngestFriend = "Amar" ;
        } else if (youngestAge == ageAkbar) {
            youngestFriend = "Akbar" ;
        } else {
            youngestFriend = "Anthony" ;
        }

        Console.WriteLine ( $" The youngest of the 3 is of the age : {youngestAge} and the friend is : {youngestFriend}" );

        // Finding the tallest height among the three with chained compairison operators
        ( string n , int h ) tallest ; // Initializing the tallest name and heigt tuple to contain the values at one place
        // which can be accessed with dot operator and the name of variable
        // as In C# tuples are structured objects unlike python where they are sequences , and thus to access anything inside an object which
        // are it's properties we will need '.' operator to access them
        if ( heightAmar >= heightAkbar &&  heightAmar >= heightAnthony)
        {
            tallest = ( "Amar" , heightAmar  ) ;
        }else if ( heightAkbar >= heightAmar && heightAkbar >= heightAnthony)
        {
            tallest = ( "Akbar" , heightAkbar ) ;
        }else
        {
            tallest = ( "Anthony" , heightAnthony ) ;
        }
        Console.WriteLine($"The tallest friend is: {tallest.n} and that person is {tallest.h}");


    }
}

public class BMICalculator
{
    public static void Run()
    {
        /*
        Program to calculate BMI and determine weight status.
        Hint =>
        Take user input for weight (kg) and height (cm).
        Convert height from cm to meters.
        Use formula: BMI = weight / (height * height).
        Determine weight status using given ranges.
        */

        Console.WriteLine(  " Enter your weight in kg : " ) ;
        double weight = Convert.ToDouble( Console.ReadLine() ) ;

        Console.WriteLine  ( " Enter your height in cm : " ) ;
        double heightCm = Convert.ToDouble( Console.ReadLine() ) ;

        // Now converting height into meteres from cm
        double heightM = heightCm / 100.0 ; // for double division otherwise with pure 100 it would have been int div

        // Calculating BMI with the help of the formula
        double bmi = weight / (heightM * heightM ) ;

        // Now for weight status
        string status  ;
        if ( bmi <= 18.4 ) {
            status = "Underweight" ;
            }
        else if ( bmi >= 18.5 && bmi <= 25.9 ){
            status = "Normal" ;
        }
        else if (bmi >= 25.0 && bmi <= 39.9) {
            status = "Overweight";
        }
        else {
            status = "Obese" ;
        }

        Console.WriteLine( $" Your BMI is : {bmi:F2} " ) ; // Fixed points after decimal
        Console.WriteLine ( $"Weight Status : {status} " ) ;
    }
}

public class FactorsOfNumber
{
    public static void Run()
    {
        /*
        Program to find the factors of a number taken as user input.
        Hint =>
        Get input value for variable 'number'.
        Run a for loop from i = 1 to i < number.
        In each iteration, check if number is perfectly divisible by i.
        If true, print the value of i.
        */

        Console.WriteLine (" Enter a number : " ) ; // Asking user for input
        int number = Convert.ToInt32 ( Console.ReadLine() ) ; // Taking input as an int and naming and storing it in var as per question

        Console.WriteLine ( $" Factors of {number} are : " ) ;

        for (int i = 1 ; i < number ; i++)
        {
            if ( number % i == 0 )
            {
                Console.WriteLine( i ) ;
            }
        }
    }
}

