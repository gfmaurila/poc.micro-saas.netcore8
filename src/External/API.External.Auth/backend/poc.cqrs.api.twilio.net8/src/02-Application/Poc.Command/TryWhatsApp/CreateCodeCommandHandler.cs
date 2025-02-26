using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using Poc.Auth.Twilio.Interfaces;
using Poc.Contract.Command.TryWhatsApp.Request;

namespace Poc.Command.TryWhatsApp;

public class CreateCodeCommandHandler : IRequestHandler<CreateCodeCommand, Result>
{
    private readonly ILogger<CreateCodeCommandHandler> _logger;
    private readonly ITwilioService _twilioService;
    public CreateCodeCommandHandler(ILogger<CreateCodeCommandHandler> logger,
                             ITwilioService twilioService)
    {
        _logger = logger;
        _twilioService = twilioService;
    }
    public async Task<Result> Handle(CreateCodeCommand request, CancellationToken cancellationToken)
    {
        await _twilioService.CodeAsync(request);
        return Result.SuccessWithMessage("Mensagem enviada com sucesso!");
    }
}
