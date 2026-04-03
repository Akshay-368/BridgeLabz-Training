using System;
class Simple_Interest
{
    public static void Main ()
    {
        Console.WriteLine (" Enter the principal amount : "); // Asking user for the principal money amount
        double p = double.Parse ( Console.ReadLine () ) ; // Taking the value of principal amount that user enetered
        // used parse method to convert the string input to the target type which is double here and hence we used double.Parse and not int.Parse
        // We use double here because these financial values can be in decimal as well

        // Similarly taking rate of interest and time period  ( in years ) from user

        Console.WriteLine ( " Enter the value of interest rate ( per annum only  ) : ");
        double r = double.Parse ( Console.ReadLine () ) ; // Taking the value of rate of interest that user entered

        Console.WriteLine ( " Enter the time period ( in years only ) : " ) ;
        double t = double.Parse ( Console.ReadLine ( ) ) ;

        // Now using formula SI = ( P * R * T ) / 100 to calculate simple interest

        double si = ( p * r * t ) / 100 ;
        Console.WriteLine ( " The simple interest for the given principal amount, rate of interest and time period is : " + si+ " units " ) ;
        Console.WriteLine ( " Or " + int.Parse (si.ToString()) + " (approx) units " ) ; // Converting the double value of simple interest to integer value using ToString method and then Parse method
    }
}
