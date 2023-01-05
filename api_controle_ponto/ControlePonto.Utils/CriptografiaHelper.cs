using Microsoft.AspNetCore.Cryptography.KeyDerivation;

namespace ControlePonto.Helpers
{
    public static class CriptografiaHelper
    {
        public static string Criptografar(string texto)
        {
            byte[] salt = new byte[128 / 8];
            return Convert.ToBase64String(KeyDerivation.Pbkdf2(texto!, salt, KeyDerivationPrf.HMACSHA256, 100000, 256 / 8));
        }
    }
}
