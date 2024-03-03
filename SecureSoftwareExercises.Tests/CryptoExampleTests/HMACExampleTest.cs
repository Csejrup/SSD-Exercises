
using SecureSoftwareExercises.CryptoExercises;

namespace SecureSoftwareExercises.Tests.CryptoExampleTests;

[TestFixture]
public class HMACExampleTests
{
    [Test]
    public void GenerateHMACSHA256_ShouldReturnByteArray()
    {
        // Arrange
        const string message = "Hello, World!";
        var key = CRNGExample.GenerateRandomNumber(32); 

        // Act
        var hmac = HMACExample.GenerateHMACSHA256(message, key);

        // Assert
        Assert.That(hmac, Is.Not.Null);
        Assert.That(hmac, Has.Length.EqualTo(32)); 
    }
}