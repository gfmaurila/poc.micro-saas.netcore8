using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Infrastructure;
using System.Text;

namespace Common.Core._08.Extensions;

/// <summary>
/// Provides extension methods for creating customized <see cref="ProblemDetails"/> objects.
/// </summary>
public static class ProblemDetailsExtensions
{
    /// <summary>
    /// Creates a <see cref="ProblemDetails"/> instance for a "Not Found" (404) response.
    /// </summary>
    /// <param name="detailsFactory">The factory used to create the <see cref="ProblemDetails"/>.</param>
    /// <param name="context">The current HTTP context.</param>
    /// <param name="details">Optional additional details about the problem.</param>
    /// <param name="errors">Optional collection of error messages.</param>
    /// <returns>A customized <see cref="ProblemDetails"/> instance.</returns>
    public static ProblemDetails CreateNotFound(
        this ProblemDetailsFactory detailsFactory,
        HttpContext context,
        string? details = null,
        IEnumerable<string>? errors = null)
    {
        return CreateProblemDetailsWith(detailsFactory, StatusCodes.Status404NotFound, context, details, errors);
    }

    /// <summary>
    /// Creates a <see cref="ProblemDetails"/> instance for a "Bad Request" (400) response.
    /// </summary>
    /// <param name="detailsFactory">The factory used to create the <see cref="ProblemDetails"/>.</param>
    /// <param name="context">The current HTTP context.</param>
    /// <param name="details">Optional additional details about the problem.</param>
    /// <param name="errors">Optional collection of error messages.</param>
    /// <returns>A customized <see cref="ProblemDetails"/> instance.</returns>
    public static ProblemDetails CreateBadRequest(
        this ProblemDetailsFactory detailsFactory,
        HttpContext context,
        string? details = null,
        IEnumerable<string>? errors = null)
    {
        return CreateProblemDetailsWith(detailsFactory, StatusCodes.Status400BadRequest, context, details, errors);
    }

    /// <summary>
    /// Creates a <see cref="ProblemDetails"/> instance for a "Conflict" (409) response.
    /// </summary>
    /// <param name="detailsFactory">The factory used to create the <see cref="ProblemDetails"/>.</param>
    /// <param name="context">The current HTTP context.</param>
    /// <param name="details">Optional additional details about the problem.</param>
    /// <param name="errors">Optional collection of error messages.</param>
    /// <returns>A customized <see cref="ProblemDetails"/> instance.</returns>
    public static ProblemDetails CreateConflict(
        this ProblemDetailsFactory detailsFactory,
        HttpContext context,
        string? details = null,
        IEnumerable<string>? errors = null)
    {
        return CreateProblemDetailsWith(detailsFactory, StatusCodes.Status409Conflict, context, details, errors);
    }

    /// <summary>
    /// Creates a <see cref="ProblemDetails"/> instance for a validation error.
    /// </summary>
    /// <param name="detailsFactory">The factory used to create the <see cref="ProblemDetails"/>.</param>
    /// <param name="context">The current HTTP context.</param>
    /// <param name="details">Optional additional details about the problem.</param>
    /// <param name="errors">Optional collection of validation errors.</param>
    /// <returns>A customized <see cref="ProblemDetails"/> instance.</returns>
    public static ProblemDetails CreateValidation(
        this ProblemDetailsFactory detailsFactory,
        HttpContext context,
        string? details = null,
        IEnumerable<string>? errors = null)
    {
        return CreateProblemDetailsWith(detailsFactory, StatusCodes.Status400BadRequest, context, details, errors);
    }

    /// <summary>
    /// Creates a <see cref="ProblemDetails"/> instance for an unexpected response (500).
    /// </summary>
    /// <param name="detailsFactory">The factory used to create the <see cref="ProblemDetails"/>.</param>
    /// <param name="context">The current HTTP context.</param>
    /// <param name="details">Optional additional details about the problem.</param>
    /// <param name="errors">Optional collection of error messages.</param>
    /// <returns>A customized <see cref="ProblemDetails"/> instance.</returns>
    public static ProblemDetails CreateUnexpectedResponse(
        this ProblemDetailsFactory detailsFactory,
        HttpContext context,
        string? details = null,
        IEnumerable<string>? errors = null)
    {
        return CreateProblemDetailsWith(detailsFactory, StatusCodes.Status500InternalServerError, context, details, errors);
    }

    /// <summary>
    /// Creates a customized <see cref="ProblemDetails"/> instance with the specified parameters.
    /// </summary>
    /// <param name="detailsFactory">The factory used to create the <see cref="ProblemDetails"/>.</param>
    /// <param name="statusCode">The HTTP status code for the problem.</param>
    /// <param name="context">The current HTTP context.</param>
    /// <param name="message">Optional additional message about the problem.</param>
    /// <param name="errors">Optional collection of error messages.</param>
    /// <returns>A customized <see cref="ProblemDetails"/> instance.</returns>
    private static ProblemDetails CreateProblemDetailsWith(
        ProblemDetailsFactory detailsFactory,
        int statusCode,
        HttpContext context,
        string? message = null,
        IEnumerable<string>? errors = null)
    {
        if (errors != null && errors.Any())
        {
            StringBuilder errorList = new StringBuilder();
            errorList.AppendJoin(",", errors);

            return detailsFactory.CreateProblemDetails(context, statusCode: statusCode, detail: errorList.ToString());
        }
        else
        {
            return detailsFactory.CreateProblemDetails(context, statusCode: statusCode, detail: message);
        }
    }
}

