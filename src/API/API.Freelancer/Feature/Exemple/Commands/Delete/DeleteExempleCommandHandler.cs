using API.Freelancer.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Delete;

/// <summary>
/// Handles the deletion of an Exemple entity by validating the request,
/// retrieving the entity from the repository, removing it, and triggering domain events.
/// </summary>
public class DeleteExempleCommandHandler : IRequestHandler<DeleteExempleCommand, ApiResult<DeleteExempleResponse>>
{
    private readonly DeleteExempleCommandValidator _validator;
    private readonly IExempleRepository _repo;
    private readonly ILogger<DeleteExempleCommandHandler> _logger;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteExempleCommandHandler"/> class.
    /// </summary>
    /// <param name="logger">Logger instance for logging operations.</param>
    /// <param name="repo">Repository instance for handling Exemple data operations.</param>
    /// <param name="validator">Validator instance for validating the deletion request.</param>
    /// <param name="mediator">Mediator instance for publishing domain events.</param>
    public DeleteExempleCommandHandler(
        ILogger<DeleteExempleCommandHandler> logger,
        IExempleRepository repo,
        DeleteExempleCommandValidator validator,
        IMediator mediator)
    {
        _repo = repo;
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the request to delete an Exemple entity.
    /// </summary>
    /// <param name="request">The command containing the ID of the entity to be deleted.</param>
    /// <param name="cancellationToken">Cancellation token to handle task cancellation.</param>
    /// <returns>An <see cref="ApiResult{T}"/> containing the response details.</returns>
    public async Task<ApiResult<DeleteExempleResponse>> Handle(DeleteExempleCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Validating delete Exemple request for ID: {Id}", request.Id);

        // Validate request
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for delete Exemple request.");
            return ApiResult<DeleteExempleResponse>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);
        }

        _logger.LogInformation("Fetching Exemple entity from repository with ID: {Id}", request.Id);

        // Retrieve entity from repository
        var entity = await _repo.Get(request.Id);
        if (entity == null)
        {
            _logger.LogWarning("No record found for ID: {Id}", request.Id);
            return ApiResult<DeleteExempleResponse>.CreateError(
                new List<ErrorDetail> {
                    new ErrorDetail($"No record found for ID: {request.Id}")
                },
                400);
        }

        // Mark entity as deleted
        entity.Delete();

        _logger.LogInformation("Removing Exemple entity with ID: {Id}", request.Id);
        await _repo.Remove(entity);

        _logger.LogInformation("Publishing domain events for Exemple deletion with ID: {Id}", request.Id);

        // Publish domain events
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return ApiResult<DeleteExempleResponse>.CreateSuccess(new DeleteExempleResponse(request.Id), "Successfully removed!");
    }
}
