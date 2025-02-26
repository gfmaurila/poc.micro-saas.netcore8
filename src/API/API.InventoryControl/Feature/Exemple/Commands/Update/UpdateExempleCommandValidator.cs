using Common.Core._08.Domain.Enumerado;
using FluentValidation;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Update;

/// <summary>
/// Validator for the <see cref="UpdateExempleCommand"/> class, ensuring that all required fields
/// are provided and correctly formatted.
/// </summary>
public class UpdateExempleCommandValidator : AbstractValidator<UpdateExempleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="UpdateExempleCommandValidator"/> class.
    /// Defines validation rules for updating an Exemple entity.
    /// </summary>
    public UpdateExempleCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("The ID of the Exemple entity must not be empty.");

        RuleFor(command => command.FirstName)
            .NotEmpty()
            .WithMessage("First name is required.")
            .MaximumLength(100)
            .WithMessage("First name cannot exceed 100 characters.");

        RuleFor(command => command.LastName)
            .NotEmpty()
            .WithMessage("Last name is required.")
            .MaximumLength(100)
            .WithMessage("Last name cannot exceed 100 characters.");

        RuleFor(command => command.Email)
            .NotEmpty()
            .WithMessage("Email is required.")
            .MaximumLength(254)
            .WithMessage("Email cannot exceed 254 characters.")
            .EmailAddress()
            .WithMessage("Invalid email format.");

        // Validation for Gender, ensuring a valid value is selected.
        RuleFor(command => command.Gender)
            .Must(gender => gender != EGender.None)
            .WithMessage("Please select a valid gender. 'Not specified' is not a permitted option.");

        RuleFor(command => command.Role)
            .Must(roleList => roleList != null && roleList.Any())
            .WithMessage("At least one role must be assigned.");
    }
}

