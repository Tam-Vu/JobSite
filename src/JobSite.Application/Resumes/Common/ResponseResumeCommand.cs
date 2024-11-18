
namespace JobSite.Application.Resumes.Common;
public record ResponseResumeCommand
(
    Guid Id,
    DateTimeOffset Created,
    DateTimeOffset Updated
);