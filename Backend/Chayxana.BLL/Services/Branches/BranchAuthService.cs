using Chayxana.BLL.Interfaces.Branches;
using Chayxana.Domain.Entities.Branches;
using Microsoft.EntityFrameworkCore.Diagnostics;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Chayxana.BLL.Services.Branches;

public class BranchAuthService(IConfiguration configuration) : IBranchAuthService
{
    private readonly IConfiguration _configuration = configuration.GetSection("Jwt");
    public string GetGenerateToken(Branch branch)
    {
        var claims = new[]
        {
            new Claim("Id", branch.Id.ToString()),
            new Claim(ClaimTypes.Name, branch.Name),
            new Claim("PhoneNumber", branch.PhoneNumber),
            new Claim(ClaimTypes.Role, branch.Type.ToString())
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
