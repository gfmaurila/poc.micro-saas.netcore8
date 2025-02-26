using MediatR;
using Microsoft.AspNetCore.Mvc;
using Poc.Contract.Command.TryWhatsApp.Request;
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
[ApiExplorerSettings(GroupName = "TryWhatsApp")]
public class TryWhatsAppController : ControllerBase
{
    private readonly IMediator _mediator;
    private readonly ILogger<TryWhatsAppController> _logger;

    /// <summary>
    /// Construtor do controlador de registro.
    /// </summary>
    /// <param name="logger">Serviço para log de operações e erros.</param>
    /// <param name="mediator">Mediador para operações CQRS.</param>
    public TryWhatsAppController(ILogger<TryWhatsAppController> logger, IMediator mediator)
    {
        _mediator = mediator;
        _logger = logger;
    }

    /// <summary>
    /// Envie uma mensagem de iniciativa empresarial
    /// Nesta etapa, você pode iniciar uma conversa comercial com seus usuários. 
    /// As conversas iniciadas pelos negócios exigiam o uso de modelos pré-aprovados até que o usuário respondesse. 
    /// Escolha um de nossos modelos pré-aprovados para iniciar uma conversa de negócios. 
    /// Depois que seus clientes responderem, você poderá enviar mensagens de formato gratuito nas próximas 24 horas após a mensagem original.
    /// 
    /// Agendamentos
    /// EX: Your appointment is coming up on July 21 at 3PM
    /// EX: Your appointment is coming up on {{1}} at {{2}}
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna a resposta com a mensagem de sucesso.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum registro é encontrado pelo Id fornecido.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPost("CalendarAlert")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    //[Authorize(Roles = $"{RoleUserAuthConstants.Notification}, {RoleUserAuthConstants.PostNotification}")]
    public async Task<IActionResult> SendBusinessInitiatedMessage([FromBody] CreateCalendarAlertCommand command)
        => (await _mediator.Send(command)).ToActionResult();

    /// <summary>
    /// Envie uma mensagem de iniciativa empresarial
    /// Nesta etapa, você pode iniciar uma conversa comercial com seus usuários. 
    /// As conversas iniciadas pelos negócios exigiam o uso de modelos pré-aprovados até que o usuário respondesse. 
    /// Escolha um de nossos modelos pré-aprovados para iniciar uma conversa de negócios. 
    /// Depois que seus clientes responderem, você poderá enviar mensagens de formato gratuito nas próximas 24 horas após a mensagem original.
    /// 
    /// Agendamentos
    /// EX: Your appointment is coming up on July 21 at 3PM
    /// EX: Your appointment is coming up on {{1}} at {{2}}
    /// </summary>
    /// <param name="command"></param>
    /// <response code="200">Retorna a resposta com a mensagem de sucesso.</response>
    /// <response code="400">Retorna lista de erros, se a requisição for inválida.</response>
    /// <response code="404">Quando nenhum registro é encontrado pelo Id fornecido.</response>
    /// <response code="500">Quando ocorre um erro interno inesperado no servidor.</response>
    [HttpPost("Code")]
    [Consumes(MediaTypeNames.Application.Json)]
    [Produces(MediaTypeNames.Application.Json)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status400BadRequest)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(ApiResponse), StatusCodes.Status500InternalServerError)]
    //[Authorize(Roles = $"{RoleUserAuthConstants.Notification}, {RoleUserAuthConstants.PostNotification}")]
    public async Task<IActionResult> Code([FromBody] CreateCodeCommand command)
        => (await _mediator.Send(command)).ToActionResult();

}
