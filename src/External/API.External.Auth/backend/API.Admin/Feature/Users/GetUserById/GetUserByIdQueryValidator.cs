using FluentValidation;

namespace API.External.Auth.Feature.Users.GetUserById;


public class GetUserByIdQueryValidator : AbstractValidator<GetUserByIdQuery>
{
    public GetUserByIdQueryValidator()
    {
        RuleFor(command => command.Id).NotEmpty();
    }
}