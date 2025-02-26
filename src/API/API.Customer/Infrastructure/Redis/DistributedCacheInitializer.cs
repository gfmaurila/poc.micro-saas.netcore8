using Common.Core._08.Interface;
using Common.Core._08.Model;
using Common.Core._08.Service;
using StackExchange.Redis;

namespace API.Customer.Infrastructure.Redis;

/// <summary>
/// Initializes and configures the distributed cache services using Redis.
/// </summary>
public class DistributedCacheInitializer
{
    /// <summary>
    /// Registers Redis-related services into the dependency injection container.
    /// Configures Redis connection settings and caching services.
    /// </summary>
    /// <param name="services">The service collection to configure.</param>
    /// <param name="configuration">The application configuration settings.</param>
    public static void Initialize(IServiceCollection services, IConfiguration configuration)
    {
        // Registers the IConfiguration instance
        services.AddSingleton<IConfiguration>(provider => configuration);

        // Registers Redis connection helper
        services.AddSingleton<RedisConnection>();

        // Configures and registers the Redis connection multiplexer as a singleton
        services.AddSingleton<IConnectionMultiplexer>(provider =>
        {
            var config = ConfigurationOptions.Parse(configuration.GetConnectionString("CacheConnection"));

            // Redis connection settings
            config.AbortOnConnectFail = false;  // Prevents immediate failure if Redis is unavailable
            config.ConnectRetry = 5;            // Sets the number of retry attempts before failing
            config.ConnectTimeout = 10000;      // Timeout for connection establishment (10 seconds)
            config.SyncTimeout = 10000;         // Timeout for synchronous operations
            config.AllowAdmin = true;           // Enables administrative commands
            config.CommandMap = CommandMap.Default; // Uses the default command mapping

            return ConnectionMultiplexer.Connect(config);
        });

        // Registers Redis cache service as a scoped dependency
        services.AddScoped(typeof(IRedisCacheService<>), typeof(RedisCacheService<>));

        // Configures cache options from the application settings
        services.Configure<CacheOptions>(configuration.GetSection("CacheOptions"));
    }
}
