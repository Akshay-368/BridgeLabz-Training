using System;
class Average_of_three
{
    public static void Main ()
    {
        Console.WriteLine ( " Enter the first number : " ) ; // Asking user for first number
        double val1 = double.Parse ( Console.ReadLine () ) ; // Taking the value of first number that user entered
        // Converting string input to target type which is double here using Parse method
        // Using double here because the numbers can be in decimal as well

        Console.WriteLine ( " Enter the second number : " ) ; // Asking user for second number
        double val2 = double.Parse ( Console.ReadLine () ) ; // Taking the value of second number that user entered

        Console.WriteLine ( " Enter the third number : " ) ; // Asking user for third number
        double val3 = double.Parse ( Console.ReadLine () ) ; // Taking the value of third number that user entered

        // using formula to calculate average of three numbers which is ( val1 + val2 + val3 ) / 3
        double avg = ( val1 + val2 + val3 ) / 3 ;
        Console.WriteLine ( " The average of the three numbers is : " + avg ) ; // Showing the average of three numbers
        Console.WriteLine ( " Or " + (int)avg + " ( approx ) " ) ; // Showing approximate average in integer value using casting
    }
}
