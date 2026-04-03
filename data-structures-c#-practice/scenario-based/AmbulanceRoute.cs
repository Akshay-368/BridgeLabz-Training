using System;

// Section: Hospital Unit Node Class
// This class represents each hospital unit in the circular linked list.
// It has-a relationship with string for UnitName (to identify the unit, essential for distinguishing units).
// It has-a relationship with HospitalUnitNode for Next (to form the linked structure, essential for traversing the circular path).
// Encapsulation: Uses properties with private setters for immutable properties like UnitName. Mutable states like IsAvailable and IsUnderMaintenance have public setters but could be controlled via methods in the navigation system for better encapsulation.
// Follows KISS: Simple properties without unnecessary complexity.
// YAGNI: No extra fields or methods beyond what's needed for the requirements.
class HospitalUnitNode
{
    public string UnitName { get; private set; }
    public bool IsAvailable { get; set; } = true;
    public bool IsUnderMaintenance { get; set; } = false;
    public HospitalUnitNode Next { get; set; }

    // Constructor to pass non-primitive data (though string is reference type, used here for initialization).
    public HospitalUnitNode(string unitName)
    {
        UnitName = unitName;
    }
}

// Section: Interface for Hospital Navigation System
// This interface defines the contract for the base class, specifying operations for managing and navigating hospital units.
// It ensures that all implementing classes provide these methods, following SOLID's Interface Segregation Principle (focused on navigation tasks).
interface IHospitalNavigationSystem
{
    void InitializeUnits();
    HospitalUnitNode FindNextAvailableUnit(HospitalUnitNode startingUnit);
    void RemoveUnit(string unitName);
    HospitalUnitNode GetUnit(string unitName);
    void SetUnitAvailability(string unitName, bool available);
    void SetUnitMaintenance(string unitName, bool maintenance);
    void PrintUnits();
}

// Section: Abstract Base Class for Hospital Navigation System
// This class is-a IHospitalNavigationSystem (inheritance to implement the interface contract).
// It has-a HospitalUnitNode for Head and Tail (central storage for the circular linked list, essential because all operations read/write to this shared structure; keeps storage centralized as per requirements).
// Provides common properties and logic like adding, finding, removing, and utility methods.
// Leaves InitializeUnits abstract for child classes to implement customization (e.g., user input methods).
// Encapsulation: Protected fields for Head and Tail, accessible only to subclasses. Protected AddUnit method for internal use.
// Inheritance: Allows child classes to extend and customize while reusing common logic.
// SOLID: Single Responsibility (manages list operations), Open-Closed (extend via subclasses), Liskov Substitution (subclasses can replace base), etc.
// DRY: Common traversal and manipulation logic here to avoid repetition in subclasses.
// KISS: Straightforward circular list operations using do-while for traversal.
// YAGNI: No unnecessary features like sorting or advanced searches.
abstract class AbstractHospitalNavigationSystem : IHospitalNavigationSystem
{
    protected HospitalUnitNode Head { get; private set; }
    protected HospitalUnitNode Tail { get; private set; }

    public abstract void InitializeUnits();

    // Protected method to add a unit (used by subclasses during initialization).
    // Encapsulated to prevent external direct modification.
    protected void AddUnit(string name)
    {
        HospitalUnitNode newNode = new HospitalUnitNode(name);
        if (Head == null)
        {
            Head = newNode;
            Tail = newNode;
            newNode.Next = Head; // Make it circular from the start.
        }
        else
        {
            Tail.Next = newNode;
            Tail = newNode;
            newNode.Next = Head; // Maintain circular link.
        }
    }

    public HospitalUnitNode FindNextAvailableUnit(HospitalUnitNode startingUnit)
    {
        if (Head == null || startingUnit == null) return null;

        HospitalUnitNode current = startingUnit;
        do
        {
            if (current.IsAvailable && !current.IsUnderMaintenance)
            {
                return current;
            }
            current = current.Next;
        } while (current != startingUnit);

        return null; // No available unit found after full rotation.
    }

    public void RemoveUnit(string unitName)
    {
        if (Head == null) return;

        // Handle removal of head.
        if (Head.UnitName == unitName)
        {
            if (Head.Next == Head) // Single node case.
            {
                Head = null;
                Tail = null;
            }
            else
            {
                Tail.Next = Head.Next;
                Head = Head.Next;
            }
            return;
        }

        // Traverse to find the node to remove.
        HospitalUnitNode current = Head;
        do
        {
            if (current.Next.UnitName == unitName)
            {
                current.Next = current.Next.Next;
                if (current.Next == Head) Tail = current; // Update tail if removed last node.
                return;
            }
            current = current.Next;
        } while (current != Head);
    }

    public HospitalUnitNode GetUnit(string unitName)
    {
        if (Head == null) return null;

        HospitalUnitNode current = Head;
        do
        {
            if (current.UnitName == unitName)
            {
                return current;
            }
            current = current.Next;
        } while (current != Head);

        return null;
    }

    public void SetUnitAvailability(string unitName, bool available)
    {
        HospitalUnitNode unit = GetUnit(unitName);
        if (unit != null)
        {
            unit.IsAvailable = available;
        }
    }

    public void SetUnitMaintenance(string unitName, bool maintenance)
    {
        HospitalUnitNode unit = GetUnit(unitName);
        if (unit != null)
        {
            unit.IsUnderMaintenance = maintenance;
        }
    }

    public void PrintUnits()
    {
        if (Head == null)
        {
            Console.WriteLine("No units available.");
            return;
        }

        HospitalUnitNode current = Head;
        do
        {
            Console.WriteLine($"{current.UnitName} - Available: {current.IsAvailable}, Under Maintenance: {current.IsUnderMaintenance}");
            current = current.Next;
        } while (current != Head);
    }
}

// Section: Concrete Child Class for Circular Hospital Navigation System
// This class is-a AbstractHospitalNavigationSystem (inheritance to reuse common logic and central storage while customizing the initialization).
// Implements the abstract InitializeUnits method in its own way: by prompting the user for inputs with defaults (as per requirements, avoiding hardcoded values solely).
// The customization here is essential for flexibility, allowing user-driven setup instead of fixed logic.
// No unnecessary overrides; only implements what's left by the parent.
// Encapsulation: Relies on protected methods like AddUnit from the base class, without exposing internal details.
class CircularHospitalNavigationSystem : AbstractHospitalNavigationSystem
{
    public override void InitializeUnits()
    {
        string[] defaultUnitNames = { "Emergency", "Radiology", "Surgery", "ICU" };

        Console.WriteLine("Enter the number of hospital units (default: 4):");
        string numberInput = Console.ReadLine();
        int numberOfUnits = string.IsNullOrEmpty(numberInput) ? 4 : int.Parse(numberInput);

        for (int index = 0; index < numberOfUnits; index++)
        {
            string defaultName = (index < defaultUnitNames.Length) ? defaultUnitNames[index] : $"Unit{index + 1}";
            Console.WriteLine($"Enter name for unit {index + 1} (default: {defaultName}):");
            string unitName = Console.ReadLine();
            if (string.IsNullOrEmpty(unitName))
            {
                unitName = defaultName;
            }
            AddUnit(unitName); // Uses protected base method.
        }
    }
}

// Section: Program Entry Point
// This class contains the static Main method (necessary static for program entry, no unnecessary statics elsewhere).
// Demonstrates the usage: initializes, prints, simulates finding available unit, sets maintenance, removes, etc.
// Follows has-a relationship with CircularHospitalNavigationSystem (creates and uses an instance).
class Program
{
    static void Main(string[] args)
    {
        CircularHospitalNavigationSystem navigationSystem = new CircularHospitalNavigationSystem();
        navigationSystem.InitializeUnits();

        Console.WriteLine("\nCurrent hospital units:");
        navigationSystem.PrintUnits();

        // Simulate setting a unit to unavailable.
        Console.WriteLine("\nEnter unit name to set as unavailable (or press enter to skip):");
        string unavailableUnit = Console.ReadLine();
        if (!string.IsNullOrEmpty(unavailableUnit))
        {
            navigationSystem.SetUnitAvailability(unavailableUnit, false);
            Console.WriteLine("After update:");
            navigationSystem.PrintUnits();
        }

        // Simulate finding next available unit.
        Console.WriteLine("\nEnter starting unit name for patient redirection (default: Emergency):");
        string startingUnitName = Console.ReadLine();
        if (string.IsNullOrEmpty(startingUnitName)) startingUnitName = "Emergency";
        HospitalUnitNode startingUnit = navigationSystem.GetUnit(startingUnitName);
        if (startingUnit == null)
        {
            Console.WriteLine("Starting unit not found.");
            return;
        }
        HospitalUnitNode availableUnit = navigationSystem.FindNextAvailableUnit(startingUnit);
        if (availableUnit != null)
        {
            Console.WriteLine($"Patient redirected to next available unit: {availableUnit.UnitName}");
        }
        else
        {
            Console.WriteLine("No available units found in the circular path.");
        }

        // Simulate maintenance and removal.
        Console.WriteLine("\nEnter unit name to set under maintenance and remove (or press enter to skip):");
        string maintenanceUnit = Console.ReadLine();
        if (!string.IsNullOrEmpty(maintenanceUnit))
        {
            navigationSystem.SetUnitMaintenance(maintenanceUnit, true);
            navigationSystem.RemoveUnit(maintenanceUnit);
            Console.WriteLine("After maintenance removal:");
            navigationSystem.PrintUnits();
        }

        // Extra : Another find after removal.
        Console.WriteLine("\nPress enter to exit.");
        Console.ReadLine();
    }
}
