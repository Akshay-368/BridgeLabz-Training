using System;
class TotalSalary
{
    public static void Main()
    {
        /*6. Create a program to find the total income of a person by taking salary and bonus from the user
Hint:
Create a variable named salary and take user input.
Create another variable bonus and take user input.
Compute income by adding salary and bonus and print the result.
I/P => salary, bonus
O/P => The salary is INR ___ and bonus is INR ___. Hence Total Income is INR ___

        */
        Console.WriteLine (" Enter your salary (per year) :" );
        double salary = double.Parse ( Console.ReadLine());
        Console.WriteLine ( "Enter the bonus that you received : " );
        double bonus = Convert.ToDouble (Console.ReadLine () ) ;
        double income = salary + bonus ;
        Console.WriteLine ( " The salary is INR {0} and bonus is INR {1} . Hence the Total Income is INR {2}" , salary , bonus , income );
    }
}