using System;

public class hexVal 
{
    // hex color: # followed by 6 hex digits (0-9 A-F a-f)
    public static bool isValidHexColor(string hex)
    {
        if(hex.Length != 7 || hex[0] != '#')
        {
            Console.WriteLine("must start with # and be 7 chars long");
            return false;
        }

        string hexPart = hex.Substring(1);

        for(int i=0; i<6 ; i++)
        {
            char c = hexPart[i];

            if(!((c >= '0' && c <= '9') || 
                 (c >= 'A' && c <= 'F') || 
                 (c >= 'a' && c <= 'f')))
            {
                Console.WriteLine("invalid hex character");
                return false;
            }
        }

        Console.WriteLine("valid hex color");
        return true;
    }

    public static void Main(string[] args) 
    {
        /*
        3. Validate a Hex Color Code
        A valid hex color:
        * Starts with a #
        * Followed by 6 hexadecimal characters (0-9, A-F, a-f).
        Example Inputs & Outputs:
        * ✅ "#FFA500" → Valid
        * ✅ "#ff4500" → Valid
        * ❌ "#123" → Invalid (too short)
        */

        Console.WriteLine("Hex Color Code Validator\n");

        while(true)
        {
            Console.Write("Waiting , for user to enter hex color (or empty to exit) : ");
            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input)) break;

            isValidHexColor(input);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
