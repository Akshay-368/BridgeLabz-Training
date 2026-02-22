using System;

namespace SmartCitySmartCity.Exceptions
{
    public class InvalidIncomeException : Exception
    {
        public InvalidIncomeException(string message) : base(message)
        {
        }
    }
}
