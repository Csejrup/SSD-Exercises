using System.Security.Cryptography;

namespace HybridCryptoExercise;

public class HybridCryptoService
{
    public byte[] GenerateSharedSecret(ECDiffieHellman sender, ECDiffieHellmanPublicKey receiverPublicKey)
    {
        return sender.DeriveKeyMaterial(receiverPublicKey);
    }

    public byte[] EncryptWithAesGcm(string plaintext, byte[] key)
    {
        byte[] nonce = new byte[AesGcm.NonceByteSizes.MaxSize]; 
        byte[] tag = new byte[16]; 
        byte[] plaintextBytes = System.Text.Encoding.UTF8.GetBytes(plaintext);
        byte[] encrypted = new byte[plaintextBytes.Length];

        using (var rng = RandomNumberGenerator.Create())
        {
            rng.GetBytes(nonce);
        }

        using (var cipher = new AesGcm(key))
        {
            cipher.Encrypt(nonce, plaintextBytes, encrypted, tag);
        }

        byte[] combined = new byte[nonce.Length + encrypted.Length + tag.Length];
        Buffer.BlockCopy(nonce, 0, combined, 0, nonce.Length);
        Buffer.BlockCopy(encrypted, 0, combined, nonce.Length, encrypted.Length);
        Buffer.BlockCopy(tag, 0, combined, nonce.Length + encrypted.Length, tag.Length);

        return combined;
    }

    public string DecryptWithAesGcm(byte[] combined, byte[] key)
    {
        byte[] nonce = new byte[AesGcm.NonceByteSizes.MaxSize];
        byte[] tag = new byte[16];
        byte[] ciphertext = new byte[combined.Length - nonce.Length - tag.Length];

        Buffer.BlockCopy(combined, 0, nonce, 0, nonce.Length);
        Buffer.BlockCopy(combined, nonce.Length, ciphertext, 0, ciphertext.Length);
        Buffer.BlockCopy(combined, nonce.Length + ciphertext.Length, tag, 0, tag.Length);

        byte[] decrypted = new byte[ciphertext.Length];

        using (var cipher = new AesGcm(key))
        {
            cipher.Decrypt(nonce, ciphertext, tag, decrypted);
        }

        return System.Text.Encoding.UTF8.GetString(decrypted);
    }
}