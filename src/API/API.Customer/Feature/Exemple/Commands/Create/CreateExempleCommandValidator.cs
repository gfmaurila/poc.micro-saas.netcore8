using Common.Core._08.Domain.Enumerado;
using FluentValidation;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Create;

/// <summary>
/// Validator for the <see cref="CreateExempleCommand"/> class, ensuring that the provided data is valid.
/// </summary>
public class CreateExempleCommandValidator : AbstractValidator<CreateExempleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="CreateExempleCommandValidator"/> class.
    /// Defines validation rules for creating an Exemple entity.
    /// </summary>
    public CreateExempleCommandValidator()
    {
        RuleFor(command => command.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .MaximumLength(100)
            .WithMessage("First name must not exceed 100 characters.");

        RuleFor(command => command.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .MaximumLength(100)
            .WithMessage("Last name must not exceed 100 characters.");

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .MaximumLength(254)
            .WithMessage("Email must not exceed 254 characters.")
            .EmailAddress()
            .WithMessage("A valid email address is required.");

        // Validation for Gender, ensuring a valid value is selected
        RuleFor(command => command.Gender)
            .Must(gender => gender != EGender.None)
            .WithMessage("Please select a valid gender. 'Not specified' is not a permitted option.");

        RuleFor(command => command.Role)
            .Must(roleList => roleList != null && roleList.Any())
            .WithMessage("At least one role is required.");
    }
}
