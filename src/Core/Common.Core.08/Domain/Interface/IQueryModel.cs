namespace Common.Core._08.Domain.Interface;

/// <summary>
/// Marker interface to represent a query model (read-only).
/// </summary>
public interface IQueryModel
{
}

/// <summary>
/// Marker interface to represent a query model (read-only) with a strongly-typed key.
/// </summary>
/// <typeparam name="TKey">The type of the model's key.</typeparam>
public interface IQueryModel<out TKey> : IQueryModel where TKey : IEquatable<TKey>
{
    /// <summary>
    /// Gets the unique identifier for the query model.
    /// </summary>
    TKey Id { get; }
}

