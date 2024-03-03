
using SecureSoftwareExercises.CryptoExercises;

namespace SecureSoftwareExercises.Tests.CryptoExampleTests;

[TestFixture]
public class PBKDF2ExampleTests
{
    [Test]
    public void DeriveKey_ShouldReturnCorrectLength()
    {
        // Arrange
        const string password = "testPassword";
        var salt = new byte[16];
        const int iterations = 10000;
        const int expectedLength = 32; 

        // Act
        var derivedKey = PBKDF2Example.DeriveKey(password, salt, iterations, expectedLength);

        // Assert
        Assert.That(derivedKey,Is.Not.Empty);
        Assert.That(derivedKey, Has.Length.EqualTo(expectedLength));
    }

    [Test]
    public void DeriveKey_ShouldProduceDifferentKeysForDifferentSalts()
    {
        // Arrange
        var password = "testPassword";
        var salt1 = new byte[16]; 
        var salt2 = new byte[16]; 
        salt2[0] = 1; 
        const int iterations = 10000;
        const int  keyLength = 32;

        // Act
        byte[] derivedKey1 = PBKDF2Example.DeriveKey(password, salt1, iterations, keyLength);
        byte[] derivedKey2 = PBKDF2Example.DeriveKey(password, salt2, iterations, keyLength);

        // Assert
        Assert.Multiple(() =>
        {
            Assert.That(derivedKey1, Is.Not.Empty);
            Assert.That(derivedKey2, Is.Not.Empty);
            Assert.That(IsEqual(derivedKey1, derivedKey2), Is.False);
        });
    }

    private static bool IsEqual(IReadOnlyList<byte> array1, IReadOnlyList<byte> array2)
    {
        if (array1.Count != array2.Count)
            return false;

        return !array1.Where((t, i) => t != array2[i]).Any();
    }
}