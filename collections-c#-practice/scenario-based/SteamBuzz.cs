using System;
using System.Collections.Generic;
using System.Linq;

// Interface defining the contract for CreatorStats classes.
// This follows the Interface Segregation Principle (SOLID) by defining a focused contract.
public interface ICreatorStats
{
    string CreatorName { get; }
    double[] WeeklyLikes { get; }
    int CountWeeksAboveThreshold(double threshold);
}

// Abstract base class providing common properties and logic for CreatorStats.
// This uses inheritance (is-a relationship) to share common structure while leaving specific implementation to child classes.
// Encapsulation is applied by using protected setters.
// Constructors are used to initialize non-primitive types like arrays.
public abstract class AbstractCreatorStats : ICreatorStats
{
    public string CreatorName { get; protected set; }
    public double[] WeeklyLikes { get; protected set; }

    // Constructor to pass and set values, promoting encapsulation.
    protected AbstractCreatorStats(string creatorName, double[] weeklyLikes)
    {
        if (weeklyLikes == null || weeklyLikes.Length != 4)
        {
            // Default to empty array in case of emergency (invalid input), but problem assumes 4 weeks.
            WeeklyLikes = new double[4];
        }
        else
        {
            WeeklyLikes = weeklyLikes;
        }
        CreatorName = creatorName ?? "Unknown"; // Default name in case of null for emergency.
    }

    // Abstract method for customizable logic in child classes.
    // This follows the Open-Closed Principle (SOLID): closed for modification but open for extension via subclasses.
    public abstract int CountWeeksAboveThreshold(double threshold);
}

// Concrete implementation of CreatorStats.
// CreatorStats is-a AbstractCreatorStats (inheritance relationship), essential for reusing common properties while providing specific threshold counting logic.
// This allows future subclasses to implement different counting strategies if needed (e.g., weighted counts), following YAGNI but prepared for extension.
// Has-a relationship with double[] WeeklyLikes, as it composes the data structure for storage.
public class CreatorStats : AbstractCreatorStats
{
    // Central static storage as required by the problem.
    // Although instructions prefer minimal statics to avoid unnecessary memory usage, this is essential for shared access as per problem spec.
    // The list has-a relationship with CreatorStats objects (composition), centralizing data for all operations.
    public static List<CreatorStats> EngagementBoard = new List<CreatorStats>();

    public CreatorStats(string creatorName, double[] weeklyLikes) : base(creatorName, weeklyLikes)
    {
    }

    // Implementation of the abstract method.
    // This is specific to this child class, counting weeks where likes >= threshold.
    // Uses LINQ for concise collection handling (DRY, KISS).
    public override int CountWeeksAboveThreshold(double threshold)
    {
        return WeeklyLikes.Count(like => like >= threshold);
    }
}

// Program class containing the main logic and methods.
// Program uses CreatorStats (has-a relationship via method parameters and static access), essential for separating concerns (Single Responsibility Principle).
// Methods are instance methods as specified, even though they could be static, to follow OOP preference over unnecessary statics.
public class Program
{
    // Method to register a creator.
    // Adds to central storage, following encapsulation by not exposing the list directly.
    public void RegisterCreator(CreatorStats record)
    {
        CreatorStats.EngagementBoard.Add(record);
    }

    // Method to get top post counts.
    // Takes records as parameter as specified.
    // Uses the abstract method implemented by child for counting, promoting polymorphism.
    // Returns dictionary only if counts > 0, as per rules.
    // Dictionary uses collection framework for key-value storage.
    public Dictionary<string, int> GetTopPostCounts(List<CreatorStats> records, double likeThreshold)
    {
        Dictionary<string, int> topCounts = new Dictionary<string, int>();
        foreach (CreatorStats record in records)
        {
            int weekCount = record.CountWeeksAboveThreshold(likeThreshold);
            if (weekCount > 0)
            {
                topCounts[record.CreatorName] = weekCount;
            }
        }
        return topCounts;
    }

    // Method to calculate average likes.
    // Uses central static list since no parameter specified.
    // Calculates average across all weekly likes, handling zero case.
    public double CalculateAverageLikes()
    {
        double totalLikes = 0;
        int totalWeeks = 0;
        foreach (CreatorStats record in CreatorStats.EngagementBoard)
        {
            totalLikes += record.WeeklyLikes.Sum();
            totalWeeks += record.WeeklyLikes.Length;
        }
        return totalWeeks > 0 ? totalLikes / totalWeeks : 0;
    }

    // Main method, static as required for entry point.
    // Handles user input loop, no hardcoded values—all inputs from user.
    // Uses defaults in constructor for emergencies (e.g., null name), but assumes valid inputs as per sample.
    // Follows KISS by simple loop and conditional handling.
    // No Environment.Exit used.
    static void Main(string[] args)
    {
        Program programInstance = new Program(); // Instance for calling non-static methods.

        while (true)
        {
            // Display menu options.
            Console.WriteLine("1. Register Creator");
            Console.WriteLine("2. Show Top Posts");
            Console.WriteLine("3. Calculate Average Likes");
            Console.WriteLine("4. Exit");
            Console.WriteLine("Enter your choice:");

            // Read user choice.
            string choiceInput = Console.ReadLine();
            if (!int.TryParse(choiceInput, out int userChoice) || userChoice < 1 || userChoice > 4)
            {
                // Assume valid as per sample, but skip for invalid.
                continue;
            }

            if (userChoice == 4)
            {
                Console.WriteLine("Logging off — Keep Creating with StreamBuzz!");
                break;
            }
            else if (userChoice == 1)
            {
                // Register creator section.
                Console.WriteLine("Enter Creator Name:");
                string creatorName = Console.ReadLine();
                Console.WriteLine("Enter weekly likes (Week 1 to 4):");
                double[] weeklyLikesArray = new double[4];
                for (int weekIndex = 0; weekIndex < 4; weekIndex++)
                {
                    weeklyLikesArray[weekIndex] = double.Parse(Console.ReadLine());
                }
                CreatorStats newRecord = new CreatorStats(creatorName, weeklyLikesArray);
                programInstance.RegisterCreator(newRecord);
                Console.WriteLine("Creator registered successfully");
            }
            else if (userChoice == 2)
            {
                // Show top posts section.
                Console.WriteLine("Enter like threshold:");
                double likeThresholdValue = double.Parse(Console.ReadLine());
                Dictionary<string, int> topPerformers = programInstance.GetTopPostCounts(CreatorStats.EngagementBoard, likeThresholdValue);
                if (topPerformers.Count == 0)
                {
                    Console.WriteLine("No top-performing posts this week");
                }
                else
                {
                    foreach (KeyValuePair<string, int> performer in topPerformers)
                    {
                        Console.WriteLine($"{performer.Key} - {performer.Value}");
                    }
                }
            }
            else if (userChoice == 3)
            {
                // Calculate average section.
                double averageValue = programInstance.CalculateAverageLikes();
                Console.WriteLine($"Overall average weekly likes: {averageValue}");
            }
        }
    }
}
