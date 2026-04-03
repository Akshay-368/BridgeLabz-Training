using System;

public class bk
{
    string ttl;
    string atr;
    double prc;
    
    // default constructor
    public bk()
    {
        ttl = "Unknown Title";
        atr = "Unknown Author";
        prc = 0.0;
    }
    
    // parameterized constructor
    public bk(string t, string a, double p)
    {
        ttl = t;
        atr = a;
        prc = p;
    }
    
    public void disp()
    {
        Console.WriteLine("  Book Details:");
        Console.WriteLine ("Title  : " + ttl);
        Console.WriteLine(" Author : "  + atr);
        Console.WriteLine( "Price  : " + prc);
    }
    
    public static void Main(string[] args)
    {
        /*
        1. Book Class
           * Create a Book class with attributes title, author, and price.
           * Provide both default and parameterized constructors.
        */
        
        Console.WriteLine ( " testing default constructor " ) ;
        bk b1 = new bk();
        b1.disp();
        
        Console.WriteLine();
        
        Console.WriteLine (  " now testing parameterized " ) ;
        bk b2 = new bk (  " C # Basics", "John Doe", 899.99);
        b2.disp();
        
        Console.WriteLine ( "press enter to finish..");
        Console.ReadLine() ;
    }
}
