using API.External.Auth.Feature.Auth.ResetPassword;
using API.External.Auth.Tests.Integration.Features.Fakes;
using API.External.Auth.Tests.Integration.Utilities;
using Common.External.Auth.Net8.Response;
using System.Net;
using System.Net.Http.Json;

namespace API.External.Auth.Tests.Integration.Features.Auth;

public class AuthNewPasswordTests : IClassFixture<DatabaseSQLServerFixture>
{
    private readonly HttpClient _client;
    private readonly DatabaseSQLServerFixture _fixture;

    public AuthNewPasswordTests(DatabaseSQLServerFixture fixture)
    {
        _fixture = fixture;
        _client = fixture.Client;
    }

    [Fact]
    public async Task ShouldUser()
    {
        // Arrange
        var command = AuthFake.AuthNewPasswordPostCommand();

        await UserFake.CreateUserAuth(_fixture, UserFake.CreateUser(command.Email, "1Test123$"));

        var httpResponse = await _client.PostAsJsonAsync("/api/v1/resetpassword", command);
        httpResponse.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        var jsonResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResult<AuthResetPasswordResponse>>();

        //Assert
        Assert.NotNull(jsonResponse);
        Assert.True(jsonResponse.Success);
        Assert.Empty(jsonResponse.Errors);
    }


}
