
using System.Security.Claims;
using JobSite.Application.Common.Security.Identity;
using Microsoft.AspNetCore.Http;

namespace JobSite.Api.Services;
public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    public CurrentUser(IHttpContextAccessor httpContextAccessor)
    {
        _httpContextAccessor = httpContextAccessor;
    }
    // public string? Id => this.GetClaim(ClaimTypes.NameIdentifier);
    //if this not work, try this
    public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public string GetUserName() => this.GetClaim(ClaimTypes.Name);

    private string GetClaim(string key) => this._httpContextAccessor.HttpContext?.User?.FindFirst(key)?.Value ?? string.Empty;
}