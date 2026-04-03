using System;

public class bk
{
  
  public static void Main()
  {
    /*

    3. Program to Handle Book Details
    Problem Statement: Write a program to create a Book class with attributes title, author, and price. Add a method to display the book details.
    
    */
    
    Console.WriteLine("enter book title: ");
    string ttl = Console.ReadLine();
    
    Console.WriteLine("enter author name: ");
    string auth = Console.ReadLine();
    
    Console.WriteLine("enter book price: ");
    string pstr = Console.ReadLine();
    double pr = 0.0;
    if (double.TryParse(pstr, out pr) == false)
    {
      pr = 0.0;
    }
    
    Book b = new Book(ttl, auth, pr);
    
    Console.WriteLine();
    Console.WriteLine("book details:");
    b.print();
    
    Console.WriteLine();
    Console.WriteLine("press enter to exit...");
    Console.ReadLine();
  }
}

public class Book
{
  string title;
  string author;
  double price;
  
  public Book(string t, string a, double p)
  {
    title = t;
    author = a;
    price = p;
  }
  
  public void print()
  {
    // prints book info
    Console.WriteLine("title : " + title);
    Console.WriteLine("author: " + author);
    Console.WriteLine("price : " + price);
  }
}
