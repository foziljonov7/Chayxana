using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using Chayxana.BLL.Interfaces.Users;
using Chayxana.Domain.Entities.Users;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;

namespace Chayxana.BLL.Services.Users;

public class AuthService(IConfiguration configuration) : IAuthService
{
    private readonly IConfigurationSection configuration = configuration.GetSection("Jwt");

    public string GenerateToken(User user)
    {
        var claims = new [] 
        {
            new Claim("Id", user.Id.ToString()),
            new Claim(ClaimTypes.Name, user.FirstName + " " + user.LastName),
            new Claim("PhoneNumber", user.PhoneNumber),
            new Claim(ClaimTypes.Role, user.UserRoles.ToString())
        };

        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["SecretKey"]));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256Signature);
        var tokenDestrictor = new JwtSecurityToken(
            configuration["Issuer"], 
            configuration["Audience"],
            claims,
            expires: DateTime.Now.AddMinutes(double.Parse(configuration["Lifetime"])),
            signingCredentials: credentials);

        return new JwtSecurityTokenHandler().WriteToken(tokenDestrictor);
    }
}
