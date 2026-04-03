using System;

// Custom exception class (inherits from Exception)
// Is-a: InvalidFlightException is-an Exception
/// <summary>
/// Custom exception thrown when any flight-related validation fails
/// </summary>
public class InvalidFlightException : Exception
{
    public InvalidFlightException(string message) : base(message)
    {
    }
}

/// <summary>
/// Utility class containing all business validation and calculation logic
/// Has-a: Contains flight rules as internal constants/maps
/// Single Responsibility: Flight validation & fuel calculation
/// </summary>
public class FlightUtil
{
    // Protected constants - visible to derived classes if needed in future
    protected const string FLIGHT_NUMBER_PATTERN_PREFIX = "FL-";
    protected const int FLIGHT_NUMBER_DIGITS = 4;
    protected const int MIN_FLIGHT_NUMBER = 1000;
    protected const int MAX_FLIGHT_NUMBER = 9999;

    // Using Dictionary for easy lookup + extension friendly (OCP)
    protected static readonly Dictionary<string, int> MaximumPassengerCapacity = new(StringComparer.OrdinalIgnoreCase)
    {
        { "SpiceJet",   396 },
        { "Vistara",    615 },
        { "IndiGo",     230 },
        { "Air Arabia", 130 }
    };

    protected static readonly Dictionary<string, double> FuelTankCapacityLiters = new(StringComparer.OrdinalIgnoreCase)
    {
        { "SpiceJet",   200000 },
        { "Vistara",    300000 },
        { "IndiGo",     250000 },
        { "Air Arabia", 150000 }
    };

    /// <summary>
    /// Validates flight number format: FL-XXXX where XXXX is 1000–9999
    /// </summary>
    public bool ValidateFlightNumber(string flightNumber)
    {
        if (string.IsNullOrWhiteSpace(flightNumber))
            throw new InvalidFlightException($"The flight number {flightNumber ?? "null"} is invalid");

        if (!flightNumber.StartsWith(FLIGHT_NUMBER_PATTERN_PREFIX))
            throw new InvalidFlightException($"The flight number {flightNumber} is invalid");

        string numberPart = flightNumber.Substring(FLIGHT_NUMBER_PATTERN_PREFIX.Length);

        if (numberPart.Length != FLIGHT_NUMBER_DIGITS)
            throw new InvalidFlightException($"The flight number {flightNumber} is invalid");

        if (!int.TryParse(numberPart, out int flightNum))
            throw new InvalidFlightException($"The flight number {flightNumber} is invalid");

        if (flightNum < MIN_FLIGHT_NUMBER || flightNum > MAX_FLIGHT_NUMBER)
            throw new InvalidFlightException($"The flight number {flightNumber} is invalid");

        return true;
    }

    /// <summary>
    /// Validates that flight name is one of the allowed airlines (case-insensitive)
    /// </summary>
    public bool ValidateFlightName(string flightName)
    {
        if (string.IsNullOrWhiteSpace(flightName))
            throw new InvalidFlightException($"The flight name {flightName ?? "null"} is invalid");

        if (!MaximumPassengerCapacity.ContainsKey(flightName))
            throw new InvalidFlightException($"The flight name {flightName} is invalid");

        return true;
    }

    /// <summary>
    /// Validates passenger count against airline-specific capacity
    /// </summary>
    public bool ValidatePassengerCount(int passengerCount, string flightName)
    {
        if (passengerCount <= 0)
            throw new InvalidFlightException($"The passenger count {passengerCount} is invalid for {flightName}");

        if (!MaximumPassengerCapacity.TryGetValue(flightName, out int maxCapacity))
            throw new InvalidFlightException($"The flight name {flightName} is invalid"); // safety check

        if (passengerCount > maxCapacity)
            throw new InvalidFlightException($"The passenger count {passengerCount} is invalid for {flightName}");

        return true;
    }

    /// <summary>
    /// Calculates how much fuel is needed to fill the tank to full capacity
    /// </summary>
    public double CalculateFuelToFillTank(string flightName, double currentFuelLevel)
    {
        if (!FuelTankCapacityLiters.TryGetValue(flightName, out double maxCapacity))
            throw new InvalidFlightException($"The flight name {flightName} is invalid");

        if (currentFuelLevel < 0 || currentFuelLevel > maxCapacity)
            throw new InvalidFlightException($"Invalid fuel level for {flightName}");

        return maxCapacity - currentFuelLevel;
    }
}

/// <summary>
/// Main console application class responsible for user interaction
/// Has-a: FlightUtil (composition)
/// Single Responsibility: User input, orchestration, exception handling display
/// </summary>
public class UserInterface
{
    private readonly FlightUtil _flightUtil;

    public UserInterface()
    {
        _flightUtil = new FlightUtil();
    }

    public void Run()
    {
        Console.WriteLine("Enter flight details");
        string? inputLine = Console.ReadLine()?.Trim();

        if (string.IsNullOrWhiteSpace(inputLine))
        {
            Console.WriteLine("No input provided.");
            return;
        }

        string[] parts = inputLine.Split(':', StringSplitOptions.TrimEntries);

        if (parts.Length != 4)
        {
            Console.WriteLine("Invalid input format. Expected: FL-XXXX:Airline:passengers:fuel");
            return;
        }

        string flightNumber    = parts[0];
        string flightName      = parts[1];
        string passengerStr    = parts[2];
        string currentFuelStr  = parts[3];

        try
        {
            // Step 1: Validate flight number
            _flightUtil.ValidateFlightNumber(flightNumber);

            // Step 2: Validate flight name (also checks if we support this airline)
            _flightUtil.ValidateFlightName(flightName);

            // Step 3: Parse and validate passenger count
            if (!int.TryParse(passengerStr, out int passengerCount))
                throw new InvalidFlightException($"Invalid passenger count format: {passengerStr}");

            _flightUtil.ValidatePassengerCount(passengerCount, flightName);

            // Step 4: Parse and validate fuel level + calculate
            if (!double.TryParse(currentFuelStr, out double currentFuel))
                throw new InvalidFlightException($"Invalid fuel level format: {currentFuelStr}");

            double fuelNeeded = _flightUtil.CalculateFuelToFillTank(flightName, currentFuel);

            // Success
            Console.WriteLine($"Fuel required to fill the tank: {fuelNeeded} liters");
        }
        catch (InvalidFlightException ex)
        {
            Console.WriteLine(ex.Message);
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unexpected error: {ex.Message}");
        }
    }

    // Entry point
    public static void Main(string[] args)
    {
        UserInterface ui = new UserInterface();
        ui.Run();
    }
}
