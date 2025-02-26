using FluentValidation;

namespace API.Exemple1.Core._08.Feature.Exemple.Queries.GetById;

/// <summary>
/// Validator for the <see cref="GetExempleByIdQuery"/> class, ensuring that the provided ID is valid.
/// </summary>
public class GetExempleByIdQueryValidator : AbstractValidator<GetExempleByIdQuery>
{
    /// <summary>
    /// Initializes a new instance of the <see cref="GetExempleByIdQueryValidator"/> class.
    /// Defines validation rules for retrieving an Exemple entity by its ID.
    /// </summary>
    public GetExempleByIdQueryValidator()
    {
        RuleFor(command => command.Id)
            .NotEmpty()
            .WithMessage("The ID of the Exemple entity must not be empty.");
    }
}

