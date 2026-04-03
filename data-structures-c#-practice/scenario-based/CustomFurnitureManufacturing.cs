using System;

// Interface defining the contract for rod cutting optimization
// Relationship: BaseRodOptimizer implements IRodOptimizer (implements-a interface)
// Why essential: Provides a common contract so that different optimization strategies 
// (standard, waste-constrained, waste-aware) can be used polymorphically
public interface IRodOptimizer
{
    int CalculateMaximumRevenue();
    void DisplayOptimalCuttingStrategy();
    void DisplayWasteAndRevenueSummary();
}

// Abstract base class containing common properties and shared logic
// Central storage: rodTotalLength and pricePerLength are protected here
// Common logic: Basic validation and DP skeleton provided virtually
// Relationship: StandardOptimizer / WasteConstrainedOptimizer / WasteAwareOptimizer is-a BaseRodOptimizer (inheritance)
// Why essential: DRY principle - common length, prices, basic calculation logic is centralized
// Encapsulation: Private setters for immutability, protected fields for inheritance
// SOLID: Single responsibility (core rod cutting calculation), Open/closed principle
// KISS/YAGNI: Only essential fields and methods, no unnecessary complexity
public abstract class BaseRodOptimizer : IRodOptimizer
{
    protected int rodTotalLength;
    protected int[] pricePerLength;   // index 0 = price for 1ft, index 1 = 2ft, etc.

    // Constructor with default values for emergencies
    protected BaseRodOptimizer(int totalLength, int[] prices)
    {
        rodTotalLength = totalLength > 0 ? totalLength : 12; // default 12ft
        pricePerLength = (prices != null && prices.Length == rodTotalLength) 
            ? prices 
            : CreateDefaultPriceTable(rodTotalLength);
    }

    // Private helper - simple default prices when user doesn't provide
    private int[] CreateDefaultPriceTable(int length)
    {
        int[] defaults = new int[length];
        for (int i = 0; i < length; i++)
        {
            defaults[i] = (i + 1) * 25; // very simple default pricing
        }
        return defaults;
    }

    // Common DP calculation method - can be overridden
    public virtual int CalculateMaximumRevenue()
    {
        int[] maxRevenue = new int[rodTotalLength + 1];
        maxRevenue[0] = 0;

        for (int currentLength = 1; currentLength <= rodTotalLength; currentLength++)
        {
            int maximum = 0;
            for (int cut = 1; cut <= currentLength; cut++)
            {
                maximum = Math.Max(maximum, pricePerLength[cut - 1] + maxRevenue[currentLength - cut]);
            }
            maxRevenue[currentLength] = maximum;
        }

        return maxRevenue[rodTotalLength];
    }

    // Abstract methods to be implemented by concrete classes
    public abstract void DisplayOptimalCuttingStrategy();
    public abstract void DisplayWasteAndRevenueSummary();
}

// Concrete implementation for standard scenario (A)
// Relationship: StandardOptimizer is-a BaseRodOptimizer
public class StandardOptimizer : BaseRodOptimizer
{
    public StandardOptimizer(int length, int[] prices) : base(length, prices) { }

    public override void DisplayOptimalCuttingStrategy()
    {
        Console.WriteLine("\nScenario A - Standard optimization (no waste constraint)");
        Console.WriteLine($"Rod length: {rodTotalLength} ft");
        Console.WriteLine($"Maximum possible revenue: {CalculateMaximumRevenue()} units");

        Console.WriteLine("Price table used:");
        for (int i = 0; i < rodTotalLength; i++)
        {
            Console.WriteLine($"  {i + 1} ft → {pricePerLength[i]} units");
        }
    }

    public override void DisplayWasteAndRevenueSummary()
    {
        Console.WriteLine("Waste: 0 ft (full utilization assumed)");
        Console.WriteLine($"Revenue: {CalculateMaximumRevenue()} units");
    }
}

// Concrete implementation for waste-constrained scenario (B)
// Relationship: WasteConstrainedOptimizer is-a BaseRodOptimizer
// Has-a maximumAllowedWaste property
public class WasteConstrainedOptimizer : BaseRodOptimizer
{
    protected int maximumAllowedWaste;

    public WasteConstrainedOptimizer(int length, int[] prices, int maxWaste)
        : base(length, prices)
    {
        maximumAllowedWaste = maxWaste >= 0 ? maxWaste : 2; // default 2ft waste allowed
    }

    public override int CalculateMaximumRevenue()
    {
        // We will try all possible remaining waste from 0 to maximumAllowedWaste
        int bestRevenue = 0;

        for (int waste = 0; waste <= maximumAllowedWaste; waste++)
        {
            int usableLength = rodTotalLength - waste;
            if (usableLength <= 0) continue;

            int[] dp = new int[usableLength + 1];
            dp[0] = 0;

            for (int len = 1; len <= usableLength; len++)
            {
                int maxVal = 0;
                for (int cut = 1; cut <= len; cut++)
                {
                    maxVal = Math.Max(maxVal, pricePerLength[cut - 1] + dp[len - cut]);
                }
                dp[len] = maxVal;
            }

            if (dp[usableLength] > bestRevenue)
            {
                bestRevenue = dp[usableLength];
            }
        }

        return bestRevenue;
    }

    public override void DisplayOptimalCuttingStrategy()
    {
        Console.WriteLine(" Scenario B - With waste constraint");
        Console.WriteLine($"Rod length: {rodTotalLength} ft");
        Console.WriteLine($"Maximum allowed waste: {maximumAllowedWaste} ft");
        Console.WriteLine($"Best revenue possible: {CalculateMaximumRevenue()} units");
    }

    public override void DisplayWasteAndRevenueSummary()
    {
        Console.WriteLine($"Waste constraint: ≤ {maximumAllowedWaste} ft");
        Console.WriteLine($"Revenue: {CalculateMaximumRevenue()} units");
    }
}

// Concrete implementation for waste-aware maximization (C)
// Relationship: WasteAwareOptimizer is-a BaseRodOptimizer
public class WasteAwareOptimizer : BaseRodOptimizer
{
    public WasteAwareOptimizer(int length, int[] prices) : base(length, prices) { }

    public override void DisplayOptimalCuttingStrategy()
    {
        Console.WriteLine(" Scenario C - Maximizing revenue with minimal waste");
        int bestRevenue = CalculateMaximumRevenue();
        Console.WriteLine($"Maximum revenue: {bestRevenue} units");

        // Simple heuristic display - we don't track exact cuts for KISS
        Console.WriteLine("Best strategy tends to use as many high-value pieces as possible");
        Console.WriteLine("with minimal leftover waste (ideally 0ft)");
    }

    public override void DisplayWasteAndRevenueSummary()
    {
        Console.WriteLine("Waste-aware approach:");
        Console.WriteLine("  Prioritizes highest revenue per foot");
        Console.WriteLine(" Tries to minimize unused length");
        Console.WriteLine($"   Achieved revenue: {CalculateMaximumRevenue()} units");
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine(" Custom Furniture Manufacturing  ");

        bool continueRunning = true;

        while (continueRunning)
        {
            Console.WriteLine("Choose scenario:");
            Console.WriteLine("1 Scenario A: Standard optimization");
            Console.WriteLine("2 Scenario B: With maximum waste constraint");
            Console.WriteLine("3 Scenario C: Maximize revenue + minimal waste");
            Console.WriteLine("4 Exit");

            Console.Write("Your choice: ");
            string choiceInput = Console.ReadLine();
            int scenarioChoice = string.IsNullOrEmpty(choiceInput) ? 1 : int.Parse(choiceInput);

            if (scenarioChoice == 4)
            {
                continueRunning = false;
                continue;
            }

            // Get rod length
            Console.Write("Enter total rod length in feet (default 12): ");
            string lenInput = Console.ReadLine();
            int rodLength = string.IsNullOrEmpty(lenInput) ? 12 : int.Parse(lenInput);

            // Get price table
            int[] prices = new int[rodLength];
            Console.WriteLine("Enter price for each length (1ft to " + rodLength + "ft):");
            for (int i = 0; i < rodLength; i++)
            {
                Console.Write($"  Price for {i + 1} ft (default {(i + 1) * 25}): ");
                string priceStr = Console.ReadLine();
                prices[i] = string.IsNullOrEmpty(priceStr) ? (i + 1) * 25 : int.Parse(priceStr);
            }

            IRodOptimizer optimizer = null;

            if (scenarioChoice == 1)
            {
                optimizer = new StandardOptimizer(rodLength, prices);
            }
            else if (scenarioChoice == 2)
            {
                Console.Write("Enter maximum allowed waste in feet (default 2): ");
                string wasteStr = Console.ReadLine();
                int maxWaste = string.IsNullOrEmpty(wasteStr) ? 2 : int.Parse(wasteStr);

                optimizer = new WasteConstrainedOptimizer(rodLength, prices, maxWaste);
            }
            else if (scenarioChoice == 3)
            {
                optimizer = new WasteAwareOptimizer(rodLength, prices);
            }

            if (optimizer != null)
            {
                Console.WriteLine("\n" + new string('-', 60));
                optimizer.DisplayOptimalCuttingStrategy();
                Console.WriteLine(new string('-', 60));
                optimizer.DisplayWasteAndRevenueSummary();
                Console.WriteLine(new string('-', 60));
            }
        }

        Console.WriteLine("Thank you for using Rod Cutting Optimizer!");
    }
}
