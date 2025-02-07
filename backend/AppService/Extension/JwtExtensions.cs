using BCrypt.Net;

namespace AppService.Extension;

public static class JwtExtensions
{
    private const int WorkFactor = 12; 
    public static string HashPassword(string password)
    {
        return BCrypt.Net.BCrypt.HashPassword(password, WorkFactor);
    }

    public static bool VerifyPassword(string password, string hashedPassword)
    {
        try
        {
            return BCrypt.Net.BCrypt.Verify(password, hashedPassword);
        }
        catch (SaltParseException) 
        {
            return false;
        }
    }
}
