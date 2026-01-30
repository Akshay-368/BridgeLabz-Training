using System;

//  INTERFACE: Defines the contract for all Goods Transport types
//  Relationship: GoodsTransport implements IGoodsTransport (implements-a)
//  Why essential: Provides polymorphism & ensures every transport type
//  must implement vehicle selection and charge calculation
public interface IGoodsTransport
{
    string VehicleSelection();
    float CalculateTotalCharge();
}


//  ABSTRACT BASE CLASS: Common properties & constructor
//  Relationship: BrickTransport & TimberTransport is-a GoodsTransport (inheritance)
//  Why essential:
//    • Central storage of common fields (protected)
//    • Common constructor logic (DRY)
//    • Encapsulation: fields are protected, not public
//    • Abstract methods force children to implement specific logic

public abstract class GoodsTransport : IGoodsTransport
{
    protected string transportId;
    protected string transportDate;
    protected int transportRating;

    // Protected constructor - children must call it
    protected GoodsTransport(string transportId, string transportDate, int transportRating)
    {
        this.transportId = transportId;
        this.transportDate = transportDate;
        this.transportRating = transportRating;
    }

    // Common getter-like behavior (encapsulated)
    protected float GetDiscountPercentage()
    {
        if (transportRating == 5) return 0.20f;
        if (transportRating == 3 || transportRating == 4) return 0.10f;
        return 0.0f; // 1 or 2 → no discount
    }

    // Abstract methods - must be implemented by children
    public abstract string VehicleSelection();
    public abstract float CalculateTotalCharge();
}


//  CONCRETE CLASS: BrickTransport
//  Relationship: BrickTransport is-a GoodsTransport

public class BrickTransport : GoodsTransport
{
    private float brickSize;
    private int brickQuantity;
    private float brickPrice;

    // 6-argument constructor (as required)
    public BrickTransport(string transportId, string transportDate, int transportRating,
                          float brickSize, int brickQuantity, float brickPrice)
        : base(transportId, transportDate, transportRating)
    {
        this.brickSize = brickSize;
        this.brickQuantity = brickQuantity;
        this.brickPrice = brickPrice;
    }

    // Vehicle selection logic
    public override string VehicleSelection()
    {
        if (brickQuantity < 300)
            return "Truck";
        else if (brickQuantity <= 500)
            return "Lorry";
        else
            return "MonsterLorry";
    }

    // Total charge calculation for bricks
    public override float CalculateTotalCharge()
    {
        // Total brick cost
        float price = brickPrice * brickQuantity;

        //  Tax 30%
        float tax = price * 0.30f;

        // Vehicle price
        string vehicle = VehicleSelection();
        float vehiclePrice = 0;
        if (vehicle == "Truck") vehiclePrice = 1000;
        else if (vehicle == "Lorry") vehiclePrice = 1700;
        else if (vehicle == "MonsterLorry") vehiclePrice = 3000;

        // Discount based on rating
        float discount = price * GetDiscountPercentage();

        // Final charge
        float total = price + vehiclePrice + tax - discount;

        return total;
    }
}


//  CONCRETE CLASS: TimberTransport
//  Relationship: TimberTransport is-a GoodsTransport

public class TimberTransport : GoodsTransport
{
    private float timberLength;
    private float timberRadius;
    private string timberType;
    private float timberPrice;

    // 7-argument constructor (as required)
    public TimberTransport(string transportId, string transportDate, int transportRating,
                           float timberLength, float timberRadius, string timberType, float timberPrice)
        : base(transportId, transportDate, transportRating)
    {
        this.timberLength = timberLength;
        this.timberRadius = timberRadius;
        this.timberType = timberType;
        this.timberPrice = timberPrice;
    }

    // Vehicle selection logic based on area
    public override string VehicleSelection()
    {
        float area = 2 * 3.147f * timberRadius * timberLength;

        if (area < 250)
            return "Truck";
        else if (area <= 400)
            return "Lorry";
        else
            return "MonsterLorry";
    }

    // Total charge calculation for timber
    public override float CalculateTotalCharge()
    {
        // Step 1: Volume
        float volume = 3.147f * timberRadius * timberRadius * timberLength;

        // Step 2: Price based on type
        float rate = timberType.Equals("Premium", StringComparison.OrdinalIgnoreCase) ? 0.25f : 0.15f;
        float price = volume * timberPrice * rate;

        // Step 3: Tax 30%
        float tax = price * 0.30f;

        // Step 4: Vehicle price
        string vehicle = VehicleSelection();
        float vehiclePrice = 0;
        if (vehicle == "Truck") vehiclePrice = 1000;
        else if (vehicle == "Lorry") vehiclePrice = 1700;
        else if (vehicle == "MonsterLorry") vehiclePrice = 3000;

        //  Discount based on rating
        float discount = price * GetDiscountPercentage();

        //  Final charge
        float total = price + vehiclePrice + tax - discount;

        return total;
    }
}


//  UTILITY CLASS - contains helper methods

public static class Utility
{
    // Parse input string and return appropriate GoodsTransport object
    public static GoodsTransport ParseDetails(string input)
    {
        string[] parts = input.Split(':');

        if (parts.Length < 7)
        {
            Console.WriteLine("Invalid input format");
            return null;
        }

        string transportId    = parts[0];
        string transportDate  = parts[1];
        int transportRating   = int.Parse(parts[2]);
        string transportType  = parts[3];

        // Validate transportId format: RTS followed by 3 digits + 1 uppercase letter
        if (!ValidateTransportId(transportId))
        {
            Console.WriteLine("Transport id " + transportId + " is invalid");
            Console.WriteLine("Please provide a valid record");
            return null;
        }

        if (transportType.Equals("BrickTransport", StringComparison.OrdinalIgnoreCase))
        {
            float brickSize     = float.Parse(parts[4]);
            int brickQuantity   = int.Parse(parts[5]);
            float brickPrice    = float.Parse(parts[6]);

            return new BrickTransport(transportId, transportDate, transportRating,
                                      brickSize, brickQuantity, brickPrice);
        }
        else if (transportType.Equals("TimberTransport", StringComparison.OrdinalIgnoreCase))
        {
            float timberLength  = float.Parse(parts[4]);
            float timberRadius  = float.Parse(parts[5]);
            string timberType   = parts[6];
            float timberPrice   = float.Parse(parts[7]);

            return new TimberTransport(transportId, transportDate, transportRating,
                                       timberLength, timberRadius, timberType, timberPrice);
        }
        else
        {
            Console.WriteLine("Unknown transport type: " + transportType);
            return null;
        }
    }

    // Validate transportId: RTS + 3 digits + 1 uppercase letter
    public static bool ValidateTransportId(string transportId)
    {
        if (transportId.Length != 7)
            return false;

        if (!transportId.StartsWith("RTS"))
            return false;

        string digits = transportId.Substring(3, 3);
        for (int i = 0; i < digits.Length; i++)
        {
            if (!char.IsDigit(digits[i]))
                return false;
        }

        char last = transportId[6];
        if (!char.IsUpper(last))
            return false;

        return true;
    }

    // Identify object type
    public static string FindObjectType(GoodsTransport goodsTransport)
    {
        if (goodsTransport is BrickTransport)
            return "BrickTransport";
        if (goodsTransport is TimberTransport)
            return "TimberTransport";

        return "Unknown";
    }
}


//  MAIN USER INTERFACE CLASS

public class UserInterface
{
    public static void Main(string[] args)
    {
        /*
        FutureLogistics – Billing System
        */

        Console.WriteLine("Enter the Goods Transport details");
        string input = Console.ReadLine().Trim();

        // parse input
        GoodsTransport transport = Utility.ParseDetails(input);

        if (transport == null)
        {
            // already printed error inside ParseDetails
            goto End;
        }

        // validate transportId again (as per requirement)
        if (!Utility.ValidateTransportId(transport.transportId))
        {
            Console.WriteLine("Transport id " + transport.transportId + " is invalid");
            Console.WriteLine("Please provide a valid record");
            goto End;
        }

        // find type
        string transportType = Utility.FindObjectType(transport);

        // calculate charge
        float totalCharge = transport.CalculateTotalCharge();

        // display result
        Console.WriteLine("Transporter id : " + transport.transportId);
        Console.WriteLine("Date of transport : " + transport.transportDate);
        Console.WriteLine("Rating of the transport : " + transport.transportRating);

        if (transport is BrickTransport brick)
        {
            Console.WriteLine("Quantity of bricks : " + brick.brickQuantity);
            Console.WriteLine("Brick price : " + brick.brickPrice);
        }
        else if (transport is TimberTransport timber)
        {
            Console.WriteLine("Type of the timber : " + timber.timberType);
            Console.WriteLine("Timber price per kilo : " + timber.timberPrice);
        }

        Console.WriteLine("Vehicle for transport : " + transport.VehicleSelection());
        Console.WriteLine("Total charge : " + totalCharge.ToString("F2"));

    End:
        Console.WriteLine("\nPress any key to exit...");
        Console.ReadKey();
    }
}
