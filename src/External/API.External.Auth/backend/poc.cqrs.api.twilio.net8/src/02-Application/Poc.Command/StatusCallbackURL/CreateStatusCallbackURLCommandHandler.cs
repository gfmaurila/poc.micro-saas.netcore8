using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.Logging;
using poc.core.api.net8.Interface;
using Poc.Contract.Command.StatusCallbackURL.Request;

namespace Poc.Command.StatusCallbackURL;

public class CreateStatusCallbackURLCommandHandler : IRequestHandler<CreateCallbackURLCommand, Result>
{
    private readonly ILogger<CreateStatusCallbackURLCommandHandler> _logger;
    private readonly IRedisCacheService<CreateCallbackURLCommand> _redis;
    public CreateStatusCallbackURLCommandHandler(ILogger<CreateStatusCallbackURLCommandHandler> logger,
                                                 IRedisCacheService<CreateCallbackURLCommand> redis)
    {
        _logger = logger;
        _redis = redis;
    }
    public async Task<Result> Handle(CreateCallbackURLCommand request, CancellationToken cancellationToken)
    {
        var cacheKey = nameof(CreateCallbackURLCommand) + "_" + Guid.NewGuid().ToString();
        await _redis.SetAsync(cacheKey, request);
        return Result.SuccessWithMessage("Mensagem enviada com sucesso!");
    }
}
