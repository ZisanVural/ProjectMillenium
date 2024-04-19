using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Security.Cryptography;
using Konscious.Security.Cryptography;


namespace ProjectMillenium.Core.Helpers
{
    public class PasswordHasher : IPasswordHasher
    {
        private const int saltSize = 16; // Örnek bir salt boyutu, isteğe bağlı olarak değiştirilebilir
        private const int hashSize = 32; // Örnek bir hash boyutu, isteğe bağlı olarak değiştirilebilir
        private const int degreeOfParallelism = 8; // Argon2id parametreleri
        private const int memorySize = 65536; // Argon2id parametreleri
        private const int iterations = 4; // Argon2id parametreleri

        public string HashPassword(string password, out byte[] salt)
        {
            using (var rng = new System.Security.Cryptography.RNGCryptoServiceProvider())
            {
                salt = new byte[saltSize];
                rng.GetBytes(salt);
            }

            var hasher = new Argon2id(Encoding.UTF8.GetBytes(password))
            {
                Salt = salt,
                DegreeOfParallelism = degreeOfParallelism,
                MemorySize = memorySize,
                Iterations = iterations
            };

            byte[] hashValue = hasher.GetBytes(hashSize);

            return Convert.ToHexString(hashValue);
        }
    }

}


