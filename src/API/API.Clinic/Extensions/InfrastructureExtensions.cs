using API.Clinic.Infrastructure.Database;
using Microsoft.EntityFrameworkCore;

namespace API.Clinic.Extensions;

/// <summary>
/// Provides extension methods for configuring infrastructure services, database migrations,
/// and initializing dependencies in the application.
/// </summary>
public static class InfrastructureExtensions
{
    /// <summary>
    /// Applies database migrations synchronously during application startup.
    /// </summary>
    /// <param name="app">The host application instance.</param>
    public static void ApplyMigrations(this IHost app)
    {
        using var scope = app.Services.CreateScope();
        var services = scope.ServiceProvider;

        try
        {
            var context = services.GetRequiredService<ClinicAppDbContext>();
            context.Database.Migrate();
            Console.WriteLine("Database migrations applied successfully.");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"An error occurred while applying migrations: {ex.Message}");
            throw;
        }
    }

    /// <summary>
    /// Configures and registers infrastructure services, including repositories, cache, messaging,
    /// database context, and external service initializers.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The application configuration settings.</param>
    /// <returns>The updated service collection.</returns>
    public static IServiceCollection AddInfrastructureServices(this IServiceCollection services, IConfiguration configuration)
    {
        // Register the database context with a connection string
        services.AddDbContext<ClinicAppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        return services;
    }
}
