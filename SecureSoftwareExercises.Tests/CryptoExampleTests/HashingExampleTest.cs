
using SecureSoftwareExercises.CryptoExercises;

namespace SecureSoftwareExercises.Tests.CryptoExampleTests;

[TestFixture]
public class HashingExampleTests
{
    [Test]
    public void GenerateSHA512Hash_ShouldReturnHexString()
    {
        // Arrange
        string input = "Hello, World!";

        // Act
        string hash = HashingExample.GenerateSHA512Hash(input);

        // Assert
        Assert.That(hash, Is.Not.Empty);
        Assert.That(hash.Length, Is.EqualTo(128)); 
    }
}