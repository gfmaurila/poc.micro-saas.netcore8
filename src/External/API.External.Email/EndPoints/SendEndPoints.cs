using API.External.Email.Model;
using Microsoft.OpenApi.Models;
using poc.api.redis.Service;

namespace poc.api.redis.EndPoints;
public static class SendEndPoints
{
    public static void RegisterSendEndpoints(this IEndpointRouteBuilder app)
    {
        app.MapGet("/api/listsend", async (ISendService _service) =>
        {
            var produto = await _service.Get();
            if (produto is null)
                return Results.NotFound();

            return TypedResults.Ok(produto);
        })
        .WithName("ListSend")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Lista",
            Description = "Lista",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Send" } }
        });

        app.MapPost("/api/createsend", async (SendModel entity, ISendService _service) =>
        {
            if (entity is null)
                return Results.NotFound();

            return Results.Created($"{entity.Id}", await _service.Post(entity));
        })
        .WithName("CreateSend")
        .WithOpenApi(x => new OpenApiOperation(x)
        {
            Summary = "Create",
            Description = "Create",
            Tags = new List<OpenApiTag> { new OpenApiTag { Name = "Send" } }
        });
    }
}
