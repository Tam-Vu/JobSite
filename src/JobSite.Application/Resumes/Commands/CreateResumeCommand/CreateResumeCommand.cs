using JobSite.Application.Common.Models;
using MediatR;

namespace JobSite.Application.Resumes.Commands.CreateResumeCommand;

public record CreateResumeCommand
(
    string Title,
    string Experience,
    string Education,
    string File,
    List<CreateExperienceDetail> ExperienceDetails
) : IRequest<Result<ResponseResumeCommand>>;

public record CreateExperienceDetail
(
    string CompanyName,
    int StartYear,
    int StartMonth,
    int EndYear,
    int EndMonth,
    string Description
);