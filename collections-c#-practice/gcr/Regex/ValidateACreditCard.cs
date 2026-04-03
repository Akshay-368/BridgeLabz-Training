using System;

public class cardVal 
{
    // simple visa/mastercard validation
    // 16 digits , starts with 4 or 5
    public static bool isValidCard(string cardNum)
    {
        // remove spaces
        cardNum = cardNum.Replace(" ", "");

        if(cardNum.Length != 16)
        {
            Console.WriteLine("must be exactly 16 digits");
            return false;
        }

        // check all digits
        for(int i=0; i<16 ; i++)
        {
            if(!char.IsDigit(cardNum[i]))
            {
                Console.WriteLine("only digits allowed");
                return false;
            }
        }

        // visa starts with 4 , master with 5
        if(!cardNum.StartsWith("4") && !cardNum.StartsWith("5"))
        {
            Console.WriteLine("only Visa (4) or MasterCard (5) supported");
            return false;
        }

        Console.WriteLine("valid card number");
        return true;
    }

    public static void Main(string[] args) 
    {
        /*
        11. Validate a Credit Card Number (Visa, MasterCard, etc.)
        * A Visa card number starts with 4 and has 16 digits.
        * A MasterCard starts with 5 and has 16 digits.
        */

        Console.WriteLine("Credit Card Validator (Visa/MasterCard)\n");

        while(true)
        {
            Console.Write("Waiting , for user to enter card number (or empty to exit) : ");
            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input)) break;

            isValidCard(input);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
