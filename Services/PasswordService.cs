using System.Security.Cryptography;

namespace Services;



public interface IPasswordService
{
    string Hash(string password);

    bool Verify(string password, string inputPassword);
}

public class PasswordService:IPasswordService
{
    
    
    private const int saltSize = 128 / 8;
    private const int keySize = 256 / 8;
    private const int Iterations = 10000;
    private static readonly HashAlgorithmName _hashAlgorithm  = HashAlgorithmName.SHA256;
    private const char Delimiter = ';';
    
    public string Hash( string password)
    {
        var salt = RandomNumberGenerator.GetBytes(saltSize);
        var hash = Rfc2898DeriveBytes.Pbkdf2(password, salt, Iterations, _hashAlgorithm, keySize);

        return string.Join(Delimiter, Convert.ToBase64String(salt), Convert.ToBase64String(hash));
    }
    
    public bool Verify( string passwordHash , string inputPassword)
    {
        var elements = passwordHash.Split(Delimiter);
        var salt = Convert.FromBase64String(elements[0]);
        var hash = Convert.FromBase64String(elements[1]);
        
        var hashInput = Rfc2898DeriveBytes.Pbkdf2(inputPassword, salt, Iterations, _hashAlgorithm, keySize);

        return CryptographicOperations.FixedTimeEquals(hash, hashInput);
    }
}