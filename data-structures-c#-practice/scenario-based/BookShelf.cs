using System;

namespace LibraryManagementSystem
{

    //  DATA MODELS (Custom Nodes)

    public class Book
    {
        public string Title { get; set; }
        public string Author { get; set; }

        public Book(string title, string author)
        {
            Title = title;
            Author = author;
        }

        public override string ToString() => $"'{Title}' by {Author}";
    }


    /// Node for the Doubly Linked List of Books.
    /// Relationship: BookNode "Has-a" Book.

    public class BookNode
    {
        public Book Data { get; set; }
        public BookNode Next { get; set; }
        public BookNode Previous { get; set; }

        public BookNode(Book book) => Data = book;
    }


    /// Node for the Hash Map (Genre Bucket).
    /// Relationship: GenreBucket "Has-a" Genre Name and a BookNode chain.

    public class GenreBucket
    {
        public string GenreName { get; set; }
        public BookNode Head { get; set; } // Head of the Book Linked List
        public GenreBucket NextBucket { get; set; } // For handling Hash Collisions

        public GenreBucket(string genre) => GenreName = genre;
    }

    //  ABSTRACTIONS


    public interface ILibraryActions
    {
        void AddBook(string genre, string title, string author);
        void RemoveBook(string genre, string title);
        void ViewGenreCatalog(string genre);
        void ShowAllGenres();
    }


    /// Abstract Base Class for Central Storage.
    /// Uses a custom Hash Map (Array of GenreBuckets).

    public abstract class LibraryStorageBase : ILibraryActions
    {
        // Central Storage: Array-based Hash Table
        protected GenreBucket[] genreTable;
        protected int tableSize;

        protected LibraryStorageBase(int size)
        {
            this.tableSize = size;
            this.genreTable = new GenreBucket[size];
        }

        // Custom Hashing Logic
        protected int GetHash(string key)
        {
            int hash = 0;
            foreach (char c in key) hash += c;
            return Math.Abs(hash % tableSize);
        }

        public abstract void AddBook(string genre, string title, string author);
        public abstract void RemoveBook(string genre, string title);
        
        public void ViewGenreCatalog(string genre)
        {
            int index = GetHash(genre);
            GenreBucket current = genreTable[index];

            // Traverse collision chain to find the right genre
            while (current != null && current.GenreName != genre)
                current = current.NextBucket;

            if (current == null || current.Head == null)
            {
                Console.WriteLine($"Catalog for '{genre}' is empty.");
                return;
            }

            Console.WriteLine($" Books in {genre} ");
            BookNode temp = current.Head;
            while (temp != null)
            {
                Console.WriteLine($"- {temp.Data}");
                temp = temp.Next;
            }
        }

        public void ShowAllGenres()
        {
            Console.WriteLine(" Available Genres ");
            for (int i = 0; i < tableSize; i++)
            {
                GenreBucket temp = genreTable[i];
                while (temp != null)
                {
                    Console.WriteLine($"> {temp.GenreName}");
                    temp = temp.NextBucket;
                }
            }
        }
    }

    //  CONCRETE IMPLEMENTATION


    public class BookShelfManager : LibraryStorageBase
    {
        public BookShelfManager(int size) : base(size) { }

        public override void AddBook(string genre, string title, string author)
        {
            int index = GetHash(genre);
            
            //  Find or Create the Genre Bucket
            if (genreTable[index] == null)
            {
                genreTable[index] = new GenreBucket(genre);
            }
            
            GenreBucket bucket = genreTable[index];
            while (bucket.GenreName != genre && bucket.NextBucket != null)
                bucket = bucket.NextBucket;

            if (bucket.GenreName != genre)
            {
                bucket.NextBucket = new GenreBucket(genre);
                bucket = bucket.NextBucket;
            }

            //  Add Book to Linked List (Avoid Duplicates - Custom HashSet Logic)
            BookNode newNode = new BookNode(new Book(title, author));
            if (bucket.Head == null)
            {
                bucket.Head = newNode;
            }
            else
            {
                BookNode temp = bucket.Head;
                while (temp.Next != null)
                {
                    if (temp.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                    {
                        Console.WriteLine("Entry Skipped: Book already exists in this genre.");
                        return;
                    }
                    temp = temp.Next;
                }
                // Final check for the last node
                if (temp.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase)) return;

                temp.Next = newNode;
                newNode.Previous = temp;
            }
            Console.WriteLine($"Success: '{title}' added to {genre}.");
        }

        public override void RemoveBook(string genre, string title)
        {
            int index = GetHash(genre);
            GenreBucket bucket = genreTable[index];

            while (bucket != null && bucket.GenreName != genre)
                bucket = bucket.NextBucket;

            if (bucket == null || bucket.Head == null)
            {
                Console.WriteLine("Error: Book or Genre not found.");
                return;
            }

            // Delete from Linked List logic
            BookNode current = bucket.Head;
            while (current != null)
            {
                if (current.Data.Title.Equals(title, StringComparison.OrdinalIgnoreCase))
                {
                    if (current.Previous != null) current.Previous.Next = current.Next;
                    else bucket.Head = current.Next; // Update head if first node deleted

                    if (current.Next != null) current.Next.Previous = current.Previous;

                    Console.WriteLine($"Success: '{title}' removed from {genre}.");
                    return;
                }
                current = current.Next;
            }
            Console.WriteLine("Book not found in this genre.");
        }
    }

    //  Main PROGRAM


    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine(" Library BookShelf System ");
            
            Console.Write("Enter internal storage capacity (Default 10): ");
            if (!int.TryParse(Console.ReadLine(), out int capacity)) capacity = 10;

            ILibraryActions shelf = new BookShelfManager(capacity);

            while (true)
            {
                Console.WriteLine(" 1. Add Book | 2. Remove Book | 3. View Genre | 4. List Genres | 5. Exit");
                Console.Write("Choice: ");
                string choice = Console.ReadLine();

                if (choice == "5") break;

                switch (choice)
                {
                    case "1":
                        Console.Write("Genre: "); 
                        string g = Console.ReadLine();
                        Console.Write("Title: "); 
                        string t = Console.ReadLine();
                        Console.Write("Author: "); 
                        string a = Console.ReadLine();
                        shelf.AddBook(g, t, a);
                        break;
                    case "2":
                        Console.Write("Genre: "); 
                        string rg = Console.ReadLine();
                        Console.Write("Title: "); 
                        string rt = Console.ReadLine();
                        shelf.RemoveBook(rg, rt);
                        break;
                    case "3":
                        Console.Write("Enter Genre: "); 
                        string vg = Console.ReadLine();
                        shelf.ViewGenreCatalog(vg);
                        break;
                    case "4":
                        shelf.ShowAllGenres();
                        break;
                }
            }
        }
    }
}
