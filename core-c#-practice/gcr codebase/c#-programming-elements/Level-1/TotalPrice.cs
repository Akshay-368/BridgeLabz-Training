using System ;
class TotalPrice
{
    public static void Main ()
    {
        /*
        15. Write a program to input the unit price of an item and the quantity to be bought. Then, calculate the total price.
Hint: NA
I/P => unitPrice, quantity
O/P => The total purchase price is INR ___ if the quantity ___ and unit price is INR ___

        */
        Console.WriteLine ( " Enter both unit price and item quantity ( sperated by space ) : " ) ;
        string i = Console.ReadLine ();
        string[] I = i.Split( ' ' );
        double u = Convert.ToDouble ( I[0]);
        double q = Convert.ToDouble ( I[1]);

        double tp = u * q ;
        Console.WriteLine ( " The total purchase prince is INR {0} , if the quantity {1}  and unit price is INR {2} " , tp , q , u ) ;

    }

}