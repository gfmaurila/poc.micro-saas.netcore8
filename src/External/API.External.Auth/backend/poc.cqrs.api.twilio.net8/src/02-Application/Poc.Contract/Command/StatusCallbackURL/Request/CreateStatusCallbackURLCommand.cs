using Ardalis.Result;
using MediatR;
using Poc.Contract.Command.StatusCallbackURL.Request.DTO;

namespace Poc.Contract.Command.StatusCallbackURL.Request;

public class CreateCallbackURLCommand : IRequest<Result>
{
    public CreateStatusCallbackURLDTO CreateStatusCallbackURL { get; set; }
    public CreateStatusCallbackURLCancelDTO CreateStatusCallbackURLCancel { get; set; }
    public CreateStatusCallbackURLConfirmDTO CreateStatusCallbackURLConfirm { get; set; }
}

