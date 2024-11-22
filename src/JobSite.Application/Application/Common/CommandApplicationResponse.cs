namespace JobSite.Application.Application.Common;

public record CommandApplicationResponse
(
    Guid ResumeId,
    Guid JobId
);