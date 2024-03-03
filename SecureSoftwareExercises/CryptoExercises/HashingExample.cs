using System.Security.Cryptography;
using System.Text;

namespace SecureSoftwareExercises.CryptoExercises;

public abstract class HashingExample
{
    public static string GenerateSHA512Hash(string input)
    {
        using var sha512Hash = SHA512.Create();
        var bytes = sha512Hash.ComputeHash(Encoding.UTF8.GetBytes(input));

        var builder = new StringBuilder();
        foreach (var t in bytes)
        {
            builder.Append(t.ToString("x2"));
        }
        return builder.ToString();
    }
}