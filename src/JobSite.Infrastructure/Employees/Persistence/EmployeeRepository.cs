using System.Linq.Expressions;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Employees.Queries.GetSingleEmployee;
using JobSite.Infrastructure.Common.Persistence;
using Microsoft.EntityFrameworkCore.Query.SqlExpressions;

namespace JobSite.Infrastructure.Employees.Persistence;

public class EmployeeRepository : BaseRepository<Employee>, IEmployeeRepository
{
    public EmployeeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<Employee> GetEmployeeByAccountIdAsync(Guid accountId, CancellationToken cancellationToken)
    {
        var employee = await (
            from empl in _dbContext.Employees
            where empl.AccountId == accountId
            select new Employee
            {
                Id = empl.Id,
                Fullname = empl.Fullname,
                Address = empl.Address,
                AccountId = empl.AccountId
            }
        ).SingleAsync(cancellationToken);
        return employee ?? throw new BadRequestException("Employee not found");
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
                        new AccountDto(acc.Email!)
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