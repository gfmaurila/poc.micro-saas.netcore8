using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using Common.Core._08.Response;
using Newtonsoft.Json;
using System.Net;
using System.Net.Http.Headers;

namespace API.Exemple.Core.Tests.Integration.Features.Exemple.Queries;

public class GetExempleTests : IClassFixture<DatabaseSQLServerFixture>
{
    private readonly HttpClient _client;
    private readonly DatabaseSQLServerFixture _fixture;

    public GetExempleTests(DatabaseSQLServerFixture fixture)
    {
        _fixture = fixture;
        _client = fixture.Client;
    }

    [Fact]
    public async Task ShouldExemple()
    {
        // Auth
        var token = await _fixture.GetAuthAsync();
        _client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", token.AccessToken);

        var httpResponse = await _client.GetAsync("/api/v1/exemple");
        httpResponse.EnsureSuccessStatusCode();
        var stringResponse = await httpResponse.Content.ReadAsStringAsync();
        var result = JsonConvert.DeserializeObject<ApiResult<List<ExempleQueryModel>>>(stringResponse);
        _client.DefaultRequestHeaders.Clear();

        Assert.Equal(HttpStatusCode.OK, httpResponse.StatusCode);
        Assert.NotNull(result);
    }
}



