
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Interfaces;
using JobSite.Application.IRepository;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Application.Accounts.Commands.CreateAccount;

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, string>
{
    private readonly IAccountRepository _accountRepository;
    private readonly UserManager<Account> _userManager;
    private readonly IEmailSenderRepository _emailSenderRepository;
    public CreateAccountHandler(IAccountRepository accountRepository, UserManager<Account> userManager, IEmailSenderRepository emailSenderRepository)
    {
        _accountRepository = accountRepository;
        _userManager = userManager;
        _emailSenderRepository = emailSenderRepository;
    }
    public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        // var checkUsername = await _userManager.FindByNameAsync(request.UserName);
        // if (checkUsername != null)
        // {
        //     throw new BadRequestException($"Username {request.UserName} is already taken");
        // }
        // var checkEmail = await _userManager.FindByEmailAsync(request.Email);
        // if (checkEmail != null)
        // {
        //     throw new BadRequestException($"Email {request.Email} is already taken");
        // }
        var newAccount = new Account
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            SecurityStamp = Guid.NewGuid().ToString()
        };
        var token = await _userManager.GenerateEmailConfirmationTokenAsync(newAccount);
        var result = await _userManager.CreateAsync(newAccount, request.Password);
        await _emailSenderRepository.SendEmailConfirmationAsync(newAccount.Email, token, cancellationToken);
        return "create account success with id: " + newAccount.UserName;
    }
}