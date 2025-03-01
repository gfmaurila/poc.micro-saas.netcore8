﻿using Common.External.Auth.Net8.Response;
using MediatR;
using System.ComponentModel.DataAnnotations;

namespace API.External.Auth.Feature.Auth.Login;

public class AuthCommand : IRequest<ApiResult<AuthTokenResponse>>
{
    [Required]
    [MaxLength(200)]
    [DataType(DataType.EmailAddress)]
    public string Email { get; set; }

    [Required]
    public string Password { get; set; }
}