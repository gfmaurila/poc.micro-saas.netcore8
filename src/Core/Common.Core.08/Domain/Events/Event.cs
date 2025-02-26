using MediatR;

namespace Common.Core._08.Domain.Events;

/// <summary>
/// Represents a base class for events.
/// </summary>
public abstract class Event : INotification
{
    /// <summary>
    /// Gets the type of the event.
    /// </summary>
    public string MessageType { get; protected init; }

    /// <summary>
    /// Gets the ID of the associated aggregate.
    /// </summary>
    public Guid AggregateId { get; protected init; }

    /// <summary>
    /// Gets the date and time when the event occurred.
    /// </summary>
    public DateTime OccurredOn { get; private init; } = DateTime.Now;
}

