using API.Person.Feature.Domain.Exemple.Models;
using API.Person.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Update;

/// <summary>
/// Handles the update operation for an Exemple entity.
/// Validates the request, updates the entity in the repository, and triggers domain events.
/// </summary>
public class UpdateExempleCommandHandler : IRequestHandler<UpdateExempleCommand, ApiResult<UpdateExempleResponse>>
{
    private readonly UpdateExempleCommandValidator _validator;
    private readonly IExempleRepository _repo;
    private readonly ILogger<UpdateExempleCommandHandler> _logger;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateExempleCommandHandler"/> class.
    /// </summary>
    /// <param name="logger">Logger instance for logging operations.</param>
    /// <param name="repo">Repository instance for accessing Exemple data.</param>
    /// <param name="validator">Validator instance for validating update requests.</param>
    /// <param name="mediator">Mediator instance for handling domain events.</param>
    public UpdateExempleCommandHandler(
        ILogger<UpdateExempleCommandHandler> logger,
        IExempleRepository repo,
        UpdateExempleCommandValidator validator,
        IMediator mediator)
    {
        _repo = repo;
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the request to update an existing Exemple entity.
    /// </summary>
    /// <param name="request">The command containing updated data for the entity.</param>
    /// <param name="cancellationToken">Cancellation token to handle task cancellation.</param>
    /// <returns>An <see cref="ApiResult{T}"/> indicating the success or failure of the operation.</returns>
    public async Task<ApiResult<UpdateExempleResponse>> Handle(UpdateExempleCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Validating update request for Exemple ID: {ExempleId}", request.Id);

        // Validate request
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            return ApiResult<UpdateExempleResponse>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);
        }

        // Retrieve the existing entity from the repository
        var entity = await _repo.Get(request.Id);
        if (entity == null)
        {
            _logger.LogWarning("No record found for Exemple ID: {ExempleId}", request.Id);
            return ApiResult<UpdateExempleResponse>.CreateError(
                new List<ErrorDetail> { new ErrorDetail($"No record found for ID: {request.Id}") },
                400);
        }

        // Create authorization model for auditing updates
        var authModel = new AuthExempleCreateUpdateDeleteModel(
            entity.DtInsert,
            entity.DtInsertId,
            entity.DtUpdate ?? DateTime.Now,
            entity.DtUpdateId ?? 0,
            entity.DtDelete,
            entity.DtDeleteId);

        // Apply updates to the entity
        entity.Update(request, authModel);

        // Persist updated entity
        await _repo.Update(entity);

        _logger.LogInformation("Exemple ID: {ExempleId} successfully updated", request.Id);

        // Trigger domain events
        foreach (var domainEvent in entity.DomainEvents)
        {
            await _mediator.Publish(domainEvent);
        }

        entity.ClearDomainEvents();

        return ApiResult<UpdateExempleResponse>.CreateSuccess(
            new UpdateExempleResponse(entity.Id),
            "Successfully updated.");
    }
}