using System.Security.Cryptography;

namespace SecureSoftwareExercises.CryptoExercises;

public class DiffieHellmanExample
{
    public static void PerformKeyExchange()
    {
        using var alice = ECDiffieHellman.Create();
        using var bob = ECDiffieHellman.Create();

        var alicePubKey = alice.PublicKey;
        var bobPubKey = bob.PublicKey;

        var aliceKey = alice.DeriveKeyFromHash(bobPubKey, HashAlgorithmName.SHA256, null, null);
        var bobKey = bob.DeriveKeyFromHash(alicePubKey, HashAlgorithmName.SHA256, null, null);

        Console.WriteLine(Convert.ToBase64String(aliceKey) == Convert.ToBase64String(bobKey)
            ? "Alice and Bob have successfully derived the same secret key."
            : "Error: The derived keys are not the same.");
    }
}