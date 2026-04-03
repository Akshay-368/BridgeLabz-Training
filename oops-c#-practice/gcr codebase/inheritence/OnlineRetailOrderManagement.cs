using System;

public static class prog
{
    public static void Main(  )
    {
        /*
        Sample Problem 1: Online Retail Order Management

        * Description: Create a multilevel hierarchy to manage orders, where Order is the base class, ShippedOrder is a subclass, and DeliveredOrder extends ShippedOrder.

        * Tasks:

          * Define a base class Order with common attributes like orderId and OrderDate.

          * Create a subclass ShippedOrder with additional attributes like TrackingNumber.

          * Create another subclass DeliveredOrder extending ShippedOrder, adding a DeliveryDate attribute.

          * Implement a method GetOrderStatus() to return the current order status based on the class level.

        * Goal: Explore multilevel inheritance, showing how attributes and methods can be added across a chain of classes.
        */
        
        // multilevel inheritance for orders
        
        ord o1 = new ord(1001,"2026-01-01");
        shp s1 = new shp(1002,"2026-01-02","TRK789");
        del d1 = new del(1003,"2026-01-03","TRK456","2026-01-10");
        
        // now check status for each
        
        Console.WriteLine("Order ID: " + o1.oid + " Status : " + o1.gs() );
        Console.WriteLine("Order ID : " + s1.oid + " Status: " + s1.gs() );
        Console.WriteLine("Order ID  : " + d1.oid + " Status: " + d1.gs() );
        
        // print full details using virtual method
        Console.WriteLine();
        o1.di();
        Console.WriteLine();
        s1.di();
        Console.WriteLine();
        d1.di();
        
        // why multilevel ? coz order -> shipped -> delivered , each adds more info
        
        Console.WriteLine("order management part done");
    }
}

public class ord
{
    public int oid; // order id
    public string od; // order date
    
    public ord(int i , string d)
    {
        this.oid = i;
        this.od = d;
    }
    
    public virtual string gs()
    {
        return "Placed"; // basic order status
    }
    
    public virtual void di()
    {
        Console.WriteLine("Order ID  : " + oid );
        Console.WriteLine("Order Date : " + od );
        Console.WriteLine("Status : " + gs() );
    }
}

public class shp : ord
{
    public string tn; // tracking number
    
    public shp(int i,string d,string t) : base(i , d)
    {
        this.tn = t;
    }
    
    public override string gs()
    {
        return "Shipped";
    }
    
    public override void di()
    {
        base.di();
        Console.WriteLine("Tracking   : " + tn );
    }
}

public class del : shp
{
    public string dd; // delivery date
    
    public del(int i,string od,string t,string deld) : base(i,od,t)
    {
        this.dd = deld;
    }
    
    public override string gs()
    {
        return "Delivered"; // final status
    }
    
    public override void di()
    {
        base.di(); // gets order and shipped info
        Console.WriteLine("Delivered on : " + dd );
    }
}
