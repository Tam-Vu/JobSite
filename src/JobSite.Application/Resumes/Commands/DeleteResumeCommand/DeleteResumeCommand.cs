using JobSite.Application.Common.Models;

namespace JobSite.Application.Resumes.Commands;

public record DeleteResumeCommand
(
    Guid Id
) : IRequest<Result<string>>;