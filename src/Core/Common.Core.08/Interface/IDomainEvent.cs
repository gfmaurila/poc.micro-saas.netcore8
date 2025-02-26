using MediatR;

namespace Common.Core._08.Interface;

/// <summary>
/// Represents a domain event, providing details about an event that occurs within the domain model.
/// </summary>
public interface IDomainEvent : INotification
{
    /// <summary>
    /// Gets the version of the event for compatibility purposes.
    /// </summary>
    int Version { get; }

    /// <summary>
    /// Gets the type of the aggregate associated with the event.
    /// </summary>
    string AggregateType { get; }

    /// <summary>
    /// Gets the type of the event.
    /// </summary>
    string EventType { get; }

    /// <summary>
    /// Gets the unique identifier for the event.
    /// </summary>
    Guid Id { get; }

    /// <summary>
    /// Gets the date and time when the event occurred, in UTC.
    /// </summary>
    DateTimeOffset OccurredOnUtc { get; }

    /// <summary>
    /// Gets the unique identifier of the aggregate associated with the event.
    /// </summary>
    Guid AggregateId { get; }

    /// <summary>
    /// Gets trace information related to the event, if available.
    /// </summary>
    string? TraceInfo { get; }
}
