using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace Services.BAL.Configuration;

public class AuthOptions
{
    public const string Issuer = "ServicesApi";          // издатель токена
    public const string Audience = "Frontovik";         // потребитель токена
    private const string Key = "Servicesqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqqq"; // ключ для шифрации
    public static SymmetricSecurityKey GetSymmetricSecurityKey() => new(Encoding.UTF8.GetBytes(Key));
}