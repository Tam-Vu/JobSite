
using JobSite.Application.Common.Exceptions;
using JobSite.Application.IRepository;

namespace JobSite.Application.Skills.Commands.DeleteSkill;

public class DeleteSkillHandler : IRequestHandler<DeleteSkillCommand, string>
{
    private readonly ISkillRepository _skillRepository;

    public DeleteSkillHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }

    public async Task<string> Handle(DeleteSkillCommand request, CancellationToken cancellationToken)
    {
        var skill = await _skillRepository.GetByIdAsync(request.Id, cancellationToken);
        await _skillRepository.DeleteAsync(skill, cancellationToken);
        return "Skill deleted successfully";
    }
}