
namespace JobSite.Application.Resumes.Commands.Common;
public record ResponseResumeCommand
(
    Guid Id,
    DateTimeOffset Created,
    DateTimeOffset Updated
);