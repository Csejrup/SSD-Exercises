using System.Security.Cryptography;
using System.Text;

namespace SecureSoftwareExercises.CryptoExercises;

public class HMACExample
{
    public static byte[] GenerateHMACSHA256(string message, byte[] key)
    {
        using var hmacsha256 = new HMACSHA256(key);
        return hmacsha256.ComputeHash(Encoding.UTF8.GetBytes(message));
    }
}