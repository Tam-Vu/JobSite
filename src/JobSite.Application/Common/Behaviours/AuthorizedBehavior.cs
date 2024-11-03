

using System.Reflection;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Security.Identity;
using Microsoft.AspNetCore.Authorization;

namespace JobSite.Application.Common.Behaviours;
public class AuthorizedBehavior<TRequest, TResponse> : IPipelineBehavior<TRequest, TResponse> where TRequest : IRequest<TResponse>
{
    private readonly IUser _user;
    private readonly IIdentityService _identityService;
    public AuthorizedBehavior(IUser user, IIdentityService identityService)
    {
        _user = user;
        _identityService = identityService;
    }

    public async Task<TResponse> Handle(TRequest request, RequestHandlerDelegate<TResponse> next, CancellationToken cancellationToken)
    {
        var authorizeAttributes = request.GetType().GetCustomAttributes<AuthorizeAttribute>();
        if (authorizeAttributes.Any())
        {
            // Must be authenticated user
            if (_user.Id == null)
            {
                throw new UnauthorizedException("Unauthorized");
            }
            // Role-based authorization
            var authorizeAttributeWithRoles = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Roles));
            if (authorizeAttributeWithRoles.Any())
            {
                var authorized = false;
                foreach (var roles in authorizeAttributeWithRoles.Select(a => a.Roles?.Split(',')))
                {
                    if (roles == null)
                    {
                        break;
                    }
                    foreach (var role in roles)
                    {
                        var isInRole = await _identityService.IsInRoleAsync(_user.Id, role.Trim());
                        if (isInRole)
                        {
                            authorized = true;
                            break;
                        }
                    }
                }
                if (!authorized)
                {
                    throw new ForbiddenException("Forbidden");
                }
            }

            // Must be a member of at least one role in roles
            var authorizeAttributeWithPolicies = authorizeAttributes.Where(a => !string.IsNullOrWhiteSpace(a.Policy));
            if (authorizeAttributeWithPolicies.Any())
            {
                foreach (var policy in authorizeAttributeWithPolicies.Select(a => a.Policy))
                {
                    if (policy == null)
                    {
                        break;
                    }
                    var authorized = await _identityService.AuthorizeAsync(_user.Id, policy);
                    if (!authorized)
                    {
                        throw new ForbiddenException("Forbidden");
                    }
                }
            }
        }
        return await next();
    }
}