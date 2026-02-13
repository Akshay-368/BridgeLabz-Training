using System.Text.RegularExpressions;
using System.Globalization;

namespace Utilities;

internal static class InputValidationUtility
{
    // 1. NAME VALIDATION (Only letters and spaces, 2-50 chars)
    public static string ValidateName(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";
            if (Regex.IsMatch(input, @"^[a-zA-Z\s]{2,50}$"))
                return CultureInfo.CurrentCulture.TextInfo.ToTitleCase(input.ToLower());
            
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Name must be 2-50 letters only.");
            Console.ResetColor();
        }
    }

    // 2. EMAIL VALIDATION
    internal static string ValidateEmail(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";
            if (Regex.IsMatch(input, @"^[^@\s]+@[^@\s]+\.[^@\s]+$"))
                return input;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid email format (e.g., name@example.com).");
            Console.ResetColor();
        }
    }

    // 3. PHONE VALIDATION (Simple 10-digit check)
    internal static string ValidatePhone(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim() ?? "";
            // Matches optional +, and 10-15 digits
            if (Regex.IsMatch(input, @"^\+?[0-9]{10,15}$"))
                return input;

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Invalid phone number (10+ digits required).");
            Console.ResetColor();
        }
    }

    // 4. GENDER TRANSLATOR (m/f/o -> Male/Female/Other)
    internal static string ValidateGender()
    {
        while (true)
        {
            Console.Write("Gender (M/F/O or Male/Female/Other): ");
            string input = Console.ReadLine()?.Trim().ToLower() ?? "";

            if (input == "m" || input == "male") return "Male";
            if (input == "f" || input == "female") return "Female";
            if (input == "o" || input == "other") return "Other";

            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Error: Please enter Male, Female, or Other.");
            Console.ResetColor();
        }
    }

    // 5. AGE/DOB VALIDATION (Custom logic for Staff vs Patient)
    internal static DateTime ValidateDOB(bool isStaffMember)
    {
        while (true)
        {
            Console.Write("Date of Birth (YYYY-MM-DD): ");
            if (DateTime.TryParse(Console.ReadLine(), out DateTime dob))
            {
                int age = DateTime.Today.Year - dob.Year;
                if (dob > DateTime.Today.AddYears(-age)) age--;

                if (isStaffMember)
                {
                    if (age >= 18 && age <= 60) return dob;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Staff/Doctors must be between 18 and 60 years old.");
                    Console.ResetColor();
                }
                else
                {
                    if (age >= 0 && age <= 120) return dob;
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Error: Please enter a valid date of birth.");
                    Console.ResetColor();
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Error: Invalid date format. Use YYYY-MM-DD.");
                Console.ResetColor();
            }
        }
    }
}