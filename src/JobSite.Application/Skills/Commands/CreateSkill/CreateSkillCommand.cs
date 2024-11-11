using JobSite.Application.Common.Models;

public record CreateSkillCommand
(
    string Name
) : IRequest<Result<string>>;