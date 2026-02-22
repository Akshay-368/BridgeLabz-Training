using System.Text.RegularExpressions;

namespace SmartCitySmartCity.Utilities
{
    public static class StringHelper
    {
        public static string FormatName(string name)
        {
            if (string.IsNullOrWhiteSpace(name))
                return string.Empty;

            name = name.Trim();
            return char.ToUpper(name[0]) + name.Substring(1).ToLower();
        }

        public static bool IsValidEmail(string email)
        {
            string pattern = @"^[^@\s]+@[^@\s]+\.[^@\s]+$";
            return Regex.IsMatch(email, pattern);
        }
    }
}
