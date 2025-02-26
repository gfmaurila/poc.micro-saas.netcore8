using Common.Core._08.Interface;
using Common.Core._08.Model;
using Microsoft.Extensions.Options;
using StackExchange.Redis;
using System.Text.Json;

namespace Common.Core._08.Service;

/// <summary>
/// Provides a Redis-based caching service, implementing generic caching functionality.
/// </summary>
/// <typeparam name="T">The type of data to be stored or retrieved from the cache.</typeparam>
public class RedisCacheService<T> : IRedisCacheService<T>
{
    private readonly IDatabase _database;
    private readonly CacheOptions _cacheOptions;
    private readonly IConnectionMultiplexer _connectionMultiplexer;

    /// <summary>
    /// Initializes a new instance of the <see cref="RedisCacheService{T}"/> class.
    /// </summary>
    /// <param name="redisConnection">The Redis connection instance.</param>
    /// <param name="cacheOptions">The cache configuration options.</param>
    public RedisCacheService(RedisConnection redisConnection, IOptions<CacheOptions> cacheOptions)
    {
        _cacheOptions = cacheOptions.Value;
        _connectionMultiplexer = redisConnection.GetConnectionMultiplexer();
        // Configure the database index based on cache options
        _database = _connectionMultiplexer.GetDatabase(_cacheOptions.DbIndex);
    }

    /// <inheritdoc />
    public async Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null)
    {
        var serializedValue = JsonSerializer.Serialize(value);
        return await _database.StringSetAsync(key, serializedValue, expiry);
    }

    /// <inheritdoc />
    public async Task<long> AddToListAsync(string listKey, T value)
    {
        var serializedValue = JsonSerializer.Serialize(value);
        return await _database.ListRightPushAsync(listKey, serializedValue);
    }

    /// <inheritdoc />
    public async Task<T> GetOrCreateAsync(string key, Func<Task<T>> createItem, TimeSpan? expiry = null)
    {
        var value = await _database.StringGetAsync(key);
        if (!value.IsNullOrEmpty)
            return JsonSerializer.Deserialize<T>(value);

        var newValue = await createItem();
        var serializedValue = JsonSerializer.Serialize(newValue);
        await _database.StringSetAsync(key, serializedValue, expiry);

        return newValue;
    }

    /// <inheritdoc />
    public async Task<IEnumerable<T>> GetListAsync(string listKey)
    {
        var values = await _database.ListRangeAsync(listKey);
        return values
            .Select(value => JsonSerializer.Deserialize<T>(value))
            .Where(item => item != null);
    }

    /// <inheritdoc />
    public async Task<long> RemoveFromListAsync(string listKey, T value)
    {
        var serializedValue = JsonSerializer.Serialize(value);
        return await _database.ListRemoveAsync(listKey, serializedValue);
    }

    /// <inheritdoc />
    public async Task<T> GetAsync(string key)
    {
        var value = await _database.StringGetAsync(key);
        if (value.IsNullOrEmpty) return default;

        return JsonSerializer.Deserialize<T>(value);
    }

    /// <inheritdoc />
    public async Task<bool> DeleteAsync(string key)
    {
        return await _database.KeyDeleteAsync(key);
    }

    /// <inheritdoc />
    public async Task ClearDatabaseAsync()
    {
        var endpoints = _connectionMultiplexer.GetEndPoints();
        var server = _connectionMultiplexer.GetServer(endpoints.First());
        await server.FlushDatabaseAsync(_database.Database);
    }
}
