namespace SecureSoftwareExercises.CryptoExercises;

internal abstract class Program
{
    private static void Main()
    {

        // AES EXAMPLE
        Console.WriteLine("------AES EXAMPLE-------------");

        var aesExample = new AesExample();
        const string originalText = "Hello, world!";
        var (encrypted, decrypted) = aesExample.EncryptAndDecrypt(originalText);

        Console.WriteLine($"Original: {originalText}");
        Console.WriteLine($"Encrypted (Base64): {encrypted}");
        Console.WriteLine($"Decrypted: {decrypted}");

        // CRNG EXAMPLE
        Console.WriteLine("------CRNG EXAMPLE-------------");

        const int length = 32; // 256 bits
        var randomNumber = CRNGExample.GenerateRandomNumber(length);
        string hexString = BitConverter.ToString(randomNumber).Replace("-", "").ToLower();

        Console.WriteLine("Generated 256-bit cryptographic random number:");
        Console.WriteLine(hexString);

        // DIFFIEHELLMAN EXAMPLE
        Console.WriteLine("------DIFFIE HELLMAN EXAMPLE-------------");

        DiffieHellmanExample.PerformKeyExchange();
        
        
        // HASHING EXAMPLE
        Console.WriteLine("------HASHING EXAMPLE-------------");

        const string inputString = "Hello, world!";
        var hashedData = HashingExample.GenerateSHA512Hash(inputString);
        Console.WriteLine($"Original Data: {inputString}");
        Console.WriteLine($"SHA512 Hash: {hashedData}");
        
        // PBKDF2 EXAMPLE
        Console.WriteLine("------PBKDF2 EXAMPLE-------------");

        var password = "p@ssw0rd";
        var salt = CRNGExample.GenerateRandomNumber(16);
        var iterations = 10000;
        var numberOfBytes = 32; 
        var derivedKey = PBKDF2Example.DeriveKey(password, salt, iterations, numberOfBytes);
        var derivedKeyHexString = BitConverter.ToString(derivedKey).Replace("-", "").ToLower();
        Console.WriteLine($"Derived key (hex): {derivedKeyHexString}");
        
        
        // RSA EXAMPLE
        Console.WriteLine("------RSA EXAMPLE-------------");

        var rsaSuccess = RSAExample.EncryptAndDecrypt();
        Console.WriteLine($"RSA Encryption and Decryption Successful: {rsaSuccess}");
    }
}