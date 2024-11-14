namespace JobSite.Application.Employees.Queries.GetSingleEmployee;
public record GetSingleEmployeeQuery(
    Guid Id
) : IRequest<GetSingleEmployeeResponse>;

