using API.External.Auth.Feature.Users.CreateUser;
using Carter;
using Common.External.Auth.Net8.API.Models;
using Common.External.Auth.Net8.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace poc.vertical.slices.net8.Endpoints.User;

public class CreateUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/user", HandleCreateUser)
            .WithName("CreateUser")
            .Produces<CreateUserResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x =>
            {
                x.OperationId = "CreateUser";
                x.Summary = "Inserir usuários";
                x.Description = "Cadastra um novo usuário no sistema.";
                x.Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Usuários" } };
                return x;
            })
            .RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleUserAuthConstants.ADMIN_AUTH}, {RoleUserAuthConstants.EMPLOYEE_AUTH}" })
            ;
    }
    private async Task<IResult> HandleCreateUser(CreateUserCommand command, ISender sender)
    {
        var result = await sender.Send(command);
        if (!result.Success)
            return Results.BadRequest(result);
        return Results.Ok(result);
    }
}