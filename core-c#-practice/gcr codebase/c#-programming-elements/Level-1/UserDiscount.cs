using System ;
class UserDiscount {
    public static void Main()
    {
        /*9. Write a new program similar to the program # 6 but take user input for Student Fee and University Discount
Hint:
Create a variable named fee and take user input for fee.
Create another variable discountPercent and take user input.
Compute the discount and assign it to the discount variable.
Compute and print the fee you have to pay by subtracting the discount from the fee.
I/P => fee, discountPrecent
O/P => The discount amount is INR ___ and final discounted fee is INR ___

        */

        Console.WriteLine ( " Enter the student fee : " ) ;
        int fee = Convert.ToInt32 ( Console.ReadLine() ) ; // in inr , fees of the course
        Console.WriteLine ( " Enter the discount percentage : " ) ;
        int discountPercent = Convert.ToInt32 ( Console.ReadLine() ) ; // in percent , discount percentage

        double discount = (fee * discountPercent) / 100.0 ; // calculating the discount amount
        double ff = fee - discount ; // calculating the final discounted fee

        Console.WriteLine ( " The discount amount is INR " + discount + " and final discounted fee is INR " + ff ) ;
    }
}