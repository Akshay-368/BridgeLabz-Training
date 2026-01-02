using System;
using System.Collections.Generic;

public static class prog
{
    public static void Main( string[] args )
    {
        /*
        Problem 1: Library and Books (Aggregation)
        Description: Create a Library class that contains multiple Book objects. Model the relationship such that a library can have many books, but a book can exist independently (outside of a specific library).
        Tasks:

        * Define a Library class with a List<Book> collection.

        * Define a Book class with attributes such as Title and Author.

        * Demonstrate the aggregation relationship by creating books and adding them to different libraries.

        Goal: Understand aggregation by modeling a real-world relationship where the Library aggregates Book objects.
        */
        
        // here we start with books first , they can live alone
        
        bk b1 = new bk("harry potter","jk rowling");
        bk b2 = new bk("lord of rings" ,"tolkien");
        bk b3 = new bk("c# basics","some guy");
        bk b4 = new bk("java fun","other dude");
        
        // now make some libraries
        
        lib l1 = new lib("City Library");
        lib l2 = new lib("School Lib");
        
        // add books to libraries , this is aggregation coz books still exist even if lib gone
        
        l1.ad(b1);
        l1.ad(b2);
        l1.ad(b3);
        
        l2.ad(b3); // same book in two libs ? wait no , usually not but here just to show independence
        l2.ad(b4);
        
        // printing what each library has
        
        Console.WriteLine("Books in " + l1.nm + " :");
        l1.sh();
        
        Console.WriteLine("\nBooks in " + l2.nm + " :");
        l2.sh();
        
        // now show a book that is not in any library yet
        Console.WriteLine("\nThis book is just sitting around : " + b1.tl + " by " + b1.au );
        
        // see ? books can exist without library , thats aggregation not composition
    }
}

public static class bk
{
    public string tl; // title
    public string au; // author
    
    public bk(string t , string a)
    {
        this.tl = t; // using this coz why not
        this.au = a;
        // book created , can live alone
    }
    
    public void pr()
    {
        Console.WriteLine( tl + " written by " + au );
    }
}

public static class lib
{
    public string nm; // library name
    public List<bk> bl; // list of books , aggregation here
    
    public lib( string n )
    {
        this.nm = n;
        bl = new List<bk>(); // empty list at start
        // why new list ? coz each library has own collection
    }
    
    public void ad(bk b)
    {
        bl.Add(b); // add book to this library
        // book still exists outside , we just keep reference
    }
    
    public void sh()
    {
        // show all books in this library
        foreach(bk bb in bl )
        {
            bb.pr(); // print each book
        }
        // if no books it will print nothing , thats fine
    }
}
