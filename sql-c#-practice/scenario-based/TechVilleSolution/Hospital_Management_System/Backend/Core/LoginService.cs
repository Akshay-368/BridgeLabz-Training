using System;
using System.IO;
using System.Threading.Tasks;
using Utilities;
using Core;
using Exceptions;

namespace Services
{
    internal sealed class LoginService
    {
        private readonly UserQueryUtility _queryUtility;

        public LoginService(UserQueryUtility utility)
        {
            _queryUtility = utility;
        }

        internal async Task LoginAsync(
            string username,
            string password,
            int roleId)
        {
            var (hash, salt, userId) =
                await _queryUtility.GetUserCredentialsAsync(username, roleId);

            byte[] computed =
                PasswordHasher.HashPassword(password, salt);

            if (!CryptographicEquals(hash, computed))
            {
                ForcePasswordReset(username);
                throw new PasswordResetRequiredException();
            }

            // Set SESSION_CONTEXT safely
            await SecurityContext.SetUserContextAsync(userId);
        }

        private bool CryptographicEquals(byte[] a, byte[] b)
        {
            if (a.Length != b.Length) return false;
            int diff = 0;
            for (int i = 0; i < a.Length; i++)
                diff |= a[i] ^ b[i];
            return diff == 0;
        }

        private void ForcePasswordReset(string username)
        {
            string path = @"C:\Temp\SecurityResets";
            Directory.CreateDirectory(path);

            File.WriteAllText(
                Path.Combine(path, $"{username}_reset.txt"),
                $"Password reset triggered at {DateTime.UtcNow}"
            );
        }
    }
}
