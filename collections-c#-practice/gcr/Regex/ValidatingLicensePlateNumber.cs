using System;

public class plateVal 
{
    // license plate: two uppercase letters + four digits
    // example: AB1234 → valid
    public static bool isValidPlate(string plate)
    {
        // must be exactly 6 chars
        if(plate.Length != 6)
        {
            Console.WriteLine("must be exactly 6 characters");
            return false;
        }

        // first two must be uppercase letters
        if(!char.IsUpper(plate[0]) || !char.IsUpper(plate[1]))
        {
            Console.WriteLine("first two must be uppercase letters");
            return false;
        }

        // next four must be digits
        for(int i=2; i<6 ; i++)
        {
            if(!char.IsDigit(plate[i]))
            {
                Console.WriteLine("last four must be numbers");
                return false;
            }
        }

        Console.WriteLine("valid license plate");
        return true;
    }

    public static void Main(string[] args) 
    {
        /*
        2. Validate a License Plate Number
        License plate format: Starts with two uppercase letters, followed by four digits.
        Example: "AB1234" is valid, but "A12345" is invalid.
        */

        Console.WriteLine("License Plate Validator\n");

        while(true)
        {
            Console.Write("Waiting , for user to enter plate (or empty to exit) : ");
            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input)) break;

            isValidPlate(input);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
