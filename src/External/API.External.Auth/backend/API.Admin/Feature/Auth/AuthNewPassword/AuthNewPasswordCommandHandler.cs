using Common.External.Auth.Net8.Response;
using MediatR;

namespace API.External.Auth.Feature.Auth.AuthNewPassword;

public class AuthNewPasswordCommandHandler : IRequestHandler<AuthNewPasswordCommand, ApiResult<AuthNewPasswordResponse>>
{
    private readonly IMediator _mediator;
    private readonly AuthNewPasswordCommandValidator _validator;

    public AuthNewPasswordCommandHandler(IMediator mediator,
                                         AuthNewPasswordCommandValidator validator)
    {
        _mediator = mediator;
        _validator = validator;
    }

    public async Task<ApiResult<AuthNewPasswordResponse>> Handle(AuthNewPasswordCommand request, CancellationToken cancellationToken)
    {
        // Validanto a requisição.
        var validationResult = await _validator.ValidateAsync(request, cancellationToken);
        if (!validationResult.IsValid)
            return ApiResult<AuthNewPasswordResponse>.CreateError(
                validationResult.Errors.Select(e => new ErrorDetail(e.ErrorMessage)).ToList(),
                400);

        //var getToken = await _repo.GetAuthByToken(request.Token);
        //if (getToken == null)
        //    return Result.NotFound($"Nenhum registro encontrado");

        //await _mediator.Send(new UpdatePasswordUserCommand()
        //{
        //    Id = Guid.Parse(getToken.AuthId),
        //    Password = request.Password,
        //    ConfirmPassword = request.ConfirmPassword,
        //});

        //await _repo.Delete(getToken.Id);

        return ApiResult<AuthNewPasswordResponse>.CreateSuccess(new AuthNewPasswordResponse(), "Senha alterada com sucesso!");
    }
}
