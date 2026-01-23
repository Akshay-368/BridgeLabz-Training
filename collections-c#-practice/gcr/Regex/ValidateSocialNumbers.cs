using System;
using System.Text.RegularExpressions;

public class ssnVal 
{
    // validate SSN: 123-45-6789 format
    public static bool isValidSSN(string ssn)
    {
        string pattern = @"^\d{3}-\d{2}-\d{4}$";

        if(Regex.IsMatch(ssn, pattern))
        {
            Console.WriteLine("valid SSN format");
            return true;
        }

        Console.WriteLine("invalid SSN format (should be 123-45-6789)");
        return false;
    }

    public static void Main(string[] args) 
    {
        /*
        15. Validate a Social Security Number (SSN)
        Example Input: "My SSN is 123-45-6789."
        Expected Output:
        * ✅ "123-45-6789" is valid
        * ❌ "123456789" is invalid
        */

        Console.WriteLine("SSN Validator\n");

        while(true)
        {
            Console.Write("Waiting , for user to enter SSN (or empty to exit) : ");
            string input = Console.ReadLine();

            if(string.IsNullOrEmpty(input)) break;

            isValidSSN(input);
        }

        Console.WriteLine("\nPress any key...");
        Console.ReadKey();
    }
}
