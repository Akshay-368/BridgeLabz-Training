using System ;
class Discount {
    public static void Main()
    {
        /* 6. The University is charging the student a fee of INR 125000 for the course. The University is willing to offer a discount of 10%.
        Write a program to find the discounted amount and discounted price the student will pay for the course.
Hint:
Create a variable named fee and assign 125000 to it.
Create another variable discountPercent and assign 10 to it.
Compute discount and assign it to the discount variable.
Compute and print the fee you have to pay by subtracting the discount from the fee.
I/P => NONE
O/P => The discount amount is INR ___ and final discounted fee is INR ___
        */

        int fee = 125000 ; // in inr , fees of the course
        int discountPercent = 10 ; // in percent , discount percentage

        double discount = (fee * discountPercent) / 100.0 ; // calculating the discount amount
        double ff = fee - discount ; // calculating the final discounted fee

        Console.WriteLine ( " The discount amount is INR " + discount + " and final discounted fee is INR " + ff ) ;
    }
}