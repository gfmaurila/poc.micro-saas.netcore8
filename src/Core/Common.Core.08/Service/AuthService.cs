using Common.Core._08.Domain.Model;
using Common.Core._08.Interface;
using Common.Core._08.Model;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Common.Core._08.Service;

/// <summary>
/// Service responsible for generating JWT tokens for authentication and authorization.
/// </summary>
public class AuthService : IAuthService
{
    private readonly IConfiguration _configuration;

    /// <summary>
    /// Initializes a new instance of the <see cref="AuthService"/> class with the specified configuration.
    /// </summary>
    /// <param name="configuration">The application configuration settings.</param>
    public AuthService(IConfiguration configuration)
    {
        _configuration = configuration;
    }

    /// <summary>
    /// Generates a JWT token for a user with the specified ID, email, and roles.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <param name="email">The user's email address.</param>
    /// <param name="role">A list of roles associated with the user.</param>
    /// <returns>A JWT token as a string.</returns>
    public string GenerateJwtToken(string id, string email, List<string> role)
    {
        var issuer = _configuration.GetValue<string>(ConfigConsts.Issuer);
        var audience = _configuration.GetValue<string>(ConfigConsts.Audience);
        var key = _configuration.GetValue<string>(ConfigConsts.Key);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new Claim("userName", email),
            new Claim("id", id),
        };
        foreach (var userRole in role)
        {
            claims.Add(new Claim(ClaimTypes.Role, userRole));
        }
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddHours(8),
            signingCredentials: credentials,
            claims: claims);
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }

    /// <summary>
    /// Generates a JWT token for a user with the specified ID and email, assigning a default admin role.
    /// </summary>
    /// <param name="id">The user's unique identifier.</param>
    /// <param name="email">The user's email address.</param>
    /// <returns>A JWT token as a string.</returns>
    public string GenerateJwtToken(string id, string email)
    {
        var issuer = _configuration.GetValue<string>(ConfigConsts.Issuer);
        var audience = _configuration.GetValue<string>(ConfigConsts.Audience);
        var key = _configuration.GetValue<string>(ConfigConsts.Key);
        var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(key));
        var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
        var claims = new List<Claim>
        {
            new Claim("userName", email),
            new Claim("id", id),
            new Claim(ClaimTypes.Role, RoleConstants.ADMIN_AUTH)
        };
        var token = new JwtSecurityToken(
            issuer: issuer,
            audience: audience,
            expires: DateTime.Now.AddHours(2),
            signingCredentials: credentials,
            claims: claims);
        var tokenHandler = new JwtSecurityTokenHandler();
        return tokenHandler.WriteToken(token);
    }
}
