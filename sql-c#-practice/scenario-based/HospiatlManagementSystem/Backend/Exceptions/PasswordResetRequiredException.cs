using System;

namespace Exceptions
{
    internal sealed class PasswordResetRequiredException : Exception
    {
        public PasswordResetRequiredException()
            : base("Password reset required. Credentials have been invalidated.")
        {
        }

        public PasswordResetRequiredException(string message)
            : base(message)
        {
        }
    }
}
