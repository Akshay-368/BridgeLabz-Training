using System;

namespace Exceptions
{
    internal sealed class RoleNotAllowedException : Exception
    {
        public RoleNotAllowedException()
            : base("The selected role is not allowed to access this system.")
        {
        }

        public RoleNotAllowedException(string message)
            : base(message)
        {
        }
    }
}
