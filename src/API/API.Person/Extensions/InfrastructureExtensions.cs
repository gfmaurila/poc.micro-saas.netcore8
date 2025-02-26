using API.Exemple1.Core._08.Infrastructure.Messaging;
using API.Person.Infrastructure.Auth;
using API.Person.Infrastructure.Database;
using API.Person.Infrastructure.Database.Repositories;
using API.Person.Infrastructure.Database.Repositories.Interfaces;
using API.Person.Infrastructure.Integration;
using API.Person.Infrastructure.Redis;
using Microsoft.EntityFrameworkCore;
using System.Reflection;

namespace API.Person.Extensions;

/// <summary>
/// Provides extension methods for configuring infrastructure services, database migrations,
/// and initializing dependencies in the application.
/// </summary>
public static class InfrastructureExtensions
{
    /// <summary>
    /// Applies pending database migrations asynchronously when the application starts.
    /// </summary>
    /// <param name="app">The web application instance.</param>
    public static async Task MigrateAsync(this WebApplication app)
    {
        await using var serviceScope = app.Services.CreateAsyncScope();
        await using var writeDbContext = serviceScope.ServiceProvider.GetRequiredService<PersonAppDbContext>();

        try
        {
            await app.MigrateDbContextAsync(writeDbContext);
        }
        catch (Exception ex)
        {
            app.Logger.LogError(ex, "An exception occurred while starting the application: {Message}", ex.Message);
            throw;
        }
    }

    /// <summary>
    /// Applies pending migrations to the specified database context.
    /// </summary>
    /// <typeparam name="TContext">The type of database context to migrate.</typeparam>
    /// <param name="app">The web application instance.</param>
    /// <param name="context">The database context instance.</param>
    private static async Task MigrateDbContextAsync<TContext>(this WebApplication app, TContext context)
        where TContext : DbContext
    {
        var dbName = context.Database.GetDbConnection().Database;

        app.Logger.LogInformation("----- {DbName}: {DbConnection}", dbName, context.Database.GetConnectionString());
        app.Logger.LogInformation("----- {DbName}: Checking for pending migrations...", dbName);

        if ((await context.Database.GetPendingMigrationsAsync()).Any())
        {
            app.Logger.LogInformation("----- {DbName}: Applying database migrations...", dbName);

            await context.Database.MigrateAsync();

            app.Logger.LogInformation("----- {DbName}: Database migrated successfully!", dbName);
        }
        else
        {
            app.Logger.LogInformation("----- {DbName}: No pending migrations.", dbName);
        }
    }

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
            var context = services.GetRequiredService<PersonAppDbContext>();
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
        // Repository Registration
        services.AddScoped<IExempleRepository, ExempleRepository>();

        // Redis Cache Initialization
        DistributedCacheInitializer.Initialize(services, configuration);

        // Core Service Initialization
        CoreInitializer.Initialize(services);

        // Register AutoMapper for mapping objects between layers
        services.AddAutoMapper(Assembly.GetExecutingAssembly());

        // RabbitMQ Messaging Initialization
        MessagingInitializer.Initialize(services, configuration);

        // External Email Service Initialization
        ExternalEmailInitializer.Initialize(services, configuration);

        // Register the database context with a connection string
        services.AddDbContext<PersonAppDbContext>(options =>
            options.UseSqlServer(configuration.GetConnectionString("SqlConnection")));

        return services;
    }
}