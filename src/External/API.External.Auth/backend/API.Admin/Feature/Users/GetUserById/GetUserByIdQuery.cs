using API.External.Auth.Feature.Users.GetUser;
using Common.External.Auth.Net8.Response;
using MediatR;

namespace API.External.Auth.Feature.Users.GetUserById;


public class GetUserByIdQuery : IRequest<ApiResult<UserQueryModel>>
{
    public GetUserByIdQuery(Guid id)
    {
        Id = id;
    }
    public Guid Id { get; private set; }
}