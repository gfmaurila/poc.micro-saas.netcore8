namespace API.Exemple.Core.Tests.Integration.Features.Exemple.Commands;

public class CreateExempleCommandTests : IClassFixture<DatabaseSQLServerFixture>
{
    private readonly HttpClient _client;
    private readonly DatabaseSQLServerFixture _fixture;

    public CreateExempleCommandTests(DatabaseSQLServerFixture fixture)
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
