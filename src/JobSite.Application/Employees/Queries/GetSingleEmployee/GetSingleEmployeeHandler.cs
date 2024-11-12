using System.Security.Cryptography.X509Certificates;
using JobSite.Application.IRepository;

namespace JobSite.Application.Employees.Queries.GetSingleEmployee;

public class GetSingleEmployeeHandler : IRequestHandler<GetSingleEmployeeQuery, GetSingleEmployeeQuery>
{
    private readonly IEmployeeRepository _employeeRepository;

    public GetSingleEmployeeHandler(IEmployeeRepository employeeRepository)
    {
        _employeeRepository = employeeRepository;
    }

    async Task<GetSingleEmployeeQuery> IRequestHandler<GetSingleEmployeeQuery, GetSingleEmployeeQuery>.Handle(GetSingleEmployeeQuery request, CancellationToken cancellationToken)
    {
        var employee = await _employeeRepository.GetOneAsync(x => x.Id == request.Id, p => p.Include(p => p.Account), cancellationToken);
        throw new NotImplementedException();
    }
}