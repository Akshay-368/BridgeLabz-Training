using System;

public class prod
{
    string name;
    double prc;
    
    static int tot = 0; // class variable, shared by all
    
    public prod(string n, double p)
    {
        name = n;
        prc  = p;
        tot ++;  // one more product created
    }
    
    public void dispdet()
    {
        // printing one product details
        Console.WriteLine("Product Name : " + name);
        Console.WriteLine("Price        : " + prc);
    }
    
    public static void disptot()
    {
        // class method to show total products made
        Console.WriteLine("Total Products Created: " + tot);
    }
    
    public static void Main(string[] args)
    {
        /*
        Problem 1: Product Inventory

        * Create a Product class with:

          * Instance Variables: productName, price.

          * Class Variable: totalProducts (shared among all products).

        * Implement the following methods:

          * An instance method DisplayProductDetails() to display the details of a product.

          * A class method DisplayTotalProducts() to show the total number of products created.
        */
        
        prod p1 = new prod( "Laptop", 45000.50) ;
        prod p2 = new prod  ("Mouse" , 800);
        prod p3 = new prod(" Keyboard", 1500.75 );
        
        Console.WriteLine("showing individual products");
        Console.WriteLine() ;
        
        p1.dispdet();
        Console.WriteLine() ;
        
        p2.dispdet();
        Console.WriteLine( );
        
        p3.dispdet ();
        Console.WriteLine();
        
        prod.disptot (); // total count
        
        Console.WriteLine("  press enter to finish...");
        Console.ReadLine ();
    }
}
