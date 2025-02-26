namespace API.Exemple.Core.Tests.Integration.Features.Exemple.Queries;

public class GetPaginateExempleQueryTests : IClassFixture<DatabaseSQLServerFixture>
{
    private readonly HttpClient _client;
    private readonly DatabaseSQLServerFixture _fixture;

    public GetPaginateExempleQueryTests(DatabaseSQLServerFixture fixture)
    {
        _fixture = fixture;
        _client = fixture.Client;
    }

    [Fact]
    public async Task ShouldExemple()
    {
        Assert.True(true);
    }
}
