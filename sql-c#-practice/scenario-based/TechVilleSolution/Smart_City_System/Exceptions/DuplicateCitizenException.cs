using System;

namespace SmartCitySmartCity.Exceptions
{
    public class DuplicateCitizenException : Exception
    {
        public DuplicateCitizenException(string message) : base(message)
        {
        }
    }
}
