using API.Exemple.Core._08.Infrastructure.Database;
using API.Exemple.Core._08.Tests.Integration.Utilities.Auth;
using API.Exemple.Core.Tests.Integration.Factory;
using Microsoft.EntityFrameworkCore;

namespace API.Exemple.Core.Tests.Integration;

public class DatabaseSQLServerFixture : IAsyncLifetime
{
    private readonly TestWebApplicationFactory<Program> _factory;

    public HttpClient Client { get; }
    private readonly AuthToken1 _auth;
    private ExempleAppDbContext _context;

    private static Random random = new Random();

    public DatabaseSQLServerFixture()
    {
        _auth = new AuthToken1();
        _factory = new TestWebApplicationFactory<Program>();
        Client = _factory.CreateClient();

        // Configurando o DbContext para usar In-Memory Database
        var options = new DbContextOptionsBuilder<ExempleAppDbContext>()
            .UseInMemoryDatabase("InMemoryDbForTesting_" + random.Next())
            .Options;

        _context = new ExempleAppDbContext(options);
    }

    public async Task InitializeAsync()
    {
        // Como estamos usando um banco In-Memory, EnsureCreated é suficiente.
        await _context.Database.EnsureCreatedAsync();
    }

    public TestWebApplicationFactory<Program> Factory()
    {
        return _factory;
    }

    public async Task DisposeAsync()
    {
        // Nenhuma ação necessária para excluir o banco de dados In-Memory
        await _context.DisposeAsync();
    }

    public async Task<AuthResponse> GetAuthAsync()
    {
        return new AuthResponse()
        {
            AccessToken = GenerateJwtToken()
        };
    }

    public string GenerateJwtToken()
    {
        return _auth.GenerateJwtToken();
    }
}
