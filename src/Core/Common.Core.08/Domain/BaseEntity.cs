using Common.Core._08.Domain.Events;
using Common.Core._08.Domain.Interface;
using System.ComponentModel.DataAnnotations.Schema;
using System.Diagnostics.CodeAnalysis;

namespace Common.Core._08.Domain;

/// <summary>
/// Base class that represents an entity with common behaviors and properties.
/// </summary>
[ExcludeFromCodeCoverage]
[NotMapped]
public abstract class BaseEntity : IEntity<Guid>
{
    private readonly List<Event> _domainEvents = new();

    /// <summary>
    /// Gets or sets the unique identifier of the entity.
    /// Defaults to a newly generated <see cref="Guid"/>.
    /// </summary>
    public Guid Id { get; protected set; } = Guid.NewGuid();

    /// <summary>
    /// Indicates whether the entity is active.
    /// Defaults to <c>true</c>.
    /// </summary>
    public bool Status { get; set; } = true;

    /// <summary>
    /// Gets or sets the date and time when the entity was inserted.
    /// Defaults to the current UTC time.
    /// </summary>
    public DateTime? DtInsert { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user or process that inserted the entity.
    /// </summary>
    public int? DtInsertId { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was last updated.
    /// </summary>
    public DateTime? DtUpdate { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user or process that updated the entity.
    /// </summary>
    public int? DtUpdateId { get; set; }

    /// <summary>
    /// Gets or sets the date and time when the entity was deleted.
    /// </summary>
    public DateTime? DtDelete { get; set; }

    /// <summary>
    /// Gets or sets the identifier of the user or process that deleted the entity.
    /// </summary>
    public int? DtDeleteId { get; set; }

    /// <summary>
    /// Sets the entity's unique identifier.
    /// </summary>
    /// <param name="id">The new identifier for the entity.</param>
    public virtual void SetId(Guid id)
    {
        Id = id;
    }

    /// <summary>
    /// Gets the list of domain events associated with the entity.
    /// </summary>
    public IEnumerable<Event> DomainEvents => _domainEvents.AsReadOnly();

    /// <summary>
    /// Adds a domain event to the entity's list of events.
    /// </summary>
    /// <param name="domainEvent">The domain event to add.</param>
    public void AddDomainEvent(Event domainEvent) => _domainEvents.Add(domainEvent);

    /// <summary>
    /// Clears all domain events associated with the entity.
    /// </summary>
    public void ClearDomainEvents() => _domainEvents.Clear();
}


