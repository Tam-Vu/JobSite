using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.IRepository;
using Microsoft.AspNetCore.Identity;
using Microsoft.VisualBasic;

namespace JobSite.Application.Employees.Commands;

public class DeleteEmployeeHandler : IRequestHandler<DeleteEmployeeCommand, Result<string>>
{
    private readonly IUser _user;
    private readonly IEmployeeRepository _employeeRepository;
    private readonly UserManager<Account> _userManager;
    public DeleteEmployeeHandler(IUser user, IEmployeeRepository employeeRepository, UserManager<Account> userManager)
    {
        _user = user;
        _employeeRepository = employeeRepository;
        _userManager = userManager;
    }
    public async Task<Result<string>> Handle(DeleteEmployeeCommand request, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await _employeeRepository.GetOneAsync(x => x.AccountId.ToString() == _user.Id, cancellationToken);
            await _employeeRepository.DeleteAsync(employee, cancellationToken);
            var account = await _userManager.FindByIdAsync(_user.Id!);
            if (account == null)
            {
                throw new NotFoundException("Employee not found");
            }
            await _userManager.DeleteAsync(account);
            return Result<string>.Success("Employee deleted successfully");
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}