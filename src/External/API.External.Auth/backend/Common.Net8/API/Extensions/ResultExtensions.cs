﻿using Ardalis.Result;
using Common.External.Auth.Net8.API.Models;
using Microsoft.AspNetCore.Mvc;

namespace Common.External.Auth.Net8.API.Extensions;
public static class ResultExtensions
{
    public static IActionResult ToActionResult(this Result result)
        => result.IsSuccess
            ? new OkObjectResult(ApiResponse.Ok(result.SuccessMessage))
            : result.ToHttpNonSuccessResult();

    public static IActionResult ToActionResult<T>(this Result<T> result)
        => result.IsSuccess
            ? new OkObjectResult(ApiResponse<T>.Ok(result.Value, result.SuccessMessage))
            : result.ToHttpNonSuccessResult();

    private static IActionResult ToHttpNonSuccessResult(this Ardalis.Result.IResult result)
    {
        var errors = result.Errors.Select(error => new ApiError(error)).ToList();

        switch (result.Status)
        {
            case ResultStatus.Invalid:

                var validationErrors = result
                    .ValidationErrors
                    .ConvertAll(validation => new ApiError(validation.ErrorMessage));

                return new BadRequestObjectResult(ApiResponse.BadRequest(validationErrors));

            case ResultStatus.NotFound:
                return new NotFoundObjectResult(ApiResponse.NotFound(errors));

            case ResultStatus.Unauthorized:
                return new UnauthorizedObjectResult(ApiResponse.Unauthorized(errors));

            default:
                return new BadRequestObjectResult(ApiResponse.BadRequest(errors));
        }
    }
}
