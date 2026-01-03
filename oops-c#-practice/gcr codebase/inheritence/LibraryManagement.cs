using System;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        Sample Problem 1: Library Management with Books and Authors

        * Description: Model a Book system where Book is the superclass, and Author is a subclass.

        * Tasks:

          * Define a superclass Book with attributes like Title and PublicationYear.

          * Define a subclass Author with additional attributes like Name and Bio.

          * Create a method DisplayInfo() to show details of the book and its author.

        * Goal: Practice single inheritance by extending the base class and adding more specific details in the subclass.
        */
        
        // wait this seems backwards , author should not inherit from book
        // but question says Book superclass , Author subclass , so we follow that even if weird
        
        au a1 = new au("Great Story",2020,"john doe","born in 1980 , loves writing");
        au a2 = new au("Space Adventure",2018,"jane smith","sci fi expert");
        
        a1.di();
        Console.WriteLine();
        a2.di();
        
        // why author inherits book ? maybe to force every author has a book , but normally its other way
        // anyway we did as asked
        
        Console.WriteLine("library book author part done");
    }
}

public class bk
{
    public string tl; // title
    public int py; // publication year
    
    public bk(string t , int y)
    {
        this.tl = t;
        this.py = y;
    }
    
    public virtual void di()
    {
        Console.WriteLine("Title            : " + tl );
        Console.WriteLine("Published Year   : " + py );
    }
}

public class au : bk
{
    public string nm; // author name
    public string bo; // bio
    
    public au(string t,int y,string n,string b) : base(t , y)
    {
        this.nm = n;
        this.bo = b;
    }
    
    public override void di()
    {
        base.di(); // show book info first
        Console.WriteLine("Author Name      : " + nm );
        Console.WriteLine("Bio              : " + bo );
        // extra stuff for author
    }
}
