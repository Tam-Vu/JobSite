
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Interfaces;
using JobSite.Application.IRepository;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Application.Accounts.Commands.CreateAccount;

public class CreateAccountHandler : IRequestHandler<CreateAccountCommand, string>
{
    private readonly IAccountRepository _accountRepository;
    private readonly PasswordHasher<Account> _hashingService;
    private readonly UserManager<Account> _userManager;
    public CreateAccountHandler(IAccountRepository accountRepository, UserManager<Account> userManager, PasswordHasher<Account> hashingService)
    {
        _accountRepository = accountRepository;
        _userManager = userManager;
        _hashingService = hashingService;
    }
    public async Task<string> Handle(CreateAccountCommand request, CancellationToken cancellationToken)
    {
        var checkUsername = await _userManager.FindByNameAsync(request.UserName);
        if (checkUsername != null)
        {
            throw new BadRequestException($"Username {request.UserName} is already taken");
        }
        var checkEmail = await _userManager.FindByEmailAsync(request.Email);
        if (checkEmail != null)
        {
            throw new BadRequestException($"Email {request.Email} is already taken");
        }
        var hassedPassword = _hashingService.HashPassword(null, request.Password);
        var newAccount = new Account
        {
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber
        };
        await _accountRepository.AddAsync(newAccount, cancellationToken);
        var result = _userManager.CreateAsync(newAccount, request.Password).Result;
        return "create account success with id: " + newAccount.UserName;
    }
}