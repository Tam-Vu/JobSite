
using System.Web;
using JobSite.Application.Accounts.Common;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using JobSite.Domain.Events;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Application.Accounts.Commands.CreateEmployeeAccountCommand;

public class CreateAccountHandler : IRequestHandler<CreateEmployeeAccountCommand, Result<AccountCommandResponse>>
{
    private readonly UserManager<Account> _userManager;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IEmailSenderRepository _emailSenderRepository;
    public CreateAccountHandler(UserManager<Account> userManager, IEmailSenderRepository emailSenderRepository, IEmployeeRepository employeeRepository)
    {
        _userManager = userManager;
        _emailSenderRepository = emailSenderRepository;
        _employeeRepository = employeeRepository;
    }
    public async Task<Result<AccountCommandResponse>> Handle(CreateEmployeeAccountCommand request, CancellationToken cancellationToken)
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
        var newAccount = new Account
        {
            Id = Guid.NewGuid(),
            UserName = request.UserName,
            Email = request.Email,
            PhoneNumber = request.PhoneNumber,
            SecurityStamp = Guid.NewGuid().ToString()
        };
        var result = await _userManager.CreateAsync(newAccount, request.Password);
        if (!result.Succeeded)
        {
            throw new BadRequestException($"Create account failed: {result.Errors}");
        }

        var newEmployee = new Employee
        {
            Fullname = request.Fullname,
            Address = request.Address,
            AccountId = newAccount.Id
        };
        await _employeeRepository.AddAsync(newEmployee, cancellationToken);

        var token = await _userManager.GenerateEmailConfirmationTokenAsync(newAccount);
        await _emailSenderRepository.SendEmailConfirmationAsync(newAccount.Email, token, cancellationToken);
        // newAccount.AddDomainEvent(new AccountCreatedEvent(newAccount));
        // await _context.SaveChangesAsync(cancellationToken);
        return Result<AccountCommandResponse>.Success(new AccountCommandResponse(newAccount.Id, newAccount.Created, newAccount.LastModified));
    }
}