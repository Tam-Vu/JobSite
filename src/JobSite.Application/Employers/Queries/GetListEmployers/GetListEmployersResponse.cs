using JobSite.Domain.Enums;

namespace JobSite.Application.Employers.Queries.GetListEmployers;

public record GetListEmployersResponse
(
    Guid EmployerId,
    Guid AccountId,
    string Name,
    string Description,
    string Sector,
    string Location,
    string Website
);