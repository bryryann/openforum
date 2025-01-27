using System.Text;
using System.Security.Claims;
using System.IdentityModel.Tokens.Jwt;
using Microsoft.IdentityModel.Tokens;
using OpenForumAPI.Legacy.Models;
using OpenForumAPI.Legacy.Interfaces;

namespace OpenForumAPI.Legacy.Services;

public class TokenService : ITokenService
{
    private readonly IConfiguration _config;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config)
    {
        _config = config;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]!));
    }

    public string CreateToken(User user)
    {
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Email, user.Email!),
            new Claim(JwtRegisteredClaimNames.GivenName, user.UserName!),
        };
        var cred = new SigningCredentials(_key, SecurityAlgorithms.HmacSha512Signature);
        var tokenDesc = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(claims),
            Expires = DateTime.Now.AddDays(1),
            SigningCredentials = cred,
            Issuer = _config["JWT:Issuer"],
            Audience = _config["JWT:Audience"],
        };

        var tokenHandler = new JwtSecurityTokenHandler();
        var token = tokenHandler.CreateToken(tokenDesc);

        return tokenHandler.WriteToken(token);
    }
}
