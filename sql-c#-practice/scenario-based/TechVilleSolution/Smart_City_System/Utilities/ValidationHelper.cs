using System;
using SmartCitySmartCity.Exceptions;

namespace SmartCitySmartCity.Utilities
{
    public static class ValidationHelper
    {
        public static void ValidateAge(int age)
        {
            if (age < 18)
                throw new UnderageException("Citizen must be at least 18 years old.");
        }

        public static void ValidateIncome(double income)
        {
            if (income < 0)
                throw new InvalidIncomeException("Income cannot be negative.");
        }


        public static int ReadInt(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (int.TryParse(Console.ReadLine(), out int value))
                    return value;

                Console.WriteLine("Invalid number. Try again.");
            }
        }

        public static double ReadDouble(string message)
        {
            while (true)
            {
                Console.Write(message);
                if (double.TryParse(Console.ReadLine(), out double value))
                    return value;

                Console.WriteLine("Invalid number. Try again.");
            }
        }
    }
}
