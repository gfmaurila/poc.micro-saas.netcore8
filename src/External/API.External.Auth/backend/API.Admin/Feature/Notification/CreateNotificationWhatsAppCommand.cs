using Ardalis.Result;
using Common.External.Auth.Net8.Enumerado;
using MediatR;

namespace API.External.Auth.Feature.Notification;

public class CreateNotificationWhatsAppCommand : IRequest<Result>
{
    public ENotificationType NotificationType { get; set; }

    public int Id { get; set; }
    public string From { get; set; }
    public string Body { get; set; }
    public string To { get; set; }
}
