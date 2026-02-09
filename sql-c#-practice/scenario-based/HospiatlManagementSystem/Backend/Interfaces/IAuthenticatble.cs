namespace Interfaces
{
    internal interface IAuthenticatable
    {
        Task<bool> LoginAsync(string username, string password);
    }
}
