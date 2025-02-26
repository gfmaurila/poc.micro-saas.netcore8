using API.Exemple.Core._08.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Exemple.Core.Tests.Integration.Factory;

public class TestSqliteWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
{
    protected override void ConfigureWebHost(IWebHostBuilder builder)
    {
        Environment.SetEnvironmentVariable("ASPNETCORE_ENVIRONMENT", "Test");
        builder.UseEnvironment("Test");

        builder.ConfigureServices(services =>
        {
            // Remove the existing context configuration
            var descriptor = services.SingleOrDefault(d => d.ServiceType == typeof(DbContextOptions<ExempleAppDbContext>));

            if (descriptor is not null)
                services.Remove(descriptor);

            // Add SQLite In-Memory context for testing
            services.AddDbContext<ExempleAppDbContext>(options =>
            {
                options.UseSqlite("DataSource=:memory:"); // SQLite In-Memory
            });

            // Build the service provider
            var sp = services.BuildServiceProvider();

            // Create the schema in the SQLite In-Memory test database
            using var scope = sp.CreateScope();
            var appContext = scope.ServiceProvider.GetRequiredService<ExempleAppDbContext>();

            appContext.Database.OpenConnection(); // Necessário para SQLite In-Memory
            appContext.Database.EnsureCreated();
        });
    }
}
