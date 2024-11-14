using JobSite.Infrastructure.Common.Persistence;

namespace JobSite.Infrastructure.Resumes.ExperienceDetails;
public class ExperienceDetailsRepository : BaseRepository<ExperienceDetail>, IExperienceDetailsRepository
{
    public ExperienceDetailsRepository(ApplicationDbContext dbContext) : base(dbContext)
    {
    }
}