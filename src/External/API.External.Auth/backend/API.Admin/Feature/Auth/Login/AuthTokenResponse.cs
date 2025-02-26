using Common.External.Auth.Net8;

namespace API.External.Auth.Feature.Auth.Login;

public class AuthTokenResponse : BaseResponse
{
    public AuthTokenResponse(string token)
    {
        Token = token;
    }
    public string Token { get; }
}
