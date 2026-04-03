using System;
using System.Collections.Generic;
using System.Linq;

// Interface defining the contract for any trackable workout activity
// All workouts must be able to record details and calculate calories burned
// Relationship: Workout implements ITrackable (implements-a interface)
// Why essential: Ensures polymorphic behavior and consistent tracking across workout types
public interface ITrackable
{
    void RecordWorkoutDetails();
    double CalculateCaloriesBurned();
    void DisplayWorkoutSummary();
}

// Abstract base class representing a generic workout
// Centralizes common properties (date, duration) and shared logic
// Relationship: CardioWorkout and StrengthWorkout are-a Workout (inheritance)
// Why essential: DRY principle - avoids duplicating common fields and methods
// Encapsulation: Private setters where needed, protected fields for inheritance
// SOLID: Open/Closed - base closed for modification, open for extension
// KISS/YAGNI: Only essential common functionality, no over-engineering
public abstract class Workout : ITrackable
{
    public string WorkoutDate { get; private set; }
    public int DurationInMinutes { get; private set; }

    // Protected constructor to force derived classes to provide values
    // Allows setting non-primitive (string) and primitive defaults safely
    protected Workout(string date, int duration)
    {
        WorkoutDate = string.IsNullOrEmpty(date) ? DateTime.Today.ToShortDateString() : date;
        DurationInMinutes = duration > 0 ? duration : 30; // default 30 mins if invalid
    }

    // Common method - all workouts need to record basic info
    public virtual void RecordWorkoutDetails()
    {
        Console.WriteLine("Recording common workout details...");
        Console.Write("Enter workout date (or press Enter for today): ");
        string inputDate = Console.ReadLine();
        if (!string.IsNullOrEmpty(inputDate))
        {
            WorkoutDate = inputDate;
        }

        Console.Write("Enter duration in minutes (default 30): ");
        string durInput = Console.ReadLine();
        if (int.TryParse(durInput, out int dur) && dur > 0)
        {
            DurationInMinutes = dur;
        }
    }

    // Abstract methods - must be implemented by child classes
    public abstract double CalculateCaloriesBurned();
    public abstract void DisplayWorkoutSummary();
}

// Concrete class representing a Cardio workout (e.g., running, cycling)
// Relationship: CardioWorkout is-a Workout (inheritance)
// Has-a specific property: DistanceInKm
public class CardioWorkout : Workout
{
    public double DistanceInKilometers { get; private set; }
    public string CardioType { get; private set; } // e.g., Running, Swimming

    public CardioWorkout(string date, int duration, string type, double distance)
        : base(date, duration)
    {
        CardioType = string.IsNullOrEmpty(type) ? "Running" : type;
        DistanceInKilometers = distance > 0 ? distance : 5.0; // default 5km
    }

    public override void RecordWorkoutDetails()
    {
        base.RecordWorkoutDetails();

        Console.Write("Enter cardio type (Running/Cycling/Swimming etc.): ");
        string typeInput = Console.ReadLine();
        if (!string.IsNullOrEmpty(typeInput))
        {
            CardioType = typeInput;
        }

        Console.Write("Enter distance in kilometers (default 5.0): ");
        string distInput = Console.ReadLine();
        if (double.TryParse(distInput, out double dist) && dist > 0)
        {
            DistanceInKilometers = dist;
        }
    }

    // Cardio burns approx 10 calories per minute + bonus based on distance
    public override double CalculateCaloriesBurned()
    {
        double baseCalories = DurationInMinutes * 10;
        double distanceBonus = DistanceInKilometers * 50;
        return baseCalories + distanceBonus;
    }

    public override void DisplayWorkoutSummary()
    {
        Console.WriteLine($"Cardio Workout: {CardioType}");
        Console.WriteLine($"Date: {WorkoutDate}, Duration: {DurationInMinutes} mins");
        Console.WriteLine($"Distance: {DistanceInKilometers} km");
        Console.WriteLine($"Estimated calories burned: {CalculateCaloriesBurned():F1}");
    }
}

// Concrete class representing a Strength workout (e.g., weight lifting)
// Relationship: StrengthWorkout is-a Workout (inheritance)
// Has-a specific properties: Sets, Reps, WeightUsed
public class StrengthWorkout : Workout
{
    public int NumberOfSets { get; private set; }
    public int RepsPerSet { get; private set; }
    public double WeightInKg { get; private set; }

    public StrengthWorkout(string date, int duration, int sets, int reps, double weight)
        : base(date, duration)
    {
        NumberOfSets = sets > 0 ? sets : 4;
        RepsPerSet = reps > 0 ? reps : 10;
        WeightInKg = weight > 0 ? weight : 60.0;
    }

    public override void RecordWorkoutDetails()
    {
        base.RecordWorkoutDetails();

        Console.Write("Enter number of sets (default 4): ");
        string setsInput = Console.ReadLine();
        if (int.TryParse(setsInput, out int sets) && sets > 0)
        {
            NumberOfSets = sets;
        }

        Console.Write("Enter reps per set (default 10): ");
        string repsInput = Console.ReadLine();
        if (int.TryParse(repsInput, out int reps) && reps > 0)
        {
            RepsPerSet = reps;
        }

        Console.Write("Enter weight used in kg (default 60): ");
        string weightInput = Console.ReadLine();
        if (double.TryParse(weightInput, out double weight) && weight > 0)
        {
            WeightInKg = weight;
        }
    }

    // Strength burns approx 8 calories per minute + based on intensity
    public override double CalculateCaloriesBurned()
    {
        double baseCalories = DurationInMinutes * 8;
        double intensityFactor = (NumberOfSets * RepsPerSet * WeightInKg) / 100;
        return baseCalories + intensityFactor;
    }

    public override void DisplayWorkoutSummary()
    {
        Console.WriteLine("Strength Workout Session");
        Console.WriteLine($"Date: {WorkoutDate}, Duration: {DurationInMinutes} mins");
        Console.WriteLine($"Sets: {NumberOfSets}, Reps: {RepsPerSet}, Weight: {WeightInKg} kg");
        Console.WriteLine($"Estimated calories burned: {CalculateCaloriesBurned():F1}");
    }
}

// Central manager class for the fitness tracker
// Relationship: FitTrack has-a collection of ITrackable workouts (composition)
// Why essential: Central storage and management - avoids scattered data
// SOLID: Single responsibility - manages user workouts
public class FitTrack
{
    private UserProfile userProfile;
    private List<ITrackable> workoutHistory = new List<ITrackable>();

    public FitTrack(UserProfile profile)
    {
        userProfile = profile ?? new UserProfile("Guest User", 25, 70.0, 175.0);
    }

    public void AddWorkout(ITrackable workout)
    {
        if (workout != null)
        {
            workoutHistory.Add(workout);
            Console.WriteLine("Workout successfully recorded!");
        }
    }

    public void ShowAllWorkouts()
    {
        if (workoutHistory.Count == 0)
        {
            Console.WriteLine("No workouts recorded yet.");
            return;
        }

        Console.WriteLine($"\nWorkout History for {userProfile.Name}:");
        foreach (var workout in workoutHistory)
        {
            workout.DisplayWorkoutSummary();
            Console.WriteLine("                       "); // spcae for providing better visibilty
        }
    }

    public double GetTotalCaloriesBurned()
    {
        double total = 0;
        foreach (var workout in workoutHistory)
        {
            total += workout.CalculateCaloriesBurned();
        }
        return total;
    }

    public void ShowFitnessSummary()
    {
        Console.WriteLine($"\nFitness Summary for {userProfile.Name}");
        Console.WriteLine($"Age: {userProfile.Age}, Weight: {userProfile.WeightInKg} kg, Height: {userProfile.HeightInCm} cm");
        Console.WriteLine($"Total workouts recorded: {workoutHistory.Count}");
        Console.WriteLine($"Total estimated calories burned: {GetTotalCaloriesBurned():F1}");
    }
}

// Simple class to store user personal information
// Relationship: FitTrack has-a UserProfile (composition)
// Encapsulation: Properties with private setters where appropriate
public class UserProfile
{
    public string Name { get; private set; }
    public int Age { get; private set; }
    public double WeightInKg { get; private set; }
    public double HeightInCm { get; private set; }

    public UserProfile(string name, int age, double weight, double height)
    {
        Name = string.IsNullOrEmpty(name) ? "Default User" : name;
        Age = age > 0 ? age : 25;
        WeightInKg = weight > 0 ? weight : 70.0;
        HeightInCm = height > 0 ? height : 175.0;
    }

    public void UpdateProfile()
    {
        Console.WriteLine("Update your profile:");
        Console.Write("Enter name (or Enter to keep current): ");
        string newName = Console.ReadLine();
        if (!string.IsNullOrEmpty(newName)) Name = newName;

        Console.Write("Enter age: ");
        if (int.TryParse(Console.ReadLine(), out int newAge) && newAge > 0) Age = newAge;

        Console.Write("Enter weight in kg: ");
        if (double.TryParse(Console.ReadLine(), out double newWeight) && newWeight > 0) WeightInKg = newWeight;

        Console.Write("Enter height in cm: ");
        if (double.TryParse(Console.ReadLine(), out double newHeight) && newHeight > 0) HeightInCm = newHeight;
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("Welcome to FitTrack - Your Personal Fitness Tracker!");

        UserProfile currentUser = new UserProfile("Akshay", 25, 72.0, 170.0);
        FitTrack tracker = new FitTrack(currentUser);

        bool running = true;

        while (running)
        {
            Console.WriteLine("\n=== FitTrack Main Menu ===");
            Console.WriteLine("1. Record New Cardio Workout");
            Console.WriteLine("2. Record New Strength Workout");
            Console.WriteLine("3. View All Workouts");
            Console.WriteLine("4. View Fitness Summary");
            Console.WriteLine("5. Update User Profile");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string choiceInput = Console.ReadLine();
            int choice;
            int.TryParse(choiceInput, out choice);

            ITrackable newWorkout = null;

            switch (choice)
            {
                case 1:
                    newWorkout = new CardioWorkout("", 0, "", 0);
                    newWorkout.RecordWorkoutDetails();
                    tracker.AddWorkout(newWorkout);
                    break;

                case 2:
                    newWorkout = new StrengthWorkout("", 0, 0, 0, 0);
                    newWorkout.RecordWorkoutDetails();
                    tracker.AddWorkout(newWorkout);
                    break;

                case 3:
                    tracker.ShowAllWorkouts();
                    break;

                case 4:
                    tracker.ShowFitnessSummary();
                    break;

                case 5:
                    currentUser.UpdateProfile();
                    break;

                case 6:
                    running = false;
                    Console.WriteLine("Thank you for using FitTrack! Keep pushing!");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
