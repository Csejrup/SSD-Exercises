
using SecureSoftwareExercises.CryptoExercises;

namespace SecureSoftwareExercises.Tests.CryptoExampleTests;

[TestFixture]
public class CRNGExampleTests
{
    [Test]
    public void GenerateRandomNumber_ShouldReturnByteArrayOfSpecifiedLength()
    {
        // Arrange
        int length = 32; // 256 bits

        // Act
        byte[] randomNumber = CRNGExample.GenerateRandomNumber(length);

        // Assert
        Assert.That(randomNumber, Has.Length.EqualTo(length));
    }
}