namespace JobSite.Application.Employers.Common;

public record EmployerCommandRespose(
    Guid id,
    DateTimeOffset Created,
    string CreatedBy,
    string LastModifiedBy,
    DateTimeOffset LastModified
);