using System.Linq.Expressions;
using JobSite.Application.Employees.Common;
using JobSite.Application.Employees.Queries.GetSingleEmployee;

namespace JobSite.Application.IRepository;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<GetSingleEmployeeResponse> GetSingleEmployeeAndEmailAsync(Guid id, CancellationToken cancellationToken);
    Task<Employee> GetEmployeeByAccountIdAsync(string accountId, CancellationToken cancellationToken);
    Task<List<EmployeeResponse>> GetListEmployeesAsync(CancellationToken cancellationToken);
}