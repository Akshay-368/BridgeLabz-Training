using System;

namespace SmartCitySmartCity.Exceptions
{
    public class UnderageException : Exception
    {
        public UnderageException(string message) : base(message)
        {
        }
    }
}
