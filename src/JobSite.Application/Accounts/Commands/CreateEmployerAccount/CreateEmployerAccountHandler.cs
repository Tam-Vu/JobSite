using JobSite.Application.Accounts.Common;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using JobSite.Domain.Enums;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Application.Accounts.Commands.CreateEmployerAccountCommand;

public class CreateEmployerAccountHandler : IRequestHandler<CreateEmployerAccountCommand, Result<AccountCommandResponse>>
{
    private readonly UserManager<Account> _userManager;
    private readonly IEmployerRepository _employeeRepository;
    private readonly IEmailSenderRepository _emailSenderRepository;
    public CreateEmployerAccountHandler(UserManager<Account> userManager, IEmailSenderRepository emailSenderRepository, IEmployerRepository employerRepository)
    {
        _userManager = userManager;
        _emailSenderRepository = emailSenderRepository;
        _employeeRepository = employerRepository;
    }
    public async Task<Result<AccountCommandResponse>> Handle(CreateEmployerAccountCommand request, CancellationToken cancellationToken)
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
            var errors = string.Join(", ", result.Errors.Select(e => $"{e.Code}: {e.Description}"));
            throw new BadRequestException($"Create account failed: {errors}");
        }
        var role = await _userManager.AddToRoleAsync(newAccount, nameof(AccountRole.Employer));
        if (!role.Succeeded)
        {
            throw new Exception("Failed to assign role to admin user: " + string.Join(", ", role.Errors.Select(e => e.Description)));
        }

        var newEmployer = new Employer
        {
            Name = request.Name,
            Description = request.Description,
            Sector = request.Sector,
            Location = request.Location,
            Website = request.Website,
            AccountId = newAccount.Id
        };
        await _employeeRepository.AddAsync(newEmployer, cancellationToken);
        return Result<AccountCommandResponse>.Success(new AccountCommandResponse(newAccount.Id, newAccount.Created, newAccount.LastModified));
    }
}
