
using SecureSoftwareExercises.CryptoExercises;

namespace SecureSoftwareExercises.Tests.CryptoExampleTests;

[TestFixture]
public class AesExampleTests
{
    [Test]
    public void EncryptAndDecrypt_ShouldReturnOriginalMessage()
    {
        // Arrange
        var originalMessage = "Hello, World!";
        var aesExample = new AesExample(); 

        // Act
        var (encryptedMessage, decryptedMessage) = aesExample.EncryptAndDecrypt(originalMessage);
        
        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(encryptedMessage, Is.Not.EqualTo(originalMessage));
            Assert.That(decryptedMessage, Is.EqualTo(originalMessage));
        });
    }
}