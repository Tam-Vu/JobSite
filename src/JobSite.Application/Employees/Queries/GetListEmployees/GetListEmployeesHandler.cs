using JobSite.Application.Common.Models;
using JobSite.Application.Employees.Common;
using JobSite.Application.IRepository;

namespace JobSite.Application.Employees.Queries.GetListEmployees;

public class GetListEmployeesHandler : IRequestHandler<GetListEmployeesQuery, Result<List<EmployeeResponse>>>
{
    private readonly IEmployeeRepository _employeeRepository;
    public GetListEmployeesHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }
    public async Task<Result<List<EmployeeResponse>>> Handle(GetListEmployeesQuery request, CancellationToken cancellationToken)
    {
        var employees = await _employeeRepository.GetListEmployeesAsync(cancellationToken);
        return Result<List<EmployeeResponse>>.Success(employees);
    }
}
