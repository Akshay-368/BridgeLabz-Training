// This program implements sorting of Aadhar numbers (12-digit strings) using Radix Sort.
// It follows OOP principles heavily, with an interface defining the contract, an abstract base class for common logic,
// and a concrete child class for specific implementation.
// Relationships:
// - IAadharNumbersSorter is an interface that defines the contract for sorting and searching operations. This is essential to ensure polymorphic behavior and adherence to SOLID's Interface Segregation Principle.
// - AbstractAadharNumbersSorter is-a IAadharNumbersSorter (implements the interface) and provides common properties and partial implementations. This inheritance is essential for code reuse (DRY) and open-closed principle (extend via subclasses without modifying base).
// - RadixAadharNumbersSorter is-a AbstractAadharNumbersSorter (inheritance for specialization). This allows customizing the sort logic while inheriting common behavior, following Liskov Substitution Principle.
// - AbstractAadharNumbersSorter has-a string[] AadharNumbersStorageArray (composition via protected field). This is essential for encapsulation (data hiding) and central storage, as all operations read/write to this array, avoiding scattered data and adhering to Single Responsibility Principle (class manages its own data).
// - Methods in classes use has-a relationships with temporary arrays (e.g., count arrays in sort), essential for intermediate computations without exposing internals.
// All data structures are limited to arrays and strings; no collection frameworks are used.
// Encapsulation: Fields are protected; methods are private/protected where possible to restrict access to derived classes only.
// Principles: SOLID (e.g., single responsibility per class), DRY (common logic in base), YAGNI (no extra features), KISS (simple array-based implementation).


using System;

// Interface Section: Defines the contract for sorting and searching Aadhar numbers.
// This ensures any implementing class provides these methods, promoting polymorphism.
public interface IAadharNumbersSorter
{
    void SortInAscendingOrder();
    int PerformBinarySearchForSpecificNumber(string targetAadharNumber);
    string[] GetSortedAadharNumbersArray(); // To retrieve the sorted array for display or further use.
}

// Abstract Base Class Section: Provides common properties and logic.
// Central storage is here (protected array) for subclasses to access.
// Partial implementations and abstract methods for customization.
public abstract class AbstractAadharNumbersSorter : IAadharNumbersSorter
{
    // Protected field for central storage; accessible to derived classes but not externally (encapsulation).
    protected string[] AadharNumbersStorageArray;

    // Constructor: Takes the array to centralize storage; uses constructor for non-primitive types as required.
    protected AbstractAadharNumbersSorter(string[] initialAadharNumbersArray)
    {
        AadharNumbersStorageArray = initialAadharNumbersArray;
    }

    // Common method: Validates if all Aadhar numbers are 12-digit strings.
    // Private to restrict access; called internally.
    private bool ValidateAllAadharNumbersAreTwelveDigits()
    {
        for (int index = 0; index < AadharNumbersStorageArray.Length; index++)
        {
            if (AadharNumbersStorageArray[index] == null || AadharNumbersStorageArray[index].Length != 12 || !IsStringComposedOfDigitsOnly(AadharNumbersStorageArray[index]))
            {
                return false;
            }
        }
        return true;
    }

    // Helper method: Checks if a string is digits only. Private for encapsulation.
    private bool IsStringComposedOfDigitsOnly(string inputString)
    {
        for (int charIndex = 0; charIndex < inputString.Length; charIndex++)
        {
            if (inputString[charIndex] < '0' || inputString[charIndex] > '9')
            {
                return false;
            }
        }
        return true;
    }

    // Abstract method: To be implemented by child classes for custom sorting.
    public abstract void SortInAscendingOrder();

    // Common implementation: Binary search after sorting. Assumes array is sorted.
    // Public as per interface, but relies on protected array.
    public int PerformBinarySearchForSpecificNumber(string targetAadharNumber)
    {
        if (!ValidateAllAadharNumbersAreTwelveDigits())
        {
            throw new InvalidOperationException("Aadhar numbers must be valid 12-digit strings.");
        }

        int lowIndex = 0;
        int highIndex = AadharNumbersStorageArray.Length - 1;

        while (lowIndex <= highIndex)
        {
            int midIndex = lowIndex + (highIndex - lowIndex) / 2;
            int comparisonResult = string.Compare(AadharNumbersStorageArray[midIndex], targetAadharNumber);

            if (comparisonResult == 0)
            {
                return midIndex; // Found.
            }
            else if (comparisonResult < 0)
            {
                lowIndex = midIndex + 1;
            }
            else
            {
                highIndex = midIndex - 1;
            }
        }
        return -1; // Not found.
    }

    // Common method: Returns a copy of the array to prevent external modification (encapsulation).
    public string[] GetSortedAadharNumbersArray()
    {
        string[] copyArray = new string[AadharNumbersStorageArray.Length];
        Array.Copy(AadharNumbersStorageArray, copyArray, AadharNumbersStorageArray.Length);
        return copyArray;
    }

    // Protected helper: Gets digit at position (from right, 0-based) for Radix Sort.
    // Accessible to derived classes.
    protected int GetDigitAtSpecificPositionFromRight(string aadharNumber, int position)
    {
        return aadharNumber[aadharNumber.Length - 1 - position] - '0';
    }
}

// Concrete Child Class Section: Implements Radix Sort specifically.
// Overrides abstract method with its own implementation (not just for show).
// Uses array-based counting sort for each digit pass, ensuring stability (maintains order for same prefixes).
// No collections; only arrays.
public class RadixAadharNumbersSorter : AbstractAadharNumbersSorter
{
    // Constructor: Passes to base for central storage.
    public RadixAadharNumbersSorter(string[] initialAadharNumbersArray) : base(initialAadharNumbersArray)
    {
    }

    // Implementation of abstract method: Radix Sort (LSD, stable).
    // Public as per interface, but internals are private/protected.
    public override void SortInAscendingOrder()
    {
        if (!ValidateAllAadharNumbersAreTwelveDigitsInArray())
        {
            throw new InvalidOperationException("Aadhar numbers must be valid 12-digit strings.");
        }

        // 12 digits, so 12 passes.
        for (int digitPosition = 0; digitPosition < 12; digitPosition++)
        {
            PerformCountingSortBasedOnDigitPosition(digitPosition);
        }
    }

    // Private validation method: Similar to base but specific here if needed.
    private bool ValidateAllAadharNumbersAreTwelveDigitsInArray()
    {
        for (int index = 0; index < AadharNumbersStorageArray.Length; index++)
        {
            if (AadharNumbersStorageArray[index] == null || AadharNumbersStorageArray[index].Length != 12 || !IsStringDigitsOnly(AadharNumbersStorageArray[index]))
            {
                return false;
            }
        }
        return true;
    }

    // Private helper: Checks digits.
    private bool IsStringDigitsOnly(string input)
    {
        for (int i = 0; i < input.Length; i++)
        {
            if (input[i] < '0' || input[i] > '9') return false;
        }
        return true;
    }

    // Private method: Counting sort for a digit position. Stable sort.
    private void PerformCountingSortBasedOnDigitPosition(int digitPosition)
    {
        int arrayLength = AadharNumbersStorageArray.Length;
        string[] outputArray = new string[arrayLength];
        int[] countArray = new int[10]; // Digits 0-9.

        // Count frequencies.
        for (int index = 0; index < arrayLength; index++)
        {
            int digit = GetDigitAtSpecificPositionFromRight(AadharNumbersStorageArray[index], digitPosition);
            countArray[digit]++;
        }

        // Cumulative counts for positions.
        for (int countIndex = 1; countIndex < 10; countIndex++)
        {
            countArray[countIndex] += countArray[countIndex - 1];
        }

        // Build output array from end to maintain stability.
        for (int index = arrayLength - 1; index >= 0; index--)
        {
            int digit = GetDigitAtSpecificPositionFromRight(AadharNumbersStorageArray[index], digitPosition);
            outputArray[countArray[digit] - 1] = AadharNumbersStorageArray[index];
            countArray[digit]--;
        }

        // Copy back to storage.
        Array.Copy(outputArray, AadharNumbersStorageArray, arrayLength);
    }
}

// Main Program Section: Entry point.

public class Program
{
    public static void Main(string[] args)
    {
        // Ask user for number of Aadhar numbers; default to 5 if empty or invalid.
        Console.WriteLine("Enter the number of Aadhar numbers to process (default: 5):");
        string inputCountString = Console.ReadLine();
        int numberOfAadharNumbers = 5; // Default.
        if (!string.IsNullOrEmpty(inputCountString) && int.TryParse(inputCountString, out int parsedCount))
        {
            numberOfAadharNumbers = parsedCount;
        }

        string[] aadharNumbersArray = new string[numberOfAadharNumbers];

        // Ask for each Aadhar number; default to hardcoded if empty.
        string[] defaultAadharNumbers = { "123456789012", "987654321098", "111111111111", "222222222222", "333333333333" };
        for (int index = 0; index < numberOfAadharNumbers; index++)
        {
            Console.WriteLine($"Enter Aadhar number {index + 1} (12 digits, default: {defaultAadharNumbers[index % defaultAadharNumbers.Length]}):");
            string inputAadhar = Console.ReadLine();
            aadharNumbersArray[index] = string.IsNullOrEmpty(inputAadhar) ? defaultAadharNumbers[index % defaultAadharNumbers.Length] : inputAadhar;
        }

        // Create sorter instance.
        RadixAadharNumbersSorter sorterInstance = new RadixAadharNumbersSorter(aadharNumbersArray);

        // Scenario A: Sort ascending.
        Console.WriteLine("Sorting Aadhar numbers in ascending order...");
        sorterInstance.SortInAscendingOrder();

        // Display sorted.
        Console.WriteLine("Sorted Aadhar numbers:");
        string[] sortedArray = sorterInstance.GetSortedAadharNumbersArray();
        for (int i = 0; i < sortedArray.Length; i++)
        {
            Console.WriteLine(sortedArray[i]);
        }

        // Scenario B: Search for a number.
        Console.WriteLine("Enter an Aadhar number to search for:");
        string searchTarget = Console.ReadLine();
        int searchResultIndex = sorterInstance.PerformBinarySearchForSpecificNumber(searchTarget);
        if (searchResultIndex != -1)
        {
            Console.WriteLine($"Found at position {searchResultIndex + 1}.");
        }
        else
        {
            Console.WriteLine("Not found.");
        }

        // Scenario C: Stability is inherent in Radix Sort; no extra action needed, as order for same prefixes is maintained.
        Console.WriteLine("Note: Radix Sort is stable, maintaining relative order for entries with same prefix.");
    }
}
