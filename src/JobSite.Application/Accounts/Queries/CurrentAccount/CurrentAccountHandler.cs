using System.Security.Principal;
using JobSite.Application.Common.Security.Identity;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Application.Accounts.Queries.CurrentAccount;

public class CurrentAccountHandler : IRequestHandler<CurrentAccountQuery, CurrentAccountResponse>
{
    // private readonly IIdentityService _identityService;
    private readonly UserManager<Account> _userManager;
    private readonly IUser _user;

    public CurrentAccountHandler(UserManager<Account> userManager, IUser user)
    {
        _userManager = userManager;
        _user = user;
    }
    public async Task<CurrentAccountResponse> Handle(CurrentAccountQuery request, CancellationToken cancellationToken)
    {
        // var userId = _user.Id;
        // if (userId == "")
        // {
        //     throw new ValidationException("Invalid user id");
        // }
        var user = await _userManager.FindByIdAsync("986aa9b8-0eff-4f21-af01-636b326ea320");
        return new CurrentAccountResponse(user.Email, user.UserName);
    }
}