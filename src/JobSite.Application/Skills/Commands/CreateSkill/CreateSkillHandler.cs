using JobSite.Application.Common.Exceptions;
using JobSite.Application.IRepository;
namespace JobSite.Application.Skills.Commands.CreateSkill;

public class CreateSkillHandler : IRequestHandler<CreateSkillCommand, string>
{
    private readonly ISkillRepository _skillRepository;
    public CreateSkillHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }
    public async Task<string> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        // var isSkillExist = await _skillRepository.GetQuery().AnyAsync(x => x.Name == request.Name, cancellationToken);
        var isSkillExist = await _skillRepository.CheckSkillByName(request.Name, cancellationToken);
        if (isSkillExist)
        {
            throw new BadRequestException("Skill already exist");
        }
        var entity = new Skill
        {
            Name = request.Name
        };
        await _skillRepository.AddAsync(entity, cancellationToken);
        return "Skill created successfully";
    }
}