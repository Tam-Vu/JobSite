using JobSite.Application.Common.Models;
using JobSite.Application.Resumes.Common;

namespace JobSite.Application.Resumes.Commands.CreateResumeCommand;

public record CreateResumeCommand
(
    string Title,
    string Experience,
    string Education,
    string File,
    List<SkillCommand> Skills,
    List<CreateExperienceDetail> ExperienceDetails
) : IRequest<Result<ResponseResumeCommand>>;
