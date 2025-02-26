using API.InventoryControl.Feature.Domain.Exemple.Models;
using API.InventoryControl.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Interface;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Queries.Get;

/// <summary>
/// Handles the request to retrieve a list of Exemple entities, utilizing caching for performance optimization.
/// </summary>
public class GetExempleQueryHandler : IRequestHandler<GetExempleQuery, ApiResult<List<ExempleQueryModel>>>
{
    private readonly IExempleRepository _repo;
    private readonly IRedisCacheService<List<ExempleQueryModel>> _cacheService;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetExempleQueryHandler"/> class.
    /// </summary>
    /// <param name="repo">Repository instance for accessing Exemple data.</param>
    /// <param name="cacheService">Redis cache service to improve performance and reduce database load.</param>
    public GetExempleQueryHandler(IExempleRepository repo, IRedisCacheService<List<ExempleQueryModel>> cacheService)
    {
        _repo = repo;
        _cacheService = cacheService;
    }

    /// <summary>
    /// Handles the request to retrieve all Exemple records, leveraging caching for optimized performance.
    /// </summary>
    /// <param name="request">The request containing the query parameters.</param>
    /// <param name="cancellationToken">Cancellation token to handle request cancellation.</param>
    /// <returns>An <see cref="ApiResult{T}"/> containing the list of Exemple records.</returns>
    public async Task<ApiResult<List<ExempleQueryModel>>> Handle(GetExempleQuery request, CancellationToken cancellationToken)
    {
        const string cacheKey = nameof(GetExempleQuery);

        // Retrieves data from cache or fetches from repository if not cached
        var users = await _cacheService.GetOrCreateAsync(cacheKey, () => _repo.GetAllAsync(), TimeSpan.FromHours(2));

        if (users is not null && users.Any())
            return ApiResult<List<ExempleQueryModel>>.CreateSuccess(users, "Records successfully retrieved.");

        return ApiResult<List<ExempleQueryModel>>.CreateSuccess(new List<ExempleQueryModel>(), "No records found.");
    }
}
