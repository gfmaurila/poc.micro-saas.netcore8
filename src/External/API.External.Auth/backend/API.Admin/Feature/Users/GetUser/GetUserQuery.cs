using Common.External.Auth.Net8.Response;
using MediatR;

namespace API.External.Auth.Feature.Users.GetUser;

public class GetUserQuery : IRequest<ApiResult<List<UserQueryModel>>>
{
    public GetUserQuery()
    {
    }
}
