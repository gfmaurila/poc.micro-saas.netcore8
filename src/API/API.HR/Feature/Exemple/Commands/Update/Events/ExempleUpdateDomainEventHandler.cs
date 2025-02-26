using API.Exemple1.Core._08.Feature.Exemple.Queries.Get;
using API.HR.Feature.Domain.Exemple.Events;
using API.HR.Feature.Domain.Exemple.Models;
using API.HR.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Interface;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Update.Events;

/// <summary>
/// Handles the <see cref="ExempleUpdateDomainEvent"/> by updating the cache
/// after an Exemple entity is modified.
/// </summary>
public class ExempleUpdateDomainEventHandler : INotificationHandler<ExempleUpdateDomainEvent>
{
    private readonly ILogger<ExempleUpdateDomainEventHandler> _logger;
    private readonly IExempleRepository _repo;
    private readonly IRedisCacheService<List<ExempleQueryModel>> _cacheService;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleUpdateDomainEventHandler"/> class.
    /// </summary>
    /// <param name="logger">Logger instance for logging operations.</param>
    /// <param name="repo">Repository instance for retrieving Exemple data.</param>
    /// <param name="cacheService">Redis cache service used for caching Exemple data.</param>
    public ExempleUpdateDomainEventHandler(
        ILogger<ExempleUpdateDomainEventHandler> logger,
        IExempleRepository repo,
        IRedisCacheService<List<ExempleQueryModel>> cacheService)
    {
        _logger = logger;
        _repo = repo;
        _cacheService = cacheService;
    }

    /// <summary>
    /// Handles the event when an Exemple entity is updated by refreshing the cache.
    /// </summary>
    /// <param name="notification">The event notification containing the updated Exemple entity data.</param>
    /// <param name="cancellationToken">Cancellation token to handle task cancellation.</param>
    /// <returns>A task representing the asynchronous operation.</returns>
    public async Task Handle(ExempleUpdateDomainEvent notification, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetExempleQuery);

        _logger.LogInformation("Updating cache for key: {CacheKey} after Exemple update.", cacheKey);

        // Remove outdated cache entry
        await _cacheService.DeleteAsync(cacheKey);

        // Reload cache with updated data
        await _cacheService.GetOrCreateAsync(cacheKey, _repo.GetAllAsync, TimeSpan.FromHours(2));

        _logger.LogInformation("Cache successfully refreshed for key: {CacheKey}.", cacheKey);
    }
}
