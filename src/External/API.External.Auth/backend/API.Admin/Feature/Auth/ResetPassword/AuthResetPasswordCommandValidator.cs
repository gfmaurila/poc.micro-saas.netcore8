using FluentValidation;

namespace API.External.Auth.Feature.Auth.ResetPassword;
public class AuthResetPasswordCommandValidator : AbstractValidator<AuthResetPasswordCommand>
{
    public AuthResetPasswordCommandValidator()
    {
        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage("O campo de e-mail é obrigatório.")
            .EmailAddress()
            .WithMessage("O e-mail fornecido não é válido.")
            .MaximumLength(200)
            .WithMessage("O e-mail não pode ter mais de 200 caracteres.");
    }
}