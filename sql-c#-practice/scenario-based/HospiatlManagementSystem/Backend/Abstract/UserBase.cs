using Interfaces;

namespace Abstract
{
    internal abstract class UserBase : IAuthenticatable
    {
        protected readonly int RoleId;

        protected UserBase(int roleId)
        {
            RoleId = roleId;
        }

        public abstract Task<bool> LoginAsync(string username, string password);
    }
}
