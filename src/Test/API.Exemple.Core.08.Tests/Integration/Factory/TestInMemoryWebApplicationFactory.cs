using API.Exemple.Core._08.Infrastructure.Database;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;

namespace API.Exemple.Core.Tests.Integration.Factory;


public class TestInMemoryWebApplicationFactory<TProgram> : WebApplicationFactory<TProgram> where TProgram : class
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

            // Add In-Memory context for testing
            services.AddDbContext<ExempleAppDbContext>(options =>
            {
                options.UseInMemoryDatabase("InMemoryDbForTesting");
            });

            // Build the service provider
            var sp = services.BuildServiceProvider();

            // Create the schema in the In-Memory test database
            using var scope = sp.CreateScope();
            using var appContext = scope.ServiceProvider.GetRequiredService<ExempleAppDbContext>();
            appContext.Database.EnsureCreated();
        });
    }
}
