
using JobSite.Application.Common.Security.Identity;
using JobSite.Application.Employees.Commands.CreateEmployee;
using JobSite.Application.IRepository;
using Microsoft.AspNetCore.Identity;

namespace JobSite.Application.Employees.Commands;

public class CreateEmployeeHandler : IRequestHandler<CreateEmployeeComamnd, EmployeeCommandRespose>
{
    private readonly IEmployeeRepository _employeeRepository;
    private readonly IUser _user;
    public CreateEmployeeHandler(IEmployeeRepository employeeRepository, IUser user)
    {
        _employeeRepository = employeeRepository;
        _user = user;
    }
    public Task<EmployeeCommandRespose> Handle(CreateEmployeeComamnd request, CancellationToken cancellationToken)
    {
        var currentUserId = _user.Id!;
        var newEmployee = new Employee
        {
            Fullname = request.Fullname,
            Address = request.Address,
            AccountId = Guid.Parse(currentUserId)
        };
        _employeeRepository.AddAsync(newEmployee, cancellationToken);
        return Task.FromResult(new EmployeeCommandRespose(newEmployee.Fullname, newEmployee.Address));
    }
}