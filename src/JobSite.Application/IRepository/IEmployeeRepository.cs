using System.Linq.Expressions;
using JobSite.Application.Employees.Queries.GetSingleEmployee;

namespace JobSite.Application.IRepository;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<GetSingleEmployeeResponse> GetSingleEmployeeAndEmailAsync(Guid id, CancellationToken cancellationToken);
}