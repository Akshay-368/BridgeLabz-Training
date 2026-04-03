using System;

public static class prog
{
    public static void Main(string[] args)
    {
        /*
        * Festival Lucky Draw 🎉
        At Diwali mela, each visitor draws a number.
        ● If the number is divisible by 3 and 5, they win a gift.
        ● Use if, modulus, and loop for multiple visitors.
        ● continue if input is invalid.
        */
        
        // diwali lucky draw at mela
        
        Console.WriteLine("Welcome to Diwali Mela Lucky Draw !");
        Console.WriteLine("Enter your lucky number , if divisible by 3 and 5 you win big gift !!");
        
        bool mo = true; // more visitors
        
        int wc = 0; // win count
        
        while(mo)
        {
            Console.WriteLine("\nNext visitor , please enter your number (or type quit to end) :");
            
            string inp = Console.ReadLine();
            inp = inp.Trim();
            
            if(inp.ToLower() == "quit" || inp.ToLower() == "exit")
            {
                mo = false;
                Console.WriteLine("Lucky draw over , thanks for coming !");
                break;
            }
            
            // check if valid number
            if(!int.TryParse(inp , out int num))
            {
                Console.WriteLine("hey thats not a proper number , try again");
                continue; // invalid , skip to next visitor
            }
            
            if(num <= 0)
            {
                Console.WriteLine("number should be positive , try again");
                continue;
            }
            
            // now check win condition
            if(num % 3 == 0 && num % 5 == 0)
            {
                wc++;
                Console.WriteLine("WOW !! " + num + " is divisible by both 3 and 5 !!");
                Console.WriteLine("YOU WIN A BIG GIFT !!! ");
            }
            else
            {
                Console.WriteLine("Sorry , " + num + " didnt win this time");
                if(num % 3 == 0) Console.WriteLine("it was divisible by 3 though");
                if(num % 5 == 0) Console.WriteLine("it was divisible by 5 though");
                Console.WriteLine("better luck next time !");
            }
            // why modulus ? coz thats how we check divisible
        }
        
        Console.WriteLine("Total winners today : " + wc );
        Console.WriteLine("happy diwali everyone !!");
    }
}
