using System;
using System.Collections.Generic;

public static class prog
{
    public static void Main(string[] args)
    {
        /*
        Problem 4: E-commerce Platform with Orders, Customers, and Products
        Description: Design an e-commerce platform with Order, Customer, and Product classes. Model relationships where a Customer places an Order, and each Order contains multiple Product objects.
        Goal: Show communication and object relationships by designing a system where customers communicate through orders, and orders aggregate products.
        */
        
        // simple ecom thing
        
        prd p1 = new prd("phone",800);
        prd p2 = new prd("case",20);
        prd p3 = new prd("charger",30);
        
        cus c = new cus("alex");
        
        ord o = c.po(); // place order
        
        o.ap(p1,1);
        o.ap(p2,2);
        o.ap(p3,1);
        
        o.sh();
        
        Console.WriteLine("Total for order : " + o.tt() );
        
        Console.WriteLine("customer " + c.nm + " placed the order");
    }
}

public static class prd
{
    public string nm;
    public double pr;
    
    public prd(string n,double p)
    {
        this.nm = n;
        this.pr = p;
    }
}

public static class cus
{
    public string nm;
    
    public cus(string n)
    {
        this.nm = n;
    }
    
    public ord po()
    {
        ord o = new ord(this);
        Console.WriteLine(nm + " created new order");
        return o;
    }
}

public static class ord
{
    public cus c; // who placed
    public List<item> il; // aggregation of products
    
    public ord(cus cu)
    {
        this.c = cu;
        il = new List<item>();
    }
    
    public void ap(prd p , int q)
    {
        item i = new item(p , q);
        il.Add(i);
        Console.WriteLine("added " + q + " of " + p.nm );
    }
    
    public void sh()
    {
        Console.WriteLine("Order items :");
        foreach(item i in il)
        {
            Console.WriteLine("  " + i.q + " x " + i.p.nm + " = " + (i.q * i.p.pr) );
        }
    }
    
    public double tt()
    {
        double t = 0;
        foreach(item i in il)
        {
            t = t + i.q * i.p.pr;
        }
        return t;
    }
}

public static class item
{
    public prd p;
    public int q;
    
    public item ( prd pr , int qt)
    {
        this.p = pr;
        this.q = qt;
    }
}
