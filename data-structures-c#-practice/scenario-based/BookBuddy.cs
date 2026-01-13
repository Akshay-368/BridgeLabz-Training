using System;
namespace BookBuddy;
// Interface defining the contract for managing bookshelf
// Relationship: BookshelfManagerBase implements IBookshelfManager (implements-a interface)
// Why essential: ensures all managers can add , sort , search , export in same way
// allows polymorphism if we want different managers later
public interface IBookshelfManager
{
    void AddBookToBookshelf(string bookTitle, string authorName);
    void SortBooksAlphabetically();
    void SearchByAuthorName(string authorToSearch);
    string[] GenerateExportArray();
}

// Abstract base class for bookshelf management
// Central storage: bookEntriesArray is protected here for children
// Common logic: add , sort skeleton is virtual
// Relationship: StandardBookshelfManager is-a BookshelfManagerBase (inheritance)
// AuthorPriorityBookshelfManager is-a BookshelfManagerBase (inheritance)
// Why essential: DRY - array and count central , no repeat in children
// Encapsulation: array private setter , protected for inherit
// SOLID: single responsibility (manage bookshelf data)
// open/closed: extend via override , base unchanged
// KISS/YAGNI: only needed stuff , no extra
public abstract class BookshelfManagerBase : IBookshelfManager
{
    protected string[] bookEntriesArray; // stores "Title - Author"
    protected int currentBookCount;

    // Constructor to set up array size
    protected BookshelfManagerBase(int maxBooksCapacity)
    {
        bookEntriesArray = new string[maxBooksCapacity > 0 ? maxBooksCapacity : 10]; // default 10
        currentBookCount = 0;
    }

    // Common add logic
    public virtual void AddBookToBookshelf(string bookTitle, string authorName)
    {
        if (currentBookCount >= bookEntriesArray.Length)
        {
            Console.WriteLine("Bookshelf full , cant add more");
            return;
        }

        string entry = bookTitle + " - " + authorName;
        bookEntriesArray[currentBookCount] = entry;
        currentBookCount++;
        Console.WriteLine("Added book: " + entry);
    }

    // Abstract sort - children must implement their way
    public abstract void SortBooksAlphabetically();

    // Common search
    public virtual void SearchByAuthorName(string authorToSearch)
    {
        bool found = false;
        for (int i = 0; i < currentBookCount ; i++ )
        {
            string[] parts = bookEntriesArray[i].Split(new string[] { " - " }, StringSplitOptions.None);
            if (parts.Length == 2 && parts[1].ToLower().Contains(authorToSearch.ToLower()))
            {
                Console.WriteLine("Found: " + bookEntriesArray[i]);
                found = true;
            }
        }
        if (!found)
        {
            Console.WriteLine("No book by author " + authorToSearch);
        }
    }

    // Generate array copy for export
    public string[] GenerateExportArray()
    {
        string[] export = new string[currentBookCount];
        for (int i = 0; i < currentBookCount ; i++ )
        {
            export[i] = bookEntriesArray[i];
        }
        return export;
    }
}

// Child class 1: standard manager , sorts by title
// Relationship: StandardBookshelfManager is-a BookshelfManagerBase
// Why essential: provides basic title sort
public class StandardBookshelfManager : BookshelfManagerBase
{
    public StandardBookshelfManager(int capacity) : base(capacity) { }

    public override void SortBooksAlphabetically()
    {
        // simple bubble sort by title (not optimal but works)
        for (int i = 0; i < currentBookCount - 1 ; i++ )
        {
            for (int j = 0; j < currentBookCount - i - 1 ; j++ )
            {
                string title1 = bookEntriesArray[j].Split(new string[] { " - " }, StringSplitOptions.None)[0];
                string title2 = bookEntriesArray[j + 1].Split(new string[] { " - " }, StringSplitOptions.None)[0];

                if (string.Compare(title1, title2) > 0)
                {
                    string temp = bookEntriesArray[j];
                    bookEntriesArray[j] = bookEntriesArray[j + 1];
                    bookEntriesArray[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Sorted by title");
    }
}

// Child class 2: author priority , sorts by author instead
// Relationship: AuthorPriorityBookshelfManager is-a BookshelfManagerBase
// Why essential: overrides sort for different behavior
public class AuthorPriorityBookshelfManager : BookshelfManagerBase
{
    public AuthorPriorityBookshelfManager(int capacity) : base(capacity) { }

    public override void SortBooksAlphabetically()
    {
        // bubble sort by author
        for (int i = 0; i < currentBookCount - 1 ; i++ )
        {
            for (int j = 0; j < currentBookCount - i - 1 ; j++ )
            {
                string author1 = bookEntriesArray[j].Split(new string[] { " - " }, StringSplitOptions.None)[1];
                string author2 = bookEntriesArray[j + 1].Split(new string[] { " - " }, StringSplitOptions.None)[1];

                if (string.Compare(author1, author2) > 0)
                {
                    string temp = bookEntriesArray[j];
                    bookEntriesArray[j] = bookEntriesArray[j + 1];
                    bookEntriesArray[j + 1] = temp;
                }
            }
        }
        Console.WriteLine("Sorted by author");
    }
}

// Utility class with static helpers
// Relationship: MenuHandler uses UtilityClass (uses-a static methods)
// Why essential: keeps input validation separate , loose coupling
public class UtilityClass
{
    public static string GetValidStringInput(string prompt, string defaultValue)
    {
        Console.Write(prompt);
        string input = Console.ReadLine();
        return string.IsNullOrEmpty(input) ? defaultValue : input;
    }
}

// Menu class for user interaction
// Relationship: MenuHandler has-a IBookshelfManager (has-a relation)
// Why essential: separates UI from logic , loose coupling via interface
// design is loosely coupled - menu only knows interface , not concrete class
public class MenuHandler
{
    private IBookshelfManager manager;

    public MenuHandler(IBookshelfManager bookshelfManager)
    {
        manager = bookshelfManager;
    }

    public void ShowMenu()
    {
        bool run = true;

        while (run)
        {
            Console.WriteLine(" BookBuddy Menu");
            Console.WriteLine("1 Add book");
            Console.WriteLine("2 Sort alphabetically");
            Console.WriteLine("3 Search by author");
            Console.WriteLine("4 Export to array");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            string ch = Console.ReadLine();
            int choice = int.Parse(ch);

            if (choice == 1)
            {
                string title = UtilityClass.GetValidStringInput("Enter title (default Unknown) : ", "Unknown");
                string author = UtilityClass.GetValidStringInput("Enter author (default Anonymous) : ", "Anonymous");
                manager.AddBookToBookshelf(title, author);
            }
            else if (choice == 2)
            {
                manager.SortBooksAlphabetically();
            }
            else if (choice == 3)
            {
                string auth = UtilityClass.GetValidStringInput("Enter author to search (default John) : ", "John");
                manager.SearchByAuthorName(auth);
            }
            else if (choice == 4)
            {
                string[] exp = manager.GenerateExportArray();
                Console.WriteLine("Export array:");
                for (int i = 0; i < exp.Length ; i++ )
                {
                    Console.WriteLine(exp[i]);
                }
            }
            else if (choice == 5)
            {
                run = false;
            }
            else
            {
                Console.WriteLine("wrong choice");
            }
        }
    }
}

public class Program
{
    public static void Run(string[] args)
    {
        /*
        "BookBuddy – Digital Bookshelf App"
        Story: Users maintain a personal digital bookshelf by adding, updating, and sorting their favorite
        books by title and author.
        Requirements:
        ● Use an ArrayList to store book titles in "Title - Author" format.
        ● Methods:
        ○ addBook(String title, String author)
        ○ sortBooksAlphabetically()
        ○ searchByAuthor(String author)
        ● Use String.split() to separate title and author.
        ● Exception Handling:
        ○ Throw InvalidBookFormatException if string input is not in the right format.
        ○ Handle cases when the list is empty using try-catch.
        ● Convert the ArrayList to an array before exporting.
        */

        Console.WriteLine(" BookBuddy - Digital Bookshelf ");

        string capStr = UtilityClass.GetValidStringInput("Enter max books (default 10) : ", "10");
        int capacity = int.Parse(capStr);

        // create standard manager
        IBookshelfManager stdManager = new StandardBookshelfManager(capacity);

        // create author priority manager
        IBookshelfManager authManager = new AuthorPriorityBookshelfManager(capacity);

        // use standard for this run (can swap to authManager for different sort)
        MenuHandler menu = new MenuHandler(stdManager);

        menu.ShowMenu();
    }
}
