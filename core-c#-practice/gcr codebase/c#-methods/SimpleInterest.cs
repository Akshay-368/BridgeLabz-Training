using System;
class Simple_Interest
{
    public static void Main ()
    {
        /*
        11. Write a program to input the Principal, Rate, and Time values and calculate Simple Interest.
        Hint: Write a method to calculate the simple interest given principle, rate and time as parameters
        Simple Interest = (Principal * Rate * Time) / 100
        I/P => principal, rate, time
        O/P => The Simple Interest is ___ for Principal ___, Rate of Interest ___ and Time ___
        */

        Console.WriteLine (" Enter the principal amount : "); // Asking user for the principal money amount
        double p = double.Parse ( Console.ReadLine () ) ; // Taking the value of principal amount that user enetered
        // used parse method to convert the string input to the target type which is double here and hence we used double.Parse and not int.Parse
        // We use double here because these financial values can be in decimal as well

        // Similarly taking rate of interest and time period  ( in years ) from user

        Console.WriteLine ( " Enter the value of interest rate ( per annum only  ) : ");
        double r = double.Parse ( Console.ReadLine () ) ; // Taking the value of rate of interest that user entered

        Console.WriteLine ( " Enter the time period ( in years only ) : " ) ;
        double t = double.Parse ( Console.ReadLine ( ) ) ;

        Func (p , r, t); // Calling the function to calculate the simple interest
        
    }
    private static void Func (double p , double r , double t)
    {
        // Now using formula SI = ( P * R * T ) / 100 to calculate simple interest

        double si = ( p * r * t ) / 100 ;
        Console.WriteLine ( " The simple interest for the given principal amount, rate of interest and time period is : " + si+ " units " ) ;
        Console.WriteLine ( " Or " + int.Parse (si.ToString()) + " (approx) units " ) ; // Converting the double value of simple interest to integer value using ToString method and then Parse method
        // Here we could have also converted using : type casting - (int) si ; or we can also use Convert.ToInt32 (si) to convert this double to int
        // but this way we learn about another built in  method variable.ToString() to convert the varibale into string . 
        // Other than we also have this cool method called string.IsNullOrWhiteSpace(varibale) function to check if the variable is null or white space
        // then couple it with ternary operator to get the default condition or anything else
        // We also have double.TryParse() or int.TryParse() as well
    }
}
