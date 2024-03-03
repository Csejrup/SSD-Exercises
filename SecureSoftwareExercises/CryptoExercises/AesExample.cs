using System.Security.Cryptography;

namespace SecureSoftwareExercises.CryptoExercises;

public class AesExample
{
    public (string encrypted, string decrypted) EncryptAndDecrypt(string original)
    {
        using var aesAlg = Aes.Create();
        aesAlg.KeySize = 256;
        aesAlg.BlockSize = 128;
        aesAlg.GenerateIV();
        aesAlg.GenerateKey();

        string encryptedText;
        string decryptedText;

        // Encryption
        var encryptor = aesAlg.CreateEncryptor(aesAlg.Key, aesAlg.IV);
        using (var msEncrypt = new MemoryStream())
        {
            using (var csEncrypt = new CryptoStream(msEncrypt, encryptor, CryptoStreamMode.Write))
            {
                using (var swEncrypt = new StreamWriter(csEncrypt))
                {
                    swEncrypt.Write(original);
                }
            }
        
            var encryptedBytes = msEncrypt.ToArray();
            encryptedText = Convert.ToBase64String(encryptedBytes);
        }

        // Decryption
        var decryptor = aesAlg.CreateDecryptor(aesAlg.Key, aesAlg.IV);
        using (var msDecrypt = new MemoryStream(Convert.FromBase64String(encryptedText))) 
        {
            using (var csDecrypt = new CryptoStream(msDecrypt, decryptor, CryptoStreamMode.Read))
            {
                using (var srDecrypt = new StreamReader(csDecrypt))
                {
                    decryptedText = srDecrypt.ReadToEnd();
                }
            }
        }

        return (encryptedText, decryptedText);
    }
}