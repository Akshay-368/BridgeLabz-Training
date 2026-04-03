using System;

/// <summary>
// Section: UserStepData Class
// Represents a single user's daily step count data
// Has-a relationship: string (UserName), int (StepCount)
// Encapsulation: private setters to protect data integrity
// Follows SRP: only responsible for holding user-step information
/// </summary>

class UserStepData
{
    public string UserName { get; private set; }
    public int StepCount { get; private set; }

    public UserStepData(string userName, int stepCount)
    {
        UserName = userName;
        StepCount = stepCount;
    }

    // for  display/debugging
    public override string ToString()
    {
        return $"{UserName}: {StepCount} steps";
    }
}


// Section: Interface - Contract for any ranking/sorting mechanism

interface IUserRankingSorter
{
    void GenerateLeaderboard();
}

///<summary>
// Section: Abstract Base Class for Step Rankers
// Central storage of user data (protected array)
// Implements interface (is-a IUserRankingSorter)
// Constructor passes the array (non-primitive)
// Leaves actual sorting implementation to children (OCP)
// Follows DRY - storage is centralized, not duplicated
///</summary>

abstract class AbstractStepRanker : IUserRankingSorter
{
    protected UserStepData[] UserStepRecords;  // Central storage

    protected AbstractStepRanker(UserStepData[] userStepRecords)
    {
        UserStepRecords = userStepRecords;
    }

    public abstract void GenerateLeaderboard(); // Must be implemented by children
}

/// <summary>
// Section: Bubble Sort Implementation for Leaderboard
// Child class implementing Bubble Sort (descending order - highest steps first)
// is-a AbstractStepRanker
// Private helper method for swapping - encapsulation
// Meaningful implementation, not placeholder
// Follows KISS, YAGNI, LSP, SRP
/// </summary>

class BubbleSortStepRanker : AbstractStepRanker
{
    public BubbleSortStepRanker(UserStepData[] userStepRecords)
        : base(userStepRecords)
    {
    }

    public override void GenerateLeaderboard()
    {
        if (UserStepRecords == null || UserStepRecords.Length <= 1)
        {
            return; // Nothing to sort
        }

        bool wasSwapped;
        int n = UserStepRecords.Length;

        // Bubble Sort - repeated passes until no more swaps needed
        for (int i = 0; i < n - 1; i++)
        {
            wasSwapped = false;

            for (int j = 0; j < n - i - 1; j++)
            {
                // Compare adjacent elements - descending order (more steps first)
                if (UserStepRecords[j].StepCount < UserStepRecords[j + 1].StepCount)
                {
                    SwapUsers(j, j + 1);
                    wasSwapped = true;
                }
            }

            //  if no swap happened in a pass ,then  array is sorted
            if (!wasSwapped)
            {
                break;
            }
        }
    }

    private void SwapUsers(int indexA, int indexB)
    {
        UserStepData temp = UserStepRecords[indexA];
        UserStepRecords[indexA] = UserStepRecords[indexB];
        UserStepRecords[indexB] = temp;
    }
}


// Section: Main Application Entry Point

class FitnessTrackerLeaderboardProgram
{
    static void Main(string[] args)
    {
        Console.WriteLine(" Daily Step Leaderboard Generator ");

        // Get number of participants (small group - default 8)
        Console.Write("How many people are in your fitness group? (default 8): ");
        string inputCount = Console.ReadLine();
        int participantCount = string.IsNullOrEmpty(inputCount) ? 8 : int.Parse(inputCount);

        if (participantCount <= 0)
        {
            Console.WriteLine("Invalid number. Using default of 8 participants.");
            participantCount = 8;
        }

        UserStepData[] dailySteps = new UserStepData[participantCount];

        // Input step data from users
        for (int i = 0; i < participantCount; i++)
        {
            Console.Write($"\nEnter name of participant {i + 1}: ");
            string name = Console.ReadLine()?.Trim();

            if (string.IsNullOrEmpty(name))
                name = $"User{i + 1}";

            Console.Write($"Enter steps for {name}: ");
            string stepsInput = Console.ReadLine();
            int steps = 0;

            if (!string.IsNullOrEmpty(stepsInput))
            {
                int.TryParse(stepsInput, out steps);
            }

            dailySteps[i] = new UserStepData(name, steps);
        }

        Console.WriteLine(" Sorting leaderboard using Bubble Sort...");

        // Create and use the sorter
        IUserRankingSorter leaderboardGenerator = new BubbleSortStepRanker(dailySteps);
        leaderboardGenerator.GenerateLeaderboard();

        // Display final ranking

        Console.WriteLine("|          DAILY STEP LEADERBOARD            |");
        Console.WriteLine("|----- | -------------------|---------------| ");
        Console.WriteLine("| Rank |        Name        |     Steps     |");
        Console.WriteLine("|----- | -------------------|---------------| ");

        for (int rank = 0; rank < dailySteps.Length; rank++)
        {
            Console.WriteLine($" | {rank + 1,4} | {dailySteps[rank].UserName,-18} | {dailySteps[rank].StepCount,13:#,##0} |");
        }


        Console.WriteLine(" Leaderboard updated! Ready for future's steps! ");
    }
}
