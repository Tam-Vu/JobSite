
using JobSite.Application.Common.Exceptions;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Application.Accounts.Commands.VerifyAccount;

public class VerifyAccountHandler : IRequestHandler<VerifyAccountCommand, string>
{
    private readonly UserManager<Account> _userManager;
    public VerifyAccountHandler(UserManager<Account> userManager)
    {
        _userManager = userManager;
    }
    public async Task<string> Handle(VerifyAccountCommand request, CancellationToken cancellationToken)
    {
        var account = await _userManager.FindByEmailAsync(request.Email);
        if (account == null)
        {
            throw new BadRequestException($"Account with email {request.Email} not found");
        }
        var result = await _userManager.ConfirmEmailAsync(account, request.Token);
        if (!result.Succeeded)
        {
            throw new BadRequestException($"Invalid token for email {request.Email}");
        }
        return $"verify {result} with email: {request.Email}";
    }
}