using System;

public class bk
{
    public string isbn;       // public
    protected string ttl;     // protected
    private string ath;       // private
    
    public bk(string i, string t, string a)
    {
        isbn = i;
        ttl = t;
        ath = a;
    }
    
    public string getath()
    {
        return ath;
    }
    
    public void setath(string newath)
    {
        ath = newath;
    }
    
    public void disp()
    {
        Console.WriteLine("ISBN  : " + isbn);
        Console.WriteLine("Title : " + ttl);
        Console.WriteLine("Author: " + ath);
    }
}

public class ebk : bk
{
    public ebk(string i, string t, string a) : base(i, t, a)
    {
    }
    
    public void showaccess()
    {
        // can access public and protected here
        Console.WriteLine("from EBook subclass:");
        Console.WriteLine("Public ISBN  : " + isbn);
        Console.WriteLine("Protected Title: " + ttl);
        // ath is private, cant access directly
    }
}

public class lib
{
    public static void Main ( string[] args )
    {
        /*
        Problem 2: Book Library System

        * Design a Book class with:

          * ISBN (public)

          * title (protected)

          * author (private)

        * Implement methods to:

          * Set and get the author name.

          * Create a subclass EBook to access ISBN and title and demonstrate access modifiers.
        */
        
        bk b = new bk("978-3-16-148410-0", "C# Guide", "John Smith");
        b.disp();
        
        Console.WriteLine();
        Console.WriteLine("author via getter: " + b.getath());
        b.setath("Jane Doe");
        Console.WriteLine("after changing author");
        b.disp();
        
        Console.WriteLine();
        ebk e = new ebk("978-1-23-456789-0", "Digital World", "Alex Brown");
        e.showaccess();
        
        Console.WriteLine("all done, press enter...");
        Console.ReadLine();
    }
}
