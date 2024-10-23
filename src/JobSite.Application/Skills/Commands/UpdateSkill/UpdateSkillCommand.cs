namespace JobSite.Application.Skills.Commands.UpdateSkill;

public record UpdateSkillCommand
(
    Guid Id,
    string Name
) : IRequest<string>;
