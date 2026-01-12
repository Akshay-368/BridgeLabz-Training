using System;

// Interface defining the contract for optimizing rod cuts and revenue calculation
// Relationship: BaseRodCutter implements ICutOptimizer (implements-a interface relation)
// Why essential: Ensures all cutters follow a standard for optimization and display, enabling polymorphism
public interface ICutOptimizer
{
    int CalculateMaxRevenue();
    void DisplayOptimalCuts();
    void DisplayNonOptimizedRevenue();  // For scenario C visualization
}

// Abstract base class for rod cutting logic, centralizing common properties and shared methods
// Common storage: rodLength and priceChart are protected here for child access
// Common logic: Basic revenue calculation skeleton provided virtually
// Relationship: StandardRodCutter and CustomRodCutter is-a BaseRodCutter (inheritance relation)
// Why essential: DRY - avoids duplicating rod length, prices, and basic DP logic across cutters
// Encapsulation: Properties use private setters, protected for inheritance
// SOLID: Single responsibility (handles core cutting optimization)
// Open/closed: Base closed for modification, open for extension via overrides
// KISS/YAGNI: Only essential fields/methods, no extras
public abstract class BaseRodCutter : ICutOptimizer
{
    protected int rodLength;
    protected int[] priceChart;  // Array for prices of lengths 1 to rodLength

    // Constructor to pass non-primitive (array) and primitive with defaults
    protected BaseRodCutter(int length, int[] prices)
    {
        rodLength = length > 0 ? length : 8;  // Default rod length 8 for emergencies
        priceChart = prices != null && prices.Length == rodLength ? prices : GetDefaultPrices(rodLength);
    }

    // Private helper for default price chart if not provided
    private int[] GetDefaultPrices(int len)
    {
        int[] defaults = new int[len];
        for (int i = 0; i < len; i++)
        {
            defaults[i] = (i + 1) * 10;  // Simple default: length * 10
        }
        return defaults;
    }

    // Virtual method for max revenue using DP - children can extend
    public virtual int CalculateMaxRevenue()
    {
        int[] dp = new int[rodLength + 1];
        dp[0] = 0;

        for (int i = 1; i <= rodLength; i++)
        {
            int maxVal = 0;
            for (int j = 1; j <= i; j++)
            {
                maxVal = Math.Max(maxVal, priceChart[j - 1] + dp[i - j]);
            }
            dp[i] = maxVal;
        }
        return dp[rodLength];
    }

    // Abstract methods for customization in children
    public abstract void DisplayOptimalCuts();
    public abstract void DisplayNonOptimizedRevenue();
}

// Concrete class for standard rod cutting (Scenario A)
// Relationship: StandardRodCutter is-a BaseRodCutter
// Has-a no additional, relies on base
// Why essential: Handles basic optimization without customs
public class StandardRodCutter : BaseRodCutter
{
    public StandardRodCutter(int length, int[] prices) : base(length, prices) { }

    public override void DisplayOptimalCuts()
    {
        Console.WriteLine("Optimal cuts for standard scenario (A):");
        Console.WriteLine($"Max revenue: {CalculateMaxRevenue()}");
        // Simple print of possible cuts - not tracking actual cuts for KISS
        for (int i = 0; i < rodLength; i++)
        {
            Console.WriteLine($"Length {i + 1}: Price {priceChart[i]}");
        }
    }

    public override void DisplayNonOptimizedRevenue()
    {
        Console.WriteLine("Non-optimized revenue (greedy full length):");
        int nonOpt = priceChart[rodLength - 1];  // Assume no cuts, full rod price
        Console.WriteLine($"Revenue: {nonOpt} (vs optimized {CalculateMaxRevenue()})");
    }
}

// Concrete class for custom order rod cutting (Scenario B)
// Overrides revenue to include custom impact
// Relationship: CustomRodCutter is-a BaseRodCutter
// Has-a customLength and customPrice as additional properties
// Why essential: Extends for custom orders, showing impact
public class CustomRodCutter : BaseRodCutter
{
    private int customLength;
    private int customPrice;

    public CustomRodCutter(int length, int[] prices, int custLen, int custPri)
        : base(length, prices)
    {
        customLength = custLen > 0 ? custLen : 3;  // Default custom length 3
        customPrice = custPri > 0 ? custPri : 50;  // Default custom price 50
    }

    public override int CalculateMaxRevenue()
    {
        int baseRev = base.CalculateMaxRevenue();
        // Simple impact: Add custom if fits
        if (customLength <= rodLength)
        {
            int remaining = rodLength - customLength;
            int remRev = remaining > 0 ? CalculateRevenueForLength(remaining) : 0;
            return Math.Max(baseRev, customPrice + remRev);
        }
        return baseRev;
    }

    // Private helper for revenue of a sub-length
    private int CalculateRevenueForLength(int len)
    {
        int[] dp = new int[len + 1];
        dp[0] = 0;
        for (int i = 1; i <= len; i++)
        {
            int maxVal = 0;
            for (int j = 1; j <= i; j++)
            {
                maxVal = Math.Max(maxVal, priceChart[j - 1] + dp[i - j]);
            }
            dp[i] = maxVal;
        }
        return dp[len];
    }

    public override void DisplayOptimalCuts()
    {
        Console.WriteLine("Optimal cuts with custom order (B):");
        Console.WriteLine($"Max revenue: {CalculateMaxRevenue()}");
        Console.WriteLine($"Custom length: {customLength}, Price: {customPrice}");
    }

    public override void DisplayNonOptimizedRevenue()
    {
        Console.WriteLine("Non-optimized revenue with custom:");
        int nonOpt = priceChart[rodLength - 1];  // Full rod
        Console.WriteLine($"Revenue: {nonOpt} (vs optimized {CalculateMaxRevenue()})");
    }
}

// Main program class to handle scenarios
// Relationship: Program has-a instances of ICutOptimizer (composition/has-a)
// Why essential: Centralizes user interaction and scenario management
public class Program
{
    public static void Main(string[] args)
    {
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nMetal Factory Pipe Cutting Menu:");
            Console.WriteLine("1. Scenario A: Standard Cuts");
            Console.WriteLine("2. Scenario B: With Custom Order");
            Console.WriteLine("3. Scenario C: Non-Optimized Visualization");
            Console.WriteLine("4. Exit");

            Console.Write("Enter choice: ");
            int choice = int.Parse(Console.ReadLine() ?? "4");

            ICutOptimizer cutter = null;

            if (choice == 1 || choice == 3)
            {
                Console.Write("Enter rod length (default 8): ");
                string lenInput = Console.ReadLine();
                int length = string.IsNullOrEmpty(lenInput) ? 8 : int.Parse(lenInput);

                int[] prices = new int[length];
                for (int i = 0; i < length; i++)
                {
                    Console.Write($"Enter price for length {i + 1} (default {(i + 1) * 10}): ");
                    string priInput = Console.ReadLine();
                    prices[i] = string.IsNullOrEmpty(priInput) ? (i + 1) * 10 : int.Parse(priInput);
                }

                cutter = new StandardRodCutter(length, prices);
            }
            else if (choice == 2)
            {
                Console.Write("Enter rod length (default 8): ");
                string lenInput = Console.ReadLine();
                int length = string.IsNullOrEmpty(lenInput) ? 8 : int.Parse(lenInput);

                int[] prices = new int[length];
                for (int i = 0; i < length; i++)
                {
                    Console.Write($"Enter price for length {i + 1} (default {(i + 1) * 10}): ");
                    string priInput = Console.ReadLine();
                    prices[i] = string.IsNullOrEmpty(priInput) ? (i + 1) * 10 : int.Parse(priInput);
                }

                Console.Write("Enter custom length (default 3): ");
                string custLenInput = Console.ReadLine();
                int custLen = string.IsNullOrEmpty(custLenInput) ? 3 : int.Parse(custLenInput);

                Console.Write("Enter custom price (default 50): ");
                string custPriInput = Console.ReadLine();
                int custPri = string.IsNullOrEmpty(custPriInput) ? 50 : int.Parse(custPriInput);

                cutter = new CustomRodCutter(length, prices, custLen, custPri);
            }
            else
            {
                running = false;
                continue;
            }

            if (cutter != null)
            {
                if (choice == 3)
                {
                    cutter.DisplayNonOptimizedRevenue();
                }
                else
                {
                    cutter.DisplayOptimalCuts();
                }
            }
        }
    }
}
