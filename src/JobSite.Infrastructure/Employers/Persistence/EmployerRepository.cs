using JobSite.Infrastructure.Common.Persistence;

namespace JobSite.Infrastructure.Employers.Persistence;

public class EmployerRepository : BaseRepository<Employer>, IEmployerRepository
{
    public EmployerRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}