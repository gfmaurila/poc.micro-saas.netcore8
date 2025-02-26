using API.Exemple.Core._08.Tests.Integration.Features.Fakes;
using API.Exemple.Core.Tests.Integration;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace API.Exemple.Core._08.Tests.Integration.Utilities.Auth;

public class AuthToken1 : IClassFixture<DatabaseSQLServerFixture>
{
    public string GenerateJwtToken()
    {
        List<string> role = UtilFake.Role();


        SigningCredentials signingCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("cHJqc2xuYmFjay1ndWlsaGVybWVtYXVyaWxh")), "HS256");
        List<Claim> list = new List<Claim>
        {
            new Claim("userName", "auth@auth.com.br"),
            new Claim("id", "9A749D84-5734-4FAA-95C2-CF2B209EBE89")
        };
        foreach (string item in role)
        {
            list.Add(new Claim("http://schemas.microsoft.com/ws/2008/06/identity/claims/role", item.ToString()));
        }

        DateTime? expires = DateTime.Now.AddHours(8.0);
        SigningCredentials signingCredentials2 = signingCredentials;
        JwtSecurityToken token = new JwtSecurityToken("JwtApiAuth", "JwtApiAuth", list, null, expires, signingCredentials2);
        return new JwtSecurityTokenHandler().WriteToken(token);
    }
}
