using JobSite.Application.Common.Exceptions;
using JobSite.Infrastructure.Common.Persistence;

namespace JobSite.Infrastructure.Employees.Persistence;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<GetSingleEmployeeResponse> GetSingleEmployeeAndEmailAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var employee = await (
                    from emp in _dbContext.Employees
                    join acc in _dbContext.Accounts
                    on emp.AccountId equals acc.Id
                    where emp.Id == id
                    select new GetSingleEmployeeResponse(
                        emp.Fullname,
                        emp.Address,
                        acc.Email!
                    )

                ).SingleAsync(cancellationToken);
            return employee ?? throw new BadRequestException("Employee not found");
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}