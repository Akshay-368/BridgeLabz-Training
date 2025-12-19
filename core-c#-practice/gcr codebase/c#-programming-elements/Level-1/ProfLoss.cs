using System;
class ProfLoss{
    public static void Main()
    {
        /*4. Create a program to calculate the profit and loss in number and percentage based on the cost price of INR 129 
        and the selling price of INR 191.
Hint:
Use a single print statement to display multiline text and variables.
Profit = selling price - cost price
Profit Percentage = profit / cost price * 100
I/P => NONE
O/P =>
The Cost Price is INR ___ and Selling Price is INR ___
The Profit is INR ___ and the Profit Percentage is ___
        */

        int cp = 129; // in inr
        int sp = 191 ; // in inr

        Console.WriteLine ( " The Cost Price is INR : " + cp + " and Selling Price is INR : " + sp ) ;

        int p = sp - cp ; // profit

        double pp = ( p / (double) cp ) * 100 ; // profite percentage

        Console.WriteLine ( " The Profit is INR : " + p + " and the Profit Percentage is : " + pp ) ;


    }
}