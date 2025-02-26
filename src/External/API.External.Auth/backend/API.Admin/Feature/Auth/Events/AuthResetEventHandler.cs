using API.External.Auth.Domain.User.Events.Auth;
using API.External.Auth.Feature.Notification;
using Common.External.Auth.Net8.AppSettings;
using Common.External.Auth.Net8.Enumerado;
using Common.External.Auth.Net8.Helper;
using Common.External.Auth.Net8.Interface;
using MediatR;

namespace API.External.Auth.Feature.Auth.Events;

public class AuthResetEventHandler : INotificationHandler<AuthResetEvent>
{
    private readonly IMediator _mediator;
    private readonly IConfiguration _configuration;
    private readonly IAuthService _authService;

    public AuthResetEventHandler(IMediator mediator,
                                 IConfiguration configuration,
                                 IAuthService authService)
    {
        _mediator = mediator;
        _configuration = configuration;
        _authService = authService;
    }

    public async Task Handle(AuthResetEvent authevent, CancellationToken cancellationToken)
    {
        //var token = _authService.GenerateJwtToken(authevent.Id.ToString(), authevent.Email);

        //// Envio de aviso por email
        //if (authevent.Notification == ENotificationType.Email)
        //    await EmailCommand(authevent, token);

        //// Envio de aviso por SMS
        //if (authevent.Notification == ENotificationType.SMS)
        //    await SMSCommand(authevent, token);

        //// envio de aviso por WhatsApp
        //if (authevent.Notification == ENotificationType.WhatsApp)
        //    await WhatsAppCommand(authevent, token);

        await WhatsAppCommand(authevent);
    }

    #region Email, WhatsApp e SMS
    private async Task WhatsAppCommand(AuthResetEvent authevent)
    {
        // ....
        await _mediator.Send(new CreateNotificationWhatsAppCommand()
        {
            From = "teste@teste.com",
            NotificationType = ENotificationType.WhatsApp,
            Body = Email(authevent),
            To = authevent.Phone // Phone
        });
    }


    private async Task WhatsAppCommand(AuthResetEvent authevent, string token)
    {
        // ....
        await _mediator.Send(new CreateNotificationWhatsAppCommand()
        {
            From = _configuration.GetValue<string>(AuthConsts.NEWPASSWORD_FROM),
            NotificationType = ENotificationType.WhatsApp,
            Body = Email(authevent, token),
            To = authevent.Phone // Phone
        });
    }

    private async Task SMSCommand(AuthResetEvent authevent, string token)
    {
        // ....
    }

    private async Task EmailCommand(AuthResetEvent authevent, string token)
    {
        // ....
    }

    private string Email(AuthResetEvent entity, string token)
    {
        var passwordResetInfo = new PasswordResetInfo
        {
            UserName = entity.FirstName,
            ResetLink = $"{_configuration.GetValue<string>(AuthConsts.NEWPASSWORD)}{token}",
            ExpiryTime = TimeSpan.FromHours(2)
        };
        return EmailHelper.GeneratePasswordResetMessage(passwordResetInfo); ;
    }

    private string Email(AuthResetEvent entity)
    {
        var passwordResetInfo = new PasswordResetInfo
        {
            UserName = entity.FirstName,
            ResetLink = $"{_configuration.GetValue<string>(AuthConsts.NEWPASSWORD)}",
            ExpiryTime = TimeSpan.FromHours(2)
        };
        return EmailHelper.GeneratePasswordResetMessage(passwordResetInfo); ;
    }
    #endregion
}
