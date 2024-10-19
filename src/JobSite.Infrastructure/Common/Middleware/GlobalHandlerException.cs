
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using ChitChat.Domain.Exceptions;
using JobSite.Application.Common.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
using static JobSite.Application.Common.Models.CustomResponseError;
namespace JobSite.Infrastructure.Common.Middleware;
public class GlobalHandlerException : IExceptionHandler
{
    private readonly ILogger<GlobalHandlerException> _logger;

    public GlobalHandlerException(ILogger<GlobalHandlerException> logger)
    {
        _logger = logger;
    }

    public async ValueTask<bool> TryHandleAsync(HttpContext httpContext, Exception exception, CancellationToken cancellationToken)
    {
        _logger.LogError(exception, "Exception occurred: {Message}", exception.Message);
        var statusCode = (int)HttpStatusCode.InternalServerError;
        statusCode = exception switch
        {
            Application.Common.Exceptions.BaseException => (Application.Common.Exceptions.BaseException)exception switch
            {
                Application.Common.Exceptions.ForbiddenException => (int)HttpStatusCode.Forbidden,
                Application.Common.Exceptions.UnauthorizedException => (int)HttpStatusCode.Unauthorized,
                Application.Common.Exceptions.NotFoundException => (int)HttpStatusCode.NotFound,
                Application.Common.Exceptions.IntervalServerException => (int)HttpStatusCode.InternalServerError,
                Application.Common.Exceptions.ValidationException => (int)HttpStatusCode.BadRequest,
                _ => statusCode
            },
            ValidationException => (int)HttpStatusCode.BadRequest,
            ResourceNotFoundException => (int)HttpStatusCode.NotFound,
            _ => statusCode
        };
        // var errorCode = ErrorCodes.InternalServerError;
        var problemDetails = new ProblemDetails
        {
            Title = "Error",
            Status = statusCode,
            Detail = exception.Message
        };
        httpContext.Response.StatusCode = statusCode;
        await httpContext.Response.WriteAsJsonAsync(problemDetails);
        return true;
    }
}