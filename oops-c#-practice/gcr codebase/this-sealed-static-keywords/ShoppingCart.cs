using System;

public static class prog
{
    public static void Main(string[] args)
    {
        /*
        Sample Program 4: Shopping Cart System
        Create a Product class to manage shopping cart items with the following features:

        * static: 
          * A static variable Discount shared by all products.
          * A static method UpdateDiscount() to modify the discount percentage.

        * this: 
          * Use this to initialize ProductName, Price, and Quantity in the constructor.

        * readonly: 
          * Use a readonly variable ProductID to ensure each product has a unique identifier that cannot be changed.

        * is operator: 
          * Validate whether an object is an instance of the Product class before processing its details.
        */
        
        // shop cart program here
        
        prod.dc = 10; // starting discount
        
        prod p1 = new prod("phone", 500 , 2 , 1001);
        prod p2 = new prod("earbuds" ,80,5,1002);
        
        Console.WriteLine("Current discount for all items : " + prod.dc + "%");
        
        object x = p1;
        
        if(x is prod )
        {
            prod pp = (prod)x;
            pp.sh(); // show details only if its a real prod
        }
        
        prod.ud(15); // update discount now
        
        Console.WriteLine("After update , discount is " + prod.dc + "%");
        
        p2.sh();
    }
}

public static class prod
{
    public static int dc; // discount same for all products
    
    public readonly int pid; // cant change product id
    public string pn; // product name
    public double pr; // price
    public int qt; // quantity
    
    public prod(string n,double p,int q,int i)
    {
        this.pn = n;
        this.pr = p;
        this.qt = q;
        this.pid = i; // readonly set once
        // why here ? coz constructor is only place to set readonly
    }
    
    public static void ud(int nd)
    {
        dc = nd; // change discount for everyone
        Console.WriteLine("discount updated to " + nd);
    }
    
    public void sh()
    {
        double af = pr * (100 - dc)/100.0; // price after discount
        double tot = af * qt;
        Console.WriteLine("Product : " + this.pn );
        Console.WriteLine("Price after discount : " + af );
        Console.WriteLine("Quantity : " + qt );
        Console.WriteLine("Total : " + tot );
    }
}
