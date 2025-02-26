using Common.External.Auth.Net8.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace API.External.Auth.Feature.Auth.ResetPassword;

public class AuthResetPasswordCommand : IRequest<ApiResult<AuthResetPasswordResponse>>
{
    [Required]
    [MaxLength(200)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }
}