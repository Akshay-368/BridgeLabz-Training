using System;

namespace Exceptions
{
    internal sealed class InvalidCredentialsException : Exception
    {
        public InvalidCredentialsException()
            : base("Invalid username or password.")
        {
        }

        public InvalidCredentialsException(string message)
            : base(message)
        {
        }
    }
}
