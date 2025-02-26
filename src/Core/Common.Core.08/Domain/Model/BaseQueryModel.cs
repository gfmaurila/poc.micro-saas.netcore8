using Common.Core._08.Domain.Interface;

namespace Common.Core._08.Domain.Model;

/// <summary>
/// Represents the base class for query models with a GUID as the identifier.
/// </summary>
public abstract class BaseQueryModel : IQueryModel<Guid>
{
    /// <summary>
    /// Gets or sets the unique identifier for the query model.
    /// Defaults to a newly generated <see cref="Guid"/>.
    /// </summary>
    public Guid Id { get; set; } = Guid.NewGuid();
}
