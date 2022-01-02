using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using System;
using System.Security.Cryptography;

namespace KarpaticaTravelAPI.Infrastructure
{
    public static class HashManager
    {

        private static string CreateKey(string password, byte[] salt)
        {
            string hashed = Convert.ToBase64String(KeyDerivation.Pbkdf2(
               password: password,
               salt: salt,
               prf: KeyDerivationPrf.HMACSHA256,
               iterationCount: 100000,
               numBytesRequested: 256 / 8));

            return hashed;
        }

        public static (string, string) GenerateHashSetKeys(string argument)
        {
            byte[] salt = new byte[128 / 8];
            using (var rngCsp = new RNGCryptoServiceProvider())
            {
                rngCsp.GetNonZeroBytes(salt);
            }

            string hashed = CreateKey(argument, salt);

            return (hashed, Convert.ToBase64String(salt));
        }

        public static bool IsPasswordCorrect(string inputPassword, string password, string salt)
        {
            byte[] saltBytes = Convert.FromBase64String(salt);

            string hashed = CreateKey(inputPassword, saltBytes);

            return hashed.Equals(password);

        }

    }
}