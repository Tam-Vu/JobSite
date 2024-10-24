using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
using Microsoft.AspNetCore.Mvc.Authorization;

namespace JobSite.Application.Skills.Queries.GetListSkill;

public class GetListSkillQueryHandler : IRequestHandler<GetListSkillQuery, List<SkillResponseData>>
{
    private readonly ISkillRepository _skillRepository;
    public GetListSkillQueryHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }
    public async Task<List<SkillResponseData>> Handle(GetListSkillQuery request, CancellationToken cancellationToken)
    {
        // var result = await _skillRepository.GetAllAsync(p=>true, p=> p.Include(c=>c.DomainEvents), cancellationToken);
        var result = await _skillRepository.GetAllAsync(cancellationToken);
        return result.Select(skill => new SkillResponseData(skill.Id, skill.Name)).ToList();
    }
}