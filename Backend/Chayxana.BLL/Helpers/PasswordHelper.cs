namespace Chayxana.BLL.Helpers;

public class PasswordHelper
{
    public const string Key = "6c9e6964-7425-40de-941c-e07fc1f91be3";
    public static(string hash, string salt) Hash(string password)
    {
        string salt = GenerateSalt();
        string hash = BCrypt.Net.BCrypt.HashPassword(salt + password + Key);
        return (hash: hash, salt: salt);
    }

    public static bool Verify(string password, string hash, string salt)
        => BCrypt.Net.BCrypt.Verify(salt + password + Key, hash);

    public static string GenerateSalt()
        => Guid.NewGuid().ToString();
}