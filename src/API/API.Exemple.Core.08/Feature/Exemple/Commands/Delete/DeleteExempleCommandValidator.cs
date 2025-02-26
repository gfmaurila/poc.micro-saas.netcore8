using FluentValidation;

namespace API.Exemple1.Core._08.Feature.Exemple.Commands.Delete;

/// <summary>
/// Validator for the <see cref="DeleteExempleCommand"/> class, ensuring that the provided data is valid.
/// </summary>
public class DeleteExempleCommandValidator : AbstractValidator<DeleteExempleCommand>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="DeleteExempleCommandValidator"/> class.
    /// Defines validation rules for deleting an Exemple entity.
    /// </summary>
    public DeleteExempleCommandValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("The ID of the Exemple entity must not be empty.");
    }
}
