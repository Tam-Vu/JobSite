namespace JobSite.Application.Skills.Commands.DeleteSkill;

public record DeleteSkillCommand(Guid Id) : IRequest<string>;