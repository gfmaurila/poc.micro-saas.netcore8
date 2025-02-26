using API.External.Auth.Feature.Users.UpdateRole;
using Carter;
using Common.External.Auth.Net8.API.Models;
using Common.External.Auth.Net8.User;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.OpenApi.Models;

namespace poc.vertical.slices.net8.Endpoints.User;

public class UpdateRoleUserEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPut("api/v1/user/updaterole", HandleUpdateUserRole)
            .WithName("UpdateUserRole")
            .Produces<ApiResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status404NotFound)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x => new OpenApiOperation(x)
            {
                Summary = "Atualizar permissões de usuário",
                Description = "Atualiza as permissões de um usuário existente, identificado pelo ID no corpo da requisição. Permite modificar o nível de acesso ou as roles atribuídas ao usuário.",
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

    private async Task<IResult> HandleUpdateUserRole(UpdateRoleUserCommand command, ISender sender)
    {
        var result = await sender.Send(command);

        if (!result.Success)
            return Results.BadRequest(result);

        return Results.Ok(result);
    }
}
