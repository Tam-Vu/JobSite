using System.Net;
using JobSite.Application.Common.Exceptions;
using JobSite.Application.Common.Models;
using JobSite.Application.IRepository;
namespace JobSite.Application.Skills.Commands.CreateSkill;

public class CreateSkillHandler : IRequestHandler<CreateSkillCommand, Result<string>>
{
    private readonly ISkillRepository _skillRepository;
    public CreateSkillHandler(ISkillRepository skillRepository)
    {
        _skillRepository = skillRepository;
    }
    public async Task<Result<string>> Handle(CreateSkillCommand request, CancellationToken cancellationToken)
    {
        // var isSkillExist = await _skillRepository.GetQuery().AnyAsync(x => x.Name == request.Name, cancellationToken);
        var isSkillExist = await _skillRepository.CheckSkillByName(request.Name, cancellationToken);
        if (isSkillExist)
        {
            return Result<string>.Fail(new List<ResultError>
            {
                new ResultError((int)HttpStatusCode.Conflict, "Skill already exist"),
            });
        }
        var entity = new Skill
        {
            Name = request.Name
        };
        await _skillRepository.AddAsync(entity, cancellationToken);
        return Result<string>.Success("Skill created successfully");
    }
}