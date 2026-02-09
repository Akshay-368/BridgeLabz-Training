using System;

namespace Exceptions
{
    internal sealed class SessionContextMissingException : Exception
    {
        public SessionContextMissingException()
            : base("Security session context is missing or was not initialized.")
        {
        }

        public SessionContextMissingException(string message)
            : base(message)
        {
        }
    }
}
