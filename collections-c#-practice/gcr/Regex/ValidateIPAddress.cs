using System;

public class ipVal 
{
    // validate IPv4 address
    // four numbers 0-255 separated by dots
    public static bool isValidIP(string ip)
    {
        string[] parts = ip.Split('.');

        if(parts.Length != 4)
        {
            Console.WriteLine("must have exactly 4 parts");
            return false;
        }

        for(int i=0; i<4 ; i++)
        {
            string p = parts[i];

            if(string.IsNullOrEmpty(p))
            {
                Console.WriteLine("empty part found");
                return false;
            }

            int num;
            if(!int.TryParse(p, out num))
            {
                Console.WriteLine("part not a number: " + p);
                return false;
            }

            if(num < 0 || num > 255)
            {
                Console.WriteLine("number out of range (0-255): " + num);
                return false;
            }

            // check no leading zeros (except 0 itself)
            if(p.Length > 1 && p.StartsWith("0"))
            {
                Console.WriteLine("leading zero not allowed: " + p);
                return false;
            }
        }

        Console.WriteLine("valid IPv4 address");
        return true;
    }

    public static void Main(string[] args) 
    {
        /*
        10. Validate an IP Address
        A valid IPv4 address consists of four groups of numbers (0-255) separated by dots.
        */

        Console.WriteLine("IPv4 Address Validator\n");

        while(true)
        {
            Console.Write("Waiting , for user to enter IP address (or empty to exit) : ");
            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input)) break;

            isValidIP(input);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
