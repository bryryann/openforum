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
    private readonly IHttpContextAccessor _accessor;
    private readonly SymmetricSecurityKey _key;

    public TokenService(IConfiguration config, IHttpContextAccessor accessor)
    {
        _config = config;
        _accessor = accessor;
        _key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_config["JWT:SigningKey"]!));
    }

    /// <summary>
    /// Parses and hashes the given user claims and credentials to generate a JWT token
    /// </summary>
    /// <param name="user">The user to have its JWT token generated</param>
    /// <returns>The user JWT token</return>
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

    /// <summary>
    /// Retrieves the JWT token from the current request Authorization header
    /// </summary>
    /// <returns>
    /// A JWT token string; otherwise, returns null.
    /// </return>
    public string? GetToken()
    {
        var authorizationHeader = _accessor.HttpContext?.Request.Headers["Authorization"].ToString();
        return authorizationHeader?.Split(" ").LastOrDefault();
    }

    /// <summary>
    /// Parses the JWT token to get the given_name claim value
    /// </summary>
    /// <param name="token">Token string to be parsed</param>
    /// <returns> A string with the given_name claim value </returns>
    public string GetUsernameFromToken(string token)
    {
        var jwtHandler = new JwtSecurityTokenHandler();
        var claims = jwtHandler.ReadJwtToken(token).Claims;

        var usernameClaim = claims.FirstOrDefault(c => c.Type == "given_name" || c.Type == ClaimTypes.GivenName);
        if (usernameClaim == null)
            throw new InvalidOperationException("given_name not found in jwt claim");

        return usernameClaim.Value;
    }
}
