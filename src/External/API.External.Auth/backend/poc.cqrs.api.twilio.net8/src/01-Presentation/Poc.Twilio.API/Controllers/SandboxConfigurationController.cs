using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.Contract.Command.StatusCallbackURL.Request;
using Poc.Twilio.API.Extensions;
using Poc.Twilio.API.Models;
using System.ComponentModel;
using System.Net.Mime;

namespace Poc.Twilio.API.Controllers;

/// <summary>
/// Controlador responsável por operações relacionadas a registro.
/// </summary>
[Route("api/v1/[controller]")]
[Produces("application/json")]
[ApiController]
[Description("Controller responsável por cadastrar registro.")]
[ApiExplorerSettings(GroupName = "SandboxConfiguration")]
public class SandboxConfigurationController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<SandboxConfigurationController> _logger;

    /// <summary>
    /// Construtor do controlador de registro.
    /// </summary>
    /// <param name="logger">Serviço para log de operações e erros.</param>
    /// <param name="mediator">Mediador para operações CQRS.</param>
    public SandboxConfigurationController(ILogger<SandboxConfigurationController> logger, IMediator mediator)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Sandbox Configuration
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna a resposta com a mensagem de sucesso.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum registro é encontrado pelo Id fornecido.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPost("StatusCallbackURL")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    //[Authorize(Roles = $"{RoleUserAuthConstants.Notification}, {RoleUserAuthConstants.PostNotification}")]
    public async Task<IActionResult> StatusCallbackURL([FromBody] CreateCallbackURLCommand command)
        => (await _mediator.Send(command)).ToActionResult();


}
