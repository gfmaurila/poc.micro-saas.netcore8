using Common.External.Auth.Net8.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace API.External.Auth.Feature.Users.UpdateRole;

public class UpdateRoleUserCommand : IRequest<ApiResult<UpdateRoleUserResponse>>
{
    [Required]
    public Guid Id { get; set; }

    public List<string> RoleUserAuth { get; set; } = new List<string>();
}
