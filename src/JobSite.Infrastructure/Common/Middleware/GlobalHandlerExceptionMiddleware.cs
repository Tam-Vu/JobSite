
using System.ComponentModel.DataAnnotations;
using System.Net;
using System.Text.Json;
using ChitChat.Domain.Exceptions;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ModelBinding;
using Microsoft.Extensions.Logging;
namespace JobSite.Infrastructure.Common.Middleware;
public class GlobalHandlerExceptionMiddleware
{
    private readonly ILogger<GlobalHandlerExceptionMiddleware> _logger;
    private readonly RequestDelegate _next;

    public GlobalHandlerExceptionMiddleware(ILogger<GlobalHandlerExceptionMiddleware> logger, RequestDelegate next)
    {
        _logger = logger;
        _next = next;
    }

    public async Task InvokeAsync(HttpContext httpContext)
    {
        try
        {
            // Tiếp tục xử lý yêu cầu
            await _next(httpContext);
        }
        catch (Exception ex)
        {
            _logger.LogError(ex, "An unhandled exception occurred: {Message}", ex.Message);
            await HandleExceptionAsync(httpContext, ex);
        }
    }

    private async Task HandleExceptionAsync(HttpContext context, Exception ex)
    {
        _logger.LogError(ex.Message);
        ProblemDetails problemDetails;
        if (ex is BaseException baseException)
        {
            if (ex is ValidationsException validationsException)
            {
                problemDetails = new ValidationProblemDetails(validationsException.Errors)
                {
                    Status = validationsException.Code,
                };
            }
            else
            {
                problemDetails = new ProblemDetails
                {
                    Status = baseException.Code,
                    Detail = baseException.Message,
                };
            }
        }
        else
        {
            problemDetails = new ProblemDetails
            {
                Status = (int)HttpStatusCode.InternalServerError,
                Detail = ex.Message,
            };
        }
        context.Response.ContentType = "application/json";
        context.Response.StatusCode = problemDetails.Status ?? StatusCodes.Status500InternalServerError;
        var json = JsonSerializer.Serialize(problemDetails);
        await context.Response.WriteAsync(json);
    }
}