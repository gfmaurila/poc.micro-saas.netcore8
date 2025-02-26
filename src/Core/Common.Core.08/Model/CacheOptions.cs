namespace Common.Core._08.Model;

/// <summary>
/// Represents configuration options for caching behavior.
/// </summary>
public class CacheOptions
{
    /// <summary>
    /// The configuration section path for cache options.
    /// </summary>
    public const string ConfigSectionPath = nameof(CacheOptions);

    /// <summary>
    /// Gets or sets the absolute expiration time for cached items, in hours.
    /// After this time, the cached item will be removed regardless of access.
    /// </summary>
    public int AbsoluteExpirationInHours { get; set; }

    /// <summary>
    /// Gets or sets the sliding expiration time for cached items, in seconds.
    /// Resets the expiration timer each time the item is accessed.
    /// </summary>
    public int SlidingExpirationInSeconds { get; set; }

    /// <summary>
    /// Gets or sets the database index to be used for caching.
    /// </summary>
    public int DbIndex { get; set; }
}
