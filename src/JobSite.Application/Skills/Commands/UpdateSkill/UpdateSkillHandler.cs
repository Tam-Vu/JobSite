using JobSite.Application.Common.Exceptions;
using JobSite.Application.IRepository;
using Microsoft.AspNetCore.Http.HttpResults;

namespace JobSite.Application.Skills.Commands.UpdateSkill;

public class UpdateSkillHandler : IRequestHandler<UpdateSkillCommand, string>
{
    private readonly ISkillRepository _skillRepository;

    public UpdateSkillHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<string> Handle(UpdateSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id, cancellationToken);

        if (skill == null)
        {
            throw new BadRequestException("Skill not found");
        }

        var isSkillNameUnique = await _skillRepository.CheckSkillByName(request.Name, cancellationToken);

        if (!isSkillNameUnique)
        {
            throw new BadRequestException("Skill already exist");
        }

        skill.Name = request.Name;

        await _skillRepository.UpdateAsync(skill, cancellationToken);

        return skill.Name;
    }
}