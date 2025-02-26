using Common.External.Auth.Net8;

namespace API.External.Auth.Feature.Users.UpdatePassword;

public class UpdatePasswordUserResponse : BaseResponse
{
    public UpdatePasswordUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
