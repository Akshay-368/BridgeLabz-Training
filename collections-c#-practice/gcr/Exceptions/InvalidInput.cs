using System;

public class intCalc 
{
    // calculate simple interest
    // throw exception if amount or rate negative
    public static double calculateInterest(double amount,double rate,int years)
    {
        if(amount < 0 || rate < 0)
        {
            throw new ArgumentException("Amount and rate must be positive");
        }

        double interest = amount * rate * years / 100;
        return interest;
    }

    public static void Main(string[] args) 
    {
        /*
        6. Handling Invalid Input in Interest Calculation
        💡 Problem Statement:
        Create a method CalculateInterest(double amount, double rate, int years) that:
        * Throws ArgumentException if amount or rate is negative.
        * Propagates the exception using throw and handles it in Main().
        Expected Behavior:
        * If valid, return and print the calculated interest.
        * If invalid, catch and display "Invalid input: Amount and rate must be positive".
        */

        Console.WriteLine("Simple Interest Calculator\n");

        Console.Write("Waiting , for user to enter principal amount : ");
        double amt = Convert.ToDouble(Console.ReadLine());

        Console.Write("Waiting , for user to enter rate (%) : ");
        double rt = Convert.ToDouble(Console.ReadLine());

        Console.Write("Waiting , for user to enter years : ");
        int yrs = Convert.ToInt32(Console.ReadLine());

        try
        {
            double intResult = calculateInterest(amt, rt, yrs);
            Console.WriteLine("Interest = " + intResult);
        }
        catch(ArgumentException argEx)
        {
            Console.WriteLine("Invalid input: Amount and rate must be positive");
            Console.WriteLine("(details: " + argEx.Message + ")");
        }
        catch(Exception e)
        {
            Console.WriteLine("some error : " + e.Message);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
