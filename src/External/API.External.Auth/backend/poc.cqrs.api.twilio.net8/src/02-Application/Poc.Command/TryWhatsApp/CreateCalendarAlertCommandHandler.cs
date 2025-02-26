using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Poc.Auth.Twilio.Interfaces;
using Poc.Contract.Command.TryWhatsApp.Request;

namespace Poc.Command.TryWhatsApp;

public class CreateCalendarAlertCommandHandler : IRequestHandler<CreateCalendarAlertCommand, Result>
{
    private readonly ILogger<CreateCalendarAlertCommandHandler> _logger;
    private readonly ITwilioService _twilioService;
    public CreateCalendarAlertCommandHandler(ILogger<CreateCalendarAlertCommandHandler> logger,
                                      ITwilioService twilioService)
    {
        _logger = logger;
        _twilioService = twilioService;
    }
    public async Task<Result> Handle(CreateCalendarAlertCommand request, CancellationToken cancellationToken)
    {
        await _twilioService.CalendarAlertAsync(request);
        return Result.SuccessWithMessage("Mensagem enviada com sucesso!");
    }
}
