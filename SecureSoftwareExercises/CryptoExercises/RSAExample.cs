using System.Security.Cryptography;
using System.Text;

namespace SecureSoftwareExercises.CryptoExercises;

public abstract class RSAExample
{
    public static bool EncryptAndDecrypt()
    {
        using var rsa = new RSACryptoServiceProvider(2048);
        try
        {
            var plaintext = Encoding.UTF8.GetBytes("Example plain text");
            var ciphertext = rsa.Encrypt(plaintext, false);
            var decrypted = rsa.Decrypt(ciphertext, false);
            return Encoding.UTF8.GetString(decrypted) == "Example plain text";
        }
        finally
        {
            rsa.PersistKeyInCsp = false;
        }
    }
}