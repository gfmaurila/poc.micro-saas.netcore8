namespace API.HR.Controllers.External.ExternalEmail;
using API.HR.Controllers;

using API.HR.Feature.External.ExternalEmail.Create;
using API.HR.Feature.External.ExternalEmail.Create.Model;
using API.HR.Feature.External.ExternalEmail.Get;
using Common.Core._08.Domain.Model;
using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller responsible for testing access to an external email service.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class ExternalEmailController : BaseController
{
    private readonly ISender _sender;
    private readonly ILogger<ExternalEmailController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExternalEmailController"/> class.
    /// </summary>
    /// <param name="sender">Mediator instance for handling requests.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public ExternalEmailController(ISender sender, ILogger<ExternalEmailController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves a paginated list of email records from the external service.
    /// </summary>
    /// <param name="query">Query parameters for pagination and filtering.</param>
    /// <param name="cancellationToken">Cancellation token to handle request cancellation.</param>
    /// <returns>Returns a paginated result of email records.</returns>
    [HttpGet]
    [Authorize(Roles = $"{RoleConstants.EMPLOYEE_EXEMPLE}, {RoleConstants.ADMIN_EXEMPLE}")]
    [ProducesResponseType(typeof(ApiResult<GetPaginateEmailQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> Get([FromQuery] GetPaginateEmailQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Processing request to fetch paginated email records.");

        var result = await _sender.Send(query);

        if (!result.Success)
        {
            _logger.LogWarning("Failed to fetch email records: {Message}", result.Data);
            return BadRequest(result);
        }

        _logger.LogInformation("Successfully fetched paginated email records.");
        return Ok(result);
    }

    /// <summary>
    /// Registers a new email record in the external service.
    /// </summary>
    /// <param name="command">The data required to create a new email record.</param>
    /// <returns>Returns the operation result.</returns>
    [HttpPost]
    [Authorize(Roles = $"{RoleConstants.EMPLOYEE_EXEMPLE}, {RoleConstants.ADMIN_EXEMPLE}")]
    [ProducesResponseType(typeof(CreateEmailResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> Create([FromBody] CreateEmailCommand command)
    {
        _logger.LogInformation("Processing request to create a new email record.");

        var result = await _sender.Send(command);

        if (!result.Success)
        {
            _logger.LogWarning("Failed to create email record: {Message}", result.Data);
            return BadRequest(result);
        }

        _logger.LogInformation("Successfully created a new email record.");
        return Ok(result);
    }
}

