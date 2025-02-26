using API.External.Auth.Infrastructure.Database.Repositories.Interfaces;
using Common.External.Auth.Net8.Interface;
using Common.External.Auth.Net8.Response;
using MediatR;

namespace API.External.Auth.Feature.Auth.ResetPassword;

public class AuthResetPasswordCommandHandler : IRequestHandler<AuthResetPasswordCommand, ApiResult<AuthResetPasswordResponse>>
{
    private readonly IAuthService _authService;
    private readonly IUserRepository _repo;
    private readonly IMediator _mediator;
    private readonly AuthResetPasswordCommandValidator _validator;

    public AuthResetPasswordCommandHandler(IAuthService authService,
                                           IUserRepository repo,
                                           IMediator mediator,
                                           AuthResetPasswordCommandValidator validator)
    {
        _authService = authService;
        _repo = repo;
        _mediator = mediator;
        _validator = validator;
    }

    public async Task<ApiResult<AuthResetPasswordResponse>> Handle(AuthResetPasswordCommand request, CancellationToken cancellationToken)
    {
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return ApiResult<AuthResetPasswordResponse>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);

        // Busca os dados do usuarios 
        var auth = await _repo.GetByEmailAsync(request.Email);

        //Se não existir, erro no login
        if (auth is null)
            return ApiResult<AuthResetPasswordResponse>.CreateError(
                new List<ErrorDetail> {
                    new ErrorDetail("E-mail inválidos.")
                },
                400);

        auth.AuthResetEvent();

        // Executa eventos
        foreach (var domainEvent in auth.DomainEvents)
            await _mediator.Publish(domainEvent);

        auth.ClearDomainEvents();

        return ApiResult<AuthResetPasswordResponse>.CreateSuccess(new AuthResetPasswordResponse(), "Uma mensagem foi enviada para o seu e-mail ou celular!");
    }


}
