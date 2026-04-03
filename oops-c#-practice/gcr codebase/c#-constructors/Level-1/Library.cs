using System;

public class libbk
{
    string title;
    string author;
    double price;
    bool avail;
    
    public libbk(string t, string a, double p)
    {
        title = t;
        author = a;
        price = p;
        avail = true; // new book is available
    }
    
    public void borrow()
    {
        if (avail)
        {
            avail = false;
            Console.WriteLine("Book \"" + title + "\" borrowed successfully");
        }
        else
        {
            Console.WriteLine("Sorry, \"" + title + "\" is already borrowed");
        }
    }
    
    public void details()
    {
        Console.WriteLine("Title      : " + title);
        Console.WriteLine("Author     : " + author);
        Console.WriteLine("Price      : " + price);
        Console.WriteLine("Available  : " + (avail ? "Yes" : "No"));
    }
    
    public static void Main()
    {
        /*
        5. Library Book System
           * Create a Book class with attributes title, author, price, and availability.
           * Implement a method BorrowBook() to borrow a book.
        */
        
        libbk book = new libbk("The Hobbit", "J.R.R. Tolkien", 1200);
        book.details();
        
        Console.WriteLine();
        book.borrow();
        
        Console.WriteLine();
        book.details();
        
        Console.WriteLine();
        book.borrow(); // try again
        
        Console.WriteLine("press enter..");
        Console.ReadLine();
    }
}
