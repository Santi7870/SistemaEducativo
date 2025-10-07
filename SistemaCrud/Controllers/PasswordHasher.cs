using System.Security.Cryptography;
using System.Text;

namespace SistemaCrud.Security
{
    public static class PasswordHasher
    {
        public static (string hash, string salt) CrearHash(string password)
        {
            byte[] saltBytes = RandomNumberGenerator.GetBytes(16);
            string saltB64 = Convert.ToBase64String(saltBytes);

            using var sha = SHA256.Create();
            string hashB64 = Convert.ToBase64String(
                sha.ComputeHash(Encoding.UTF8.GetBytes(saltB64 + password))
            );

            return (hashB64, saltB64);
        }

        public static bool Verificar(string password, string saltB64, string hashB64)
        {
            using var sha = SHA256.Create();
            string calc = Convert.ToBase64String(
                sha.ComputeHash(Encoding.UTF8.GetBytes(saltB64 + password))
            );
            return hashB64 == calc;
        }
    }
}

