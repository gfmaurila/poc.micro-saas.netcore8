//using API.Exemple.Core._08.Infrastructure.Database;
//using API.Exemple.Core._08.Tests.Integration.Utilities.Auth;
//using API.Exemple.Core.Tests.Integration.Factory;
//using Microsoft.EntityFrameworkCore;

//namespace API.Exemple.Core.Tests.Integration;

//public class DatabaseSQLServerFixture1 : IAsyncLifetime
//{
//    private readonly TestWebApplicationFactory<Program> _factory;

//    public HttpClient Client { get; }
//    private readonly AuthToken1 _auth;
//    private ExempleAppDbContext _context;

//    private static Random random = new Random();

//    public DatabaseSQLServerFixture1()
//    {
//        _auth = new AuthToken1();
//        _factory = new TestWebApplicationFactory<Program>();
//        Client = _factory.CreateClient();

//        // Configurando o DbContext para usar SQL Server
//        var options = new DbContextOptionsBuilder<ExempleAppDbContext>()
//            .UseSqlServer($"Server=127.0.0.1;Integrated Security=true;Initial Catalog=core_test_{random.Next()};User Id=sa;Password=@Poc2Minimal@Api;Trusted_Connection=false;MultipleActiveResultSets=true;Encrypt=True;TrustServerCertificate=True;")
//            .Options;

//        _context = new ExempleAppDbContext(options);
//    }

//    public async Task InitializeAsync()
//    {
//        //await _context.Database.EnsureDeletedAsync();
//        await _context.Database.MigrateAsync();
//    }

//    public TestWebApplicationFactory<Program> Factory()
//    {
//        return _factory;
//    }

//    public async Task DisposeAsync()
//    {
//        await _context.Database.EnsureDeletedAsync();
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
