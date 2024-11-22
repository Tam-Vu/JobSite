using JobSite.Infrastructure.Common.Persistence;

namespace JobSite.Infrastructure.Application.Persistence;

public class ApplicationRepository : BaseRepository<JobApplication>, IJobApplicationRepository
{
    public ApplicationRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}