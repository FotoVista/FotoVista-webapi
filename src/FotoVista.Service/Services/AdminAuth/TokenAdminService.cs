using FotoVista.Domain.Entity;
using FotoVista.Service.Helpers;
using FotoVista.Service.Interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace FotoVista.Service.Services;

public class TokenAdminService : ITokenAdminService
{
    private readonly IConfigurationSection _config;

    public TokenAdminService(IConfiguration configuration)
    {
        _config = configuration.GetSection("Jwt");
    }

    public string GenerateAdminToken(UserEntity admin)
    {
        var identityClaims = new Claim[]
       {
            new Claim("Id", admin.Id.ToString()),
            new Claim("FirstName", admin.FirstName),
            new Claim("LastName", admin.LastName),
            new Claim(ClaimTypes.Email, admin.Email),
            new Claim(ClaimTypes.Role, "Admin")
       };

        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["SecurityKey"]!));
        var keyCredentials = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);
        int expiresHours = int.Parse(_config["Lifetime"]!);
        var token = new JwtSecurityToken(
            issuer: _config["Issuer"],
            audience: _config["Audience"],
            claims: identityClaims,
            expires: TimeHelper.GetDateTime().AddHours(expiresHours),
            signingCredentials: keyCredentials);

        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
