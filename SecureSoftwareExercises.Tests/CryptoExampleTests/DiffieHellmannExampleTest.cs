
using System.Security.Cryptography;

namespace SecureSoftwareExercises.Tests.CryptoExampleTests;

[TestFixture]
public class DiffieHellmanExampleTests
{
    [Test]
    public void PerformKeyExchange_ShouldGenerateSameSecretsForBothParties()
    {
        // Arrange
        using var alice = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);
        using var bob = ECDiffieHellman.Create(ECCurve.NamedCurves.nistP256);

        var alicePublicKey = alice.PublicKey;
        var bobPublicKey = bob.PublicKey;

        var aliceSecret = alice.DeriveKeyFromHash(bobPublicKey, HashAlgorithmName.SHA256, null, null);
        var bobSecret = bob.DeriveKeyFromHash(alicePublicKey, HashAlgorithmName.SHA256, null, null);

        // Assert
        Assert.That(bobSecret, Is.EqualTo(aliceSecret), "The shared secrets should be the same for both parties.");
    }
}