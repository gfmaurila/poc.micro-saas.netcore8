using API.External.Auth.Feature.Users.DeleteUser;
using Carter;
using Common.External.Auth.Net8.API.Models;
using Common.External.Auth.Net8.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace poc.vertical.slices.net8.Endpoints.User;
public class DeleteUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapDelete("api/v1/user/{id}", HandleDeleteUser)
            .WithName("DeleteUser")
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status404NotFound)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
             .WithOpenApi(x => new OpenApiOperation(x)
             {
                 Summary = "Deletar usuário",
                 Description = "deletar usuário",
                 Tags = new List<OpenApiTag>
                {
                    new OpenApiTag
                    {
                        Name = "Usuários"
                    }
                }
             })
            .RequireAuthorization(new AuthorizeAttribute { Roles = $"{RoleUserAuthConstants.ADMIN_AUTH}, {RoleUserAuthConstants.EMPLOYEE_AUTH}" })
            ;
    }
    private async Task<IResult> HandleDeleteUser(Guid id, ISender sender)
    {
        var result = await sender.Send(new DeleteUserCommand(id));

        if (!result.Success)
            return Results.BadRequest(result);

        return Results.Ok(result);
    }
}
