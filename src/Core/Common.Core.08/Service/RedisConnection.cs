using Microsoft.Extensions.Configuration;
using StackExchange.Redis;

namespace Common.Core._08.Service;

/// <summary>
/// Manages the Redis connection and provides methods to access Redis databases and the connection multiplexer.
/// Implements a thread-safe singleton pattern for the Redis connection.
/// </summary>
public class RedisConnection
{
    private static ConnectionMultiplexer _redisConnection;
    private static readonly object padlock = new object();

    /// <summary>
    /// Initializes a new instance of the <see cref="RedisConnection"/> class and establishes a connection to Redis.
    /// </summary>
    /// <param name="configuration">The application configuration settings containing the Redis connection string.</param>
    public RedisConnection(IConfiguration configuration)
    {
        var connectionString = configuration.GetConnectionString("CacheConnection");
        lock (padlock)
        {
            if (_redisConnection == null || !_redisConnection.IsConnected)
            {
                _redisConnection = ConnectionMultiplexer.Connect(connectionString);
            }
        }
    }

    /// <summary>
    /// Gets a Redis database instance with an optional database index.
    /// </summary>
    /// <param name="dbIndex">
    /// The index of the Redis database to retrieve. Defaults to -1, which uses the default database.
    /// </param>
    /// <returns>An <see cref="IDatabase"/> instance for the specified Redis database.</returns>
    public IDatabase GetDatabase(int dbIndex = -1)
    {
        return _redisConnection.GetDatabase(dbIndex);
    }

    /// <summary>
    /// Gets the <see cref="ConnectionMultiplexer"/> instance used for managing the Redis connection.
    /// </summary>
    /// <returns>The <see cref="ConnectionMultiplexer"/> instance.</returns>
    public ConnectionMultiplexer GetConnectionMultiplexer()
    {
        return _redisConnection;
    }
}

