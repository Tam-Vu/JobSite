using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Application.Employers.Commands;

public class DeleteEmployerHandler : IRequestHandler<DeleteEmployerCommand, Result<string>>
{
    private readonly IUser _user;
    private readonly IEmployerRepository _employerRepository;
    private readonly UserManager<Account> _userManager;
    public DeleteEmployerHandler(IUser user, IEmployerRepository employerRepository, UserManager<Account> userManager)
    {
        _user = user;
        _employerRepository = employerRepository;
        _userManager = userManager;
    }
    public async Task<Result<string>> Handle(DeleteEmployerCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employer = await _employerRepository.GetOneAsync(x => x.AccountId.ToString() == _user.Id, cancellationToken);
            await _employerRepository.DeleteAsync(employer, cancellationToken);
            var account = await _userManager.FindByIdAsync(_user.Id!);
            if (account == null)
            {
                throw new NotFoundException("Employer not found");
            }
            await _userManager.DeleteAsync(account);
            return Result<string>.Success("Employer deleted successfully");
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}