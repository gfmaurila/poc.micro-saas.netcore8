namespace API.Exemple.Core.Tests.Integration.Features.Exemple.Commands;

public class DeleteExempleCommandTests : IClassFixture<DatabaseSQLServerFixture>
{
    private readonly HttpClient _client;
    private readonly DatabaseSQLServerFixture _fixture;

    public DeleteExempleCommandTests(DatabaseSQLServerFixture fixture)
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
