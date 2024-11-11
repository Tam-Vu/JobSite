using System.Security.Cryptography.X509Certificates;
using JobSite.Application.IRepository;

namespace JobSite.Application.Employees.Queries.GetSingleEmployee;

public class GetSingleEmployeeHandler : IRequestHandler<GetSingleEmployeeQuery, GetSingleEmployeeResponse>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetSingleEmployeeHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    public async Task<GetSingleEmployeeResponse> Handle(GetSingleEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetSingleEmployeeAndEmailAsync(request.Id, cancellationToken);
        return employee;
    }
}