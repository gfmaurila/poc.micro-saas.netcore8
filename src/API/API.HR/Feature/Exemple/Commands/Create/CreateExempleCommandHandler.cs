using API.HR.Feature.Domain.Exemple;
using API.HR.Feature.Domain.Exemple.Models;
using API.HR.Infrastructure.Database.Repositories.Interfaces;
using Common.Core._08.Domain.ValueObjects;
using Common.Core._08.Response;
using MediatR;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Create;

/// <summary>
/// Handles the creation of an <see cref="ExempleEntity"/> by validating the request,
/// checking for duplicate emails, and saving the entity to the repository.
/// </summary>
public class CreateExempleCommandHandler : IRequestHandler<CreateExempleCommand, ApiResult<CreateExempleResponse>>
{
    private readonly CreateExempleCommandValidator _validator;
    private readonly IExempleRepository _repo;
    private readonly ILogger<CreateExempleCommandHandler> _logger;
    private readonly IMediator _mediator;

    /// <summary>
    /// Initializes a new instance of the <see cref="CreateExempleCommandHandler"/> class.
    /// </summary>
    /// <param name="logger">Logger instance for logging operations.</param>
    /// <param name="repo">Repository instance for handling Exemple data operations.</param>
    /// <param name="mediator">Mediator instance for publishing domain events.</param>
    /// <param name="validator">Validator instance for validating the creation request.</param>
    public CreateExempleCommandHandler(
        ILogger<CreateExempleCommandHandler> logger,
        IExempleRepository repo,
        IMediator mediator,
        CreateExempleCommandValidator validator)
    {
        _repo = repo;
        _logger = logger;
        _validator = validator;
        _mediator = mediator;
    }

    /// <summary>
    /// Handles the request to create an Exemple entity.
    /// </summary>
    /// <param name="request">The command containing the details for creating an entity.</param>
    /// <param name="cancellationToken">Cancellation token to handle request cancellation.</param>
    /// <returns>An <see cref="ApiResult{T}"/> containing the response details.</returns>
    public async Task<ApiResult<CreateExempleResponse>> Handle(CreateExempleCommand request, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Validating create Exemple request.");

        // Validate request
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
        {
            _logger.LogWarning("Validation failed for create Exemple request.");
            return ApiResult<CreateExempleResponse>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);
        }

        _logger.LogInformation("Checking if email {Email} already exists.", request.Email);

        var email = new Email(request.Email);
        var phone = new PhoneNumber(request.Phone);

        if (await _repo.ExistsByEmailAsync(email))
        {
            _logger.LogWarning("Email {Email} is already in use.", request.Email);
            return ApiResult<CreateExempleResponse>.CreateError(
                new List<ErrorDetail>
                {
                    new ErrorDetail("The provided email address is already in use.")
                },
                400);
        }

        _logger.LogInformation("Creating Exemple entity.");

        var authModel = new AuthExempleCreateUpdateDeleteModel(
            DateTime.Now, 0, null, null, null, null);

        var entity = new ExempleEntity(request, authModel);

        await _repo.Create(entity);

        _logger.LogInformation("Publishing domain events for Exemple entity ID: {Id}", entity.Id);

        // Publish domain events (RabbitMQ / Kafka) and save in Redis
        foreach (var domainEvent in entity.DomainEvents)
            await _mediator.Publish(domainEvent);

        entity.ClearDomainEvents();

        return ApiResult<CreateExempleResponse>.CreateSuccess(
            new CreateExempleResponse(entity.Id), "Successfully registered!");
    }
}
