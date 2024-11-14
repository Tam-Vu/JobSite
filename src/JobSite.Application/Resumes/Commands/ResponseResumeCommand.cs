
namespace JobSite.Application.Resumes.Commands;
public record ResponseResumeCommand
(
    Guid Id,
    DateTimeOffset Created,
    DateTimeOffset Updated
);