using API.Exemple.Core._08.Feature.Domain.Exemple.Events;
using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using API.Exemple1.Core._08.Feature.Exemple.Queries.Get;
using Common.Core._08.Interface;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Delete.Events;

/// <summary>
/// Handles the <see cref="ExempleDeleteDomainEvent"/> by updating the cache after an Exemple entity is deleted.
/// </summary>
public class ExempleDeleteDomainEventHandler : INotificationHandler<ExempleDeleteDomainEvent>
{
    private readonly ILogger<ExempleDeleteDomainEventHandler> _logger;
    private readonly IExempleRepository _repo;
    private readonly IRedisCacheService<List<ExempleQueryModel>> _cacheService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleDeleteDomainEventHandler"/> class.
    /// </summary>
    /// <param name="logger">Logger instance for logging operations.</param>
    /// <param name="repo">Repository instance for retrieving Exemple data.</param>
    /// <param name="cacheService">Redis cache service used for caching Exemple data.</param>
    public ExempleDeleteDomainEventHandler(
        ILogger<ExempleDeleteDomainEventHandler> logger,
        IExempleRepository repo,
        IRedisCacheService<List<ExempleQueryModel>> cacheService)
    {
        _logger = logger;
        _repo = repo;
        _cacheService = cacheService;
    }

    /// <summary>
    /// Handles the event when an Exemple entity is deleted by refreshing the cache.
    /// </summary>
    /// <param name="notification">The event notification containing the deleted Exemple entity data.</param>
    /// <param name="cancellationToken">Cancellation token to handle task cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(ExempleDeleteDomainEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetExempleQuery);

        _logger.LogInformation("Refreshing cache for key: {CacheKey} after Exemple deletion.", cacheKey);

        // Remove outdated cache entry
        await _cacheService.DeleteAsync(cacheKey);

        // Reload cache with updated data
        await _cacheService.GetOrCreateAsync(cacheKey, _repo.GetAllAsync, TimeSpan.FromHours(2));

        _logger.LogInformation("Cache refreshed successfully for key: {CacheKey}.", cacheKey);
    }
}
