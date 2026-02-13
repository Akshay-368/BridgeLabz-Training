using System;
using System.Security.Cryptography;
using System.Text;

namespace Core
{
    internal static class PasswordHasher
    {
        internal static byte[] GenerateSalt()
        {
            byte[] salt = new byte[32];
            using (var rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(salt);
            }
            return salt;
        }

        internal static byte[] HashPassword(string password, byte[] salt)
        {
            using (var sha = SHA256.Create())
            {
                byte[] combined = Encoding.UTF8.GetBytes(password);
                byte[] salted = new byte[combined.Length + salt.Length];

                Buffer.BlockCopy(salt, 0, salted, 0, salt.Length);
                Buffer.BlockCopy(combined, 0, salted, salt.Length, combined.Length);

                return sha.ComputeHash(salted);
            }
        }

        internal static (byte[] Hash, byte[] Salt) HashNewPassword(string password)
        {
            byte[] salt = RandomNumberGenerator.GetBytes(32); // Generate fresh salt
            byte[] hash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                salt,
                iterations: 100000,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: 32);
            
            return (hash, salt);
        }

        internal static bool VerifyPassword(string password, byte[] storedHash, byte[] storedSalt)
        {
            // MUST use the exact same algorithm as HashNewPassword
            byte[] computedHash = Rfc2898DeriveBytes.Pbkdf2(
                Encoding.UTF8.GetBytes(password),
                storedSalt,
                iterations: 100000,
                hashAlgorithm: HashAlgorithmName.SHA256,
                outputLength: 32);

            
            // Cryptographic comparison to prevent timing attacks
            return CryptographicOperations.FixedTimeEquals(computedHash, storedHash);
        }
    }
}
