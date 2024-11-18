
using JobSite.Application.Common.Models;
using JobSite.Application.Resumes.Common;

namespace JobSite.Application.Resumes.Commands.UpdateResumeCommand;

public record UpdateResumeCommand
(
    Guid Id,
    string Title,
    string Experience,
    string Education,
    string File,
    List<SkillCommand> Skills,
    List<CreateExperienceDetail> ExperienceDetails
) : IRequest<Result<ResponseResumeCommand>>;
