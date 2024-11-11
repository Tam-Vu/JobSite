namespace JobSite.Application.IRepository;

public interface IEmployeeRepository : IBaseRepository<Employee>
{
    Task<GetSingleEmployeeResponse> GetSingleEmployeeAndEmailAsync(Guid id, CancellationToken cancellationToken);
}