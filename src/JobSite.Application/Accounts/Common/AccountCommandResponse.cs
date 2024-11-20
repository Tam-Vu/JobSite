
namespace JobSite.Application.Accounts.Common;
public record AccountCommandResponse(
    Guid id,
    DateTimeOffset Created,
    DateTimeOffset LastModified
);
