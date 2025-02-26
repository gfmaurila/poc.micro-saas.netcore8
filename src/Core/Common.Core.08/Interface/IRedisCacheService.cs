namespace Common.Core._08.Interface;

/// <summary>
/// Defines a generic service for interacting with Redis cache, providing methods for storing, retrieving, and managing data.
/// </summary>
/// <typeparam name="T">The type of data to be stored or retrieved from the cache.</typeparam>
public interface IRedisCacheService<T>
{
    /// <summary>
    /// Stores a value in the cache with an optional expiry time.
    /// </summary>
    /// <param name="key">The cache key under which the value will be stored.</param>
    /// <param name="value">The value to store in the cache.</param>
    /// <param name="expiry">Optional expiry time for the cached value.</param>
    /// <returns>A task that returns <c>true</c> if the value was successfully stored; otherwise, <c>false</c>.</returns>
    Task<bool> SetAsync(string key, T value, TimeSpan? expiry = null);

    /// <summary>
    /// Adds a value to a list in the cache.
    /// </summary>
    /// <param name="listKey">The key of the list in the cache.</param>
    /// <param name="value">The value to add to the list.</param>
    /// <returns>A task that returns the length of the list after the value has been added.</returns>
    Task<long> AddToListAsync(string listKey, T value);

    /// <summary>
    /// Retrieves a value from the cache or creates and stores it if it does not exist.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <param name="createItem">A function to create the value if it does not exist in the cache.</param>
    /// <param name="expiry">Optional expiry time for the cached value.</param>
    /// <returns>A task that returns the cached or newly created value.</returns>
    Task<T> GetOrCreateAsync(string key, Func<Task<T>> createItem, TimeSpan? expiry = null);

    /// <summary>
    /// Retrieves all values from a list in the cache.
    /// </summary>
    /// <param name="listKey">The key of the list in the cache.</param>
    /// <returns>A task that returns an enumerable of values in the list.</returns>
    Task<IEnumerable<T>> GetListAsync(string listKey);

    /// <summary>
    /// Removes a value from a list in the cache.
    /// </summary>
    /// <param name="listKey">The key of the list in the cache.</param>
    /// <param name="value">The value to remove from the list.</param>
    /// <returns>A task that returns the number of elements removed from the list.</returns>
    Task<long> RemoveFromListAsync(string listKey, T value);

    /// <summary>
    /// Retrieves a value from the cache by its key.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <returns>A task that returns the value from the cache, or <c>null</c> if it does not exist.</returns>
    Task<T> GetAsync(string key);

    /// <summary>
    /// Deletes a value from the cache by its key.
    /// </summary>
    /// <param name="key">The cache key.</param>
    /// <returns>A task that returns <c>true</c> if the value was successfully deleted; otherwise, <c>false</c>.</returns>
    Task<bool> DeleteAsync(string key);

    /// <summary>
    /// Clears all data from the Redis database.
    /// </summary>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task ClearDatabaseAsync();
}
