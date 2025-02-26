using Common.External.Auth.Net8;

namespace API.External.Auth.Feature.Users.UpdateEmail;

public class UpdateEmailUserResponse : BaseResponse
{
    public UpdateEmailUserResponse(Guid id) => Id = id;
    public Guid Id { get; }
}
