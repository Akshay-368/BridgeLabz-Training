using System;
namespace MovieManagerApp;

// Interface that defines what every movie manager must do
// Relationship: MovieManagerBase implements IMovieManager (implements-a interface)
// Why essential: gives us a contract so different managers can be swapped
// without changing other parts of code - loose coupling
public interface IMovieManager
{
    void AddMovieToSchedule(string movieTitle, string showTime);
    void SearchForMovie(string searchKeyword);
    void DisplayAllScheduledMovies();
    string[] GeneratePrintableReport();

    double GetTicketPrice(); //  Every manager must report a price
}

// Abstract base class - keeps common stuff like arrays central
// Relationship: StandardMovieManager is-a MovieManagerBase (inheritance)
// Why essential: all common data (movie titles array, times array)
// and basic logic stays in one place - DRY principle
// Encapsulation: arrays are private, only accessible through methods
// SOLID: single responsibility - just manages movie schedule data
// open/closed - can extend with children, base stays same
// KISS/YAGNI: only what we really need, no extras
public abstract class MovieManagerBase : IMovieManager
{
    private string[] movieTitlesArray;
    private string[] showTimesArray;
    private int currentMovieCount; // how many movies we actually have
    private int maxCapacity; // fixed size of arrays

    public virtual double GetTicketPrice()
    {
        return 10.00; // Default standard price
    }

    // constructor - sets up arrays with max size
    // we use non primitive array so constructor passes capacity
    protected MovieManagerBase(int maximumMoviesAllowed)
    {
        maxCapacity = maximumMoviesAllowed > 0 ? maximumMoviesAllowed : 20; // default 20 movies
        movieTitlesArray = new string[maxCapacity];
        showTimesArray = new string[maxCapacity];
        currentMovieCount = 0;
    }

    // common add method - children can override if needed
    public virtual void AddMovieToSchedule(string movieTitle, string showTime)
    {
        // check if we have space
        if (currentMovieCount >= maxCapacity)
        {
            Console.WriteLine("Sorry schedule is full , max " + maxCapacity + " movies");
            return;
        }

        // simple validation (no fancy exception)
        if (string.IsNullOrEmpty(movieTitle))
        {
            movieTitle = "Unknown Movie"; // default emergency
        }

        if (!IsValidTimeFormat(showTime))
        {
            Console.WriteLine("Invalid time format , please try again later");
            return;
        }

        // add to arrays
        movieTitlesArray[currentMovieCount] = movieTitle;
        showTimesArray[currentMovieCount] = showTime;
        currentMovieCount++;

        Console.WriteLine("Movie added: " + movieTitle + " at " + showTime);
    }

    // common search using contains
    public virtual void SearchForMovie(string searchKeyword)
    {
        if (string.IsNullOrEmpty(searchKeyword))
        {
            Console.WriteLine("no keyword given , nothing to search");
            return;
        }

        bool foundSomething = false;

        for (int i = 0; i < currentMovieCount ; i++)
        {
            if (movieTitlesArray[i].ToLower().Contains(searchKeyword.ToLower()))
            {
                Console.WriteLine("Found: " + movieTitlesArray[i] + " at " + showTimesArray[i]);
                foundSomething = true;
            }
        }

        if (!foundSomething)
        {
            Console.WriteLine("no movie found with '" + searchKeyword + "'");
        }
    }

    // common display
    public virtual void DisplayAllScheduledMovies()
    {
        if (currentMovieCount == 0)
        {
            Console.WriteLine("no movies in schedule yet");
            return;
        }

        Console.WriteLine("Current movie schedule:");
        for (int i = 0; i < currentMovieCount ; i++)
        {
            string formattedLine = movieTitlesArray[i] + " - " + showTimesArray[i];
            Console.WriteLine(formattedLine);
        }
    }

    // convert current movies to array report
    public virtual string[] GeneratePrintableReport()
    {
        string[] reportArray = new string[currentMovieCount];

        for (int i = 0; i < currentMovieCount ; i++)
        {
            reportArray[i] = movieTitlesArray[i] + " @ " + showTimesArray[i];
        }

        return reportArray;
    }

    // simple time validation (hh:mm) without exception
    private bool IsValidTimeFormat(string timeStr)
    {
        if (string.IsNullOrEmpty(timeStr) || timeStr.Length != 5 || timeStr[2] != ':')
            return false;

        string hoursPart = timeStr.Substring(0, 2);
        string minutesPart = timeStr.Substring(3, 2);

        int hours = 0;
        int minutes = 0;

        if (!int.TryParse(hoursPart, out hours)) return false;
        if (!int.TryParse(minutesPart, out minutes)) return false;

        return hours >= 0 && hours <= 23 && minutes >= 0 && minutes <= 59;
    }

    // protected access for children if needed
    protected int GetCurrentMovieCount() { return currentMovieCount; }
    protected string GetMovieTitleAt(int index) 
    { 
        if (index >= 0 && index < currentMovieCount) return movieTitlesArray[index];
        return "";
    }
    protected string GetShowTimeAt(int index) 
    { 
        if (index >= 0 && index < currentMovieCount) return showTimesArray[index];
        return "";
    }
}

// concrete manager that uses base as it is
// Relationship: StandardMovieManager is-a MovieManagerBase
public class StandardMovieManager : MovieManagerBase
{
    public StandardMovieManager(int maxMovies) : base(maxMovies) { }
}

// NEW CHILD CLASS: PremierMovieManager
// This class inherits from MovieManagerBase but "Overrides" the Add behavior
public class PremierMovieManager : MovieManagerBase
{
    public PremierMovieManager(int maxMovies) : base(maxMovies) { }

    // Overriding the Add method to add [VIP] to every title
    public override void AddMovieToSchedule(string movieTitle, string showTime)
    {
        string vipTitle = "[VIP] " + movieTitle;
        // We call the 'base' method so we don't have to rewrite the array logic
        base.AddMovieToSchedule(vipTitle, showTime);
    }

    // Overriding the GetTicketPrice to get Higher price for Premier as it is usually more expensive for the luxury experience vibes
    public override double GetTicketPrice()
    {
        return 25.50; // Premium luxury price
    }
}

// utility class with static helper methods
// Relationship: MenuHandler uses UtilityClass (uses-a static methods)
// Why essential: keeps small validation logic separate - loose coupling
public class UtilityClass
{
    public static int GetValidIntegerInput(string message, int defaultValue)
    {
        while (true)
        {
            Console.Write(message);
            string input = Console.ReadLine();

            int value;
            if (int.TryParse(input, out value) && value > 0)
            {
                return value;
            }

            Console.WriteLine("invalid number , using default " + defaultValue);
            return defaultValue;
        }
    }
}

// Menu handler - takes care of user interaction
// Relationship: MenuHandler has-a IMovieManager (composition)
// Why essential: separates user interface from business logic
// loose coupling: depends on interface, not concrete class
// we can change manager implementation without touching menu
public class MenuHandler
{
    private IMovieManager scheduleManager;

    public MenuHandler(IMovieManager manager)
    {
        scheduleManager = manager;
    }

    public void RunMenu()
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine(" CinemaTime - Movie Schedule");
            Console.WriteLine("1 Add new movie");
            Console.WriteLine("2 Search movie by keyword");
            Console.WriteLine("3 Show all movies");
            Console.WriteLine("4 Generate printable report");
            Console.WriteLine("5 Exit");

            Console.Write("Waiting , for user to enter choice : ");
            string choiceInput = Console.ReadLine();

            int selectedChoice = 0;
            if (!int.TryParse(choiceInput, out selectedChoice))
            {
                Console.WriteLine("wrong input , try again");
                continue;
            }

            if (selectedChoice == 1)
            {
                AddMovieInteractive();
            }
            else if (selectedChoice == 2)
            {
                SearchMovieInteractive();
            }
            else if (selectedChoice == 3)
            {
                scheduleManager.DisplayAllScheduledMovies();
            }
            else if (selectedChoice == 4)
            {
                string[] reportLines = scheduleManager.GeneratePrintableReport();
                Console.WriteLine("Printable report:");
                for (int i = 0; i < reportLines.Length ; i++)
                {
                    Console.WriteLine(reportLines[i]);
                }
            }
            else if (selectedChoice == 5)
            {
                running = false;
                Console.WriteLine("thank you for using CinemaTime");
            }
            else
            {
                Console.WriteLine("invalid choice");
            }
        }
    }

    private void AddMovieInteractive()
    {
        Console.Write("Enter movie title (empty for default 'No Title') : ");
        string titleInput = Console.ReadLine();
        string title = string.IsNullOrEmpty(titleInput) ? "No Title" : titleInput;

        string timeInput = "";
        while (true)
        {
            Console.Write("Enter show time (hh:mm) : ");
            timeInput = Console.ReadLine();

            // manual validation instead of exception
            if (timeInput.Length == 5 && timeInput[2] == ':')
            {
                string hh = timeInput.Substring(0,2);
                string mm = timeInput.Substring(3,2);
                int h = 0, m = 0;
                if (int.TryParse(hh, out h) && int.TryParse(mm, out m))
                {
                    if (h >= 0 && h <= 23 && m >= 0 && m <= 59)
                    {
                        break;
                    }
                }
            }

            Console.WriteLine("wrong time format (use hh:mm) , try again");
        }

        scheduleManager.AddMovieToSchedule(title, timeInput);
    }

    private void SearchMovieInteractive()
    {
        Console.Write("Enter keyword to search (empty for default 'movie') : ");
        string keyword = Console.ReadLine();
        if (string.IsNullOrEmpty(keyword)) keyword = "movie";

        scheduleManager.SearchForMovie(keyword);
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        /*
        "CinemaTime – Movie Schedule Manager"
        Story: A cinema manager wants a tool to store and update a list of movie showtimes and titles.
        Users should be able to add, view, and search movies.
        Requirements:
        ● Use a List for movie titles and List for showtimes.
        ● Method to:
        ○ addMovie(String title, String time)
        ○ searchMovie(String keyword) – use String.contains()
        ○ displayAllMovies()
        ● Combine titles and times into a formatted string using .format() or concatenation.
        ● Use Exception Handling:
        ○ Handle IndexOutOfBoundsException for invalid search indices.
        ○ Throw InvalidTimeFormatException for improperly formatted showtimes
        (e.g., "25:99").
        ● Convert list to array when generating printable reports.
        */

        Console.WriteLine(" CinemaTime - Movie Schedule Manager ");

        // Asking for capacity
        int maxMovies = UtilityClass.GetValidIntegerInput("How many movies maximum can we store? (default 20) : ", 20);

        // wait for  user to choose the Manager Type
        Console.WriteLine(" Select Cinema Type:");
        Console.WriteLine("1. Standard Cinema");
        Console.WriteLine("2. Premier Cinema (Adds [VIP] to all titles)");
        Console.Write("Choice: ");
        string typeChoice = Console.ReadLine();

        // Declaring the interface variable (The "Contract")
        IMovieManager manager;

        //  Polymorphism to decide which object to create
        if (typeChoice == "2")
        {
            manager = new PremierMovieManager(maxMovies);
            Console.WriteLine(" Premier Manager Active ");
        }
        else
        {
            manager = new StandardMovieManager(maxMovies);
            Console.WriteLine(" Standard Manager Active ");
        }

        // Passing the chosen manager to the menu
        // The menu doesn't care which one it is!
        MenuHandler userMenu = new MenuHandler(manager);

        //  Run the menu
        userMenu.RunMenu();
    }
}
