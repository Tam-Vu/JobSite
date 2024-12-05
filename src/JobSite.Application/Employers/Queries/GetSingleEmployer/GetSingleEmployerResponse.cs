namespace JobSite.Application.Employers.Queries.GetSingleEmployerResponse;

public record GetSingleEmployereResponse
(
    Guid EmployerId,
    Guid AccountId,
    string Name,
    string Sector,
    string Location,
    string UserName
);
