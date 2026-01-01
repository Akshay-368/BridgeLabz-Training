using System;

public class Book
{
    public static string LibraryName = "City Central Library";  // static, same for all books
    
    public readonly string ISBN;     // readonly - cant change after set
    public string Title;
    public string Author;
    public bool IsAvailable;
    
    public Book(string ISBN, string Title, string Author)
    {
        // using this to make it clear were setting instance fields
        this.ISBN = ISBN;
        this.Title = Title;
        this.Author = Author;
        this.IsAvailable = true;
    }
    
    public void DisplayDetails()
    {
        Console.WriteLine("Library : " + LibraryName);
        Console.WriteLine("ISBN : " + ISBN);
        Console.WriteLine("Title : " + Title);
        Console.WriteLine("Author : " + Author);
        Console.WriteLine("Available: " + (IsAvailable ? "Yes" : "No"));
    }
    
    public static void DisplayLibraryName()
    {
        // simple static method
        Console.WriteLine("This library is: " + LibraryName);
    }
    
    public static void Main(string[] args)
    {
        /*
        Sample Program 2: Library Management System
        Create a Book class to manage library books with the following features:

        * static: 
          * A static variable LibraryName shared across all books.
          * A static method DisplayLibraryName() to print the library name.

        * this: 
          * Use this to initialize Title, Author, and ISBN in the constructor.

        * readonly: 
          * Use a readonly variable ISBN to ensure the unique identifier of a book cannot be changed.

        * is operator: 
          * Verify if an object is an instance of the Book class before displaying its details.
        */
        
        Book.DisplayLibraryName();
        Console.WriteLine();
        
        Book b1 = new Book("978-3-16-148410-0", "Advanced C#", "Mark Wilson");
        Book b2 = new Book("978-1-23-456789-7", "Data Structures", "Lisa Ray");
        
        object item1 = b1;
        object item2 = 12345;  // not a book
        
        Console.WriteLine("testing with 'is' operator");
        Console.WriteLine();
        
        if (item1 is Book bk1)
        {
            Console.WriteLine("item1 is a Book, printing details:");
            bk1.DisplayDetails();
        }
        
        Console.WriteLine();
        
        if (item2 is Book)
        {
            Console.WriteLine("this wont show");
        }
        else
        {
            Console.WriteLine("item2 is not a Book object");
        }
        
        Console.WriteLine();
        b2.DisplayDetails();
        
        Console.WriteLine();
        Book.DisplayLibraryName();
        
        Console.WriteLine("all done, press enter to close..");
        Console.ReadLine();
    }
}
