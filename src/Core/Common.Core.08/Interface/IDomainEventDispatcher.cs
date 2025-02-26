namespace Common.Core._08.Interface;

/// <summary>
/// Represents a dispatcher responsible for handling domain events.
/// </summary>
public interface IDomainEventDispatcher
{
    /// <summary>
    /// Dispatches a collection of domain events asynchronously.
    /// </summary>
    /// <param name="domainEvents">The collection of domain events to be dispatched.</param>
    /// <param name="cancellationToken">
    /// A cancellation token to observe while waiting for the tasks to complete.
    /// Defaults to <see cref="CancellationToken.None"/>.
    /// </param>
    /// <returns>A task representing the asynchronous operation.</returns>
    Task DispatchAsync(IEnumerable<IDomainEvent> domainEvents, CancellationToken cancellationToken = default);
}

