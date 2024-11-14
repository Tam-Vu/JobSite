
using System.Security.Claims;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Security.Identity;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Api.Services;
public class CurrentUser : IUser
{
    private readonly IHttpContextAccessor _httpContextAccessor;
    private readonly UserManager<Account> _userManager;
    public CurrentUser(IHttpContextAccessor httpContextAccessor, UserManager<Account> userManager)
    {
        _httpContextAccessor = httpContextAccessor;
        _userManager = userManager;
    }
    // public string? Id => this.GetClaim(ClaimTypes.NameIdentifier);
    //if this not work, try this
    public string? Id => _httpContextAccessor.HttpContext?.User?.FindFirstValue(ClaimTypes.NameIdentifier);

    public Account GetAccount()
    {
        var userId = this.GetClaim(ClaimTypes.NameIdentifier);
        return _userManager.FindByIdAsync(userId).Result ?? throw new UnauthorizedException("You did not login yet");
    }

    public string GetUserName() => this.GetClaim(ClaimTypes.Name);

    private string GetClaim(string key) => this._httpContextAccessor.HttpContext?.User?.FindFirst(key)?.Value ?? string.Empty;
}