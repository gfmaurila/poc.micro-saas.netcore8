namespace API.Exemple.Core._08.Controllers;

using API.Exemple.Core._08.Feature.Domain.Exemple.Models;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Create;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Delete;
using API.Exemple1.Core._08.Feature.Exemple.Commands.Update;
using API.Exemple1.Core._08.Feature.Exemple.Queries.Get;
using API.Exemple1.Core._08.Feature.Exemple.Queries.GetById;
using API.Exemple1.Core._08.Feature.Exemple.Queries.GetPaginate;
using Common.Core._08.Domain.Model;
using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller responsible for managing Exemple entities, including creation, retrieval, updating, and deletion.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class ExempleController : BaseController
{
    private readonly ISender _sender;
    private readonly ILogger<ExempleController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="ExempleController"/> class.
    /// </summary>
    /// <param name="sender">Mediator instance for handling requests.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public ExempleController(ISender sender, ILogger<ExempleController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    /// <summary>
    /// Retrieves a list of all Exemple entities.
    /// </summary>
    /// <returns>A list of all registered Exemple entities.</returns>
    [HttpGet]
    [Authorize(Roles = $"{RoleConstants.EMPLOYEE_EXEMPLE}, {RoleConstants.ADMIN_EXEMPLE}")]
    [ProducesResponseType(typeof(ApiResponse<List<ExempleQueryModel>>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> GetAllExemple()
    {
        _logger.LogInformation("Fetching all Exemple records.");
        var result = await _sender.Send(new GetExempleQuery());

        if (!result.Success)
        {
            _logger.LogWarning("Failed to retrieve Exemple records.");
            return BadRequest(result);
        }

        _logger.LogInformation("Successfully retrieved Exemple records.");
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a paginated list of Exemple entities based on query parameters.
    /// </summary>
    /// <param name="query">Pagination and filtering parameters.</param>
    /// <param name="cancellationToken">Token for request cancellation.</param>
    /// <returns>A paginated result of Exemple entities.</returns>
    [HttpGet("exemple")]
    [Authorize(Roles = $"{RoleConstants.EMPLOYEE_EXEMPLE}, {RoleConstants.ADMIN_EXEMPLE}")]
    [ProducesResponseType(typeof(ApiResult<GetPaginateExempleQueryResult>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> GetAllExemple([FromQuery] GetPaginateExempleQuery query, CancellationToken cancellationToken)
    {
        _logger.LogInformation("Fetching paginated Exemple records.");
        var result = await _sender.Send(query);

        if (!result.Success)
        {
            _logger.LogWarning("Failed to retrieve paginated Exemple records.");
            return BadRequest(result);
        }

        _logger.LogInformation("Successfully retrieved paginated Exemple records.");
        return Ok(result);
    }

    /// <summary>
    /// Retrieves a specific Exemple entity by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the Exemple entity.</param>
    /// <returns>The Exemple entity corresponding to the specified ID.</returns>
    [HttpGet("{id}")]
    [Authorize(Roles = $"{RoleConstants.EMPLOYEE_EXEMPLE}, {RoleConstants.ADMIN_EXEMPLE}")]
    [ProducesResponseType(typeof(ApiResponse<ExempleQueryModel>), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    public async Task<IActionResult> GetExempleById(Guid id)
    {
        _logger.LogInformation("Fetching Exemple record with ID: {Id}", id);
        var query = new GetExempleByIdQuery(id);
        var result = await _sender.Send(query);

        if (!result.Success)
        {
            _logger.LogWarning("Failed to retrieve Exemple record with ID: {Id}", id);
            return BadRequest(result);
        }

        _logger.LogInformation("Successfully retrieved Exemple record with ID: {Id}", id);
        return Ok(result);
    }

    /// <summary>
    /// Creates a new Exemple entity.
    /// </summary>
    /// <param name="command">The data required to create an Exemple entity.</param>
    /// <returns>The result of the creation operation.</returns>
    [HttpPost]
    [Authorize(Roles = $"{RoleConstants.ADMIN_AUTH}, {RoleConstants.EMPLOYEE_AUTH}")]
    [ProducesResponseType(typeof(CreateExempleResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> CreateExemple([FromBody] CreateExempleCommand command)
    {
        _logger.LogInformation("Creating a new Exemple entity.");
        var result = await _sender.Send(command);

        if (!result.Success)
        {
            _logger.LogWarning("Failed to create Exemple entity.");
            return BadRequest(result);
        }

        _logger.LogInformation("Successfully created Exemple entity.");
        return Ok(result);
    }

    /// <summary>
    /// Updates an existing Exemple entity.
    /// </summary>
    /// <param name="command">The updated data for the Exemple entity.</param>
    /// <returns>The result of the update operation.</returns>
    [HttpPut]
    [Authorize(Roles = $"{RoleConstants.ADMIN_AUTH}, {RoleConstants.EMPLOYEE_AUTH}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> UpdateExemple([FromBody] UpdateExempleCommand command)
    {
        _logger.LogInformation("Updating Exemple entity.");
        var result = await _sender.Send(command);

        if (!result.Success)
        {
            _logger.LogWarning("Failed to update Exemple entity.");
            return BadRequest(result);
        }

        _logger.LogInformation("Successfully updated Exemple entity.");
        return Ok(result);
    }

    /// <summary>
    /// Deletes an Exemple entity by its ID.
    /// </summary>
    /// <param name="id">The unique identifier of the Exemple entity to be deleted.</param>
    /// <returns>The result of the deletion operation.</returns>
    [HttpDelete("{id}")]
    [Authorize(Roles = $"{RoleConstants.EMPLOYEE_EXEMPLE}, {RoleConstants.ADMIN_EXEMPLE}")]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    public async Task<IActionResult> DeleteExemple(Guid id)
    {
        _logger.LogInformation("Deleting Exemple entity with ID: {Id}", id);
        var result = await _sender.Send(new DeleteExempleCommand(id));

        if (!result.Success)
        {
            _logger.LogWarning("Failed to delete Exemple entity with ID: {Id}", id);
            return BadRequest(result);
        }

        _logger.LogInformation("Successfully deleted Exemple entity with ID: {Id}", id);
        return Ok(result);
    }
}
