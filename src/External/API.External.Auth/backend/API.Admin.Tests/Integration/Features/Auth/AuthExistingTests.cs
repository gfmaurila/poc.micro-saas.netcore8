using API.External.Auth.Feature.Auth.Login;
using API.External.Auth.Tests.Integration.Features.Fakes;
using API.External.Auth.Tests.Integration.Utilities;
using Common.External.Auth.Net8.API.Models;
using System.Net;
using System.Net.Http.Json;

namespace API.External.Auth.Tests.Integration.Features.Auth;

public class AuthExistingTests : IClassFixture<DatabaseSQLServerFixture>
{
    private readonly HttpClient _client;
    private readonly DatabaseSQLServerFixture _fixture;

    public AuthExistingTests(DatabaseSQLServerFixture fixture)
    {
        _fixture = fixture;
        _client = fixture.Client;
    }

    [Fact]
    public async Task ShouldUser()
    {
        // Arrange
        var command = AuthFake.AuthExistingCommand();

        var httpResponse = await _client.PostAsJsonAsync("/api/v1/login", command);

        Assert.Equal(HttpStatusCode.BadRequest, httpResponse.StatusCode);
        var jsonResponse = await httpResponse.Content.ReadFromJsonAsync<ApiResponse<AuthTokenResponse>>();

        //Assert
        Assert.NotNull(jsonResponse);
        Assert.False(jsonResponse.Success);
        Assert.NotEmpty(jsonResponse.Errors);
    }
}
