namespace API.Customer.Controllers;

using API.Customer.Feature.Notification;
using Common.Core._08.Domain.Model;
using Common.Core._08.Response;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

/// <summary>
/// Controller responsible for sending notifications via Kafka and RabbitMQ,
/// integrating with an API for email and WhatsApp dispatch.
/// </summary>
[ApiController]
[Route("api/v1/[controller]")]
public class NotificationController : BaseController
{
    private readonly ISender _sender;
    private readonly ILogger<NotificationController> _logger;

    /// <summary>
    /// Initializes a new instance of the <see cref="NotificationController"/> class.
    /// </summary>
    /// <param name="sender">Mediator instance for handling commands.</param>
    /// <param name="logger">Logger instance for logging operations.</param>
    public NotificationController(ISender sender, ILogger<NotificationController> logger)
    {
        _sender = sender;
        _logger = logger;
    }

    /// <summary>
    /// Sends a new notification using Kafka or RabbitMQ, integrating with an external API for email and WhatsApp dispatch.
    /// </summary>
    /// <param name="command">The notification details to be sent.</param>
    /// <returns>Returns the operation result.</returns>
    [HttpPost]
    [Authorize(Roles = $"{RoleConstants.EMPLOYEE_EXEMPLE}, {RoleConstants.ADMIN_EXEMPLE}")]
    [ProducesResponseType(typeof(CreateNotificationResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    public async Task<IActionResult> SendNotification([FromBody] CreateNotificationCommand command)
    {
        _logger.LogInformation("Processing notification request...");

        // Sends the command to the handler
        var result = await _sender.Send(command);

        // Logs the result
        if (!result.Success)
        {
            _logger.LogWarning("Notification request failed: {Message}", result.Data);
            return BadRequest(result);
        }

        _logger.LogInformation("Notification request processed successfully.");
        return Ok(result);
    }
}

