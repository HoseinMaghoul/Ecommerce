using System.Security.Cryptography;
using System.Text;

namespace Infrastrucutre.Shared.HashAndEncryption;
public class HashFunctions
{
    public static string HashPassword(string password)
    {
        using SHA256 sha256Hash = SHA256.Create();
        byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(password));
        StringBuilder builder = new StringBuilder();
        for (int i = 0; i < bytes.Length; i++)
        {
            builder.Append(bytes[i].ToString("x2"));
        }
        return builder.ToString();
    }
    public static bool VerifyPassword(string enteredPassword, string hashPassword)
    {
        string hashedInputPassword = HashPassword(enteredPassword);
        return hashedInputPassword.Equals(hashPassword);
    }
}