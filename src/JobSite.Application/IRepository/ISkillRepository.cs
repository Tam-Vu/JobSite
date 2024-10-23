namespace JobSite.Application.IRepository;
public interface ISkillRepository : IBaseRepository<Skill>
{
    Task<bool> CheckSkillByName(string SkillName, CancellationToken cancellationToken);
}