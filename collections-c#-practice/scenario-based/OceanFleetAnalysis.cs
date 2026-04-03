using System;
using System.Collections.Generic;
using System.Linq;


// INTERFACE - Defines the contract that all Vessel implementations must follow
// Principle: Interface Segregation + Contract-first design

public interface IVessel
{
    string VesselId { get; }
    string VesselName { get; }
    double AverageSpeed { get; }      // in knots
    string VesselType { get; }

    string GetDisplayString();        // For consistent formatted output
}


// ABSTRACT BASE CLASS - Common behavior and protected storage
// Relationship: is-a (inheritance)
// Provides encapsulation + common logic + constructor injection

public abstract class AbstractVessel : IVessel
{
    // Protected so derived classes can access, but not public exposure
    protected string vesselId;
    protected string vesselName;
    protected double averageSpeed;
    protected string vesselType;

    public string VesselId => vesselId;
    public string VesselName => vesselName;
    public double AverageSpeed => averageSpeed;
    public string VesselType => vesselType;

    // Constructor enforces valid initialization (defensive programming)
    protected AbstractVessel(string id, string name, double speed, string type)
    {
        vesselId = string.IsNullOrWhiteSpace(id) ? "UNKNOWN" : id.Trim();
        vesselName = string.IsNullOrWhiteSpace(name) ? "Unnamed Vessel" : name.Trim();
        averageSpeed = speed < 0 ? 0 : speed;           // emergency default
        vesselType = string.IsNullOrWhiteSpace(type) ? "Unknown" : type.Trim();
    }

    // Common formatted output logic (DRY principle)
    public virtual string GetDisplayString()
    {
        return $"{VesselId} | {VesselName} | {VesselType} | {AverageSpeed} knots";
    }
}


// CONCRETE VESSEL CLASS
// Relationship: is-a AbstractVessel
// Implements the required behavior + formatting

public class Vessel : AbstractVessel
{
    public Vessel(string vesselId, string vesselName, double averageSpeed, string vesselType)
        : base(vesselId, vesselName, averageSpeed, vesselType)
    {
    }

    // Can be overridden in future specialized vessel types if needed
    public override string GetDisplayString()
    {
        return base.GetDisplayString();
    }
}


// VESSEL UTILITY CLASS - Manages central collection of vessels
// Relationship: has-a List<Vessel> (composition - central storage)
// Single Responsibility: vessel collection management

public class VesselUtil
{
    // Central storage - private to enforce encapsulation
    // Only this class manages the collection directly
    private readonly List<Vessel> vesselList = new List<Vessel>();

    // Getter (read-only view - protects internal collection)
    public IReadOnlyList<Vessel> VesselList => vesselList.AsReadOnly();

    // Requirement 1: Add vessel to central storage
    public void AddVesselPerformance(Vessel vessel)
    {
        if (vessel == null) return; // defensive
        vesselList.Add(vessel);
    }

    // Requirement 2: Find vessel by ID
    public Vessel GetVesselById(string vesselId)
    {
        if (string.IsNullOrWhiteSpace(vesselId))
            return null;

        return vesselList.FirstOrDefault(v => v.VesselId.Equals(vesselId, StringComparison.Ordinal));
    }

    // Requirement 3: Return all vessels with the maximum average speed
    public List<Vessel> GetHighPerformanceVessels()
    {
        if (vesselList.Count == 0)
            return new List<Vessel>();

        double maxSpeed = vesselList.Max(v => v.AverageSpeed);

        return vesselList
            .Where(v => Math.Abs(v.AverageSpeed - maxSpeed) < 0.0001) // floating-point safety
            .ToList();
    }
}


// MAIN APPLICATION ENTRY POINT
// Handles user interaction, input parsing, output formatting

public class UserInterface
{
    private readonly VesselUtil vesselManager;

    public UserInterface()
    {
        vesselManager = new VesselUtil();
    }

    public void Run()
    {
        Console.WriteLine("Enter the number of vessels to be added");
        if (!int.TryParse(Console.ReadLine(), out int numberOfVessels) || numberOfVessels <= 0)
        {
            Console.WriteLine("Invalid number. Exiting.");
            return;
        }

        Console.WriteLine("Enter vessel details");

        for (int i = 0; i < numberOfVessels; i++)
        {
            string line = Console.ReadLine()?.Trim();
            if (string.IsNullOrWhiteSpace(line)) continue;

            string[] parts = line.Split(':');
            if (parts.Length != 4) continue;

            string id = parts[0].Trim();
            string name = parts[1].Trim();
            if (!double.TryParse(parts[2].Trim(), out double speed)) continue;
            string type = parts[3].Trim();

            Vessel vessel = new Vessel(id, name, speed, type);
            vesselManager.AddVesselPerformance(vessel);
        }

        // Retrieve single vessel by ID
        Console.WriteLine("Enter the Vessel Id to check speed");
        string searchId = Console.ReadLine()?.Trim();

        Vessel foundVessel = vesselManager.GetVesselById(searchId);

        if (foundVessel != null)
        {
            Console.WriteLine(foundVessel.GetDisplayString());
        }
        else
        {
            Console.WriteLine($"Vessel Id {searchId} not found");
        }

        // Show high performance vessels
        Console.WriteLine("High performance vessels are");

        List<Vessel> topVessels = vesselManager.GetHighPerformanceVessels();

        if (topVessels.Count == 0)
        {
            Console.WriteLine("(No vessels recorded)");
        }
        else
        {
            foreach (Vessel v in topVessels)
            {
                Console.WriteLine(v.GetDisplayString());
            }
        }
    }

    // Program entry point
    public static void Main(string[] args)
    {
        UserInterface app = new UserInterface();
        app.Run();
    }
}
