using API.External.Auth.Feature.Auth.AuthNewPassword;
using Carter;
using Common.External.Auth.Net8.API.Models;
using MediatR;
using Microsoft.OpenApi.Models;

namespace poc.vertical.slices.net8.Endpoints.Auth;

public class AuthNewPasswordEndpoint : ICarterModule
{
    public void AddRoutes(IEndpointRouteBuilder app)
    {
        app.MapPost("api/v1/newpassword", HandleResetPassword)
            .WithName("AuthNewPassword")
            .Produces<AuthNewPasswordResponse>(StatusCodes.Status200OK)
            .Produces<ApiResponse>(StatusCodes.Status400BadRequest)
            .Produces<ApiResponse>(StatusCodes.Status500InternalServerError)
            .WithOpenApi(x =>
            {
                x.OperationId = "AuthNewPassword";
                x.Summary = "AuthNewPassword";
                x.Description = "AuthNewPassword";
                x.Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Auth" } };
                return x;
            })
            ;
    }
    private async Task<IResult> HandleResetPassword(AuthNewPasswordCommand command, ISender sender)
    {
        var result = await sender.Send(command);
        if (!result.Success)
            return Results.BadRequest(result);
        return Results.Ok(result);
    }
}