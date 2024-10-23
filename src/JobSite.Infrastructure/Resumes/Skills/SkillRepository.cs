using System.Security.Cryptography.X509Certificates;
using JobSite.Infrastructure.Common.Persistence;
namespace JobSite.Infrastructure.Resumes.Skills;
public class SkillRepository : BaseRepository<Skill>, ISkillRepository
{
    public SkillRepository(ApplicationDbContext dbContext) : base(dbContext)
    {

    }

    public async Task<bool> CheckSkillByName(string SkillName, CancellationToken cancellationToken)
    {
        var result = await (from s in _dbContext.Skills
                            where s.Name == SkillName
                            select s).FirstOrDefaultAsync(cancellationToken);
        return result != null;
    }
}