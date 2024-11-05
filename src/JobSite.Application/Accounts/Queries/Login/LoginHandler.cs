

using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Security.Jwt;
using JobSite.Domain.Identity;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace JobSite.Application.Accounts.Queries.Login;
public class LoginHandler : IRequestHandler<LoginQuery, LoginResponse>
{
    private readonly UserManager<Account> _userManager;
    private readonly ITokenService _tokenService;
    private readonly RoleManager<UserRole> _roleManager;
    public LoginHandler(UserManager<Account> userManager, ITokenService tokenService, RoleManager<UserRole> roleManager)
    {
        _userManager = userManager;
        _tokenService = tokenService;
        _roleManager = roleManager;
    }

    public async Task<LoginResponse> Handle(LoginQuery request, CancellationToken cancellationToken)
    {
        var user = await _userManager.FindByEmailAsync(request.EmailOrUserName);
        if (user == null)
        {
            user = await _userManager.FindByNameAsync(request.EmailOrUserName);
        }
        if (user == null)
        {
            throw new BadRequestException("Invalid username or password");
        }
        var result = await _userManager.CheckPasswordAsync(user, request.Password);
        if (!result)
        {
            throw new BadRequestException("Invalid username or password");
        }
        var roles = await _userManager.GetRolesAsync(user);
        var accessToken = _tokenService.GenerateAccessToken(user, roles);
        LoginResponse response = new(accessToken, "hello");
        return response;
    }
}