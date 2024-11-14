using JobSite.Infrastructure.Common.Persistence;

namespace JobSite.Infrastructure.Resumes.Persistence;

public class ResumeRepository : BaseRepository<Resume>, IResumeRepository
{
    public ResumeRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}