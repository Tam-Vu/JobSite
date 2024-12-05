using JobSite.Application.Common.Exceptions;
using JobSite.Application.Employees.Queries.GetSingleEmployee;
using JobSite.Application.Employers.Queries.GetListEmployers;
using JobSite.Application.Employers.Queries.GetSingleEmployerResponse;
using JobSite.Infrastructure.Common.Persistence;

namespace JobSite.Infrastructure.Employers.Persistence;

public class EmployerRepository : BaseRepository<Employer>, IEmployerRepository
{
    public EmployerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

    public async Task<List<GetListEmployersResponse>> GetListEmployersAsync(CancellationToken cancellationToken)
    {
        try
        {
            var employers = await
            (
                from emps in _dbContext.Employers
                join acc in _dbContext.Accounts
                on emps.AccountId equals acc.Id
                select new GetListEmployersResponse(
                    emps.Id,
                    acc.Id,
                    emps.Name,
                    emps.Description!,
                    emps.Sector.ToString()!,
                    emps.Location!,
                    emps.Website ?? ""
                )
            ).ToListAsync(cancellationToken);
            return employers;
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }

    public async Task<GetSingleEmployereResponse> GetSingleEmployerAsync(Guid id, CancellationToken cancellationToken)
    {
        try
        {
            var employer = await
            (
                from emps in _dbContext.Employers
                join acc in _dbContext.Accounts
                on emps.AccountId equals acc.Id
                where emps.Id == id
                select new GetSingleEmployereResponse(
                    emps.Id,
                    acc.Id,
                    emps.Name,
                    emps.Sector.ToString()!,
                    emps.Website ?? "",
                    acc.UserName!
                )
            ).SingleAsync(cancellationToken);
            return employer;
        }
        catch (Exception e)
        {
            throw new BadRequestException(e.Message);
        }
    }
}