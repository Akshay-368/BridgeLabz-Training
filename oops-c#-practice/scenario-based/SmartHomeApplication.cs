using System;
using System.Collections.Generic;
using System.Linq;

// Interface defining the contract for controllable devices
// This ensures all appliances adhere to a common control mechanism (TurnOn, TurnOff)
// Relationship: Appliance implements IControllable (implements-a interface relation)
// Why essential: Provides polymorphism and ensures consistent control across different appliance types
public interface IControllable
{
    void TurnOn();
    void TurnOff();
}

// Abstract base class for all appliances, providing common properties and logic
// Common properties like Name and IsOn are centralized here for inheritance
// Common logic in TurnOn/TurnOff is defined virtually, allowing children to extend
// Relationship: Light/Fan/AC is-a Appliance (inheritance relation)
// Why essential: Follows DRY by avoiding code duplication; enables polymorphism
// Encapsulation: Properties use private setters to control access
// SOLID: Single responsibility (manages common appliance state/behavior)
// Open/closed: Base class closed for modification, open for extension via overrides
// KISS/YAGNI: Only essential common features; no unnecessary complexity
public abstract class Appliance : IControllable
{
    public string Name { get; private set; }
    public bool IsOn { get; protected set; }

    // Constructor to initialize non-primitive types like string
    // Allows passing name, with default for emergencies
    protected Appliance(string name)
    {
        Name = string.IsNullOrEmpty(name) ? "Default Appliance" : name;
        IsOn = false;
    }

    // Virtual method for common TurnOn logic, customizable by children
    public virtual void TurnOn()
    {
        if (!IsOn)
        {
            IsOn = true;
            Console.WriteLine($"{Name} is now turning on.");
        }
        else
        {
            Console.WriteLine($"{Name} is already on.");
        }
    }

    // Virtual method for common TurnOff logic, customizable by children
    public virtual void TurnOff()
    {
        if (IsOn)
        {
            IsOn = false;
            Console.WriteLine($"{Name} is now turning off.");
        }
        else
        {
            Console.WriteLine($"{Name} is already off.");
        }
    }
}

// Concrete class for Light, extending Appliance
// Overrides TurnOn for specific behavior (polymorphism)
// Relationship: Light is-a Appliance
// Why essential: Specializes light-specific actions while inheriting common logic
public class Light : Appliance
{
    public Light(string name) : base(name) { }

    public override void TurnOn()
    {
        base.TurnOn();
        if (IsOn)
        {
            Console.WriteLine("Illuminating the room with bright light.");
        }
    }

    public override void TurnOff()
    {
        base.TurnOff();
        if (!IsOn)
        {
            Console.WriteLine("Dimming the room to darkness.");
        }
    }
}

// Concrete class for Fan, extending Appliance
// Overrides TurnOn for specific behavior
// Relationship: Fan is-a Appliance
// Why essential: Allows fan-specific customization
public class Fan : Appliance
{
    public Fan(string name) : base(name) { }

    public override void TurnOn()
    {
        base.TurnOn();
        if (IsOn)
        {
            Console.WriteLine("Circulating air with a gentle breeze.");
        }
    }

    public override void TurnOff()
    {
        base.TurnOff();
        if (!IsOn)
        {
            Console.WriteLine("Stopping the air circulation.");
        }
    }
}

// Concrete class for AC, extending Appliance
// Overrides TurnOn for different behavior than Light (polymorphism example)
// Relationship: AC is-a Appliance
// Why essential: Demonstrates varied polymorphic behavior for AC
public class AC : Appliance
{
    public AC(string name) : base(name) { }

    public override void TurnOn()
    {
        base.TurnOn();
        if (IsOn)
        {
            Console.WriteLine("Starting cooling and regulating temperature.");
        }
    }

    public override void TurnOff()
    {
        base.TurnOff();
        if (!IsOn)
        {
            Console.WriteLine("Stopping cooling and powering down.");
        }
    }
}

// Class managing the smart home system
// Central storage for all appliances here (List<Appliance>)
// Relationship: SmartHome has-a List<Appliance> (composition/has-a relation)
// Why essential: Centralizes management; avoids scattering appliances
// SOLID: Single responsibility (manages collection and operations)
// DRY: Centralized add/control methods
// KISS: Simple list management without over-engineering
public class SmartHome
{
    private List<Appliance> appliances = new List<Appliance>();

    public void AddAppliance(Appliance appliance)
    {
        if (appliance != null)
        {
            appliances.Add(appliance);
            Console.WriteLine($"Added {appliance.Name} to the smart home system.");
        }
    }

    public void TurnOnAppliance(string name)
    {
        var appliance = appliances.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (appliance != null)
        {
            appliance.TurnOn();
        }
        else
        {
            Console.WriteLine($"Appliance {name} not found.");
        }
    }

    public void TurnOffAppliance(string name)
    {
        var appliance = appliances.FirstOrDefault(a => a.Name.Equals(name, StringComparison.OrdinalIgnoreCase));
        if (appliance != null)
        {
            appliance.TurnOff();
        }
        else
        {
            Console.WriteLine($"Appliance {name} not found.");
        }
    }

    public void ListAllAppliances()
    {
        if (appliances.Count == 0)
        {
            Console.WriteLine("No appliances in the system.");
            return;
        }

        Console.WriteLine("Current appliances in the smart home:");
        foreach (var appliance in appliances)
        {
            Console.WriteLine($"- {appliance.Name} ({appliance.GetType().Name}), Status: {(appliance.IsOn ? "On" : "Off")}");
        }
    }

    // Method to demonstrate polymorphism: Turn on all appliances
    public void TurnOnAll()
    {
        Console.WriteLine("Turning on all appliances (demonstrating polymorphism):");
        foreach (var appliance in appliances)
        {
            appliance.TurnOn();
        }
    }
}

public class Program
{
    public static void Main(string[] args)
    {
        SmartHome home = new SmartHome();
        bool running = true;

        while (running)
        {
            Console.WriteLine("\nSmart Home Automation System Menu:");
            Console.WriteLine("1. Add Appliance");
            Console.WriteLine("2. Turn On Appliance");
            Console.WriteLine("3. Turn Off Appliance");
            Console.WriteLine("4. List All Appliances");
            Console.WriteLine("5. Turn On All (Polymorphism Demo)");
            Console.WriteLine("6. Exit");

            Console.Write("Enter your choice: ");
            string input = Console.ReadLine();
            int choice;
            int.TryParse(input, out choice);

            switch (choice)
            {
                case 1:
                    Console.Write("Enter appliance type (1: Light, 2: Fan, 3: AC): ");
                    string typeInput = Console.ReadLine();
                    int type;
                    int.TryParse(typeInput, out type);

                    Console.Write("Enter appliance name (or press Enter for default): ");
                    string name = Console.ReadLine();

                    Appliance newAppliance = null;
                    switch (type)
                    {
                        case 1:
                            newAppliance = new Light(name);
                            break;
                        case 2:
                            newAppliance = new Fan(name);
                            break;
                        case 3:
                            newAppliance = new AC(name);
                            break;
                        default:
                            Console.WriteLine("Invalid type. Using default Light.");
                            newAppliance = new Light(name);
                            break;
                    }
                    home.AddAppliance(newAppliance);
                    break;

                case 2:
                    Console.Write("Enter appliance name to turn on: ");
                    string onName = Console.ReadLine();
                    home.TurnOnAppliance(onName);
                    break;

                case 3:
                    Console.Write("Enter appliance name to turn off: ");
                    string offName = Console.ReadLine();
                    home.TurnOffAppliance(offName);
                    break;

                case 4:
                    home.ListAllAppliances();
                    break;

                case 5:
                    home.TurnOnAll();
                    break;

                case 6:
                    running = false;
                    Console.WriteLine("Exiting the system.");
                    break;

                default:
                    Console.WriteLine("Invalid choice. Please try again.");
                    break;
            }
        }
    }
}
