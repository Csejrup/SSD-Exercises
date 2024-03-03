
using SecureSoftwareExercises.CryptoExercises;

namespace SecureSoftwareExercises.Tests.CryptoExampleTests;

[TestFixture]
public class CRNGExampleTests
{
    [Test]
    public void GenerateRandomNumber_ShouldReturnByteArrayOfSpecifiedLength()
    {
        // Arrange
        const int length = 32; 

        // Act
        var randomNumber = CRNGExample.GenerateRandomNumber(length);

        // Assert
        Assert.That(randomNumber, Has.Length.EqualTo(length));
    }
}