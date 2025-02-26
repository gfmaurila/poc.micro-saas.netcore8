using API.External.MKT.Database.Model;
using Microsoft.AspNetCore.Identity;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.External.MKT.Database;

// JwtTokenService and Interface
public interface IJwtTokenService
{
    string GenerateJwtToken(ApplicationUser user);
}

public class JwtTokenService : IJwtTokenService
{
    private readonly IConfiguration _configuration;
    private readonly UserManager<ApplicationUser> _userManager;

    public JwtTokenService(IConfiguration configuration, UserManager<ApplicationUser> userManager)
    {
        _configuration = configuration;
        _userManager = userManager;
    }

    public string GenerateJwtToken(ApplicationUser user)
    {
        // Obter as roles do usuário
        var roles = _userManager.GetRolesAsync(user).Result;

        // Criar as claims
        var claims = new List<Claim>
        {
            new Claim(JwtRegisteredClaimNames.Sub, user.UserName), // Nome de usuário
            new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()), // Identificador único do token
            new Claim(ClaimTypes.NameIdentifier, user.Id), // ID do usuário
            new Claim("username", user.UserName), // Nome de usuário adicional
        };

        // Adicionar as roles como claims
        foreach (var role in roles)
        {
            claims.Add(new Claim(ClaimTypes.Role, role));
        }

        // Gerar a chave para assinar o token
        var key = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["Jwt:Key"]));
        var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

        // Tempo de expiração do token
        var expirationTimeInSeconds = int.Parse(_configuration["Jwt:TIMEOUT"]);

        // Criar o token
        var token = new JwtSecurityToken(
            issuer: _configuration["Jwt:Issuer"],
            audience: _configuration["Jwt:Audience"],
            claims: claims,
            expires: DateTime.Now.AddSeconds(expirationTimeInSeconds),
            signingCredentials: creds
        );

        // Retornar o token gerado
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}


