namespace JobSite.Application.Jobs.Common;
public record JobCommandResponse
(
    Guid id,
    DateTimeOffset created,
    DateTimeOffset lastModified
);