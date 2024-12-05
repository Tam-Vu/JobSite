using System.Net.Http.Headers;
using JobSite.Application.Common.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Authorization.Policy;
using Microsoft.AspNetCore.Http;

namespace JobSite.Infrastructure.Common.Middleware;

public class CustomAuthorizationMiddleware : IAuthorizationMiddlewareResultHandler
{
    private readonly AuthorizationMiddlewareResultHandler defaultHandler = new();
    public async Task HandleAsync(RequestDelegate next, HttpContext context, AuthorizationPolicy policy, PolicyAuthorizationResult authorizeResult)
    {
        if (authorizeResult.Forbidden)
        {
            context.Response.StatusCode = StatusCodes.Status403Forbidden;
            const string message = "You are not authorized to access this resource.";
            context.Response.ContentType = "application/json";
            var result = Result<object>.Fail(new List<ResultError>
            {
                new((int)StatusCodes.Status403Forbidden, message)
            });
            var jsonResult = System.Text.Json.JsonSerializer.Serialize(result);
            await context.Response.WriteAsync(jsonResult);
            return;
        }
        await defaultHandler.HandleAsync(next, context, policy, authorizeResult);
    }
}