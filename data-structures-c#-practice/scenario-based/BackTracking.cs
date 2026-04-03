// This C# program implements a Password Cracker Simulator using backtracking.
// It generates all possible strings of a given length from a character set (Scenario A),
// attempts to crack a target password by stopping when matched (Scenario B),
// and visualizes time-space complexity (Scenario C, via print statements and timing).
// Relationships:
// - IPasswordCrackerSimulator is an interface that defines the contract for password generation, cracking, and visualization operations. This is essential to ensure polymorphic behavior and adherence to SOLID's Interface Segregation Principle.
// - AbstractPasswordCrackerSimulator is-a IPasswordCrackerSimulator (implements the interface) and provides common properties and partial implementations. This inheritance is essential for code reuse (DRY) and open-closed principle (extend via subclasses without modifying base).
// - BacktrackingPasswordCrackerSimulator is-a AbstractPasswordCrackerSimulator (inheritance for specialization). This allows customizing the backtracking logic while inheriting common behavior, following Liskov Substitution Principle.
// - AbstractPasswordCrackerSimulator has-a char[] CharacterSetArray (composition via protected field). This is essential for encapsulation (data hiding) and central storage, as all operations read from this array, avoiding scattered data and adhering to Single Responsibility Principle (class manages its own data).
// - AbstractPasswordCrackerSimulator has-a int PasswordLength (protected field for central config).
// - Methods in classes use has-a relationships with temporary char[] (e.g., current password builder), essential for intermediate computations without exposing internals.
// All data structures are limited to arrays and strings; no collection frameworks or custom structures like linked lists are used.
// Encapsulation: Fields are protected; methods are private/protected where possible to restrict access to derived classes only.
// Principles: SOLID (e.g., single responsibility per class), DRY (common logic in base), YAGNI (no extra features), KISS (simple recursive backtracking).


using System;
using System.Diagnostics;

// Interface Section: Defines the contract for password cracking simulations.
// This ensures any implementing class provides these methods, promoting polymorphism.
public interface IPasswordCrackerSimulator
{
    void GenerateAllPossiblePasswordsOfLength();
    bool AttemptToCrackTargetPassword(string targetPassword, out string foundPassword);
    void VisualizeTimeAndSpaceComplexity();
}

// Abstract Base Class Section: Provides common properties and logic.
// Central storage for character set and length here (protected) for subclasses to access.
// Partial implementations and abstract methods for customization.
public abstract class AbstractPasswordCrackerSimulator : IPasswordCrackerSimulator
{
    // Protected fields for central storage; accessible to derived classes but not externally (encapsulation).
    protected char[] CharacterSetArray;
    protected int PasswordLength;

    // Constructor: Takes the character set array and length to centralize config; uses constructor for non-primitive types as required.
    protected AbstractPasswordCrackerSimulator(char[] initialCharacterSetArray, int initialPasswordLength)
    {
        CharacterSetArray = initialCharacterSetArray;
        PasswordLength = initialPasswordLength;
    }

    // Common method: Validates the character set and length.
    // Private to restrict access; called internally.
    private bool ValidateCharacterSetAndLength()
    {
        return CharacterSetArray != null && CharacterSetArray.Length > 0 && PasswordLength > 0;
    }

    // Abstract method: To be implemented by child classes for generating all passwords.
    public abstract void GenerateAllPossiblePasswordsOfLength();

    // Abstract method: To be implemented by child classes for cracking (with early stop).
    public abstract bool AttemptToCrackTargetPassword(string targetPassword, out string foundPassword);

    // Common implementation: Visualizes complexity by printing theoretical values and measuring time for generation.
    // Public as per interface.
    public void VisualizeTimeAndSpaceComplexity()
    {
        if (!ValidateCharacterSetAndLength())
        {
            throw new InvalidOperationException("Character set and password length must be valid.");
        }

        Console.WriteLine("Visualizing Time and Space Complexity for Password Cracker Simulator:");
        long totalCombinations = (long)Math.Pow(CharacterSetArray.Length, PasswordLength);
        Console.WriteLine($"Theoretical Time Complexity: O(k^n) where k = {CharacterSetArray.Length} (character set size), n = {PasswordLength} (length).");
        Console.WriteLine($"Total possible combinations: {totalCombinations}");
        Console.WriteLine("Space Complexity: O(n) due to recursion stack depth.");

        // Measure actual time for generation (Scenario A).
        Stopwatch timerStopwatch = Stopwatch.StartNew();
        GenerateAllPossiblePasswordsOfLength(); // This will print them, but we time it.
        timerStopwatch.Stop();
        Console.WriteLine($"Actual time taken to generate all: {timerStopwatch.ElapsedMilliseconds} ms");
    }
}

// Concrete Child Class Section: Implements backtracking specifically.
// Overrides abstract methods with its own recursive implementations (not just for show).
// Uses char[] for building passwords, recursion for backtracking.
// No collections; only arrays and strings.
public class BacktrackingPasswordCrackerSimulator : AbstractPasswordCrackerSimulator
{
    // Constructor: Passes to base for central storage.
    public BacktrackingPasswordCrackerSimulator(char[] initialCharacterSetArray, int initialPasswordLength) : base(initialCharacterSetArray, initialPasswordLength)
    {
    }

    // Implementation of abstract method: Generates all possible passwords using backtracking.
    // Public as per interface, but delegates to private recursive helper.
    public override void GenerateAllPossiblePasswordsOfLength()
    {
        if (!ValidateInputs())
        {
            throw new InvalidOperationException("Invalid character set or password length.");
        }

        char[] currentPasswordBuilder = new char[PasswordLength];
        PerformBacktrackingToGenerateAll(0, currentPasswordBuilder);
    }

    // Private validation method.
    private bool ValidateInputs()
    {
        return CharacterSetArray != null && CharacterSetArray.Length > 0 && PasswordLength > 0;
    }

    // Private recursive helper: Backtracking to build and print all combinations.
    private void PerformBacktrackingToGenerateAll(int currentPosition, char[] currentPasswordBuilder)
    {
        if (currentPosition == PasswordLength)
        {
            Console.WriteLine(new string(currentPasswordBuilder));
            return;
        }

        for (int charIndex = 0; charIndex < CharacterSetArray.Length; charIndex++)
        {
            currentPasswordBuilder[currentPosition] = CharacterSetArray[charIndex];
            PerformBacktrackingToGenerateAll(currentPosition + 1, currentPasswordBuilder);
        }
    }

    // Implementation of abstract method: Attempts to crack by generating until match.
    // Uses backtracking with early stop.
    // Public as per interface, delegates to private recursive helper with ref found flag.
    public override bool AttemptToCrackTargetPassword(string targetPassword, out string foundPassword)
    {
        foundPassword = null;
        if (!ValidateInputs() || targetPassword == null || targetPassword.Length != PasswordLength)
        {
            return false;
        }

        char[] currentPasswordBuilder = new char[PasswordLength];
        bool isPasswordFound = false;
        PerformBacktrackingToFindMatch(0, currentPasswordBuilder, targetPassword, ref isPasswordFound, ref foundPassword);

        return isPasswordFound;
    }

    // Private recursive helper: Backtracking to find match, stops early if found.
    private void PerformBacktrackingToFindMatch(int currentPosition, char[] currentPasswordBuilder, string targetPassword, ref bool isPasswordFound, ref string foundPassword)
    {
        if (isPasswordFound) return; // Early stop.

        if (currentPosition == PasswordLength)
        {
            string generatedPassword = new string(currentPasswordBuilder);
            if (generatedPassword.Equals(targetPassword))
            {
                foundPassword = generatedPassword;
                isPasswordFound = true;
            }
            return;
        }

        for (int charIndex = 0; charIndex < CharacterSetArray.Length; charIndex++)
        {
            currentPasswordBuilder[currentPosition] = CharacterSetArray[charIndex];
            PerformBacktrackingToFindMatch(currentPosition + 1, currentPasswordBuilder, targetPassword, ref isPasswordFound, ref foundPassword);
            if (isPasswordFound) return; // Early stop.
        }
    }
}

// Main Program Section: Entry point.
// Static Main as required; handles user input with defaults.
public class Program
{
    public static void Main(string[] args)
    {
        // Ask user for password length; default to 3 if empty or invalid.
        Console.WriteLine("Enter the password length (default: 3):");
        string inputLengthString = Console.ReadLine();
        int passwordLength = 3; // Default.
        if (!string.IsNullOrEmpty(inputLengthString) && int.TryParse(inputLengthString, out int parsedLength))
        {
            passwordLength = parsedLength;
        }

        // Ask user for character set; default to "abc".
        Console.WriteLine("Enter the character set (e.g., abc, default: abc):");
        string inputCharacterSet = Console.ReadLine();
        string characterSetString = string.IsNullOrEmpty(inputCharacterSet) ? "abc" : inputCharacterSet;
        char[] characterSetArray = characterSetString.ToCharArray();

        // Create simulator instance.
        BacktrackingPasswordCrackerSimulator simulatorInstance = new BacktrackingPasswordCrackerSimulator(characterSetArray, passwordLength);

        // Scenario A: Generate all possible.
        Console.WriteLine("Scenario A: Generating all possible passwords:");
        simulatorInstance.GenerateAllPossiblePasswordsOfLength();

        // Scenario B: Crack a target.
        Console.WriteLine("Enter the target password to crack (default: aaa):");
        string inputTarget = Console.ReadLine();
        string targetPassword = string.IsNullOrEmpty(inputTarget) ? new string('a', passwordLength) : inputTarget;

        if (simulatorInstance.AttemptToCrackTargetPassword(targetPassword, out string foundPassword))
        {
            Console.WriteLine($"Scenario B: Password cracked: {foundPassword}");
        }
        else
        {
            Console.WriteLine("Scenario B: Password not found (invalid target or setup).");
        }

        // Scenario C: Visualize complexity.
        Console.WriteLine("Scenario C:");
        simulatorInstance.VisualizeTimeAndSpaceComplexity();
    }
}
