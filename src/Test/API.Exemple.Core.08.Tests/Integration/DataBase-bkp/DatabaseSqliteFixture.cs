//using API.Exemple.Core._08.Infrastructure.Database;
//using API.Exemple.Core._08.Tests.Integration.Utilities.Auth;
//using API.Exemple.Core.Tests.Integration.Factory;
//using Microsoft.EntityFrameworkCore;

//namespace API.Exemple.Core.Tests.Integration;

//public class DatabaseSqliteFixture : IAsyncLifetime
//{
//    private readonly TestWebApplicationFactory<Program> _factory;

//    public HttpClient Client { get; }
//    private readonly AuthToken1 _auth;
//    private ExempleAppDbContext _context;

//    public DatabaseSqliteFixture()
//    {
//        _auth = new AuthToken1();
//        _factory = new TestWebApplicationFactory<Program>();
//        Client = _factory.CreateClient();

//        // Configurando o DbContext para usar SQLite In-Memory
//        var options = new DbContextOptionsBuilder<ExempleAppDbContext>()
//            .UseSqlite("DataSource=:memory:") // SQLite In-Memory
//            .Options;

//        _context = new ExempleAppDbContext(options);
//    }

//    public async Task InitializeAsync()
//    {
//        // SQLite In-Memory precisa abrir a conexão para que o banco de dados exista
//        await _context.Database.OpenConnectionAsync();
//        await _context.Database.EnsureCreatedAsync();
//    }

//    public TestWebApplicationFactory<Program> Factory()
//    {
//        return _factory;
//    }

//    public async Task DisposeAsync()
//    {
//        await _context.Database.EnsureDeletedAsync();
//        await _context.Database.CloseConnectionAsync();
//        await _context.DisposeAsync();
//    }

//    public async Task<AuthResponse> GetAuthAsync()
//    {
//        return new AuthResponse()
//        {
//            AccessToken = GenerateJwtToken()
//        };
//    }

//    public string GenerateJwtToken()
//    {
//        return _auth.GenerateJwtToken();
//    }
//}
