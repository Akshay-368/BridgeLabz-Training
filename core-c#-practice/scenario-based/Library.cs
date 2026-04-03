
using System;
using System.ComponentModel;
using System.Drawing;
namespace Library_Management;
/*
3. Library Management System – Book Search and Checkout
Scenario: You’re designing a system for a small library to manage books and track checkouts.
Problem Requirements:
● Store book details (title, author, status) in a Array.
● Allow searching by partial title using String operations.
● Store book data in an Array.
● Use methods for searching, displaying, and updating book status (checked out or
available).
*/
public class Library_Management
{
    private  static int  SizeOfLibrary; // The maximum storing capacity of the library.

    // Here each of these arrays will store the details of the same book at index i. and details of different (from the i-th index) but the same book's details for the j-th index and similarly keep going on 
    // private static string[] titles = new string[SizeOfLibrary];
    // private static string[] authors = new string[SizeOfLibrary];
    // private static string[] statuses = new string[SizeOfLibrary];

    // Don't do that as this will just result in making these arrays as size of 0 default value of int because the value of arrays are fixed and if you declared them here when you don't have size clearly defined that ruin them permanently and will need to create new arrays then . 
    private  string[] titles ;// Not making it static so that each library_management's instance can have their own version of books and their details and users
    private  string[] authors;
    private  string[] statuses ;

    private  string[] books_checked_out_by_user ; // Here we will add the names of those users who have checked-out a particular book
    // with the help of statuses if the book at index i is getting checked-out then we will place the name at index i only for the book in the same index i in other arrays to map the storage.

    private  int bookCount = 0; // To actually keep track of how many books we have added in the library actually.

    private string password ;

    public static void Run()
    {
        Library_Management library = new Library_Management();
        library.SetLibrarySize();
        library.SetPasswordForAdmin();
        library.AddBook("The Great Gatsby", "F. Scott Fitzgerald", "Available");
        library.AddBook("To Kill a Mockingbird", "Harper Lee", "Available");
        library.AddBook("1984", "George Orwell", "Available");
        library.AddBook("Pride and Prejudice", "Jane Austen", "Available");
        library.AddBook("The Catcher in the Rye", "J.D. Salinger", "Available");
        library.AddBook("The Alchemist", "Paulo Coelho", "Available");

        library.ListOfBooks();

        int bookIndex = library.SearchBookByTitle("The Great Gatsby");
        if (bookIndex != -1)
        {
            library.ShowStatusBook(bookIndex);
            // library.CheckOutBook(bookIndex); No need to call this method here
        }
        else
        {
            Console.WriteLine("Book not found in the library.");
        }

        bookIndex = library.SearchBookByAuthor("F. Scott Fitzgerald");
        if (bookIndex != -1)
        {
            library.ShowStatusBook(bookIndex);
            // library.CheckOutBook(bookIndex); No need to call this method here
        }
        else
        {
            Console.WriteLine("Book not found in the library.");
        }

        library.ReturnBook();

        library.DeleteBook(1) ;
    }

    private void SetPasswordForAdmin()
    {
        Console.WriteLine ( " Enter the password for your account and remember it always : ") ;
        password = Console.ReadLine();
        password = string.IsNullOrWhiteSpace(password) ? "admin1234" : password ;

        // Now since the passwords are sensitive and should be only saved in a secret code which is usually called as Hashing. which is technically irreversible.
        // Unlike encryption . and thus now while actual hashing technique is quite complicated. But still for the spectrum of this project i will create a toy version
        // BAsically a model of my own to simulate the behaviour of hashing. ( whether it can be converted back or not is arguable but still this will add one extra layer of protection )
        
    }

    private void SetLibrarySize()
    {
        Console.WriteLine("Enter the size of the library : ");
        string input  = Console.ReadLine();
        if ( ! int.TryParse ( input , out int SizeOfLibrary ) )
        {
            // if the input is not a valid integer, set the SizeOfLibrary to a default value
            SizeOfLibrary = 100 ; // default value of the storing capacity of library
        }
        // Initializing them here after they have been declared first and we get the actual value of library size.
        titles = new string[SizeOfLibrary];
        authors = new string[SizeOfLibrary];
        statuses = new string[SizeOfLibrary];
        books_checked_out_by_user = new string[SizeOfLibrary];

        Console.WriteLine ("Welcome to the library admin and your default password for future use case is 'admin1234'. This is a one-time display only. ");
    }

    private void AddBook(string title, string author, string status)
    {
        // This method was for adding books in the library.

        // Adding a capacity check to make sure we don't end up exceeding the limit of the library.
        if (bookCount >= SizeOfLibrary)
        {
            Console.WriteLine("Library is full. \nCannot add more books. \nTry to remove some books first for freeing up some space.");
            return;
        }
        titles[bookCount] = title;
        authors[bookCount] = author;
        statuses[bookCount] = status;
        bookCount++;
    }

    private int SearchBookByTitle(string title)
    {
        // This method is for searching for books  by the title in the library.
        for (int i = 0; i < bookCount; i++)
        {
            if (titles[i].IndexOf(title, StringComparison.OrdinalIgnoreCase) >= 0)
            {
                return i;
            }

        }
        return -1;
    }

    private int SearchBookByAuthor(string author)
    {
        // This method is for searching for books  by the author in the library.
        for (int i = 0; i < bookCount; i++)
        {
            if (authors[i].Contains(author))
            {
                return i;
            }
        }
        return -1;
    }

    private void CheckOutBook(int bookIndex)
    {
        // This method is for checking out a book from the library.
        if (statuses[bookIndex] == "Available")
        {
            Console.WriteLine("Enter your name to check out this book:");
            string inputNameOfUser = Console.ReadLine();
            books_checked_out_by_user[bookIndex] = inputNameOfUser;
            statuses[bookIndex] = "Checked Out";
            Console.WriteLine("Book checked out successfully.");
        }
        else
        {
            Console.WriteLine("Book is not available for checkout.");
        }
    }

    private void ShowStatusBook(int bookIndex)
    {
        // This method is for showing the status of a book in the library.
        Console.WriteLine($"Title: {titles[bookIndex]}");
        Console.WriteLine($"Author: {authors[bookIndex]}");
        Console.WriteLine($"Status: {statuses[bookIndex]}");

        if (statuses[bookIndex] == "Available")
        {
            Console.WriteLine("Status: Available");
            Console.WriteLine ( " DO you want to check-out the available book ? If yes , then please enter y and if no then type n");
            Console.WriteLine ( " Please pay attention that the default value is 'y' \n thus if you did not give a valid input book will be checked-out by you.");
            string input = Console.ReadLine();
            input = string.IsNullOrWhiteSpace(input) ? "y" : input ;
            if (input == "y")
            {
                CheckOutBook(bookIndex);
            }
        }
        else
        {
            Console.WriteLine("Status: Checked Out");
        }
    }

    private void ListOfBooks()
    {
        // This method is for listing the books in the library.
        for (int i = 0; i < bookCount; i++)
        {
            Console.WriteLine($"Title: {titles[i]}");
            Console.WriteLine($"Author: {authors[i]}");
            Console.WriteLine($"Status: {statuses[i]}");
            Console.WriteLine();
        }
    }

    private void DeleteBook(int bookIndex)
    {
        // This method is for deleting a book from the library. So use it cautiously.
        Console.WriteLine ( " Enter the password before deleting the book (only admin can delete a book from the library ) : ") ;
        string password_entered_by_user = Console.ReadLine();

        if (password != password_entered_by_user)
        {
            Console.WriteLine("Invalid password.");
            return;
        }

        for (int i = bookIndex; i < bookCount - 1; i++)
        {
            titles[i] = titles[i + 1];
            authors[i] = authors[i + 1];
            statuses[i] = statuses[i + 1];
            books_checked_out_by_user[i] = books_checked_out_by_user[i + 1];
        }
        bookCount--;
    }

    private void ReturnBook()
    {
        // This method is for returning a book to the library.
        Console.WriteLine("Enter your name to return this book:");
        string inputNameOfUser = Console.ReadLine();
        for (int i = 0; i < bookCount; i++)
        {
            if (books_checked_out_by_user[i] == inputNameOfUser)
            {
                statuses[i] = "Available";
                books_checked_out_by_user[i] = string.Empty;
                Console.WriteLine("Book returned successfully.");
                return;
            }
        }
        Console.WriteLine("Book not found.");
    }

}

