using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple.Core._08.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Interface;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Queries.GetById;


/// <summary>
/// Handles the retrieval of an Exemple entity by its unique identifier.
/// It first attempts to fetch the entity from the Redis cache before querying the database.
/// </summary>
public class GetExempleByIdQueryHandler : IRequestHandler<GetExempleByIdQuery, ApiResult<ExempleQueryModel>>
{
    private readonly IExempleRepository _repo;
    private readonly IRedisCacheService<ExempleQueryModel> _cacheService;
    private readonly GetExempleByIdQueryValidator _validator;

    /// <summary>
    /// Initializes a new instance of the <see cref="GetExempleByIdQueryHandler"/> class.
    /// </summary>
    /// <param name="repo">Repository instance for retrieving Exemple data.</param>
    /// <param name="cacheService">Redis cache service used for caching Exemple data.</param>
    /// <param name="validator">Validator instance for ensuring query validity.</param>
    public GetExempleByIdQueryHandler(
        IExempleRepository repo,
        IRedisCacheService<ExempleQueryModel> cacheService,
        GetExempleByIdQueryValidator validator)
    {
        _repo = repo;
        _cacheService = cacheService;
        _validator = validator;
    }

    /// <summary>
    /// Handles the query to retrieve an Exemple entity by its ID.
    /// First checks Redis cache before querying the SQL database.
    /// </summary>
    /// <param name="request">The query containing the ID of the entity to retrieve.</param>
    /// <param name="cancellationToken">Cancellation token to handle task cancellation.</param>
    /// <returns>An <see cref="ApiResult{T}"/> containing the entity if found, otherwise an error message.</returns>
    public async Task<ApiResult<ExempleQueryModel>> Handle(GetExempleByIdQuery request, CancellationToken cancellationToken)
    {
        // Validate request
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ApiResult<ExempleQueryModel>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);
        }

        var cacheKey = $"{nameof(GetExempleByIdQuery)}_{request.Id}";

        // Attempt to retrieve from Redis cache
        var modelRedis = await _cacheService.GetAsync(cacheKey);
        if (modelRedis is not null)
        {
            return ApiResult<ExempleQueryModel>.CreateSuccess(
                modelRedis,
                "Record successfully retrieved from cache.");
        }

        // Retrieve entity from SQL database
        var entity = await _repo.GetByIdAsync(request.Id);
        if (entity is not null)
        {
            var cachedEntity = await _cacheService.GetOrCreateAsync(cacheKey, () => _repo.GetByIdAsync(request.Id), TimeSpan.FromHours(2));

            return ApiResult<ExempleQueryModel>.CreateSuccess(
                cachedEntity,
                "Record successfully retrieved from database.");
        }

        return ApiResult<ExempleQueryModel>.CreateSuccess(null, "No record found!");
    }
}

