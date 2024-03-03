using System.Security.Cryptography;

namespace SecureSoftwareExercises.CryptoExercises;

public class CRNGExample
{
    public static byte[] GenerateRandomNumber(int length)
    {
        using var randomNumberGenerator = new RNGCryptoServiceProvider();
        var randomNumber = new byte[length];
        randomNumberGenerator.GetBytes(randomNumber);
        return randomNumber;
    }
}