using System.Security.Cryptography;

namespace SecureSoftwareExercises.CryptoExercises;

public class PBKDF2Example
{
    public static byte[] DeriveKey(string password, byte[] salt, int iterations, int numberOfBytes)
    {
        using var rfc2898DeriveBytes = new Rfc2898DeriveBytes(password, salt, iterations, HashAlgorithmName.SHA256);
        return rfc2898DeriveBytes.GetBytes(numberOfBytes);
    }
}