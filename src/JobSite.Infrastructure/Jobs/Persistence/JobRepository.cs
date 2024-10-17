

using JobSite.Infrastructure.Common.Persistence;

namespace JobSite.Infrastructure.Jobs.Persistence;
public class JobRepository : BaseRepository<Job>, IJobRepository
{
    public JobRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }

}