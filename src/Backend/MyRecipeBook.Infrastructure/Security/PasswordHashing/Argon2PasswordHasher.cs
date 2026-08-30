using System;
using System.Collections.Generic;
using System.Security.Cryptography;
using System.Text;
using Konscious.Security.Cryptography;
using MyRecipeBook.Domain.Security.PasswordHashing;


namespace MyRecipeBook.Infrastructure.Security.PasswordHashing
{
    internal class Argon2PasswordHasher : IPasswordHashing
    {
        private const int DEGREE_OF_PARALLELISM = 1; 
        private const int ITERATIONS = 2;
        private const int MEMORY_SIZE = 20 * 1024; 
        private const int SALT_SIZE = 16;
        private const int HASH_SIZE = 32;



        public string HashPassword(string password)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var salt = RandomNumberGenerator.GetBytes(SALT_SIZE);
           
            var hash = HashPassword(password, salt);
            var combinedBytes = new byte[SALT_SIZE + HASH_SIZE];

            salt.CopyTo(combinedBytes);
            hash.CopyTo(combinedBytes, SALT_SIZE);

            return Convert.ToBase64String(combinedBytes);

        }

        public bool VerifyPassword(string password, string hashedPassword)
        {
            var combinedBytes = Convert.FromBase64String(hashedPassword);
            var salt = new byte[SALT_SIZE];
            var hash = new byte[HASH_SIZE];

            Array.Copy(combinedBytes, salt, SALT_SIZE);
            Array.Copy(combinedBytes, SALT_SIZE, hash, 0, HASH_SIZE);

            var passwordHash = HashPassword(password, salt);

            return CryptographicOperations.FixedTimeEquals(hash, passwordHash);
        }

        private byte[] HashPassword(string password, byte[] salt)
        {
            var passwordBytes = Encoding.UTF8.GetBytes(password);
            var hashAlgoritm = new Argon2id(passwordBytes)
            {
                DegreeOfParallelism = DEGREE_OF_PARALLELISM,
                Iterations = ITERATIONS,
                MemorySize = MEMORY_SIZE,
                Salt = salt
            };
            return hashAlgoritm.GetBytes(HASH_SIZE);
        }
    }
}
