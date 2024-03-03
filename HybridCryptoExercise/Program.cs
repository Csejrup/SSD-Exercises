using System;
using System.Security.Cryptography;

namespace HybridCryptoExercise;

public static class HybridCryptoExample
{
    public static void Main()
    {
        var service = new HybridCryptoService(); // Instantiate the service

        // Simulate key exchange using ECDiffieHellman
        using var alice = ECDiffieHellman.Create();
        using var bob = ECDiffieHellman.Create();

        // Derive shared secrets using the service
        var aliceSharedSecret = service.GenerateSharedSecret(alice, bob.PublicKey);
        var bobSharedSecret = service.GenerateSharedSecret(bob, alice.PublicKey);

        // Validate shared secrets match
        Console.WriteLine($"Alice's shared secret: {Convert.ToBase64String(aliceSharedSecret)}");
        Console.WriteLine($"Bob's shared secret: {Convert.ToBase64String(bobSharedSecret)}");
        var secretsMatch = Convert.ToBase64String(aliceSharedSecret) == Convert.ToBase64String(bobSharedSecret);
        Console.WriteLine($"Shared secrets match: {secretsMatch}");

        // Simulate message exchange using AES-GCM
        const string originalMessage = "Hello, Hybrid Cryptography World!";
        var encryptedMessage = service.EncryptWithAesGcm(originalMessage, aliceSharedSecret); // Alice encrypts a message with the shared secret
        var decryptedMessage = service.DecryptWithAesGcm(encryptedMessage, bobSharedSecret); // Bob decrypts the message with the shared secret

        Console.WriteLine($"Original: {originalMessage}");
        Console.WriteLine($"Encrypted: {BitConverter.ToString(encryptedMessage)}");
        Console.WriteLine($"Decrypted: {decryptedMessage}");
    }
}