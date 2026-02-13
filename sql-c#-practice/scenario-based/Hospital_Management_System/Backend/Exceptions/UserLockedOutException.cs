using System;

namespace Exceptions
{
    internal sealed class UserLockedOutException : Exception
    {
        public UserLockedOutException()
            : base("User account is locked due to multiple failed login attempts.")
        {
        }

        public UserLockedOutException(string message)
            : base(message)
        {
        }
    }
}
