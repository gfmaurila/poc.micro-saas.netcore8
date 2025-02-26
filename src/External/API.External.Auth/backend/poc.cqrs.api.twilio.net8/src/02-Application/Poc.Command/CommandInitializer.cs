using Ardalis.Result;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using Poc.Command.StatusCallbackURL;
using Poc.Command.TryWhatsApp;
using Poc.Contract.Command.StatusCallbackURL.Request;
using Poc.Contract.Command.TryWhatsApp.Request;

namespace Poc.Command;

public class CommandInitializer
{
    public static void Initialize(IServiceCollection services)
    {
        services.AddTransient<IRequestHandler<CreateCalendarAlertCommand, Result>, CreateCalendarAlertCommandHandler>();
        services.AddTransient<IRequestHandler<CreateCodeCommand, Result>, CreateCodeCommandHandler>();
        services.AddTransient<IRequestHandler<CreateCallbackURLCommand, Result>, CreateStatusCallbackURLCommandHandler>();
    }
}
