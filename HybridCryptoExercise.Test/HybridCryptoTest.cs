using System.Security.Cryptography;

namespace HybridCryptoExercise.Test;

[TestFixture]
public class HybridCryptoServiceTests
{
    
    private HybridCryptoService _service;
    private ECDiffieHellman _alice;
    private ECDiffieHellman _bob;
    [OneTimeSetUp]
    public void Setup()
    {
        _service = new HybridCryptoService();
        _alice = ECDiffieHellman.Create();
        _bob = ECDiffieHellman.Create();
    }

    [OneTimeTearDown]
    public void Teardown()
    {
        _alice.Dispose();
        _bob.Dispose();
    }

    [Test]
    public void SharedSecretsShouldMatch()
    {
        var aliceSharedSecret = _service.GenerateSharedSecret(_alice, _bob.PublicKey);
        var bobSharedSecret = _service.GenerateSharedSecret(_bob, _alice.PublicKey);

        Assert.That(Convert.ToBase64String(bobSharedSecret), Is.EqualTo(Convert.ToBase64String(aliceSharedSecret)));
    }

    [Test]
    public void EncryptAndDecryptShouldReturnOriginalMessage()
    {
        const string originalMessage = "Hello, EASV!";
        var aliceSharedSecret = _service.GenerateSharedSecret(_alice, _bob.PublicKey);

        var encryptedMessage = _service.EncryptWithAesGcm(originalMessage, aliceSharedSecret);
        var decryptedMessage = _service.DecryptWithAesGcm(encryptedMessage, aliceSharedSecret);

        Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
    }
}