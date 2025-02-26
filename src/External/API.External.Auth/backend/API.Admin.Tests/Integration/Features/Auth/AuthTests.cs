using API.External.Auth.Feature.Auth.Login;
using API.External.Auth.Tests.Integration.Features.Fakes;
using API.External.Auth.Tests.Integration.Utilities;
using Common.External.Auth.Net8.Response;
using System.Net;
using System.Net.Http.Json;

namespace API.External.Auth.Tests.Integration.Features.Auth;

public class AuthTests : IClassFixture<DatabaseSQLServerFixture>
{
    private readonly HttpClient _client;
    private readonly DatabaseSQLServerFixture _fixture;

    public AuthTests(DatabaseSQLServerFixture fixture)
    {
        _fixture = fixture;
        _client = fixture.Client;
    }

    [Fact]
    public async Task ShouldUser()
    {
        // Arrange
        var command = AuthFake.AuthCommand();

        await UserFake.CreateUserAuth(_fixture, UserFake.CreateUser(command.Email, command.Password));

        var httpResponse = await _client.PostAsJsonAsync("/api/v1/login", command);
        httpResponse.EnsureSuccessStatusCode();

        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        var jsonResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResult<AuthTokenResponse>>();

        //Assert
        Assert.NotNull(jsonResponse);
        Assert.Equal("Sucesso!", jsonResponse.SuccessMessage);
        Assert.True(jsonResponse.Success);
        Assert.Empty(jsonResponse.Errors);
    }
}
