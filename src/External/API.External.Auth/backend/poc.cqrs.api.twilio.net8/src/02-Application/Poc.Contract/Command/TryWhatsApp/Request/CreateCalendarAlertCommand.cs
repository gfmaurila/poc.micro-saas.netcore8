using Ardalis.Result;
using MediatR;
using poc.core.api.net8.Enumerado;
using Poc.Contract.Command.TryWhatsApp.Request.DTO;

namespace Poc.Contract.Command.TryWhatsApp.Request;
public class CreateCalendarAlertCommand : IRequest<Result>
{
    public AuthDTO Auth { get; set; }
    public string To { get; set; }
    public ENotificationType Notification { get; set; }
    public string Body { get; set; }
}

